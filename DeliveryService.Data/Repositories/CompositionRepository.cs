using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Compositions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class CompositionRepository : ICompositionRepository
    {
        private AppDbContext appDbContext;

        public CompositionRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Composition> CreateAsync(Composition composition)
        {
            var result = await appDbContext.AddAsync(composition);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Composition, bool>> expression)
        {
            var composition = await appDbContext.Compositions.FirstOrDefaultAsync(expression);

            if (composition == null)
                return false;

            appDbContext.Compositions.Remove(composition);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<Composition>> GetAllAsync(Expression<Func<Composition, bool>> expression = null)
        {
            return expression is null ? appDbContext.Compositions.Include(p => p.Products) : appDbContext.Compositions.Include(p => p.Products).Where(expression);
        }

        public async Task<Composition> GetAsync(Expression<Func<Composition, bool>> expression)
        {
            return await appDbContext.Compositions.Include(p => p.Products).FirstOrDefaultAsync(expression);
        }

        public async Task<Composition> UpdateAsync(Guid Id, Composition composition)
        {
            var result = appDbContext.Compositions.Update(composition);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
