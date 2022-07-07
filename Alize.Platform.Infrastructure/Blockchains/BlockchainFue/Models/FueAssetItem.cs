using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("data")]
        public FueAssetData Data { get; set; }
    }
}