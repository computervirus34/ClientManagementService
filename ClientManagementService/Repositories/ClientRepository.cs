using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientManagementService.Models;
using ClientManagementService.IRepositories;
using ClientManagementService.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementService.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Client>> All()
        {
            try
            {
                return await _dbSet.Include(i => i.Branch)
                    .Include(i=>i.Currency).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ClientRepository));
                return new List<Client>();
            }
        }

        public override async Task<Client> GetByID(int Id)
        {
            try
            {
                return await _context.Clients.Include(i => i.Branch)
                    .Include(i=>i.Currency)
                    .FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(ClientRepository));
                return new Client();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(ClientRepository));
                return false;
            }
        }

        public override async Task<bool> Update(Client entity)
        {
            try
            {
                var existingBranch = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingBranch == null)
                    return false;
                existingBranch.CompanyName = entity.CompanyName;
                existingBranch.ContactPerson = entity.ContactPerson;
                existingBranch.BranchId = entity.BranchId;
                existingBranch.CurrencyId = entity.CurrencyId;
                existingBranch.Contact = entity.Contact;
                existingBranch.Location = entity.Location;
                existingBranch.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(ClientRepository));
                return false;
            }
        }
    }
}
