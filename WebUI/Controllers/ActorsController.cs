using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Entities;
using Models.ViewModels;
using Service.Abstract;

namespace WebUI.Controllers;

public class ActorsController : Controller
{
    private readonly IActorService _service;

    public ActorsController(IActorService service)
    {
        _service = service;
    }

    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ActorVM model)
    {
        if (ModelState.IsValid)
        {
            Actor actor = new()
            {
                FullName = model.FullName,
                Bio = model.Bio,
                ProfilePictureUrl = model.ProfilePictureUrl
            };

            await _service.AddAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    #endregion

    #region Read
    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();

        return View(allActors);
    }
    public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        if (actorDetails == null)
        {
            return View("NotFound");
        }

        return View(actorDetails);
    }
    #endregion

    #region Update
    public async Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        if (actorDetails == null)
        {
            return View("NotFound");
        }

        return View(actorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Actor actor, int id)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(actor.Id, actor);

            return RedirectToAction(nameof(Index));
        }

        return View(actor);
    }
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        if (actorDetails == null)
        {
            return View("NotFound");
        }

        return View(actorDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        if (actorDetails == null)
        {
            return View("NotFound");
        }

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
    #endregion
}
