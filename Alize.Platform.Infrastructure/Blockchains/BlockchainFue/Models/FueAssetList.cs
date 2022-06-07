using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetList : FueResponse
    {
        [JsonPropertyName("count")]
        public FueResponseCount Count { get; set; }

        [JsonPropertyName("assets")]
        public IEnumerable<FueAssetItem> Assets { get; set; }
    }
}