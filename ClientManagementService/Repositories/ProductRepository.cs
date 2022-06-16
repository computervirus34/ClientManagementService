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
                return await _dbSet.Include(i => i.ProductPrices).ToListAsync();
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
                return await _context.Products.Include(i => i.ProductPrices)
                    .FirstOrDefaultAsync(i => i.Id == Id);
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
                existingProduct.AvailableQuantity = entity.AvailableQuantity;
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

        //public async Task<Product> GetByClientAndCategory(int client, int category)
        //{
        //    try
        //    {
        //        return await _context.Products.Include(i => i.ProductPrices).FirstOrDefaultAsync(i => i.Id == Id);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} All method error.", typeof(ProductRepository));
        //        return new Product();
        //    }
        //}
    }
}
