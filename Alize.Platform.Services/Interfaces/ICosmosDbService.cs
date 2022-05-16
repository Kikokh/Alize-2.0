
using Alize.Platform.Data.Models;

namespace Alize.Platform.Services
{
    public interface ICosmosDbService
    {
        Task AddItemAsync<T>(T item) where T : Entity;
        Task DeleteItemAsync<T>(string id) where T : Entity;
        Task<T?> GetItemAsync<T>(string id) where T : Entity;
        Task<IEnumerable<T>> GetItemsAsync<T>(string queryString) where T : Entity;
        Task UpdateItemAsync<T>(string id, T item) where T : Entity;
    }
}