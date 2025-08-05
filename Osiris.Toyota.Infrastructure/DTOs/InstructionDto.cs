using Osiris.Toyota.Core.Enums;


namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class InstructionDto
    {
        public string LocationName { get; set; }
        public InstructionAction Action { get; set; } 
        public string[][] Loads { get; set; } 
        public InstructionStateDto State { get; set; }
    }
}
