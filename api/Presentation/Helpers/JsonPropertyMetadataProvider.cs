using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Sociussion.Presentation.Helpers;

internal class JsonPropertyMetadataProvider : IBindingMetadataProvider, IDisplayMetadataProvider
{
    private readonly JsonNamingPolicy _jsonNamingPolicy;

    public JsonPropertyMetadataProvider(JsonNamingPolicy jsonNamingPolicy)
    {
        _jsonNamingPolicy = jsonNamingPolicy;
    }

    public void CreateBindingMetadata(BindingMetadataProviderContext context)
    {
        if (context.BindingMetadata.IsBindingAllowed && IsNonControllerProperty(context.Key))
        {
            var jsonPropertyName = JsonPropertyName(context.Attributes, context.Key);
            context.BindingMetadata.BinderModelName ??= jsonPropertyName;
        }
    }

    public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
    {
        if (IsNonControllerProperty(context.Key))
        {
            var jsonPropertyName = JsonPropertyName(context.Attributes, context.Key);
            context.DisplayMetadata.DisplayName ??= () => jsonPropertyName;
        }
    }

    private static bool IsNonControllerProperty(ModelMetadataIdentity key) =>
        key.ContainerType != null &&
        key.MetadataKind == ModelMetadataKind.Property &&
        !key.ContainerType.IsAssignableTo(typeof(ControllerBase));

    private string JsonPropertyName(IReadOnlyList<object> attributes, ModelMetadataIdentity key)
    {
        if (key.Name is not null)
            return attributes.OfType<JsonPropertyNameAttribute>().FirstOrDefault()?.Name
                   ?? _jsonNamingPolicy.ConvertName(key.Name);

        return string.Empty;
    }
}