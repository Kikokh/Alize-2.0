using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaPagination
    {
        [JsonProperty("totalAssets")]
        public int TotalAssets { get; set; }

        [JsonProperty("selectedAssets")]
        public int SelectedAssets { get; set; }

        [JsonProperty("sorted")]
        public string Sorted { get; set; }
    }
}