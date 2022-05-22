using Newtonsoft.Json;

namespace Alize.Platform.Core.Models
{
    public class ApplicationTemplate
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ApplicationId { get; set; }

        public IEnumerable<TemplateColumn> Columns { get; set; }

        public ApplicationAssetTemplate AssetTemplate { get; set; }
    }
}
