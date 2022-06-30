﻿using Alize.Platform.Core.Models;
using Alize.Platform.Services.BlockchainFue.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

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
            var url = $"asset?query={JsonConvert.SerializeObject(new { id = assetId })}";

            try
            {
                var response = await GetHttpClient().GetFromJsonAsync<FueAsset>(url);

                return response is not null ? new Asset()
                {
                    Id = response.AssetItem.Id,
                    Data = response.AssetItem.Data.BlockchainData,
                    CreatedAt = response.AssetItem.Data.CreatedAt,
                    Namespace = response.AssetItem.Data.Namespace
                } : default;
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public async Task<IEnumerable<AssetHistory>> GetAssetHistoryAsync(string assetId)
        {
            var url = $"asset/history?query={JsonConvert.SerializeObject(new { id = assetId })}";

            try
            {
                var response = await GetHttpClient().GetFromJsonAsync<FueAssetHistoryList>(url);

                return response is not null ? response.History.Select(h => new AssetHistory()
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

        public async Task<IEnumerable<Asset>> GetAssets()
        {
            var parameters = new
            {
                page_num = 1,
                per_page = 500
            };

            var url = $"asset?query={JsonConvert.SerializeObject(parameters)}";

            try
            {
                var response = await GetHttpClient().GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();

                var assetList = JsonConvert.DeserializeObject<FueAssetList>(content);

                return assetList is not null ? assetList.Assets.Select(a => new Asset()
                {
                    Id = a.Id,
                    Data = a.Data.BlockchainData,
                    CreatedAt = a.Data.CreatedAt,
                    Namespace = a.Data.Namespace
                }) : Enumerable.Empty<Asset>();
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public async Task<AssetsPage?> GetAssetsPageAsync(Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1)
        {
            var parameters = new
            {
                page_num = pageNumber,
                per_page = pageSize,
                data = queries.Where(q => q.Key != "pageSize" && q.Key != "pageNumber").ToDictionary(q => $"bc_data.{q.Key}", q => q.Value)
            };

            var url = $"asset?query={JsonConvert.SerializeObject(parameters)}";

            var response = await GetHttpClient().GetFromJsonAsync<FueAssetList>(url);

            return response != null ? new AssetsPage()
            {
                Assets = response.Assets.Select(a => new Asset()
                {
                    Id = a.Id,
                    Data = a.Data.BlockchainData,
                    CreatedAt = a.Data.CreatedAt,
                    Namespace = a.Data.Namespace
                }),
                Total = response.Count.Total
            } : new AssetsPage();
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_applicationCredentials.Blockchain.ApiUrl)
            };

            httpClient.DefaultRequestHeaders.Add("X-App-Id", _applicationCredentials.Username);
            httpClient.DefaultRequestHeaders.Add("X-App-Key", _applicationCredentials.EncriptedPassword);

            return httpClient;
        }
    }
}