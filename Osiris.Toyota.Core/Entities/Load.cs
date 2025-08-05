using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class Load
    {
        public string Id { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public Dimensions Dimensions { get; set; }
        public double? Weight { get; set; } 
        public string LoadCarrierType { get; set; }
        public Stackability Stackability { get; set; }
        public Location Location { get; set; }
        public LoadState State { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
