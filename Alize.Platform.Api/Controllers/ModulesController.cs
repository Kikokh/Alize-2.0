using Alize.Platform.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;

        public ModulesController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var modules = await _moduleRepository.GetModulesAsync();

            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var module = await _moduleRepository.GetModuleAsync(id);

            if (module is null)
                return NotFound();

            return Ok(module);
        }
    }
}
