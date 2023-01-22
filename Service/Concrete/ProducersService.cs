using Core.Repository.Concrete;
using DataAccess.Data;
using Models.Entities;
using Service.Abstract;

namespace Service.Concrete;

public class ProducersService : EntityBaseRepository<Producer>, IProducersService
{
    public ProducersService(AppDbContext context) : base(context) { }
}
