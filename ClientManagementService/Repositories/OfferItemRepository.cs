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
    public class OfferItemRepository : GenericRepository<OfferItem>, IOfferItemRepository
    {
        public OfferItemRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public override async Task<IEnumerable<OfferItem>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.Product).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OfferItemRepository));
                return new List<OfferItem>();
            }
        }

        public override async Task<OfferItem> GetByID(int Id)
        {
            try
            {
                return await _context.OfferItems.Include(i => i.Product)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OfferItemRepository));
                return new OfferItem();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(OfferItemRepository));
                return false;
            }
        }

        public override async Task<bool> Update(OfferItem entity)
        {
            try
            {
                var existingOfferItem = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingOfferItem == null)
                    return false;
                existingOfferItem.OfferId = entity.OfferId;
                existingOfferItem.ProductId = entity.ProductId;
                existingOfferItem.Quantity = entity.Quantity;
                existingOfferItem.UnitPrice = entity.UnitPrice;
                existingOfferItem.IsTaxApplied = entity.IsTaxApplied;
                existingOfferItem.TaxAmount = entity.TaxAmount;
                existingOfferItem.IsDiscountApplied = entity.IsDiscountApplied;
                existingOfferItem.DiscountAmount = entity.DiscountAmount;
                existingOfferItem.OriginalProductCost = entity.OriginalProductCost;
                existingOfferItem.ItemWeight = entity.ItemWeight;
                existingOfferItem.Comment = entity.Comment;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(OfferItemRepository));
                return false;
            }
        }
    }
}
