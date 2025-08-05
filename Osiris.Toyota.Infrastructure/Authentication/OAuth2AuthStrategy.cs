using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.DTOs;
using Osiris.Toyota.Core.Entities;
using System.Net.Http.Headers;

namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class OAuth2AuthStrategy : AuthStrategyBase
    {
        private readonly ILogger<OAuth2AuthStrategy> _logger;

        public OAuth2AuthStrategy(IDataProtectionProvider provider, ILogger<OAuth2AuthStrategy> logger) : base(provider)
        {
            _logger = logger;
        }

        public override async Task<AuthResult> ApplyAuthorizationAsync(
            HttpRequestMessage request,
            ExternalSystem system)
        {
            try
            {
                var token = await GetToken(system);
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                return new AuthResult { IsSuccess = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Authorization failed for system {SystemId}", system.Id);
                return new AuthResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Failed to apply authorization. See logs for details."
                };
            }
        }
    }
}