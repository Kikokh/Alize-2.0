using Alize.Platform.Infrastructure.Services.BlockchainFue;
using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetData
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
        //[JsonIgnore]
        public DateTime CreatedAt { get; set; }
    }
}