using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Core.Models
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
