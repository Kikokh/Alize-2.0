using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueListResponse : FueResponse
    {
        [JsonPropertyName("count")]
        public FueResponseCount Count { get; set; }

        [JsonPropertyName("assets")]
        public IEnumerable<FueResponseAsset> Assets { get; set; }
    }
}