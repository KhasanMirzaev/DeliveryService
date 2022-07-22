using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            var result = await appDbContext.AddAsync(category);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await appDbContext.Categories.FirstOrDefaultAsync(expression);

            if (category == null)
                return false;

            appDbContext.Categories.Remove(category);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            return expression is null ? appDbContext.Categories.Include(p => p.Products) : appDbContext.Categories.Include(p => p.Products).Where(expression);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            return await appDbContext.Categories.Include(p => p.Products).FirstOrDefaultAsync(expression);
        }

        public async Task<Category> UpdateAsync(Guid Id, Category category)
        {
            var result = appDbContext.Categories.Update(category);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
