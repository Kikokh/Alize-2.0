using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateTemplateRequest
    {
        [Required]
        public IEnumerable<CreateTemplateColumnRequest> Columns { get; set; }
    }
}
