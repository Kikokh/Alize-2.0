using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Data.Models
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
