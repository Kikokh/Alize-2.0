namespace Alize.Platform.Services.Models
{
    public class Asset
    {
        public string Id { get; set; }

        public Dictionary<string, object> Data { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? Namespace { get; set; }

        public string? Type { get; set; }
    }
}
