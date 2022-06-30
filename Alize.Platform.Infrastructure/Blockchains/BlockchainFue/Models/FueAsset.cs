
using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAsset : FueResponse
    {
        [JsonProperty("asset")]
        public FueAssetItem AssetItem { get; set; }
    }
}
