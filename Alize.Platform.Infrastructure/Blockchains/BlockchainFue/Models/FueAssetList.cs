using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetList : FueResponse
    {
        [JsonProperty("count")]
        public FueResponseCount Count { get; set; }

        [JsonProperty("assets")]
        public IEnumerable<FueAssetItem> Assets { get; set; }
    }
}