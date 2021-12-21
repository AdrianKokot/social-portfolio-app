using Microsoft.Extensions.Configuration;

namespace Sociussion.Infrastructure.Identity;

public class JwtConfiguration
{
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public string Secret { get; init; }
    public int TokenExpirationInMinutes { get; init; }
}

public static class JwtConfigurationFromIConfiguration
{
    public static JwtConfiguration GetJwtConfiguration(this IConfiguration config)
    {
        return config.GetSection("Auth:Jwt").Get<JwtConfiguration>();
    }
}