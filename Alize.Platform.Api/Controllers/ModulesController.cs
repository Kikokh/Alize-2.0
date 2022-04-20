using Alize.Platform.Data.Models;
using Alize.Platform.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;

        public ModulesController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Module>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var modules = await _moduleRepository.GetModulesAsync();

            return Ok(modules);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Module), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var module = await _moduleRepository.GetModuleAsync(id);

            if (module is null)
                return NotFound();

            return Ok(module);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody] Module module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }

            if (await _moduleRepository.GetModuleAsync(id) is null)
                return NotFound();

            await _moduleRepository.UpdateModuleAsync(module);

            return NoContent();
        }
    }
}
