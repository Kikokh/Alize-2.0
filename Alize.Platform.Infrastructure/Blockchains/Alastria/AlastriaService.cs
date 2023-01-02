using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Alastria.Models;
using Alize.Platform.Infrastructure.Extensions;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Configuration;
using System.Text;

namespace Alize.Platform.Infrastructure.Alastria
{
    public class AlastriaService : IBlockchainService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApplicationCredentialsRepository _applicationCredentialsRepository;
        private readonly IBlockchainRepository _blockchainRepository;
        private readonly ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AlastriaService(
            IHttpClientFactory httpClientFactory,
            IApplicationCredentialsRepository applicationCredentialsRepository,
            IBlockchainRepository blockchainRepository,
            ICryptographyService cryptographyService,
            IMapper mapper,
            IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _applicationCredentialsRepository = applicationCredentialsRepository;
            _blockchainRepository = blockchainRepository;
            _cryptographyService = cryptographyService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<ApplicationCredentials> CreateApplicationAsync(Application application)
        {
            var url = "bc-applications";

            using var client = await RootLoginAsync();

            var alastriaApplication = _mapper.Map<AlastriaApplication>(application);
            alastriaApplication.Password = _cryptographyService.DecryptString(_configuration["BlockchainCredentials:Alastria:Password"]);
            alastriaApplication.Roles = new[] { "APP_ADMINISTRATOR" };
            alastriaApplication.AdminUser = $"admin_{application.Id}";
            alastriaApplication.Email = $"{application.Id}@alize.es";

            var body = JsonConvert.SerializeObject(alastriaApplication);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            var result = await response.Content.GetResult<AlastriaApplication>();

            var credentials = new ApplicationCredentials()
            {
                ApplicationId = application.Id,
                BlockchainId = Guid.Parse(Blockchains.Alastria),
                Username = result.AdminUser,
                EncryptedPassword = _cryptographyService.EncryptString(alastriaApplication.Password)
            };

            await _applicationCredentialsRepository.CreateApplicationCredentialsAsync(credentials);

            return credentials;
        }

        public async Task<Asset?> GetAssetAsync(Guid applicationId, string assetId)
        {
            var url = $"assets/{assetId}";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<AlastriaResponse>();

            return _mapper.Map<Asset>(result.Asset);
        }

        public async Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(Guid applicationId, string assetId)
        {
            var url = $"assets/{assetId}/history";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<AlastriaResponse>();

            return _mapper.Map<IEnumerable<AssetHistory>>(result.History);
        }

        public async Task<IDictionary<string, dynamic>?> GetAssetMetadataAsync(Guid applicationId, string assetId)
        {
            var url = $"assets/{assetId}/metadata";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<AlastriaResponse>();

            return result.Metadata;
        }

        public async Task UpdateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> metadata)
        {
            var url = $"assets/{assetId}/metadata";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);

            var body = JsonConvert.SerializeObject(metadata);
            var content = new StringContent(body, Encoding.UTF8, "application/json");

            await client.PostAsync(url, content);
        }

        public async Task<AssetsPage?> GetAssetsPageAsync(Guid applicationId, Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1)
        {
            var url = $"assets/?limit={pageSize}&from={(pageNumber - 1)*pageSize}&sort=DESC";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.GetResult<AlastriaResponse>();

                var assets = _mapper.Map<IEnumerable<Asset>>(result.Assets);

                return new AssetsPage()
                {
                    Assets = assets,
                    Total = result.Pagination.TotalAssets
                };
            }

            return null;            
        }

        public async Task<IEnumerable<Asset>> GetAssets(Guid applicationId)
        {
            var url = $"assets";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<AlastriaResponse>();

            return _mapper.Map<IEnumerable<Asset>>(result.Assets);
        }

        public async Task<Asset> CreateAssetAsync(Guid applicationId, Asset asset)
        {
            var url = $"assets";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);

            var content = new StringContent(JsonConvert.SerializeObject(asset.Data));

            var response = await client.PostAsync(url, content);

            return asset;
        }

        private async Task<HttpClient> RootLoginAsync()
        {
            var httpClient = await GetHttpClient();

            var user = _configuration["BlockchainCredentials:Alastria:User"];
            var password = _cryptographyService.DecryptString(_configuration["BlockchainCredentials:Alastria:Password"]);
            var body = JsonConvert.SerializeObject(new { username = user, password });

            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("oauth/token", content);

            var result = await response.Content.ReadAsStringAsync();

            var alastriaLoginResponse = JsonConvert.DeserializeObject<AlastriaLoginResponse>(result);

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {alastriaLoginResponse.AccessToken}");

            return httpClient;
        }

        private async Task<HttpClient> AppLoginAsync(ApplicationCredentials applicationCredentials)
        {
            var httpClient = await GetHttpClient();

            var password = _cryptographyService.DecryptString(applicationCredentials.EncryptedPassword);
            var body = JsonConvert.SerializeObject(new { username = applicationCredentials.Username, password });

            var content = new StringContent(body, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("oauth/app", content);

            var result = await response.Content.GetResult<AlastriaLoginResponse>();

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + result?.AccessToken);

            return httpClient;
        }

        private async Task<HttpClient> GetHttpClient()
        {
            var blockchain = await _blockchainRepository.GetBlockchainAsync(Guid.Parse(Blockchains.Alastria));

            var httpClient = _httpClientFactory.CreateClient("HttpClientWithSSLUntrusted");

            httpClient.BaseAddress = new Uri(blockchain.ApiUrl);

            return httpClient;
        }

        public async Task<IDictionary<string, dynamic>> CreateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> data)
        {
            var url = $"assets";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await AppLoginAsync(applicationCredentials);

            var content = new StringContent(JsonConvert.SerializeObject(data));

            var response = await client.PostAsync($"{url}/{assetId}/metadata", content);

            return data;
        }
    }
}