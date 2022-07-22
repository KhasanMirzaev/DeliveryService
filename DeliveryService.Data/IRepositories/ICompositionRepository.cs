using DeliveryService.Domain.Entities.Compositions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.IRepositories
{
    public interface ICompositionRepository
    {
        Task<Composition> CreateAsync(Composition composition);
        Task<Composition> UpdateAsync(Guid Id, Composition composition);
        Task<bool> DeleteAsync(Expression<Func<Composition, bool>> expression);
        Task<Composition> GetAsync(Expression<Func<Composition, bool>> expression);
        Task<IQueryable<Composition>> GetAllAsync(Expression<Func<Composition, bool>> expression = null);
    }
}
