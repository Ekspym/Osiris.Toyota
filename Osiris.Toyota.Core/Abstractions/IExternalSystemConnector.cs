
namespace Osiris.Toyota.Core.Abstractions
{
    public interface IExternalSystemConnector
    {
        Task<TResponse> SendRequestAsync<TResponse>(
            HttpMethod method,
            string route,
            object payload = null
        );

        Task<bool> HealthCheckAsync();
    }
}
