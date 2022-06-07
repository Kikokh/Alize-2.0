using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAsset : FueResponse
    {
        [JsonPropertyName("asset")]
        public FueAssetItem AssetItem { get; set; }
    }
}
