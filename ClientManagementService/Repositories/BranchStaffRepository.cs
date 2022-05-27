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
    public class BranchStaffRepository : GenericRepository<BranchStaff>, IBranchStaffRepository
    {
        public BranchStaffRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<BranchStaff>> All()
        {
            try
            {
                return await _dbSet.Include(i=>i.Branch).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(BranchRepository));
                return new List<BranchStaff>();
            }
        }

        public override async Task<BranchStaff> GetByID(int Id)
        {
            try
            {
                return await _context.BranchStaffs.Include(i=>i.Branch).FirstOrDefaultAsync(i=>i.Id==Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(BranchStaffRepository));
                return new BranchStaff();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(BranchRepository));
                return false;
            }
        }

        public override async Task<bool> Update(BranchStaff entity)
        {
            try
            {
                var existingBranch = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (existingBranch == null)
                    return false;
                existingBranch.FirstName = entity.FirstName;
                existingBranch.LastName = entity.LastName;
                existingBranch.Gender = entity.Gender;
                existingBranch.Contact = entity.Contact;
                existingBranch.Location = entity.Location;
                existingBranch.Email = entity.Email;
                existingBranch.BranchId = entity.BranchId;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(BranchRepository));
                return false;
            }
        }
    }
}
