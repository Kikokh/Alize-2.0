using System.Security.Claims;

namespace Alize.Platform.Infrastructure.Extensions
{
    public static class HttpExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);
        }

        public static bool IsAuthenticated(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Identity?.IsAuthenticated ?? false;
        }
    }
}
