using ClientManagementService.Data;
using ClientManagementService.IRepositories;
using ClientManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Repositories
{
    public class ProductPriceRepository : GenericRepository<ProductPrice>, IProductPriceRepository
    {
        public ProductPriceRepository(DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<ProductPrice>> All()
        {
            try
            {
                return await _dbSet.Include(i=>i.Currency).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ProductPriceRepository));
                return new List<ProductPrice>();
            }
        }

        public override async Task<ProductPrice> GetByID(int Id)
        {
            try
            {
                return await _context.ProductPrices.Include(i => i.Currency).FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ProductPrice));
                return new ProductPrice();
            }
        }

        public override async Task<bool> Delete(int Id)
        {
            try
            {
                var exist = await _dbSet.Where(o => o.Id == Id)
                                        .SingleOrDefaultAsync();

                if (exist != null)
                {
                    _dbSet.Remove(exist);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(ProductPriceRepository));
                return false;
            }
        }

        public override async Task<bool> Update(ProductPrice entity)
        {
            try
            {
                var existingPrice = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingPrice == null)
                    return false;
                existingPrice.ProductId = entity.ProductId;
                existingPrice.CurrencyId = entity.CurrencyId;
                existingPrice.UnitPrice = entity.UnitPrice;
                existingPrice.GSTApplicable = entity.GSTApplicable;
                existingPrice.IsActive = entity.IsActive;
                existingPrice.ActivationDate = entity.ActivationDate;
                existingPrice.StopDate = entity.StopDate;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(ProductRepository));
                return false;
            }
        }
    }
}
