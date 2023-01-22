using DataAccess;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Service.Abstract;

namespace Service.Concrete;

public class ActorService : IActorService
{
    private readonly AppDbContext _context;

    public ActorService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Actor> GetByIdAsync(int id)
    {
        var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

        return result;
    }
    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        return await _context.Actors.ToListAsync();   
    }

    public async Task AddAsync(Actor actor)
    {
        _context.Actors.Add(actor);
        await _context.SaveChangesAsync();
    }

    public async Task<Actor> UpdateAsync(int id, Actor newActor)
    {
        _context.Update(newActor);
        await _context.SaveChangesAsync();
        return newActor;
    }

    public async Task DeleteAsync(int id)
    {
        var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

        _context.Actors.Remove(result);
        await _context.SaveChangesAsync();  
    }
}
