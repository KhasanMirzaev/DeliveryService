using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.TimeCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class TimeCategoryRepository : ITimeCategoryRepository
    {
        private AppDbContext appDbContext;

        public TimeCategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<TimeCategory> CreateAsync(TimeCategory timeCategory)
        {
            var result = await appDbContext.AddAsync(timeCategory);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<TimeCategory, bool>> expression)
        {
            var timeCategory = await appDbContext.TimeCategories.FirstOrDefaultAsync(expression);

            if (timeCategory == null)
                return false;

            appDbContext.TimeCategories.Remove(timeCategory);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<TimeCategory>> GetAllAsync(Expression<Func<TimeCategory, bool>> expression = null)
        {
            return expression is null ? appDbContext.TimeCategories.Include(p => p.Products) : appDbContext.TimeCategories.Include(p => p.Products).Where(expression);
        }

        public async Task<TimeCategory> GetAsync(Expression<Func<TimeCategory, bool>> expression)
        {
            return await appDbContext.TimeCategories.Include(p => p.Products).FirstOrDefaultAsync(expression);
        }

        public async Task<TimeCategory> UpdateAsync(Guid Id, TimeCategory timeCategory)
        {
            var result = appDbContext.TimeCategories.Update(timeCategory);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
