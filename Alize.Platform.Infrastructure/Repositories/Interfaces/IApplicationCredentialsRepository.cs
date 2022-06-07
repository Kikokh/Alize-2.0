using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IApplicationCredentialsRepository
    {
        Task<ApplicationCredentials?> GetApplicationCredentialsAsync(Guid applicationId, Guid blockchainId);
    }
}