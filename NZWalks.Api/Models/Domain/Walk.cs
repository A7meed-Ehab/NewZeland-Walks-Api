using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.Api.Models.Domain
{
    public class Walk : BaseModel
    {
        public string Description { get; set; }
        public string LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
