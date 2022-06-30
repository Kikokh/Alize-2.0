using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetHistoryList : FueResponse
    {
        [JsonProperty("history")]
        public IEnumerable<FueAssetHistory> History { get; set; }
    }
}
