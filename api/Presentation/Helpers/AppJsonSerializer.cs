using System.Text.Json;

namespace Sociussion.Presentation.Helpers;

public class AppJsonSerializer
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