using ClientManagementService.IRepositories;
using ClientManagementService.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(
            DatabaseContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
