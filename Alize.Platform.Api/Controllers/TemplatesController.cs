using Alize.Platform.Api.Responses.Templates;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/Applications/{applicationId}/[controller]")]
    [ApiController]
    [Authorize]
    public class TemplatesController : ControllerBase
    {
        private readonly ITemplateRespository _templateRespository;
        private readonly IMapper _mapper;

        public TemplatesController(ITemplateRespository templateRespository, IMapper mapper)
        {
            _templateRespository = templateRespository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplate(Guid applicationId)
        {
            var template = await _templateRespository.GetApplicationTemplateAsync(applicationId);

            return Ok(_mapper.Map<ApplicationTemplateResponse>(template));
        }

        [HttpGet("Asset")]
        public async Task<IActionResult> GetAssetTemplate(Guid applicationId)
        {
            var template = await _templateRespository.GetApplicationAssetTemplateAsync(applicationId);

            return Ok(_mapper.Map<ApplicationAssetTemplateResponse>(template));
        }
    }
}
