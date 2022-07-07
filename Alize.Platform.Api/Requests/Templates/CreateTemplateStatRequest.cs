namespace Alize.Platform.Api.Requests.Templates
{
    public class CreateTemplateStatRequest
    {
        public string Title { get; set; }

        public string Property { get; set; }

        public int Type { get; set; } // TODO Type

        public string? Footer { get; set; }
    }
}
