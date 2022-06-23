using System.ComponentModel.DataAnnotations;

namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateTemplateStepRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public IEnumerable<CreateTemplateFieldRequest>? Fields { get; set; }
    }
}