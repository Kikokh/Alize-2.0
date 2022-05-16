using Alize.Platform.Api.Responses.Assets;
using Alize.Platform.Data.Constants;
using Alize.Platform.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/Blockchain/{blockchainId}/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Queries)]
    public class QueriesController : ControllerBase
    {
        private readonly IBlockchainFactory _blockchainFactory;
        private readonly IMapper _mapper;

        public QueriesController(IBlockchainFactory blockchainFactory, IMapper mapper)
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
    }
}
