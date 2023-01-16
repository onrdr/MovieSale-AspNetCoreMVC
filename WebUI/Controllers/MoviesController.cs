using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers;

public class MoviesController : Controller
{
    private readonly AppDbContext _context;

    public MoviesController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<ActionResult> Index()
    {
        var allMovies = await _context.Movies.Include(m => m.Cinema)
            .OrderBy(m => m.Name).ToListAsync();

        return View(allMovies);
    }
}
