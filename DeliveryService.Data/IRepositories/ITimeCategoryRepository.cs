using DeliveryService.Domain.Entities.TimeCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface ITimeCategoryRepository
    {
        Task<TimeCategory> CreateAsync(TimeCategory timeCategory);
        Task<TimeCategory> UpdateAsync(Guid Id, TimeCategory timeCategory);
        Task<bool> DeleteAsync(Expression<Func<TimeCategory, bool>> expression);
        Task<TimeCategory> GetAsync(Expression<Func<TimeCategory, bool>> expression);
        Task<IQueryable<TimeCategory>> GetAllAsync(Expression<Func<TimeCategory, bool>> expression = null);
    }
}
