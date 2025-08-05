using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Enums;


namespace Osiris.Toyota.Infrastructure.Authentication
{
    public static class AuthStrategyFactory
    {
        public static IAuthStrategy GetStrategy(ExternalSystemAuthType type) =>
            type switch
            {
                ExternalSystemAuthType.OAuth2ClientCredentials => new OAuth2AuthStrategy(),
                ExternalSystemAuthType.BasicAuth => new BasicAuthStrategy(),
                _ => new BasicAuthStrategy()
            };
    }
}
