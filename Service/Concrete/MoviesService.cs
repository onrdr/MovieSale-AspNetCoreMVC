using Core.Repository.Concrete;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ViewModels;
using Service.Abstract;

namespace Service.Concrete;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    private readonly AppDbContext _context;
    public MoviesService(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDetails = await _context.Movies
            .Include(m => m.Cinema)
            .Include(m => m.Producer)
            .Include(m => m.Actors_Movies).ThenInclude(a => a.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);

        return movieDetails;
    }

    public async Task<NewMovieDropdownsVM> GetNewMovieDrowdownsValuesAsync()
    {
        return new NewMovieDropdownsVM
        {
            Actors = await _context.Actors.OrderBy(a => a.FullName).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(a => a.Name).ToListAsync(),
            Producers = await _context.Producers.OrderBy(a => a.FullName).ToListAsync()
        };
    }

    public async Task AddNewMovieAsync(NewMovieVM data)
    {
        var newMovie = new Movie()
        {
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            ImageUrl = data.ImageUrl,
            CinemaId = data.CinemaId,
            StartDate = data.StartDate,
            EndDate = data.EndDate,
            MovieCategory = data.MovieCategory,
            ProducerId = data.ProducerId,
        };

        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        foreach (var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = newMovie.Id,
                ActorId = actorId,
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMovieAsync(NewMovieVM data)
    {
        var dbMovie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == data.Id);
        if (dbMovie != null)
        {
            dbMovie.Name = data.Name;
            dbMovie.Description = data.Description;
            dbMovie.Price = data.Price;
            dbMovie.ImageUrl = data.ImageUrl;
            dbMovie.CinemaId = data.CinemaId;
            dbMovie.StartDate = data.StartDate;
            dbMovie.EndDate = data.EndDate;
            dbMovie.MovieCategory = data.MovieCategory;
            dbMovie.ProducerId = data.ProducerId;

            await _context.SaveChangesAsync();
        }

        var existingActorsDb = _context.Actors_Movies.Where(m => m.MovieId == data.Id).ToList();
        _context.Actors_Movies.RemoveRange(existingActorsDb);
        await _context.SaveChangesAsync();

        foreach (var actorId in data.ActorIds)
        {
            var newActorMovie = new Actor_Movie()
            {
                MovieId = data.Id,
                ActorId = actorId,
            };
            await _context.Actors_Movies.AddAsync(newActorMovie);
        }

        await _context.SaveChangesAsync();
    }
}
