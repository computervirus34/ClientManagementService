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
        public IProductCategoryRepository ProductCategories { get; set; }
        public IProductRepository Products { get; set; }
        public IDiscountConfigRepository DiscountConfigs { get; set; }
        public IProductPriceRepository ProductPrices { get; set; }
        public IOfferRepository Offers { get; set; }
        public IOfferItemRepository OfferItems { get; set; }
        public IOrderRepository Orders { get; set; }
        public IOrderItemRepository OrderItems { get; set; }
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
            ProductCategories = new ProductCategoryRepository(_context, _logger);
            DiscountConfigs = new DiscountConfigRepository(_context, _logger);
            Products = new ProductRepository(_context, _logger);
            ProductPrices = new ProductPriceRepository(_context, _logger);
            Offers = new OfferRepository(_context, _logger);
            OfferItems = new OfferItemRepository(_context, _logger);
            Orders = new OrderRepository(_context, _logger);
            OrderItems = new OrderItemRepository(_context, _logger);
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
