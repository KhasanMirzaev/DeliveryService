using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            var result = await appDbContext.AddAsync(product);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Product, bool>> expression)
        {
            var product = await appDbContext.Products.FirstOrDefaultAsync(expression);

            if (product == null)
                return false;

            appDbContext.Products.Remove(product);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression = null)
        {
            return expression is null ? appDbContext.Products.Include(p => p.OrderDetails) : appDbContext.Products.Include(p => p.OrderDetails).Where(expression);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> expression)
        {
            return await appDbContext.Products.Include(p => p.OrderDetails).FirstOrDefaultAsync(expression);
        }

        public async Task<Product> UpdateAsync(Guid Id, Product product)
        {
            var result = appDbContext.Products.Update(product);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
