using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class TransportRequestDto
    {
        public string ExternalTransportId { get; set; }
        public byte Priority { get; set; } = 1;
        public DateTime? DueTime { get; set; }
        public List<TransportInstructionDto> Instructions { get; set; } = new();
        public Dictionary<string, string> Metadata { get; set; } = new();
    }
}
