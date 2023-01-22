using Models.Entities;

namespace Service.Abstract;

public interface IActorService
{
    Task<Actor> GetByIdAsync(int id);
    Task<IEnumerable<Actor>> GetAllAsync();
    Task AddAsync(Actor actor);
    Task<Actor> UpdateAsync(int id, Actor newActor);
    Task DeleteAsync(int id);
}