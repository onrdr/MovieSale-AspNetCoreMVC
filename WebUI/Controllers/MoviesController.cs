using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace WebUI.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _service;

    public MoviesController(IMoviesService service)
    {
        _service = service;
    }
    public async Task<ActionResult> Index()
    {
        var allMovies = await _service.GetAllAsync(m => m.Cinema); 

        return View(allMovies);
    }
}
