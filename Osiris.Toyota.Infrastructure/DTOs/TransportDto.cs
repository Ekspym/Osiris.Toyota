
namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class TransportDto
    {
        public string Id { get; set; }
        public string ExternalTransportId { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public byte Priority { get; set; }
        public DateTime? DueTime { get; set; }
        public byte CurrentInstruction { get; set; }
        public List<InstructionDto> Instructions { get; set; }
        public List<VehicleDto> Vehicles { get; set; }
        public bool AbortRequested { get; set; }
        public TransportStateDto State { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? StartedDateTime { get; set; }
        public DateTime? FinishedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
