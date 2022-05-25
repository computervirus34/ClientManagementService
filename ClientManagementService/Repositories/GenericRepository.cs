﻿using ClientManagementService.Data;
using ClientManagementService.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientManagementService.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DatabaseContext _context;
        protected DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            DatabaseContext context,
            ILogger logger
            )
        {
            _context = context;
            _logger = logger;
            this._dbSet = context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual Task<bool> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetByID(int Id)
        {
            return await _dbSet.FindAsync(Id);
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
