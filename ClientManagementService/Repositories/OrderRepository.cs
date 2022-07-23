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
    public class OrderRepository:GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Order>> All()
        {
            try
            {
                return await _dbSet
                    .Include(i => i.OrderItems)
                    .Include(i=>i.ProductAdditionalInfos)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderRepository));
                return new List<Order>();
            }
        }

        public override async Task<Order> GetByID(int Id)
        {
            try
            {
                return await _context.Orders
                    .Include(i => i.OrderItems)
                    .Include(i => i.ProductAdditionalInfos)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderRepository));
                return new Order();
            }
        }

        public async Task<IEnumerable<Order>> GetByClient(int id)
        {
            try
            {
                return await _dbSet
                    .Include(i => i.OrderItems)
                    .Include(i => i.ProductAdditionalInfos)
                    .Where(i => i.ClientID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderRepository));
                return new List<Order>();
            }
        }

        public async Task<IEnumerable<Order>> GetByClientAndCat(int id, int catId)
        {
            try
            {
                return await _dbSet
                    .Include(i => i.OrderItems.Where(o=>o.Product.ProductCategoryId==catId))
                    .Include(i => i.ProductAdditionalInfos)
                    .Where(i => i.ClientID == id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderRepository));
                return new List<Order>();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(OrderRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Order entity)
        {
            try
            {
                var existingOrder = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingOrder == null)
                    return false;
                existingOrder.ClientID = entity.ClientID;
                //existingOrder.BranchId = entity.BranchId;
                existingOrder.OrderDate = entity.OrderDate;
                existingOrder.Description = entity.Description;
                existingOrder.CustomerCurrency = entity.CustomerCurrency;
                existingOrder.OrderTotal = entity.OrderTotal;
                existingOrder.OrderTax = entity.OrderTax;
                existingOrder.OrderDiscount = entity.OrderDiscount;
                existingOrder.CreatedBy = entity.CreatedBy;
                existingOrder.OriginalOrderTotal = entity.OriginalOrderTotal;
                existingOrder.Comment = entity.Comment;
                existingOrder.IsFromOffer = entity.IsFromOffer;
                existingOrder.OfferId = entity.OfferId;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(OrderRepository));
                return false;
            }
        }
    }
}
