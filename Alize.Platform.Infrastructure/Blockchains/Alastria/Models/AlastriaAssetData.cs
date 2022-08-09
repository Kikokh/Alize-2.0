using Alize.Platform.Infrastructure.Services.BlockchainFue;
using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaAssetData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("bc_data")]
        public Dictionary<string, dynamic> BlockchainData { get; set; }

        [JsonProperty("app")]
        public string Application { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("token")]
        public bool Token { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("created_at")]
        [JsonConverter(typeof(DateTimeTicksConverter))]
        public DateTime CreatedAt { get; set; }
    }
}