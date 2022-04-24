using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Alize.Platform.Services
{
    public class BlockChainFueService : IBlockChainService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IConfiguration _configuration;

        public BlockChainFueService(IConfiguration configuration, IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
            _configuration = configuration;
        }

        public async Task<Asset> CreateAssetAsync(string content)
        {
            var apiId = "60ffbe3ef24524680871dc75";
            var apiKey = "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436";
            var dataType = "bc_calidad_mapex";

            var body = new
            {
                asset = new
                {
                    data = new
                    {
                        type = dataType,
                        content = content
                    },
                    from = new
                    {
                        pub = "4afFg7bVp1whZQaR1EjjD8XLmXEXexXowqymvki2nA2W", // X_PUBLIC_KEY
                        pvt = "C9JzhtwVU34pEyELiTUVFGauEVKr4prPZhRKL5t37BHf" // X_PRIVATE_KEY
                    }
                }
            };

            var foo = JsonSerializer.Serialize(body);

            var stringContent = new StringContent(foo, Encoding.UTF8, "application/json");

            var response = await GetHttpClient(apiId, apiKey).PostAsync("asset", stringContent);

            return await ReadResponse<Asset>(response);
        }

        public async Task<Asset> GetAssetAsync(Guid assetId)
        {
            var apiId = "60ffbe3ef24524680871dc75";
            var apiKey = "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436";

            var response = await GetHttpClient(apiId, apiKey).GetAsync("asset");

            return await ReadResponse<Asset>(response);            
        }

        private HttpClient GetHttpClient(string id, string key)
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_configuration["ApiUrls:BlockChainFUE"])
            };

            httpClient.DefaultRequestHeaders.Add("X-App-Id", id);
            httpClient.DefaultRequestHeaders.Add("X-App-Key", key);

            return httpClient;
        }

        private async Task<T> ReadResponse<T>(HttpResponseMessage responseMessage) where T : class
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                return await responseMessage.Content.ReadAsAsync<T>();
            }
            else
            {
                throw new Exception(responseMessage.StatusCode.ToString());
            }
        }
    }
}