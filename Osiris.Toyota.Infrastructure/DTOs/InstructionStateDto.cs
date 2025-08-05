
using Osiris.Toyota.Core.Enums;

namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class InstructionStateDto
    {
        public InstructionState Code { get; set; } 
        public string Reason { get; set; }
        public Dictionary<string, string> Data { get; set; }
    }

}
