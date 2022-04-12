using Alize.Platform.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RolesController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //[HttpPost("Users/{userId}")]
        //[Authorize(Roles = Roles.Admin)]
        //public async Task<IActionResult> AddUserToRole(Guid userId,  Guid roleId)
        //{
        //    var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
        //    var role = await _roleManager.Roles.SingleOrDefaultAsync(r => r.Id == roleId);

        //    if (user is null || role is null)
        //        return NotFound();

        //    var result = await _userManager.AddToRoleAsync(user, role.Name);

        //    if (result.Succeeded)
        //        return NoContent();

        //    return BadRequest(result.Errors);
        //}

        //[HttpDelete("{roleId}")]
        //[Authorize(Roles = Roles.Admin)]
        //public async Task<IActionResult> RemoveUserFromRole(Guid userId, Guid roleId)
        //{
        //    var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
        //    var role = await _roleManager.Roles.SingleOrDefaultAsync(r => r.Id == roleId);

        //    if (user is null || role is null)
        //        return NotFound();

        //    await _userManager.RemoveFromRoleAsync(user, role.Name);

        //    return NoContent();
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(roles);
        }
    }
}
