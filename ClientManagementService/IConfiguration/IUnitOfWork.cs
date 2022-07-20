using ClientManagementService.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService
{
    public interface IUnitOfWork
    {
        public IBranchRepository Branches { get; }
        public IBranchStaffRepository BranchStaffs { get; }
        public IClientRepository Clients { get; }
        public ICurrencyRepository Currencies { get; }
        public IProductCategoryRepository ProductCategories { get; }
        public IProductRepository Products { get; }
        public IDiscountConfigRepository DiscountConfigs { get; }
        public IProductPriceRepository ProductPrices { get; }
        public IOfferRepository Offers { get; }
        public IOfferItemRepository OfferItems { get; }
        public IOrderRepository Orders { get; }
        public IOrderItemRepository OrderItems { get; }
        Task CompleteAsync();
    }
}
