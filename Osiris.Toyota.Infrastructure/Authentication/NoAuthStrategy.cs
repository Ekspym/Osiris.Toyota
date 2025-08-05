using Microsoft.AspNetCore.DataProtection;
using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.DTOs;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class NoAuthStrategy : AuthStrategyBase
    {
        public NoAuthStrategy(IDataProtectionProvider provider) : base(provider)
        {
        }

        public override Task<AuthResult> ApplyAuthorizationAsync(HttpRequestMessage request, ExternalSystem system)
        {
            throw new NotImplementedException();
        }
    }
}
