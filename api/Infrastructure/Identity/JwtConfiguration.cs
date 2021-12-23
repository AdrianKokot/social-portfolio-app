using Microsoft.Extensions.Configuration;

namespace Sociussion.Infrastructure.Identity;

public class JwtConfiguration
{
    public string Issuer { get; init; } = string.Empty;
    public string Audience { get; init; } = string.Empty;
    public string Secret { get; init; } = string.Empty;
    public int TokenExpirationInMinutes { get; init; }
}

public static class JwtConfigurationFromIConfiguration
{
    public static JwtConfiguration GetJwtConfiguration(this IConfiguration config)
    {
        return config.GetSection("Auth:Jwt").Get<JwtConfiguration>();
    }
}