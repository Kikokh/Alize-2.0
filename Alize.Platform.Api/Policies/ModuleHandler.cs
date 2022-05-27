using Alize.Platform.Core.Models;
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
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userRoleName = context.User.Claims.Single(c => c.Type == ClaimTypes.Role).Value;
                var userRole = await _roleManager.Roles
                    .Include(r => r.Modules)
                    .SingleAsync(r => userRoleName == r.Name);

                if (userRole.Modules.Any(m => m.Name == requirement.Module && m.IsActive))
                    context.Succeed(requirement);
                else
                    context.Fail();
            }
            else
            {
                context.Fail();
            }
        }
    }
}
