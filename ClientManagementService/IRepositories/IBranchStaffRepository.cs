using ClientManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.IRepositories
{
    public interface IBranchStaffRepository : IGenericRepository<BranchStaff>
    {
        Task<BranchStaff> ValidateUser(string userId, string password);
        string GetHash(string userID, string password);
        Task<bool> ChangePassword(PasswordChangeModel passwordChange);
    }
}
