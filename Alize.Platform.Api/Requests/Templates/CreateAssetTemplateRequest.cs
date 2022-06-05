namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateAssetTemplateRequest
    {
        public IEnumerable<CreateTemplateColumnRequest> Columns { get; set; }

        public IEnumerable<CreateTemplateFieldRequest> Fields { get; set; }
    }
}
