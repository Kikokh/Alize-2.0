using Alize.Platform.Core.Constants;
using Alize.Platform.Infrastructure.Repositories;
using Alize.Platform.Infrastructure.Services.BlockchainFue;

namespace Alize.Platform.Infrastructure
{
    public class BlockchainFactory : IBlockchainFactory
    {
        private readonly IApplicationCredentialsRepository _applicationCredentialsRepository;
        private readonly ICryptographyService _cryptographyService;

        public BlockchainFactory(IApplicationCredentialsRepository applicationCredentialsRepository, ICryptographyService cryptographyService)
        {
            _applicationCredentialsRepository = applicationCredentialsRepository;
            _cryptographyService = cryptographyService;
        }

        public async Task<IBlockchainService> CreateAsync(Guid blockchainId, Guid applicationId)
        {
            var credentials = await _applicationCredentialsRepository.GetApplicationCredentialsAsync(applicationId, blockchainId);

            if (credentials is null)
                throw new ArgumentNullException(nameof(credentials));

            switch (blockchainId.ToString())
            {
                case Blockchains.BlockchainFue:
                    return new BlockchainFueService(credentials, _cryptographyService);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
