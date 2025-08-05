

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IGenericMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        void ApplyMappings(Dictionary<string, string> mappings);
    }
}
