using Models.Entities.Abstract;
using System.Linq.Expressions;

namespace Core.Repository.Abstract;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
