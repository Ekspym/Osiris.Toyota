using Osiris.Toyota.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osiris.Toyota.Core.Entities
{
    public class Instruction
    {
        public string LocationName { get; set; }
        public InstructionAction Action { get; set; }
        public List<string> LoadIds { get; set; } = new();
        public InstructionState State { get; set; }
    }
}
