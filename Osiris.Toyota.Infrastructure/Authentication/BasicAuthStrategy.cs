using Osiris.Toyota.Core.Abstractions;
using Osiris.Toyota.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.Authentication
{
    public class BasicAuthStrategy : IAuthStrategy
    {
        public void ApplyAuthorization(HttpRequestMessage request, ExternalSystem system)
        {
            var base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(system.AccessToken));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", base64);
        }
    }
}
