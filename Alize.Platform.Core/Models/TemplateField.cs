using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Core.Models
{
    public class TemplateField
    {
        public string? Header { get; set; }

        public string Property { get; set; }

        public string DataType { get; set; }

        public string? Preffix { get; set; }

        public string? Suffix { get; set; }
    }
}