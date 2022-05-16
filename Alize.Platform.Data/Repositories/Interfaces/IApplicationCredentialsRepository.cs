using Alize.Platform.Data.Models;

namespace Alize.Platform.Data.Repositories
{
    public interface IApplicationCredentialsRepository
    {
        Task<ApplicationCredentials?> GetApplicationCredentialsAsync(Guid applicationId, Guid blockchainId);
    }
}