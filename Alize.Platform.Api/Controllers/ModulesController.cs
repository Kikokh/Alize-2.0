using Alize.Platform.Api.Requests.Modules;
using Alize.Platform.Api.Responses.Modules;
using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize(Policy = Modules.ModuleAdmin)]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModulesController(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModuleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var modules = await _moduleRepository.GetModulesAsync();

            return Ok(_mapper.Map<IEnumerable<ModuleResponse>>(modules));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ModuleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var module = await _moduleRepository.GetModuleAsync(id);

            return module is null ? NotFound() : Ok(_mapper.Map<ModuleResponse>(module));
        }

        
        [HttpPost]
        [ProducesResponseType(typeof(ModuleResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateModuleRequest request)
        {
            var module = await _moduleRepository.AddModuleAsync(_mapper.Map<Module>(request));

            return CreatedAtAction(nameof(Get), new { id = module.Id }, _mapper.Map<ModuleResponse>(module));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateModuleRequest request)
        {
            if (id != request.Id) return BadRequest();
          
            if (await _moduleRepository.GetModuleAsync(id) is null) return NotFound();

            await _moduleRepository.UpdateModuleAsync(_mapper.Map<Module>(request));

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var module = await _moduleRepository.GetModuleAsync(id);

            if (module is null) return NotFound();

            await _moduleRepository.DeleteModuleAsync(module);

            return NoContent();
        }
    }
}
