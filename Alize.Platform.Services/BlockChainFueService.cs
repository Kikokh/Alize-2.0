using Alize.Platform.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;
using Xpander.Shared.ThirdParty.BCLibrary;
using Xpander.Shared.ThirdParty.BCLibrary.Messages.HistoryAsset;
using Xpander.Shared.ThirdParty.BCLibrary.Messages.RetrieveAsset;

namespace Alize.Platform.Services
{
    public class BlockChainFueService : IBlockChainService
    {
        private readonly HttpClient _httpClient;

        public BlockChainFueService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiUrls:BlockChainFUE"]);
        }

        public async Task<Asset> CreateAssetAsync(Application app, string content)
        {
            app.ApiId = "60ffbe3ef24524680871dc75";
            app.ApiKey = "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436";
            app.DataType = "bc_calidad_mapex";

            var body = new
            {
                asset = new
                {
                    data = new
                    {
                        type = app.DataType,
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

            SetHeaders(app.ApiId, app.ApiKey);
            var response = await _httpClient.PostAsync("asset", stringContent); 

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<dynamic>();
                return new Asset { Id = result.id, Content = content };
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public async Task<Asset> GetAssetAsync(Application app, Guid assetId)
        {
            var key = "a2f0be170eca423cfa305126da9b190ea6e99b25eee33ef3a7226d86e748920d";
            app.ApiId = "60ffbe3ef24524680871dc75";
            app.ApiKey = "fcc11ca743e9c7a0fd24b3dee879d5f9bba35864e28a1d7c2ef1a3813bbc5436";
            app.DataType = "bc_calidad_mapex";

            Processor.SetHeaders(app.ApiId, app.ApiKey, app.DataType);

            RetrieveAssetResponse response = await Processor.RetrieveAssetAsync(key);
            RetrieveAssetHistoryResponse historyResponse = await Processor.RetriveAssetHistoryAsync(key);

            return new Asset { Id = response.Asset.Id, Content = response.Asset.Data };
        }

        private void SetHeaders(string id, string key)
        {
            _httpClient.DefaultRequestHeaders.Remove("X-App-Id");
            _httpClient.DefaultRequestHeaders.Remove("X-App-Key");
            _httpClient.DefaultRequestHeaders.Add("X-App-Id", id);
            _httpClient.DefaultRequestHeaders.Add("X-App-Key", key);
        }
    }
}