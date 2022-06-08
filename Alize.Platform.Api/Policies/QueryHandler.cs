using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Alize.Platform.Api.Policies
{
    public class QueryHandler : AuthorizationHandler<QueryRequirement>
    {
        private readonly ISecurityService _securityService;
        private readonly RoleManager<Role> _roleManager;

        public QueryHandler(RoleManager<Role> roleManager, ISecurityService securityService)
        {
            _securityService = securityService;
            _roleManager = roleManager;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, QueryRequirement requirement)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userRoleName = context.User.Claims.Single(c => c.Type == ClaimTypes.Role).Value;
                var userRole = await _roleManager.Roles
                    .Include(r => r.Modules)
                    .SingleAsync(r => userRoleName == r.Name);

                if (userRole.Modules.Any(m => m.Name == requirement.Module && m.IsActive))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var user = await _securityService.GetUserAsync(context.User.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);
                    var applicationId = (context.Resource as DefaultHttpContext)
                        .Request
                        .RouteValues["applicationId"] as string;

                    if (user.Applications.Any(a => string.Equals(applicationId, a.Id.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                        context.Succeed(requirement);
                    else
                        context.Fail();
                }
            }
            else
            {
                context.Fail();
            }
        }
    }
}
