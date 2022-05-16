using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueResponseCount
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}