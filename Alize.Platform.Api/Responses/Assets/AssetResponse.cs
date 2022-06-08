namespace Alize.Platform.Api.Responses.Assets
{
    public class AssetResponse
    {
        public string Id { get; set; }

        public IDictionary<string, object> Data { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? Namespace { get; set; }

        public string? Type { get; set; }
    }
}
