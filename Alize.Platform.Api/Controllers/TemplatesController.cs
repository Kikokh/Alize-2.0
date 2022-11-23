using Alize.Platform.Api.Requests.Templates;
using Alize.Platform.Api.Responses.Templates;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/[controller]")]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Authorize]
    public class TemplatesController : ControllerBase
    {
        private readonly ICosmosRepositoryFactory _templateRepositoryFactory;
        private readonly IMapper _mapper;

        public TemplatesController(ICosmosRepositoryFactory templateRepositoryFactory, IMapper mapper)
        {
            _templateRepositoryFactory = templateRepositoryFactory;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApplicationTemplateResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTemplate(Guid applicationId)
        {
            var repository = _templateRepositoryFactory.GetApplicationTemplateRepository(applicationId);
            var template = await repository.GetApplicationTemplateAsync();

            if (template is null)
                return NotFound();

            return Ok(_mapper.Map<ApplicationTemplateResponse>(template));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApplicationTemplateResponse), StatusCodes.Status201Created)]

        public async Task<IActionResult> CreateTemplate(Guid applicationId, CreateTemplateRequest createTemplateRequest)
        {
            var template = _mapper.Map<ApplicationTemplate>(createTemplateRequest);
            var repository = _templateRepositoryFactory.GetApplicationTemplateRepository(applicationId);
            await repository.CreateApplicationTemplateAsync(template);

            return CreatedAtAction(nameof(GetTemplate), new { applicationId }, _mapper.Map<ApplicationTemplateResponse>(template));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> DeleteTemplate(Guid applicationId)
        {
            var repository = _templateRepositoryFactory.GetApplicationTemplateRepository(applicationId);
            var template = await repository.GetApplicationTemplateAsync();

            if (template is null)
                return NotFound();

            await repository.DeleteApplicationTemplateAsync();

            return NoContent();
        }

        [HttpGet("Asset")]
        [ProducesResponseType(typeof(AssetTemplateResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAssetTemplate(Guid applicationId)
        {
            var repository = _templateRepositoryFactory.GetIAssetTemplateRepository(applicationId);
            var template = await repository.GetAssetTemplateAsync();

            return Ok(_mapper.Map<AssetTemplateResponse>(template));
        }

        [HttpPost("Asset")]
        [ProducesResponseType(typeof(AssetTemplateResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAssetTemplate(Guid applicationId, CreateAssetTemplateRequest createAssetTemplateRequest)
        {
            var template = _mapper.Map<AssetTemplate>(createAssetTemplateRequest);
            var repository = _templateRepositoryFactory.GetIAssetTemplateRepository(applicationId);
            await repository.CreateAssetTemplateAsync(template);

            return CreatedAtAction(nameof(CreateAssetTemplate), new { applicationId }, _mapper.Map<AssetTemplateResponse>(template));
        }

        [HttpDelete("Asset")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> DeleteAssetTemplate(Guid applicationId)
        {
            var repository = _templateRepositoryFactory.GetIAssetTemplateRepository(applicationId);
            var template = await repository.GetAssetTemplateAsync();

            if (template is null)
                return NotFound();

            await repository.DeleteAssetTemplateAsync();

            return NoContent();
        }

        /// <summary>
        /// ONLY FOR DEVELOPMENT PURPOSES
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns>A new <see cref="ApplicationRepository"/> for the application.</returns>
        [HttpPost("MANUALLY_CREATE")]
        [ProducesResponseType(typeof(ApplicationRepository), StatusCodes.Status200OK)]

        public async Task<IActionResult> CreateTemplateRepository(Guid applicationId)
        {
            var repository = await _templateRepositoryFactory.CreateApplicationContainerAsync(applicationId);

            return Ok(repository);
        }
    }
}
