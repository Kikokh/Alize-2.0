using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetHistory
    {
        [JsonPropertyName("id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, object> Metadata { get; set; }
    }
}