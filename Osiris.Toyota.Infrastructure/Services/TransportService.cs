using Microsoft.Extensions.Logging;
using Osiris.Toyota.Infrastructure.Connectors;
using Osiris.Toyota.Infrastructure.DTOs;


namespace Osiris.Toyota.Infrastructure.Services
{
    public interface ITransportService
    {
        Task<TransportDto> CreateTransport(TransportRequestDto request);
        Task AbortTransport(string transportId);
        Task<TransportStateDto> GetTransportStatus(string transportId);
    }

    public class TransportService : ITransportService
    {
        private readonly TOneConnector _connector;
        private readonly ILogger<TransportService> _logger;

        public TransportService(TOneConnector connector, ILogger<TransportService> logger)
        {
            _connector = connector;
            _logger = logger;
        }

        public async Task AbortTransport(string transportId)
        {
            try
            {
                await _connector.SendRequestAsync<object>(
                    HttpMethod.Delete,
                    $"/api/v1/transports/{transportId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to abort transport {TransportId}", transportId);
                throw;
            }
        }

        public async Task<TransportDto> CreateTransport(TransportRequestDto request)
        {
            return await _connector.SendRequestAsync<TransportDto>(
                HttpMethod.Post,
                "/api/v1/transports",
                request);
        }

        public async Task<TransportStateDto> GetTransportStatus(string transportId)
        {
            return await _connector.SendRequestAsync<TransportStateDto>(
                HttpMethod.Get,
                $"/api/v1/transports/{transportId}/status");
        }
    }
}
