namespace Alize.Platform.Api.Responses.Templates
{
    public class AssetTemplateResponse
    {
        public IEnumerable<TemplateColumnResponse> Columns { get; set; }

        public IEnumerable<TemplateFieldResponse> Fields { get; set; }
    }
}
