using Alize.Platform.Infrastructure.Services.BlockchainFue;
using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueAssetData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("bc_data")]
        public Dictionary<string, object> BlockchainData { get; set; }

        [JsonPropertyName("app")]
        public string Application { get; set; }

        [JsonPropertyName("from")]
        public string From { get; set; }

        [JsonPropertyName("token")]
        public bool Token { get; set; }

        [JsonPropertyName("namespace")]
        public string Namespace { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeTicksConverter))]
        public DateTime CreatedAt { get; set; }
    }
}