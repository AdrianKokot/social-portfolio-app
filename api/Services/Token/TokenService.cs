using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sociussion.Configuration;
using Sociussion.Data.Models;

namespace Sociussion.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TokenConfiguration _tokenConfiguration;
        private readonly SymmetricSecurityKey _key;

        public TokenService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenConfiguration = configuration.GetTokenConfiguration();
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Secret));
        }

        public async Task<string> CreateJwtToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _tokenConfiguration.Audience,
                Issuer = _tokenConfiguration.Issuer,
                Expires = DateTime.UtcNow.AddMinutes(_tokenConfiguration.TokenExpirationInMinutes),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512),
                Subject = new ClaimsIdentity(await GetUserClaims(user))
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return  tokenHandler.WriteToken(token);
        }

        private async Task<IEnumerable<Claim>> GetUserClaims(ApplicationUser user)
        {

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id),
                new(JwtRegisteredClaimNames.UniqueName, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // var userRoles = await _userManager.GetRolesAsync(user);
            // authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            return authClaims;
        }
    }
}
