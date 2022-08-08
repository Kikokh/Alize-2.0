using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Extensions;
using Alize.Platform.Infrastructure.Repositories;
using Alize.Platform.Services.BlockchainFue.Models;
using Newtonsoft.Json;

namespace Alize.Platform.Infrastructure.Services.BlockchainFue
{
    public class BlockchainFueService : IBlockchainService
    {
        private readonly IApplicationCredentialsRepository _applicationCredentialsRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public BlockchainFueService(IHttpClientFactory httpClientFactory, IApplicationCredentialsRepository applicationCredentialsRepository)
        {
            _applicationCredentialsRepository = applicationCredentialsRepository;
            _httpClientFactory = httpClientFactory;
        }

        public Task<ApplicationCredentials> CreateApplicationAsync(Application application, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<Asset?> GetAssetAsync(Guid applicationId, string assetId)
        {
            var url = $"asset?query={JsonConvert.SerializeObject(new { id = assetId })}";

            try
            {
                var client = await GetHttpClient(applicationId);
                var response = await client.GetAsync(url);
                var result = await response.Content.GetResult<FueAsset>();

                return result is not null ? new Asset()
                {
                    Id = result.AssetItem.Id,
                    Data = result.AssetItem.Data.BlockchainData,
                    CreatedAt = result.AssetItem.Data.CreatedAt,
                    Namespace = result.AssetItem.Data.Namespace
                } : default;
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public async Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(Guid applicationId, string assetId)
        {
            var url = $"asset/history?query={JsonConvert.SerializeObject(new { id = assetId })}";

            try
            {
                var client = await GetHttpClient(applicationId);
                var response = await client.GetAsync(url);
                var result = await response.Content.GetResult<FueAssetHistoryList>();

                return result is not null ? result.History.Select(h => new AssetHistory()
                {
                    TransactionId = h.TransactionId,
                    Metadata = h.Metadata
                }) : Enumerable.Empty<AssetHistory>();
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<AssetHistory>();
            }
        }

        public Task<IDictionary<string, dynamic>?> GetAssetMetadataAsync(Guid applicationId, string assetId)
        {
            throw new NotImplementedException();
        }

        public async Task<AssetsPage?> GetAssetsPageAsync(Guid applicationId, Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1)
        {
            var parameters = new
            {
                page_num = pageNumber,
                per_page = pageSize,
                data = queries.Where(q => q.Key != "pageSize" && q.Key != "pageNumber").ToDictionary(q => $"bc_data.{q.Key}", q => q.Value)
            };

            var url = $"asset?query={JsonConvert.SerializeObject(parameters)}";

            var client = await GetHttpClient(applicationId);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<FueAssetList>();

            return result != null ? new AssetsPage()
            {
                Assets = result.Assets.Select(a => new Asset()
                {
                    Id = a.Id,
                    Data = a.Data.BlockchainData,
                    CreatedAt = a.Data.CreatedAt,
                    Namespace = a.Data.Namespace
                }),
                Total = result.Count.Total
            } : new AssetsPage();
        }

        public Task UpdateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> metadata)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Asset>> GetAssets(Guid applicationId)
        {
            var url = $"asset";

            var applicationCredentials = await _applicationCredentialsRepository
                .GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.Alastria));

            using var client = await GetHttpClient(applicationId);
            var response = await client.GetAsync(url);
            var result = await response.Content.GetResult<FueAssetList>();

            return result.Assets.Select(a => new Asset()
            {
                Id = a.Id,
                Data = a.Data.BlockchainData,
                CreatedAt = a.Data.CreatedAt,
                Namespace = a.Data.Namespace
            });
        }

        private async Task<HttpClient> GetHttpClient(Guid applicationId)
        {
            var applicationCredentials = await _applicationCredentialsRepository.GetApplicationCredentialsAsync(applicationId, Guid.Parse(Blockchains.BlockchainFue));

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(applicationCredentials.Blockchain.ApiUrl);

            httpClient.DefaultRequestHeaders.Add("X-App-Id", applicationCredentials.Username);
            httpClient.DefaultRequestHeaders.Add("X-App-Key", applicationCredentials.EncryptedPassword);

            return httpClient;
        }

        public Task<Asset> CreateAssetAsync(Guid applicationId, Asset asset)
        {
            throw new NotImplementedException();
        }

        public Task<IDictionary<string, dynamic>> CreateAssetMetadataAsync(Guid applicationId, string assetId, IDictionary<string, dynamic> data)
        {
            throw new NotImplementedException();
        }
    }
}