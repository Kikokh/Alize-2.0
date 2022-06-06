using Alize.Platform.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Alize.Platform.Infrastructure.Repositories
{
    public class RequestLogEntryRepository : IRequestLogEntryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RequestLogEntryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RequestLogEntry> AddRequestLogEntryAsync(RequestLogEntry requestLogEntry)
        {
            await _dbContext.RequestLogsEntries.AddAsync(requestLogEntry);
            await _dbContext.SaveChangesAsync();
            return requestLogEntry;
        }

        public async Task<IEnumerable<RequestLogEntry>> GetRequestLogEntriesAsync(DateTime dateFrom)
        {
            var logEntries = await _dbContext.RequestLogsEntries.Where(x => x.CreationDate >= dateFrom).ToListAsync();

            return logEntries;
        }
    }
}
