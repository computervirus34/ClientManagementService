﻿using ClientManagementService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.IRepositories
{
    public interface IDiscountConfigRepository : IGenericRepository<DiscountRateConfig>
    {
        Task<IEnumerable<DiscountRateConfig>> GetDiscountByCategory(int id);
    }
}
