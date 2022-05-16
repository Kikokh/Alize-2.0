using Alize.Platform.Data.Models;
using Alize.Platform.Services.BlockchainFue.Models;
using Alize.Platform.Services.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Alize.Platform.Services.BlockchainFue
{
    public class BlockchainFueService : IBlockchainService
    {
        private readonly ApplicationCredentials _applicationCredentials;
        private readonly ICryptographyService _cryptographyService;

        public BlockchainFueService(ApplicationCredentials applicationCredentials, ICryptographyService cryptographyService)
        {
            _applicationCredentials = applicationCredentials;
            _cryptographyService = cryptographyService;
        }

        public async Task<Asset?> GetAssetAsync(string assetId)
        {
            var url = $"asset?query={JsonSerializer.Serialize(new { id = assetId })}";

            try
            {
                var response = await GetHttpClient().GetFromJsonAsync<FueSingleResponse>(url);
                return new Asset()
                {
                    Id = response.Asset.Id,
                    Data = response.Asset.Data.BlockchainData,
                    CreatedAt = response.Asset.Data.CreatedAt,
                    Namespace = response.Asset.Data.Namespace,
                    Type = response.Asset.Data.Type
                };
            }
            catch (HttpRequestException)
            {
                return default;
            }            
        }

        public async Task<IEnumerable<Asset>> GetAssetsAsync(int? pageNumber = default, int? pageSize = default, bool isInverse = false)
        {
            var parameters = new Dictionary<string, object>();

            if (pageNumber.HasValue)
                parameters.Add("page_num", pageNumber.Value);

            if (pageSize.HasValue)
                parameters.Add("per_page", pageSize.Value);

            if (isInverse)
                parameters.Add("inverse", isInverse);

            var url = parameters.Any() ? $"asset?query={JsonSerializer.Serialize(parameters)}" : "asset";

            var response = await GetHttpClient().GetFromJsonAsync<FueListResponse>(url);

            return response.Assets.Select(a => new Asset()
            {
                Id = a.Id,
                Data = a.Data.BlockchainData,
                CreatedAt = a.Data.CreatedAt,
                Namespace = a.Data.Namespace,
                Type = a.Data.Type
            });            
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_applicationCredentials.Blockchain.ApiUrl)
            };

            httpClient.DefaultRequestHeaders.Add("X-App-Id", _applicationCredentials.Username);
            httpClient.DefaultRequestHeaders.Add("X-App-Key", _cryptographyService.DecryptString(_applicationCredentials.EncriptedPassword));

            return httpClient;
        }
    }
}