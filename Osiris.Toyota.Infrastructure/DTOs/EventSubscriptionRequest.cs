using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class EventSubscriptionRequest
    {
        public string Url { get; set; }
        public List<string> EventTypes { get; set; } = new();
    }
}
