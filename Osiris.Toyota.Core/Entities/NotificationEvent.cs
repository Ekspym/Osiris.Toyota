using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class NotificationEvent
    {
        public EventSourceType SourceType { get; set; }
        public string EventType { get; set; } 
        public object EventData { get; set; } 
    }
}
