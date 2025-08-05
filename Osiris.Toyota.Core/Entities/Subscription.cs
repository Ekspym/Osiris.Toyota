using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class Subscription
    {
        public string Id { get; set; }
        public EventSourceType SourceType { get; set; }
        public string Endpoint { get; set; }
        public Authentication Authentication { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
