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
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        public OfferRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Offer>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.OfferItems).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OfferRepository));
                return new List<Offer>();
            }
        }

        public override async Task<Offer> GetByID(int Id)
        {
            try
            {
                return await _context.Offers.Include(i => i.OfferItems)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OfferRepository));
                return new Offer();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(OfferRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Offer entity)
        {
            try
            {
                var existingOffer = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingOffer == null)
                    return false;
                existingOffer.ClientID = entity.ClientID;
                //existingOffer.BranchId = entity.BranchId;
                existingOffer.OfferDate = entity.OfferDate;
                existingOffer.Description = entity.Description;
                existingOffer.CustomerCurrency = entity.CustomerCurrency;
                existingOffer.OfferTotal = entity.OfferTotal;
                existingOffer.OfferTax = entity.OfferTax;
                existingOffer.OfferDiscount = entity.OfferDiscount;
                existingOffer.CreatedBy = entity.CreatedBy;
                existingOffer.OriginalOfferTotal = entity.OriginalOfferTotal;
                existingOffer.Comment = entity.Comment;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(OfferRepository));
                return false;
            }
        }
        
        public async Task<bool> UpdateOfferPurchaseDate(int id, DateTime date)
        {
            try
            {

                var existingOffer = await _dbSet.Where(o => o.Id == id)
                                     .SingleOrDefaultAsync();
                if (existingOffer == null)
                    return false;
                existingOffer.PurchaseDate = date;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(OfferRepository));
                return false;
            }
        }
    }
}
