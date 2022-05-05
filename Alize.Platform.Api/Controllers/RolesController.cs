using Alize.Platform.Api.Responses.Roles;
using Alize.Platform.Data.Constants;
using Alize.Platform.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Modules.Groups)]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;

        public RolesController(RoleManager<Role> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<RoleResponse>>(roles));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var role = await _roleManager.Roles.SingleOrDefaultAsync(r => r.Id == id);

            return role is null ? NotFound() : Ok(_mapper.Map<RoleResponse>(role));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, bool enabled)
        {
            var role = await _roleManager.Roles.SingleOrDefaultAsync(r => r.Id == id);

            if (role is null) 
                return NotFound();

            role.IsActive = enabled;

            await _roleManager.UpdateAsync(role);

            return NoContent();
        }
    }
}
