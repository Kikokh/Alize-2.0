using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Repositories;
using Alize.Platform.Services.BlockchainFue;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alize.Platform.Services
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
