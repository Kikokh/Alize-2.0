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

    internal class ZendeskUsersResponse
    {
        [JsonPropertyName("users")]
        public IEnumerable<ZendeskUser> Users { get; set; }
    }

    public class ZendeskService : IZendeskService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private const string _zendeskApiUrl = "https://soporte.alize.es/api/v2/users";

        public ZendeskService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task CreateZendeskUserAsync(User user)
        {
            var zendeskUser = new
            {
                user = new
                {
                    email = user.Email,
                    name = user.FirstName + " " + user.LastName
                }

            };

            var body = new StringContent(JsonSerializer.Serialize(zendeskUser), Encoding.UTF8, Application.Json);

            var existingUserId = await TryGetUserAsync(user.Email);

            if (existingUserId != null)
            {
                user.ZendeskUserId = existingUserId;
                return;
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = GetCredentials();
            var httpResponseMessage = await httpClient.PostAsync(_zendeskApiUrl, body);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ZendeskUserResponse>(content);

                user.ZendeskUserId = result?.User.Id;
            }
        }

        private AuthenticationHeaderValue GetCredentials()
        {
            var zendeskApiKey = "ylSfDj8DzPbkgzoFVlBIvqHzINs9WY3zQdn0tHIo";
            var zendeskApiEmail = "sistemas@xpander.es";
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{zendeskApiEmail}/token:{zendeskApiKey}"));

            return new AuthenticationHeaderValue("Basic", credentials);
        }

        private async Task<long?> TryGetUserAsync(string email)
        {
            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization = GetCredentials();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.GetAsync($"{_zendeskApiUrl}/search?query={email}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ZendeskUsersResponse>(content);

                return result?.Users.FirstOrDefault()?.Id;
            }

            return default;
        }
    }
}
