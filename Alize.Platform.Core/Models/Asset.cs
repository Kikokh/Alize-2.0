using Alize.Platform.Core.Constants;
using Newtonsoft.Json;

namespace Alize.Platform.Core.Models
{
    public class Asset : ApplicationItem
    {
        public string BlockNumber { get; set; }

        public string BlockHash { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, object> Data { get; set; }

        [JsonProperty(PropertyName = "createdAt")]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonProperty(PropertyName = "namespace")]
        public string? Namespace { get; set; }

        public override string Type => ApplicationItemTypes.Asset;
    }
}
