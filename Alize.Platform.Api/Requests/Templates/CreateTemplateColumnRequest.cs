using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateTemplateColumnRequest
    {
        [Required]
        public string Header { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        public string DataType { get; set; }

        public string? Preffix { get; set; }

        public string? Suffix { get; set; }

        public bool HasFilter { get; set; } = false;

        public ICollection<string>? FilterOption { get; set; }
    }
}