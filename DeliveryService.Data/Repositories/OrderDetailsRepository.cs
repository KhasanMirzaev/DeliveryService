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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private AppDbContext appDbContext;

        public OrderDetailsRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<OrderDetails> CreateAsync(OrderDetails orderDetails)
        {
            var result = await appDbContext.AddAsync(orderDetails);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<OrderDetails, bool>> expression)
        {
            var orderDetails = await appDbContext.OrderDetails.FirstOrDefaultAsync(expression);

            if (orderDetails == null)
                return false;

            appDbContext.OrderDetails.Remove(orderDetails);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<OrderDetails>> GetAllAsync(Expression<Func<OrderDetails, bool>> expression = null)
        {
            return expression is null ? appDbContext.OrderDetails : appDbContext.OrderDetails.Where(expression);
        }

        public async Task<OrderDetails> GetAsync(Expression<Func<OrderDetails, bool>> expression)
        {
            return await appDbContext.OrderDetails.FirstOrDefaultAsync(expression);
        }

        public async Task<OrderDetails> UpdateAsync(Guid Id, OrderDetails orderDetails)
        {
            var result = appDbContext.OrderDetails.Update(orderDetails);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
