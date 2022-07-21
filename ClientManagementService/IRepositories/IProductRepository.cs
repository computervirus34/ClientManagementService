using ClientManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByCategory(int category);
        //Task<Product> GetPriceByClient(int Id, int client);
        Task<ProductPriceCalculationModel> GetProductPrice(int prodcutId, int quantity, int clientId);
    }
}
