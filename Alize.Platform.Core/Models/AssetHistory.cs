using System.Text.Json.Serialization;

namespace Alize.Platform.Core.Models
{
    public class AssetHistory
    {
        [JsonPropertyName("id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("blockNumber")]
        public long BlockNumber { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, dynamic> Metadata { get; set; }
    }
}
