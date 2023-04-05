using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models.Identity;
using Models.ViewModels;
using Service.Abstract;

namespace WebUI.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class MoviesController : Controller
{
    private readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }

    #region Create
    public async Task<ActionResult> Create()
    {
        var movieDropdownsData = await _service.GetNewMovieDrowdownsValuesAsync();
        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(NewMovieVM data)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDrowdownsValuesAsync();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(data);
        }

        await _service.AddNewMovieAsync(data);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Read

    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(m => m.Cinema);

        return View(allMovies);
    } 

    [AllowAnonymous]
    public async Task<ActionResult> Search(string searchString)
    {
        var allMovies = await _service.GetAllAsync(m => m.Cinema);

        var filteredResult = allMovies
            .Where(m => m.Name.ToLower().Contains(searchString))
            .ToList();

        return PartialView("_SearchResults", filteredResult);
    }

    [AllowAnonymous]
    public async Task<ActionResult> Details(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);

        return View(movieDetails);
    }
    #endregion

    #region Update
    public async Task<ActionResult> Edit(int id)
    {
        var movieDetails = await _service.GetMovieByIdAsync(id);
        if (movieDetails == null)
            return View(nameof(NotFound));

        var response = new NewMovieVM()
        {
            Id = movieDetails.Id,
            Name = movieDetails.Name,
            Description = movieDetails.Description,
            Price = movieDetails.Price,
            StartDate = movieDetails.StartDate,
            EndDate = movieDetails.EndDate,
            ImageUrl = movieDetails.ImageUrl,
            MovieCategory = movieDetails.MovieCategory,
            CinemaId = movieDetails.CinemaId,
            ProducerId = movieDetails.ProducerId,
            ActorIds = movieDetails.Actors_Movies.Select(m => m.ActorId).ToList()
        };

        var movieDropdownsData = await _service.GetNewMovieDrowdownsValuesAsync();
        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

        return View(response);
    }

    [HttpPost]
    public async Task<ActionResult> Edit(int id, NewMovieVM data)
    {
        if (id != data.Id)
            return View(nameof(NotFound));

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _service.GetNewMovieDrowdownsValuesAsync();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

            return View(data);
        }

        await _service.UpdateMovieAsync(data);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
