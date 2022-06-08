using Microsoft.AspNetCore.Authorization;

namespace Alize.Platform.Api.Policies
{
    public class QueryRequirement : IAuthorizationRequirement
    {
        public QueryRequirement(string module) => Module = module;

        public string Module { get; set; }
    }
}
