using Newtonsoft.Json;

namespace Alize.Platform.Services.BlockchainFue.Models
{
    public class FueResponseCount
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}