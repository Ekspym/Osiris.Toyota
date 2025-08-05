using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Enums;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public static class AuthStrategyFactory
    {
        public static IAuthStrategy CreateStrategy(
            ExternalSystemAuthType type,
            IDataProtectionProvider dataProtectionProvider,
            ILoggerFactory loggerFactory)
        {
            return type switch
            {
                ExternalSystemAuthType.OAuth2ClientCredentials => new OAuth2AuthStrategy(
                    dataProtectionProvider,
                    loggerFactory.CreateLogger<OAuth2AuthStrategy>()),

                ExternalSystemAuthType.BasicAuth => new BasicAuthStrategy(
                    dataProtectionProvider,
                    loggerFactory.CreateLogger<BasicAuthStrategy>()),

                _ => throw new NotSupportedException($"Auth type {type} is not supported")
            };
        }
    }
}
