using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaAssetHistory
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("blockNumber")]
        public int BlockNumber { get; set; }

        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockTimestamp")]
        public DateTime BlockTimestamp { get; set; }

        [JsonProperty("transacctionHash")]
        public string TransacctionHash { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, dynamic> Metadata { get; set; }
    }
}
