using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alize.Platform.Data.Models
{
    public class Application
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string? Description { get; set; }

        public Company? Company { get; set; }

        [ForeignKey("Company")]
        public Guid? CompanyId { get; set; }

        public bool IsActive { get; set; } = false;

        public ICollection<User>? Users { get; set; }
    }
}
