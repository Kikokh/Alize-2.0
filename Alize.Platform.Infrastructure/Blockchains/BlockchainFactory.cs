using Alize.Platform.Core.Constants;
using Alize.Platform.Infrastructure.Alastria;
using Alize.Platform.Infrastructure.Services.BlockchainFue;

namespace Alize.Platform.Infrastructure
{
    public class BlockchainFactory : IBlockchainFactory
    {
        private readonly IEnumerable<IBlockchainService> _blockchainServices;

        public BlockchainFactory(IEnumerable<IBlockchainService> blockchainServices)
        {
            _blockchainServices = blockchainServices;
        }

        public IBlockchainService Resolve(Guid blockchainId)
        {
            return blockchainId.ToString() switch
            {
                Blockchains.Alastria => _blockchainServices.Single(service => service is AlastriaService),
                Blockchains.BlockchainFue => _blockchainServices.Single(service => service is BlockchainFueService),
                _ => throw new NotImplementedException()
            };
        }
    }
}
