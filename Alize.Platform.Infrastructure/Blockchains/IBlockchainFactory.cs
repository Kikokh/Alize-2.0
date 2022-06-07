
namespace Alize.Platform.Infrastructure
{
    public interface IBlockchainFactory
    {
        Task<IBlockchainService> CreateAsync(Guid blockchainId, Guid applicationId);
    }
}