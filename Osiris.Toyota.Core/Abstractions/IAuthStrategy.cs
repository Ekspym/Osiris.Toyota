using Osiris.Toyota.Core.Entities;

namespace Osiris.Toyota.Core.Abstractions
{
    public interface IAuthStrategy
    {
        Task ApplyAuthorizationAsync(HttpRequestMessage request, ExternalSystem system);
    }
}
