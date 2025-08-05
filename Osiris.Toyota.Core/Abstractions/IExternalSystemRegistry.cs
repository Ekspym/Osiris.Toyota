using Osiris.Toyota.Core.Entities;

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IExternalSystemRegistry
    {
        IEnumerable<ExternalSystem> GetAll();
        ExternalSystem? GetByName(string name);
        void AddOrUpdate(ExternalSystem system);
    }
}
