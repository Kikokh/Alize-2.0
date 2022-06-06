using Alize.Platform.Core.Models;

namespace Alize.Platform.Infrastructure.Repositories
{
    public interface IRequestLogEntryRepository
    {
        Task<RequestLogEntry> AddRequestLogEntryAsync(RequestLogEntry requestLogEntry);
        Task<IEnumerable<RequestLogEntry>> GetRequestLogEntriesAsync(DateTime dateFrom);
    }
}
