using System.Text.Json.Serialization;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueResponse
    {
        [JsonPropertyName("ok")]
        public bool IsSuccessful { get; set; }

        [JsonPropertyName("msg")]
        public string Message { get; set; }
    }
}