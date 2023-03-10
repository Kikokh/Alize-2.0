using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Api.Responses.Applications;
using Alize.Platform.Core.Constants;
using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Extensions;
using Alize.Platform.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        private readonly IBlockchainFactory _blockchainFactory;
        private readonly IMapper _mapper;
        private readonly ICosmosRepositoryFactory _templateRepositoryFactory;
        private readonly IWebHostEnvironment _environment;

        public ApplicationsController(
            IApplicationRepository applicationRepository, 
            ISecurityService securityService,
            IBlockchainFactory blockchainFactory,
            IMapper mapper,
            ICosmosRepositoryFactory templateRepositoryFactory,
            IWebHostEnvironment environment)
        {
            _applicationRepository = applicationRepository;
            _securityService = securityService;
            _blockchainFactory = blockchainFactory;
            _mapper = mapper;
            _templateRepositoryFactory = templateRepositoryFactory;
            _environment = environment;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        [AllowAnonymous]
        [Authorize(Policy = Modules.Queries)]
        [ProducesResponseType(typeof(IEnumerable<ApplicationResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            if (User.Identity is null || !User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.GetUserId();
            var apps = await _applicationRepository.GetApplicationsForUserAsync(userId);

            return Ok(_mapper.Map<IEnumerable<ApplicationResponse>>(apps));
        }

        // GET api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (User.Identity is null || !User.Identity.IsAuthenticated)
                return Unauthorized();

            var userId = User.GetUserId();
            var app = await _applicationRepository.GetApplicationForUserAsync(userId, id);

            if (app is null)
                return NotFound();

            return Ok(_mapper.Map<ApplicationResponse>(app));
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        [ProducesResponseType(typeof(ApplicationResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateApplicationRequest request)
        {
            var user = await _securityService.GetUserAsync(User.GetUserId());

            if (user is null)
                return Unauthorized();

            var newApp = _mapper.Map<Application>(request);
            newApp.CompanyId = user.CompanyId;

            await _applicationRepository.AddApplicationAsync(newApp);

            if(!_environment.IsDevelopment())
            {
                try
                {
                    var service = _blockchainFactory.Resolve(request.BlockchainId);
                    await service.CreateApplicationAsync(newApp);

                    await _templateRepositoryFactory.CreateApplicationContainerAsync(newApp.Id);

                }
                catch (Exception)
                {
                    await _applicationRepository.DeleteApplicationAsync(newApp);
                    return UnprocessableEntity();
                }
            }

            return CreatedAtAction(nameof(Get), new { id = newApp.Id }, _mapper.Map<ApplicationResponse>(newApp));
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

            var userId = User.GetUserId();
            var app = await _applicationRepository.GetApplicationForUserAsync(userId, id);

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
            var userId = User.GetUserId();
            var app = await _applicationRepository.GetApplicationForUserAsync(userId, id);

            if (app is null) 
                return NotFound();

            await _applicationRepository.DeleteApplicationAsync(app);

            return NoContent();
        }

        [HttpPost("{id}/Users")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GrantApplicationAccess(Guid id, IEnumerable<SetApplicationAccessRequest> accessRequests)
        {
            foreach (var request in accessRequests)
            {
                await _applicationRepository.SetUserApplicationAccessAsync(id, request.UserId, request.CanAccess);
            }

            return NoContent();
        }
    }
}
