using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class NoAuthStrategy : IAuthStrategy
    {
        public async Task ApplyAuthorizationAsync(HttpRequestMessage request, ExternalSystem system)
        {
            // no-op
        }
    }
}
