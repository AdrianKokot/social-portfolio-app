using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sociussion.Presentation.Helpers;

public class DateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        Debug.Assert(typeToConvert == typeof(DateTime));
        return DateTime.Parse(reader.GetString() ?? string.Empty);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        value = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        writer.WriteStringValue(value.ToUniversalTime());
    }
}