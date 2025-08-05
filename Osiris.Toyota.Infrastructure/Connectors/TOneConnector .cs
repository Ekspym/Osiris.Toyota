using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Core.Enums;
using Osiris.Toyota.Infrastructure.Authentication;
using System.Net;
using System.Text;

namespace Osiris.Toyota.Infrastructure.Connectors
{
    public class TOneConnector : IExternalSystemConnector
    {
        private readonly ExternalSystem _system;
        private readonly HttpClient _httpClient;
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly ILogger<TOneConnector> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private const string HealthCheckEndpoint = "/api/v1/health";

        public TOneConnector(
            ExternalSystem system,
            HttpClient httpClient,
            IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory)
        {
            _system = system ?? throw new ArgumentNullException(nameof(system));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _dataProtectionProvider = dataProtectionProvider ?? throw new ArgumentNullException(nameof(dataProtectionProvider));
            _loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            _logger = loggerFactory.CreateLogger<TOneConnector>();
        }

        public async Task<bool> HealthCheckAsync()
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Get, BuildFullUrl(HealthCheckEndpoint));

                var authStrategy = GetAuthStrategy();
                await authStrategy.ApplyAuthorizationAsync(request, _system);

                using var response = await _httpClient.SendAsync(request);
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Health check failed for system {SystemId}", _system.Id);
                return false;
            }
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(HttpMethod method, string route, object payload = null)
        {
            using var request = new HttpRequestMessage(method, BuildFullUrl(route));

            if (payload != null)
            {
                request.Content = CreateHttpContent(payload);
            }

            var authStrategy = AuthStrategyFactory.CreateStrategy(
                ExternalSystemAuthType.OAuth2ClientCredentials,
                _dataProtectionProvider,
                _loggerFactory);

            var authResult = await authStrategy.ApplyAuthorizationAsync(request, _system);
            if (!authResult.IsSuccess)
            {
                throw new AuthorizationException($"Authorization failed: {authResult.ErrorMessage}");
            }

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        private HttpContent CreateHttpContent(object payload)
        {
            return payload switch
            {
                string str => new StringContent(str, Encoding.UTF8, "text/plain"),
                JsonPatchDocument patch => new StringContent(
                    JsonConvert.SerializeObject(patch.Operations),
                    Encoding.UTF8,
                    "application/json-patch+json"),
                _ => new StringContent(
                    JsonConvert.SerializeObject(payload),
                    Encoding.UTF8,
                    "application/json")
            };
        }

        private Uri BuildFullUrl(string route)
        {
            if (string.IsNullOrWhiteSpace(_system.EndpointUrl))
            {
                throw new InvalidOperationException("System endpoint URL is not configured");
            }

            return new Uri(new Uri(_system.EndpointUrl), route);
        }

        private IAuthStrategy GetAuthStrategy()
        {
            return AuthStrategyFactory.CreateStrategy(
                _system.AuthType,
                _dataProtectionProvider,
                _loggerFactory);
        }
    }

    public class AuthorizationException : Exception
    {
        public AuthorizationException(string message) : base(message) { }
    }
}
