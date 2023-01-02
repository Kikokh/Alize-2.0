using Alize.Platform.Core.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application = System.Net.Mime.MediaTypeNames.Application;

namespace Alize.Platform.Infrastructure.Services
{
    internal class ZendeskOrganiation
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    internal class ZendeskIdentity
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    internal class ZendeskUser
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("id")]
        public long? Id { get; set; }

        [JsonPropertyName("external_id")]
        public long? ExternalId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("role_type")]
        public long? RoleType { get; set; }

        [JsonPropertyName("identities")]
        public IEnumerable<ZendeskIdentity> Identities { get; set; }

        [JsonPropertyName("organization")]
        public ZendeskOrganiation? Organization { get; set; }
    }

    internal class ZendeskUserResponse
    {
        [JsonPropertyName("user")]
        public ZendeskUser User { get; set; }
    }

    public class ZendeskService : IZendeskService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ZendeskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateZendeskUserAsync(User user)
        {
            var zendeskApiKey = "ylSfDj8DzPbkgzoFVlBIvqHzINs9WY3zQdn0tHIo";
            var zendeskApiEmail = "sistemas@xpander.es";
            var zendeskApiUrl = "https://soporte.alize.es/api/v2/users";

            var zendeskUser = new
            {
                user = new
                {
                    email = user.Email,
                    name = user.FirstName + " " + user.LastName
                }

            };

            var body = new StringContent(JsonSerializer.Serialize(zendeskUser), Encoding.UTF8, Application.Json);

            var httpClient = _httpClientFactory.CreateClient();
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{zendeskApiEmail}/token:{zendeskApiKey}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
            var httpResponseMessage = await httpClient.PostAsync(zendeskApiUrl, body);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ZendeskUserResponse>(content);

                user.ZendeskUserId = result?.User.Id;
            }
        }
    }
}
