using System.ComponentModel.DataAnnotations;

namespace NZWalks.Api.Models.DTO
{
    public class CreateRegionDto
    {
        [Required]
        public string Name { get; set; }

        [MinLength(2,ErrorMessage ="Code has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a max of 3 characters")]

        [Required]

        public string Code { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
