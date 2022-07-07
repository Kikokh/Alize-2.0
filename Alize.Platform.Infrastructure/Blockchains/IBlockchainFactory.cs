
namespace Alize.Platform.Infrastructure
{
    public interface IBlockchainFactory
    {
        IBlockchainService Resolve(Guid blockchainId);
    }
}