using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class Transport
    {
        public string Id { get; set; }
        public string ExternalTransportId { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new();
        public byte Priority { get; set; } = 0;
        public DateTime? DueTime { get; set; }
        public int CurrentInstructionIndex { get; set; }
        public List<Instruction> Instructions { get; set; } = new();
        public List<Vehicle> Vehicles { get; set; } = new();
        public bool AbortRequested { get; set; }
        public TransportState State { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? StartedDateTime { get; set; }
        public DateTime? FinishedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
