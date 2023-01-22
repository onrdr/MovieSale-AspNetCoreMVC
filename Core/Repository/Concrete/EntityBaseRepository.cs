using DataAccess.Data;
using Core.Repository.Abstract;
using Microsoft.EntityFrameworkCore; 
using Models.Entities.Abstract; 

namespace Core.Repository.Concrete;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> dbSet;

    public EntityBaseRepository(AppDbContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }
    public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await dbSet.FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(T entity) 
    { 
        await dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await dbSet.FindAsync(id);
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync(); 
    }
}
