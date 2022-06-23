using Alize.Platform.Core.Models;
using Alize.Platform.Infrastructure;
using Alize.Platform.Infrastructure.Extensions;
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
            var httpContext = (context.Resource as DefaultHttpContext);

            if (httpContext is not null && context.User.IsAuthenticated())
            {
                var user = await _securityService.GetUserAsync(context.User.GetUserId());

                if (user?.Role?.Modules.Any(m => m.Name == requirement.Module && m.IsActive) ?? false)
                {
                    context.Succeed(requirement);
                }
                else
                {
                    var applicationId = httpContext
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
