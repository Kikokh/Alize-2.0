using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaAsset
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, dynamic> Data { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, dynamic> Metadata { get; set; }
    }
}
