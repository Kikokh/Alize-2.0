﻿using Alize.Platform.Core.Models;
using Alize.Platform.Services.BlockchainFue.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Alize.Platform.Infrastructure.Services.BlockchainFue
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
                var response = await GetHttpClient().GetFromJsonAsync<FueAsset>(url);
                return new Asset()
                {
                    Id = response.AssetItem.Id,
                    Data = response.AssetItem.Data.BlockchainData,
                    CreatedAt = response.AssetItem.Data.CreatedAt,
                    Namespace = response.AssetItem.Data.Namespace,
                    Type = response.AssetItem.Data.Type
                };
            }
            catch (HttpRequestException)
            {
                return default;
            }            
        }

        public async Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(string assetId)
        {
            var url = $"asset/history?query={JsonSerializer.Serialize(new { id = assetId })}";

            try
            {
                var response = await GetHttpClient().GetFromJsonAsync<FueAssetHistoryList>(url);
                return response.History.Select(h => new AssetHistory()
                {
                    TransactionId = h.TransactionId,
                    Metadata = h.Metadata
                });
            }
            catch (HttpRequestException)
            {
                return Enumerable.Empty<AssetHistory>();
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

            var response = await GetHttpClient().GetFromJsonAsync<FueAssetList>(url);

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