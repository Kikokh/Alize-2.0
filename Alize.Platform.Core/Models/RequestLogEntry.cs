using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alize.Platform.Core.Models
{
    public class RequestLogEntry
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Users")]
        public Guid UserId { get; set; }

        [ForeignKey("Applications")]
        public Guid ApplicationId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [StringLength(40)]
        public string Action { get; set; }
    }
}
