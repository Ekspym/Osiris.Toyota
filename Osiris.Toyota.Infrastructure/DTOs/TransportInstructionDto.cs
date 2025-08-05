using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class TransportInstructionDto
    {
        public string LocationName { get; set; }
        public InstructionAction Action { get; set; }
        public List<string> LoadIds { get; set; } = new();
    }
}
