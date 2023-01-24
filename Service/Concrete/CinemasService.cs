using Core.Repository.Concrete;
using DataAccess.Data;
using Models.Entities;
using Service.Abstract;

namespace Service.Concrete;

public class CinemasService : EntityBaseRepository<Cinema>, ICinemasService
{
    public CinemasService(AppDbContext context) : base(context) { }
}