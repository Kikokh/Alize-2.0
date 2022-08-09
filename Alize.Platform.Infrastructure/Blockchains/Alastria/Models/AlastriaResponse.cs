using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaResponse
    {
        
        [JsonProperty("created")]
        public bool? Created { get; set; }

        [JsonProperty("found")]
        public bool Found { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("assets")]
        public IEnumerable<AlastriaAsset>? Assets { get; set; }

        [JsonProperty("history")]
        public IEnumerable<AlastriaAssetHistory>? History { get; set; }

        [JsonProperty("asset")]
        public AlastriaAsset? Asset { get; set; }

        [JsonProperty("metadata")]
        public IDictionary<string, dynamic>? Metadata { get; set; }
    }
}
