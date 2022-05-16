using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueSingleResponse : FueResponse
    {
        [JsonPropertyName("asset")]
        public FueResponseAsset Asset { get; set; }
    }
}
