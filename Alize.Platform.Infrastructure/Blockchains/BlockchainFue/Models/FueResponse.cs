using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueResponse
    {
        [JsonProperty("ok")]
        public bool IsSuccessful { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }
    }
}