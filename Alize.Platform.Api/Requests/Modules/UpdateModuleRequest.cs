using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Modules
{
    public class UpdateModuleRequest
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }
    }
}
