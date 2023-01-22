using Models.Entities.Abstract;

namespace Core.Repository.Abstract;

public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
