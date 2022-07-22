using DeliveryService.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateAsync(Order order);
        Task<Order> UpdateAsync(Guid Id, Order order);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<IQueryable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null);
    }
}
