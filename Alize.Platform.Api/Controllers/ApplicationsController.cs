using Alize.Platform.Api.Requests.Applications;
using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        // GET: api/<ApplicationsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var apps = await _applicationRepository.GetApplicationsAsync();

            return Ok(apps);
        }

        // GET api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var app = await _applicationRepository.GetApplicationAsync(id);

            if (app is null)
                return NotFound();

            return Ok(app);
        }

        // POST api/<ApplicationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateApplicationRequest request)
        {

            var app = await _applicationRepository.AddApplicationAsync(_mapper.Map<Application>(request));

            return CreatedAtAction(nameof(Get), new { id = app.Id }, app);
        }

        // PUT api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Application application)
        {
            if (id != application.Id)
            {
                return BadRequest();
            }

            await _applicationRepository.UpdateApplicationAsync(application);

            return NoContent();
        }

        // DELETE api/<ApplicationsController>/4B900A74-E2D9-4837-B9A4-9E828752716E
        [HttpDelete("{id}")]
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
