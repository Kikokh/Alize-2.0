using Alize.Platform.Api.Responses.Assets;
using Alize.Platform.Core.Constants;
using Alize.Platform.Infrastructure;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/Blockchain/{blockchainId}/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Queries)]
    public class AssetsController : ControllerBase
    {
        private readonly IBlockchainFactory _blockchainFactory;
        private readonly IMapper _mapper;

        public AssetsController(IBlockchainFactory blockchainFactory, IMapper mapper)
        {
            _blockchainFactory = blockchainFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid applicationId, Guid blockchainId, int? pageNumber = default, int? pageSize = default, bool isInverse = false)
        {
            var service = await _blockchainFactory.CreateAsync(blockchainId, applicationId);

            if (service is null)
                return NotFound();

            var assets = await service.GetAssetsAsync(pageNumber, pageSize, isInverse);

            return Ok(_mapper.Map<IEnumerable<AssetResponse>>(assets));
        }

        [HttpGet("{assetId}")]
        public async Task<IActionResult> Get(Guid applicationId, Guid blockchainId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(blockchainId, applicationId);

            if (service is null)
                return NotFound();            

            var asset = await service.GetAssetAsync(assetId);

            return Ok(_mapper.Map<AssetResponse>(asset));
        }

        [HttpGet("{assetId}/History")]
        public async Task<IActionResult> GetHistory(Guid applicationId, Guid blockchainId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(blockchainId, applicationId);

            if (service is null)
                return NotFound();

            var assetHistory = await service.GetAssetHistoryAsync(assetId);

            return Ok(assetHistory);
        }


        //[HttpPost]
        //public async Task<IActionResult> Post(Guid applicationId, Guid blockchainId, Asset asset)
        //{
        //    var result = await _cosmosDbService.AddItemAsync(asset, asset.Id);

        //    return CreatedAtAction(nameof(Get), new { applicationId, blockchainId, assetId = result.Id }, result);
        //}
    }
}
