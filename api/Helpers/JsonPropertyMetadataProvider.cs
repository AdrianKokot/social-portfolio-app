using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Sociussion.Helpers
{
    internal class JsonPropertyMetadataProvider : IBindingMetadataProvider, IDisplayMetadataProvider
    {
        private readonly JsonNamingPolicy _jsonNamingPolicy;

        public JsonPropertyMetadataProvider(JsonNamingPolicy jsonNamingPolicy)
        {
            _jsonNamingPolicy = jsonNamingPolicy;
        }

        public void CreateBindingMetadata(BindingMetadataProviderContext context)
        {
            if (!context.BindingMetadata.IsBindingAllowed || !IsNonControllerProperty(context.Key))
            {
                return;
            }

            var jsonPropertyName = JsonPropertyName(context.Attributes, context.Key);
            context.BindingMetadata.BinderModelName ??= jsonPropertyName;
        }

        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            if (!IsNonControllerProperty(context.Key))
            {
                return;
            }

            var jsonPropertyName = JsonPropertyName(context.Attributes, context.Key);
            context.DisplayMetadata.DisplayName ??= () => jsonPropertyName;
        }

        private static bool IsNonControllerProperty(ModelMetadataIdentity key) =>
            key.MetadataKind == ModelMetadataKind.Property
            && !key.ContainerType.IsAssignableTo(typeof(ControllerBase));

        private string JsonPropertyName(IEnumerable<object> attributes, ModelMetadataIdentity key) =>
            attributes.OfType<JsonPropertyNameAttribute>().FirstOrDefault()?.Name
            ?? _jsonNamingPolicy?.ConvertName(key.Name);
    }
}
