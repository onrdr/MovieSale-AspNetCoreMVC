using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels;
using Service.Abstract;
namespace WebUI.Controllers;

public class CinemasController : Controller
{
    private readonly ICinemasService _service;

    public CinemasController(ICinemasService service)
    {
        _service = service;
    }

    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CinemaVM model)
    {
        if (ModelState.IsValid)
        {
            Cinema cinema = new()
            {
                Name = model.Name,
                Description = model.Description,
                Logo = model.Logo
            };

            await _service.AddAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    #endregion

    #region Read 
    public async Task<ActionResult> Index()
    {
        var allCinemas = await _service.GetAllAsync();

        return View(allCinemas);
    }

    public async Task<IActionResult> Details(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);

        return cinemaDetails == null ? View(nameof(NotFound)) : View(cinemaDetails);
    }
    #endregion

    #region Update
    public async Task<IActionResult> Edit(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);

        return cinemaDetails == null ? View(nameof(NotFound)) : View(cinemaDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Cinema cinema)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(cinema);

            return RedirectToAction(nameof(Index));
        }

        return View(cinema);
    }
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);

        return cinemaDetails == null ? View(nameof(NotFound)) : View(cinemaDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cinemaDetails = await _service.GetByIdAsync(id);

        if (cinemaDetails == null)
        {
            return View(nameof(NotFound));
        }

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
    #endregion
}