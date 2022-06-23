using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Core.Models
{
    public class TemplateStep
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public IEnumerable<TemplateField>? Fields { get; set; }
    }
}