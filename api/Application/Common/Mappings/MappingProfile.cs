using System.Reflection;
using AutoMapper;

namespace Sociussion.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly
            .GetExportedTypes()
            .Where(t =>
                t.GetInterfaces()
                    .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IMapFrom<>))
            );

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            type.GetMethod("Mapping")?.Invoke(instance, new object[] {this});
        }
    }
}