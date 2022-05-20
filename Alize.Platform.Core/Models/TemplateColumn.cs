using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Core.Models
{
    public class TemplateColumn : TemplateField
    {
        public bool HasFilter { get; set; } = false;

        public ICollection<string>? FilterOption { get; set; }
    }
}