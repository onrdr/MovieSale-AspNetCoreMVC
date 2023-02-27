using Core.Repository.Abstract;
using Models.Entities;
using Models.ViewModels;

namespace Service.Abstract;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
    Task<Movie> GetMovieByIdAsync(int id);
    Task<NewMovieDropdownsVM> GetNewMovieDrowdownsValuesAsync();
    Task AddNewMovieAsync(NewMovieVM data);
    Task UpdateMovieAsync(NewMovieVM data);
}
