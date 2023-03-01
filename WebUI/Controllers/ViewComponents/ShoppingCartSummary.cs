using Microsoft.AspNetCore.Mvc;
using Service.Abstract;

namespace WebUI.Controllers.ViewComponents;

public class ShoppingCartSummary : ViewComponent
{
    private readonly IShoppingCartService _shoppingCartService;
    public ShoppingCartSummary(IShoppingCartService shoppingCartService)
    {
        _shoppingCartService = shoppingCartService;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCartService.GetShoppingCartItems();

        return View(items.Count);
    }
}
