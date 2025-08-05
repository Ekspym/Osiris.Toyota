using Microsoft.AspNetCore.DataProtection;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Enums;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public static class AuthStrategyFactory
    {
        public static IAuthStrategy GetStrategy(ExternalSystemAuthType type, IDataProtectionProvider dataProtectionProvider) =>
       type switch
       {
           ExternalSystemAuthType.OAuth2ClientCredentials => new OAuth2AuthStrategy(dataProtectionProvider),
           ExternalSystemAuthType.BasicAuth => new BasicAuthStrategy(dataProtectionProvider),
           _ => new BasicAuthStrategy(dataProtectionProvider)
       };
    }
}
