using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure
{
    public interface IZendeskService
    {
        Task CreateZendeskUserAsync(User user);
    }
}