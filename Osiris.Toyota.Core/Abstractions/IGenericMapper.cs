using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IGenericMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        void ApplyMappings(Dictionary<string, string> mappings);
    }
}
