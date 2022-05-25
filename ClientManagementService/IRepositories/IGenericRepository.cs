using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetByID(int Id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int Id);
        Task<bool> Update(T entity);
    }
}
