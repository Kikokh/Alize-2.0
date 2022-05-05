using Alize.Platform.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Alize.Platform.Api.Policies
{
    public class ModuleHandler : AuthorizationHandler<ModuleRequirement>
    {
        private readonly RoleManager<Role> _roleManager;

        public ModuleHandler(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ModuleRequirement requirement)
        {
            var roleNames = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            var userModules = await _roleManager.Roles.Where(r => roleNames.Contains(r.Name)).SelectMany(r => r.Modules).ToListAsync();

            if (userModules.Any(m => m.Name == requirement.Module))
                context.Succeed(requirement);
            else
                context.Fail();
        }
    }
}
