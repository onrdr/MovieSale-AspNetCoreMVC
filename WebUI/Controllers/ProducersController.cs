using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.ViewModels;
using Service.Abstract;
namespace WebUI.Controllers;

public class ProducersController : Controller
{
    private readonly IProducersService _service;

    public ProducersController(IProducersService service)
    {
        _service = service;
    }

    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProducerVM model)
    {
        if (ModelState.IsValid)
        {
            Producer producer = new()
            {
                FullName = model.FullName,
                Bio = model.Bio,
                ProfilePictureUrl = model.ProfilePictureUrl
            };

            await _service.AddAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }
    #endregion 

    #region Read
    public async Task<IActionResult> Index()
    {
        var allProducers = await _service.GetAllAsync();

        return View(allProducers);
    }

    public async Task<IActionResult> Details(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);

        if (producerDetails == null)
        {
            return View("NotFound");
        }

        return View(producerDetails);
    }
    #endregion

    #region Update
    public async Task<IActionResult> Edit(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);

        if (producerDetails == null)
        {
            return View("NotFound");
        }

        return View(producerDetails);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Producer producer)
    { 
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(producer);

            return RedirectToAction(nameof(Index));
        }

        return View(producer);
    }
    #endregion

    #region Delete
    public async Task<IActionResult> Delete(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);

        if (producerDetails == null)
        {
            return View("NotFound");
        }

        return View(producerDetails);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var producerDetails = await _service.GetByIdAsync(id);

        if (producerDetails == null)
        {
            return View("NotFound");
        }

        await _service.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }
    #endregion
}

