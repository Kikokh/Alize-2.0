using System.ComponentModel.DataAnnotations;

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

        public bool IsActive { get; set; }

        public string? ApiId { get; set; }

        public string? ApiKey { get; set; }

        public string? DataType { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
