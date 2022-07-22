using DeliveryService.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Guid Id, Category category);
        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
        Task<IQueryable<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null);
    }
}
