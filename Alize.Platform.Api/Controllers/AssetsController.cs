using Alize.Platform.Api.Requests.Assets;
using Alize.Platform.Api.Responses.Assets;
using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Queries)]
    public class AssetsController : ControllerBase
    {
        private readonly IBlockchainFactory _blockchainFactory;
        private readonly ICosmosRepositoryFactory _cosmosRepositoryFactory;
        private readonly IMapper _mapper;

        public AssetsController(IBlockchainFactory blockchainFactory, ICosmosRepositoryFactory cosmosRepositoryFactory, IMapper mapper)
        {
            _blockchainFactory = blockchainFactory;
            _cosmosRepositoryFactory = cosmosRepositoryFactory;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(AssetsPageResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid applicationId, [FromQuery] Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

            if (service is null)
                return NotFound();

            var assets = await service.GetAssetsPageAsync(queries, pageSize, pageNumber);

            return Ok(_mapper.Map<AssetsPageResponse>(assets));
        }

        [HttpGet("{assetId}")]
        [ProducesResponseType(typeof(AssetResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid applicationId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

            if (service is null)
                return NotFound();

            var asset = await service.GetAssetAsync(assetId);

            return Ok(_mapper.Map<AssetResponse>(asset));
        }

        [HttpGet("{assetId}/History")]
        [ProducesResponseType(typeof(IEnumerable<AssetHistoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHistory(Guid applicationId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

            if (service is null)
                return NotFound();

            var assetHistory = await service.GetAssetHistoryAsync(assetId);

            return Ok(_mapper.Map<IEnumerable<AssetHistoryResponse>>(assetHistory));
        }


        [HttpPost]
        [ProducesResponseType(typeof(AssetResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post(Guid applicationId, CreateAssetRequest createAssetRequest)
        {
            if (createAssetRequest.ApplicationId != applicationId)
                return BadRequest();

            var asset = _mapper.Map<Asset>(createAssetRequest);

            await _cosmosRepositoryFactory
                .GetAssetRepository(applicationId)
                .CreateAssetAsync(asset);

            return CreatedAtAction(nameof(Get), new { applicationId, assetId = asset.Id }, asset);
        }
    }
}
