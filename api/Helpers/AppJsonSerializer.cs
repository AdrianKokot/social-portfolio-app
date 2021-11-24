using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Sociussion.Helpers
{
    public static class AppJsonSerializer
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public static string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj, Options);
        }
    }
}
