using Newtonsoft.Json;

namespace Alize.Platform.Core.Models
{
    public abstract class ApplicationItem
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public abstract string Type { get; }
    }
}