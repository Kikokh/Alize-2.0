using Alize.Platform.Data.Repositories;
using Alize.Platform.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/[controller]")]
    [ApiController]
    [Authorize]
    public class AssetsController : ControllerBase
    {
        private readonly IBlockChainService _libraryService;
        private readonly IApplicationRepository _applicationRepository;

        public AssetsController(IBlockChainService libraryService, IApplicationRepository applicationRepository)
        {
            _libraryService = libraryService;
            _applicationRepository = applicationRepository;
        }

        [HttpGet("{assetId}")]
        public async Task<IActionResult> Get(Guid applicationId, Guid assetId)
        {
            var app = await _applicationRepository.GetApplicationAsync(applicationId);
            var asset = await _libraryService.GetAssetAsync(app, assetId);

            return Ok(asset);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid applicationId, string content)
        {
            var app = await _applicationRepository.GetApplicationAsync(applicationId);
            var asset = await _libraryService.CreateAssetAsync(app, content);

            return CreatedAtAction(nameof(Get), new { assetId = asset.Id }, asset);
        }
    }
}
