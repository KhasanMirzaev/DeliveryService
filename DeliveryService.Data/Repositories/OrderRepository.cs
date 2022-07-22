using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Order> CreateAsync(Order order)
        {
            var result = await appDbContext.AddAsync(order);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await appDbContext.Orders.FirstOrDefaultAsync(expression);

            if (order == null)
                return false;

            appDbContext.Orders.Remove(order);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null)
        {
            return expression is null ? appDbContext.Orders.Include(p => p.OrderDetails) : appDbContext.Orders.Include(p => p.OrderDetails).Where(expression);
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            return await appDbContext.Orders.Include(p => p.OrderDetails).FirstOrDefaultAsync(expression);
        }

        public async Task<Order> UpdateAsync(Guid Id, Order order)
        {
            var result = appDbContext.Orders.Update(order);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
