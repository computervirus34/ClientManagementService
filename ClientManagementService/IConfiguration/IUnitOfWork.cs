using ClientManagementService.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService
{
    public interface IUnitOfWork
    {
        public IBranchRepository Branches { get; }
        public IBranchStaffRepository BranchStaffs { get; }
        Task CompleteAsync();
    }
}
