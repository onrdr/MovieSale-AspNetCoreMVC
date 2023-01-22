using Core.Repository.Concrete;
using DataAccess.Data;
using Models.Entities;
using Service.Abstract;

namespace Service.Concrete;

public class ActorsService : EntityBaseRepository<Actor>, IActorsService
{ 
    public ActorsService(AppDbContext context) : base(context) { }
}
