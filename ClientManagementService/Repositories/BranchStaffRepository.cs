using ClientManagementService.Data;
using ClientManagementService.IRepositories;
using ClientManagementService.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                existingBranch.IsManager = entity.IsManager;
                existingBranch.Deaprtment = entity.Deaprtment;
                //existingBranch.Gender = entity.Gender;
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

        public async Task<BranchStaff> ValidateUser(string userId, string password)
        {
            var passHash = GetHash(userId,  password);
            _logger.LogInformation(passHash);
            return await _context.BranchStaffs.FirstOrDefaultAsync(o => o.UserId == userId && o.Password == passHash);
        }

        public string GetHash(string userID, string password)
        {
            string userIDPassword = userID + password;
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            encrypt = md5.ComputeHash(encode.GetBytes(userIDPassword));
            StringBuilder encryptdata = new StringBuilder();
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }

        public async Task<bool> ChangePassword(PasswordChangeModel passwordChange)
        {
            try
            {
                var oldPassHash = GetHash(passwordChange.UserId, passwordChange.CurrentPassword);
                var passHash = GetHash(passwordChange.UserId, passwordChange.NewPassword);
                var user = await _dbSet
                         .Where(o => o.UserId == passwordChange.UserId && o.Password==oldPassHash)
                         .FirstOrDefaultAsync();

                if (user == null)
                    return false;

                user.Password = passHash;
                return true;

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
