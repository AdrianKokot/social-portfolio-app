using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sociussion.Application.Common.Interfaces;
using Sociussion.Domain.Entities;

namespace Sociussion.Infrastructure.Identity;

public class TokenService : ITokenService
{
    // private readonly UserManager<ApplicationUser> _userManager;
    private readonly IDateTime _dateTime;
    private readonly JwtConfiguration _jwtConfig;
    private readonly SymmetricSecurityKey _key;

    public TokenService(
        // UserManager<ApplicationUser> userManager,
        IConfiguration configuration,
        IDateTime dateTime)
    {
        // _userManager = userManager;
        _dateTime = dateTime;
        _jwtConfig = configuration.GetJwtConfiguration();
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.Secret));
    }

    public async Task<string> CreateJwtToken(ApplicationUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Audience = _jwtConfig.Audience,
            Issuer = _jwtConfig.Issuer,
            Expires = _dateTime.Now.AddMinutes(_jwtConfig.TokenExpirationInMinutes),
            SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512),
            Subject = new ClaimsIdentity(await GetUserClaims(user))
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private Task<IEnumerable<Claim>> GetUserClaims(ApplicationUser user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        // var userRoles = await _userManager.GetRolesAsync(user);
        // authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

        return Task.FromResult<IEnumerable<Claim>>(authClaims);
    }
}