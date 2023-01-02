using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Alastria.Models
{
    public class AlastriaApplication
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("app_name")]
        public string ApplicationName { get; set; }

        [JsonProperty("admin_user")]
        public string AdminUser { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("revoked")]
        public bool Revoked { get; set; }

        [JsonProperty("roles")]
        public ICollection<string> Roles { get; set; }
    }
}
