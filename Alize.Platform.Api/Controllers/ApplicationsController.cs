using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Applications)]
    [Produces("application/json")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationRepository applicationRepository, ISecurityService securityService, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _securityService = securityService;
            _mapper = mapper;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ApplicationResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var user = await _securityService.GetUserAsync(User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);

            if (user == null)
                return NotFound();

            var apps = await _applicationRepository.GetApplicationsForUserAsync(user);

            return Ok(_mapper.Map<IEnumerable<ApplicationResponse>>(apps));
        }

        // GET api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var app = await _applicationRepository.GetApplicationAsync(id);

            if (app is null)
                return NotFound();

            return Ok(_mapper.Map<ApplicationResponse>(app));
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateApplicationRequest request)
        {

            var app = await _applicationRepository.AddApplicationAsync(_mapper.Map<Application>(request));

            return CreatedAtAction(nameof(Get), new { id = app.Id }, _mapper.Map<ApplicationResponse>(app));
        }

        // PUT api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateApplicationRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            var app = await _applicationRepository.GetApplicationAsync(id);

            if (app is null)
                return NotFound();

            await _applicationRepository.UpdateApplicationAsync(_mapper.Map(request, app));

            return NoContent();
        }

        // DELETE api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var app = await _applicationRepository.GetApplicationAsync(id);

            if (app is null) 
                return NotFound();

            await _applicationRepository.DeleteApplicationAsync(app);

            return NoContent();
        }
    }
}
