using DeliveryService.Domain.Entities.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Guid Id, Customer customer);
        Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);
    }
}
