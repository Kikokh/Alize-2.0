using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Applications
{
    public class CreateApplicationRequest
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }
    }
}
