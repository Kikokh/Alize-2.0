using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaLoginResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}
