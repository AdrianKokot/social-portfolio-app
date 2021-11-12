namespace Sociussion.Services.Token
{
    public record TokenConfiguration
    {
        public string Issuer { get; init; }
        public string Audience { get; init; }
        public string Secret { get; init; }
        public int TokenExpirationInMinutes { get; init; }
    }
}
