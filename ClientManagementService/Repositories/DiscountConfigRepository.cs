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
    public class DiscountConfigRepository : GenericRepository<DiscountRateConfig>, IDiscountConfigRepository
    {
        public DiscountConfigRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<DiscountRateConfig>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.ProductCategory)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(DiscountConfigRepository));
                return new List<DiscountRateConfig>();
            }
        }

        public override async Task<DiscountRateConfig> GetByID(int Id)
        {
            try
            {
                return await _context.DiscountRates.Include(i => i.ProductCategory)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(DiscountConfigRepository));
                return new DiscountRateConfig();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(DiscountConfigRepository));
                return false;
            }
        }

        public override async Task<bool> Update(DiscountRateConfig entity)
        {
            try
            {
                var existingDiscount = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingDiscount == null)
                    return false;
                existingDiscount.ProductCategoryId = entity.ProductCategoryId;
                existingDiscount.LicenseType = entity.LicenseType;
                existingDiscount.SlabFrom = entity.SlabFrom;
                existingDiscount.SlabTo = entity.SlabTo;
                existingDiscount.IsActive = entity.IsActive;
                existingDiscount.DiscountRate = entity.DiscountRate;
                existingDiscount.UpdatedOn = DateTime.Now;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(DiscountConfigRepository));
                return false;
            }
        }
    }
}
