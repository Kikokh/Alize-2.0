namespace Alize.Platform.Api.Responses.Templates
{
    public class ApplicationTemplateResponse
    {
        public IEnumerable<TemplateColumnResponse> Columns { get; set; }

        public IEnumerable<TemplateStatResponse>? Stats { get; set; }
    }
}
