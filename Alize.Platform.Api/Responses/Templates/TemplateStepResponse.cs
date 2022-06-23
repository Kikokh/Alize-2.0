namespace Alize.Platform.Api.Responses.Templates
{
    public class TemplateStepResponse
    {
        public string Name { get; set; }

        public int Order { get; set; }

        public IEnumerable<TemplateFieldResponse>? Fields { get; set; }
    }
}