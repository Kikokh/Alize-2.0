using Newtonsoft.Json;

namespace Alize.Platform.Core.Models
{
    public class Asset
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string BlockNumber { get; set; }

        public string BlockHash { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "namespace")]
        public string? Namespace { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string? Type { get; set; }
    }
}
