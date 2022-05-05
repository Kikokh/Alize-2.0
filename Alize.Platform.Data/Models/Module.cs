using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alize.Platform.Data.Models
{
    public class Module
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        [Required]
        [ForeignKey("ModuleType")]
        public Guid ModuleTypeId { get; set; }

        [Required]
        public string ModuleGroup { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
