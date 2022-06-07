using Microsoft.AspNetCore.Authorization;

namespace Alize.Platform.Api.Policies
{
    public class ModuleRequirement : IAuthorizationRequirement
    {
        public ModuleRequirement(string module) => Module = module;

        public string Module { get; }
    }
}
