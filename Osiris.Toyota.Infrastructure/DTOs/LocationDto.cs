using Osiris.Toyota.Core.Enums;


namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class LocationDto
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public PositionQualifier PositionQualifier { get; set; }
    }
}
