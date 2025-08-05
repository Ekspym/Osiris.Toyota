using Microsoft.AspNetCore.DataProtection;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.DTOs;
using Osiris.Toyota.Core.Entities;
using System.Net.Http.Headers;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class OAuth2AuthStrategy : AuthStrategyBase
    {
        public OAuth2AuthStrategy(IDataProtectionProvider provider) : base(provider) { }

        public override async Task<AuthResult> ApplyAuthorizationAsync(HttpRequestMessage request, ExternalSystem system)
        {
            var token = await GetToken(system);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return new AuthResult { IsSuccess = true };
        }

    }
}
