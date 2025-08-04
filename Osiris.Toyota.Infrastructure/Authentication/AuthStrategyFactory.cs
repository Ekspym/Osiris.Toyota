using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Authentication
{
    public static class AuthStrategyFactory
    {
        public static IAuthStrategy GetStrategy(ExternalSystemAuthType type) =>
            type switch
            {
                ExternalSystemAuthType.OAuth2ClientCredentials => new OAuth2AuthStrategy(),
                ExternalSystemAuthType.BasicAuth => new BasicAuthStrategy(),
                _ => new BasicAuth()
            };
    }
}
