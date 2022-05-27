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
        Task CompleteAsync();
    }
}
