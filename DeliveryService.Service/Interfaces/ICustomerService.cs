using DeliveryService.Domain.Entities.Customers;
using DeliveryService.Service.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CustomerForCreationDto customerDto);
        Task<Customer> UpdateAsync(Guid Id, CustomerForCreationDto customerDto);
        Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);
    }
}
