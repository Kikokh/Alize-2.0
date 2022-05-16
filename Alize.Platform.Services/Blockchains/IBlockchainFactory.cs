
namespace Alize.Platform.Services
{
    public interface IBlockchainFactory
    {
        Task<IBlockchainService> CreateAsync(Guid blockchainId, Guid applicationId);
    }
}