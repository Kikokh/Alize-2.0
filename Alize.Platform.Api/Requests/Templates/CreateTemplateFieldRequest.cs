using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateTemplateFieldRequest
    {
        [Required]
        public string Header { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        public string DataType { get; set; }

        public string? Preffix { get; set; }

        public string? Suffix { get; set; }
    }
}