﻿using ClientManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetByClient(int id);
        Task<IEnumerable<Order>> GetByClientAndCat(int id, int catId);
    }
}
