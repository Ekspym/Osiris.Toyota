using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Infrastructure.Authentication;
using System.Net;
using System.Text;

namespace Osiris.Toyota.Infrastructure.Connectors
{
    public class TOneConnector : IExternalSystemConnector
    {
        private readonly ExternalSystem _system;
        private readonly HttpClient _httpClient;
        private const string HealthCheckEndpoint = "/api/v1/health";

        public TOneConnector(ExternalSystem system, HttpClient httpClient)
        {
            _system = system;
            _httpClient = httpClient;
        }

        public async Task<bool> HealthCheckAsync()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, BuildFullUrl(HealthCheckEndpoint));

                var authStrategy = AuthStrategyFactory.GetStrategy(_system.AuthType);
                await authStrategy.ApplyAuthorizationAsync(request, _system);

                var response = await _httpClient.SendAsync(request);

                return response.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(
            HttpMethod method,
            string route,
            object payload = null)
        {
            var request = new HttpRequestMessage(method, BuildFullUrl(route));

            if (payload != null)
            {
                HttpContent content = payload switch
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
                request.Content = content;
            }

            var authStrategy = AuthStrategyFactory.GetStrategy(_system.AuthType);
            await authStrategy.ApplyAuthorizationAsync(request, _system);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        public async Task<TResponse> SendRequestAsync<TRequest, TResponse>(
            HttpMethod method,
            string route,
            TRequest payload = default)
        {
            var request = new HttpRequestMessage(method, BuildFullUrl(route));

            if (payload != null)
            {
                var json = JsonConvert.SerializeObject(payload);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var authStrategy = AuthStrategyFactory.GetStrategy(_system.AuthType);
            await authStrategy.ApplyAuthorizationAsync(request, _system);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }

        private Uri BuildFullUrl(string route)
        {
            return new Uri(new Uri(_system.EndpointUrl), route);
        }
    }
}