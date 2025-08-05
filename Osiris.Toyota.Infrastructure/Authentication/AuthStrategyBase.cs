using Microsoft.AspNetCore.DataProtection;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.DTOs;
using Osiris.Toyota.Core.Entities;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public abstract class AuthStrategyBase : IAuthStrategy
    {
        protected readonly IDataProtector protector;

        protected AuthStrategyBase(IDataProtectionProvider provider)
        {
            protector = provider.CreateProtector("ExternalSystemTokens");
        }

        protected Task<string> GetToken(ExternalSystem system)
        {
            if (system.TokenExpiration.HasValue && system.TokenExpiration.Value <= DateTime.UtcNow)
            {
                throw new Exception("Access token has expired.");
            }

            var decryptedToken = protector.Unprotect(system.EncryptedAccessToken);
            return Task.FromResult(decryptedToken);
        }

        public abstract Task<AuthResult> ApplyAuthorizationAsync(HttpRequestMessage request, ExternalSystem system);
    }
}
