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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Product>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.ProductPrices)
                    .Include(i=>i.CourseSchedules)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ProductRepository));
                return new List<Product>();
            }
        }

        public override async Task<Product> GetByID(int Id)
        {
            try
            {
                return await _dbSet.Include(i => i.ProductPrices)
                    .Include(i => i.CourseSchedules)
                    .FirstOrDefaultAsync(o => o.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ProductRepository));
                return new Product();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(ProductRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Product entity)
        {
            try
            {
                var existingProduct = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingProduct == null)
                    return false;
                existingProduct.Code = entity.Code;
                existingProduct.Name = entity.Name;
                existingProduct.ProductCategoryId = entity.ProductCategoryId;
                existingProduct.Type = entity.Type;
                existingProduct.Descripion = entity.Descripion;
                //existingProduct.AvailableQuantity = entity.AvailableQuantity;
                existingProduct.Duration = entity.Duration;
                existingProduct.IsLicenseProduct = entity.IsLicenseProduct;
                existingProduct.LicenseType = entity.LicenseType;
                existingProduct.ProtectionType = entity.ProtectionType;
                existingProduct.Comment = entity.Comment;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(ProductRepository));
                return false;
            }
        }

        public async Task<ProductPriceCalculationModel> GetProductPrice(int prodcutId, int quantity, int clientId)
        {
            decimal productCost = 0, productDiscount=0;
            var clientDet = await _context.Clients
                .Where(o => o.Id == clientId).FirstOrDefaultAsync();

            var productDetails = await _context.Products
                .Where(o=>o.Id==prodcutId).FirstOrDefaultAsync();

            var productPrice = await _context.ProductPrices.Where(o => o.ProductId == prodcutId
                && o.CurrencyId == clientDet.CurrencyId).FirstOrDefaultAsync();

            var previousPurchase = _context.Orders
                .SelectMany(orderItems => orderItems.OrderItems.Where(i=>i.ProductId==prodcutId))
                .Sum(orderItems => (int?)orderItems.Quantity) ?? 0;

            //var previousPurchase = await _context.Orders
            //    .Include(i => i.OrderItems.Where(i => i.ProductId == prodcutId))
            //    .Where(o => o.ClientID ==clientId)
            //    .Select(o=>o.OrderItems.Sum(i=>i.Quantity))
            //    .FirstOrDefaultAsync();

            if (productDetails.IsLicenseProduct)
            {
                var discountRates = await _context.DiscountRates
                    .Where(o => o.IsActive == "Y" && o.ProductCategoryId==productDetails.ProductCategoryId)
                    .OrderBy(o=>o.SlabFrom)
                    .ToListAsync();
                
                foreach(var rate in discountRates)
                {
                    if(quantity + previousPurchase >= rate.SlabFrom && quantity + previousPurchase <= rate.SlabTo)
                    {
                        productCost = (quantity * productPrice.UnitPrice * rate.DiscountRate)/100;
                        productDiscount = (quantity * productPrice.UnitPrice) - productCost;
                    }
                }
                return new ProductPriceCalculationModel { Quantity = quantity, DiscountAmount = productDiscount, ProductCost = productCost, GSTAmount = 0 };
            }
            else
            {
                if(productPrice.DiscountType=="P")
                {
                    productDiscount = (quantity * productPrice.UnitPrice * productPrice.Discount) / 100;
                    productCost = (quantity * productPrice.UnitPrice) - productDiscount;
                }
                else
                {
                    productDiscount = (quantity * productPrice.Discount);
                    productCost = (quantity * productPrice.UnitPrice) - productDiscount;
                }
                return new ProductPriceCalculationModel{ Quantity = quantity, DiscountAmount = productDiscount, ProductCost = productCost, GSTAmount = 0 };
            }
        }

        public async Task<IEnumerable<Product>> GetByCategory(int category)
        {
            try
            {
                return await _dbSet.Include(i => i.ProductPrices)
                        .Include(i => i.CourseSchedules)
                        .Where(o=>o.ProductCategoryId==category)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ProductRepository));
                return new List<Product>();
            }
        }
    }
}
