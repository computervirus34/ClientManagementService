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
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public override async Task<IEnumerable<OrderItem>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.Product).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderItemRepository));
                return new List<OrderItem>();
            }
        }

        public override async Task<OrderItem> GetByID(int Id)
        {
            try
            {
                return await _context.OrderItems.Include(i => i.Product)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(OrderItemRepository));
                return new OrderItem();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(OrderItemRepository));
                return false;
            }
        }

        public override async Task<bool> Update(OrderItem entity)
        {
            try
            {
                var existingOrderItem = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingOrderItem == null)
                    return false;
                existingOrderItem.OrderId = entity.OrderId;
                existingOrderItem.ProductId = entity.ProductId;
                existingOrderItem.Quantity = entity.Quantity;
                existingOrderItem.UnitPrice = entity.UnitPrice;
                existingOrderItem.IsTaxApplied = entity.IsTaxApplied;
                existingOrderItem.TaxAmount = entity.TaxAmount;
                existingOrderItem.IsDiscountApplied = entity.IsDiscountApplied;
                existingOrderItem.DiscountAmount = entity.DiscountAmount;
                existingOrderItem.OriginalProductCost = entity.OriginalProductCost;
                existingOrderItem.ItemWeight = entity.ItemWeight;
                existingOrderItem.Comment = entity.Comment;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(OrderItemRepository));
                return false;
            }
        }
    }
}
