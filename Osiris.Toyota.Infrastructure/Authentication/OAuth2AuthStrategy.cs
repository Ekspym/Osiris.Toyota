using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using System.Net.Http.Headers;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class OAuth2AuthStrategy : IAuthStrategy
    {
        public void ApplyAuthorization(HttpRequestMessage request, ExternalSystem system)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", system.AccessToken);
        }
    }
}
