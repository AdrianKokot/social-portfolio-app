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
using Sociussion.Models;

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
            var token = new JwtSecurityToken(
                issuer: _tokenConfiguration.Issuer,
                audience: _tokenConfiguration.Audience,
                expires: DateTime.Now.AddMinutes(_tokenConfiguration.TokenExpirationInMinutes),
                claims: await GetUserClaims(user),
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<IEnumerable<Claim>> GetUserClaims(ApplicationUser user)
        {

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(JwtRegisteredClaimNames.UniqueName, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // var userRoles = await _userManager.GetRolesAsync(user);
            // authClaims.AddRange(userRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole)));

            return authClaims;
        }
    }
}
