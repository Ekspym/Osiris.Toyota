using Osiris.Toyota.Core.Enums;

namespace Osiris.Toyota.Infrastructure.DTOs
{
    public class LoadDto
    {
        public string Id { get; set; }
        public Dictionary<string, object> Data { get; set; } 
        public DimensionsDto Dimensions { get; set; }
        public float? Weight { get; set; }
        public string LoadCarrierType { get; set; }
        public Stackability Stackability { get; set; } 
        public LocationDto Location { get; set; }
        public LoadState State { get; set; } 
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
