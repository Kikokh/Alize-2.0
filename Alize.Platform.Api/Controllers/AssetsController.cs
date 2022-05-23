using Alize.Platform.Api.Responses.Assets;
using Alize.Platform.Core.Constants;
using Alize.Platform.Infrastructure;
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
        private readonly IMapper _mapper;

        public AssetsController(IBlockchainFactory blockchainFactory, IMapper mapper)
        {
            _blockchainFactory = blockchainFactory;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid applicationId, [FromQuery] Dictionary<string, string> queries, int pageSize = 10, int pageNumber = 1)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

            if (service is null)
                return NotFound();

            var assets = await service.GetAssetsAsync(queries, pageSize, pageNumber);

            return Ok(_mapper.Map<IEnumerable<AssetResponse>>(assets));
        }

        [HttpGet("{assetId}")]
        public async Task<IActionResult> Get(Guid applicationId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

            if (service is null)
                return NotFound();            

            var asset = await service.GetAssetAsync(assetId);

            return Ok(_mapper.Map<AssetResponse>(asset));
        }

        [HttpGet("{assetId}/History")]
        public async Task<IActionResult> GetHistory(Guid applicationId, string assetId)
        {
            var service = await _blockchainFactory.CreateAsync(Guid.Parse(Blockchains.BlockchainFue), applicationId);

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
