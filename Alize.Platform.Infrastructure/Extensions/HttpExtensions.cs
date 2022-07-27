using Newtonsoft.Json;
using System.Security.Claims;

namespace Alize.Platform.Infrastructure.Extensions
{
    public static class HttpExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.Sid).Value);
        }

        public static string GetUserRole(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.Single(c => c.Type == ClaimTypes.Role).Value;
        }

        public static bool IsAuthenticated(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Identity?.IsAuthenticated ?? false;
        }

        public static async Task<T> GetResult<T>(this HttpContent content)
        {
            var result = await content.ReadAsStringAsync();

            var item = JsonConvert.DeserializeObject<T>(result);

            if (item is null)
                throw new InvalidCastException();

            return item;
        }
    }
}
