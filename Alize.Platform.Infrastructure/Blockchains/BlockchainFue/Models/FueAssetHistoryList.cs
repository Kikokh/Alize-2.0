using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetHistoryList : FueResponse
    {
        [JsonPropertyName("history")]
        public IEnumerable<FueAssetHistory> History { get; set; }
    }
}
