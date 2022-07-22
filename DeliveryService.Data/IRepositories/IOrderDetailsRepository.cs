using DeliveryService.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface IOrderDetailsRepository
    {
        Task<OrderDetails> CreateAsync(OrderDetails orderDetails);
        Task<OrderDetails> UpdateAsync(Guid Id, OrderDetails orderDetails);
        Task<bool> DeleteAsync(Expression<Func<OrderDetails, bool>> expression);
        Task<OrderDetails> GetAsync(Expression<Func<OrderDetails, bool>> expression);
        Task<IQueryable<OrderDetails>> GetAllAsync(Expression<Func<OrderDetails, bool>> expression = null);
    }
}
