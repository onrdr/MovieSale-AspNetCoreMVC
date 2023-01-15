using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebUI.Controllers;

public class ActorsController : Controller
{
    private readonly AppDbContext _context;

    public ActorsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task <IActionResult> Index()
    {
        var data = await _context.Actors.ToListAsync();
        return View();
    }
}
