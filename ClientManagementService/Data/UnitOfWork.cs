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
        public IBranchRepository Branches { get; private set; }
        public IBranchStaffRepository BranchStaffs { get; set; }
        public IClientRepository Clients { get; private set; }
        public ICurrencyRepository Currencies { get; set; }
        public IProductRepository Products { get; set; }
        public IProductPriceRepository ProductPrices { get; set; }
        public UnitOfWork(
            DatabaseContext context,
            ILoggerFactory loggerFactory
            )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");
            Branches = new BranchRepository(_context, _logger);
            BranchStaffs = new BranchStaffRepository(_context, _logger);
            Clients = new ClientRepository(_context, _logger);
            Currencies = new CurrencyRepository(_context, _logger);
            Products = new ProductRepository(_context, _logger);
            ProductPrices = new ProductPriceRepository(_context, _logger);
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
