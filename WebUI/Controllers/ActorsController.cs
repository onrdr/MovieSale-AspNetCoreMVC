﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Identity;
using Models.ViewModels;
using Service.Abstract;

namespace WebUI.Controllers;

[Authorize(Roles = UserRoles.Admin)]
public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
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

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var allActors = await _service.GetAllAsync();

        return View(allActors);
    }

    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        return actorDetails == null ? View(nameof(NotFound)) : View(actorDetails);
    }

    #endregion

    #region Update
    public async Task<IActionResult> Edit(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        return actorDetails == null ? View(nameof(NotFound)) : View(actorDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Actor actor)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(actor);

            return RedirectToAction(nameof(Index));
        }

        return View(actor);
    }
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        return actorDetails == null ? View(nameof(NotFound)) : View(actorDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actorDetails = await _service.GetByIdAsync(id);

        if (actorDetails == null)
        {
            return View(nameof(NotFound));
        }

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
    #endregion
}
