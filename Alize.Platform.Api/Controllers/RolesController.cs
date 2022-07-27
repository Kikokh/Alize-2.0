using Alize.Platform.Api.Responses.Roles;
using Alize.Platform.Core.Constants;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    [Authorize(Policy = Modules.Roles)]
    public class RolesController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;

        public RolesController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }

        [HttpGet("all")]
        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _securityService.GetRolesAsync();

            return Ok(_mapper.Map<IEnumerable<RoleResponse>>(roles));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var roles = await _securityService.GetRolesForUserAsync(User.GetUserId());

            return Ok(_mapper.Map<IEnumerable<RoleResponse>>(roles));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            var role = await _securityService.GetRoleAsync(id);

            return role is null ? NotFound() : Ok(_mapper.Map<RoleResponse>(role));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(Guid id, bool enabled)
        {
            var role = await _securityService.GetRoleAsync(id);

            if (role is null) 
                return NotFound();

            var currentRole = User.GetUserRole();

            if (!_securityService.VerifyRolePermit(currentRole, role.Name))
                return Forbid();

            role.IsActive = enabled;
            await _securityService.UpdateRoleAsync(role); 
            return NoContent();
        }
    }
}
