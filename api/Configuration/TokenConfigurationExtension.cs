using Microsoft.Extensions.Configuration;
using Sociussion.Services.Token;

namespace Sociussion.Configuration
{
    public static class TokenConfigurationExtension
    {
        public static TokenConfiguration GetTokenConfiguration(this IConfiguration configuration)
        {
            return configuration.GetSection("Auth:Jwt").Get<TokenConfiguration>();
        }
    }
}
