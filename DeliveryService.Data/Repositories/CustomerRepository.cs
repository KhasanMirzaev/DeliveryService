using DeliveryService.Data.Contexts;
using DeliveryService.Data.IRepositories;
using DeliveryService.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDbContext appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var result = await appDbContext.AddAsync(customer);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            var customer = await appDbContext.Customers.FirstOrDefaultAsync(expression);

            if (customer == null)
                return false;

            appDbContext.Customers.Remove(customer);

            await appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IQueryable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null)
        {
            return expression is null ? appDbContext.Customers.Include(p => p.Orders) : appDbContext.Customers.Include(p => p.Orders).Where(expression);
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            return await appDbContext.Customers.Include(p=>p.Orders).FirstOrDefaultAsync(expression);
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            var result = appDbContext.Customers.Update(customer);

            await appDbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
