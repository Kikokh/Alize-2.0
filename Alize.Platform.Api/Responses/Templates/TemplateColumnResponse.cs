namespace Alize.Platform.Api.Responses.Templates
{
    public class TemplateColumnResponse
    {
        public string Header { get; set; }

        public string Property { get; set; }

        public string DataType { get; set; }

        public bool HasFilter { get; set; } = false;

        public ICollection<string>? FilterOption { get; set; }
    }
}