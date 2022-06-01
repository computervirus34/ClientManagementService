using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagementService.Data;
using ClientManagementService.IRepositories;
using ClientManagementService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClientManagementService.Repositories
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {

        public CurrencyRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Currency>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(CurrencyRepository));
                return new List<Currency>();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(CurrencyRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Currency entity)
        {
            try
            {
                var exists = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (exists == null)
                    return false;
                exists.Code = entity.Code;
                exists.Symbol = entity.Symbol;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(CurrencyRepository));
                return false;
            }
        }
    }
}
