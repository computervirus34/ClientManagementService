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
    public class CourseScheduleRepository : GenericRepository<CourseSchedule>, ICourseScheduleRepository
    {
        public CourseScheduleRepository(
            DatabaseContext context,
            ILogger logger
            ) : base(context, logger)
        {

        }
        public override async Task<IEnumerable<CourseSchedule>> All()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(CourseScheduleRepository));
                return new List<CourseSchedule>();
            }
        }
        public override async Task<CourseSchedule> GetByID(int Id)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(i => i.Id == Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error.", typeof(CourseScheduleRepository));
                return new CourseSchedule();
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

                _logger.LogError(ex, "{Repo} Delete method error.", typeof(CourseScheduleRepository));
                return false;
            }
        }

        public override async Task<bool> Update(CourseSchedule entity)
        {
            try
            {
                var infoExists = await _dbSet.Where(o => o.Id == entity.Id)
                                     .SingleOrDefaultAsync();
                if (infoExists == null)
                    return false;
                infoExists.ProductId = entity.ProductId;
                infoExists.Datetime = entity.Datetime;
                infoExists.CourseContent = entity.CourseContent;
                infoExists.Venue = entity.Venue;
                infoExists.Mode = entity.Mode;
                infoExists.IsActive = entity.IsActive;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error.", typeof(CourseScheduleRepository));
                return false;
            }
        }
    }
}
