using Microsoft.AspNetCore.Mvc;
using Models.ViewModels; 
using Service.Abstract; 
using System.Security.Claims;

namespace WebUI.Controllers;

public class OrdersController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IOrdersService _ordersService;

    public OrdersController(IMoviesService moviesService, IShoppingCartService shoppingCartService, IOrdersService ordersService)
    {
        _moviesService = moviesService;
        _shoppingCartService = shoppingCartService;
        _ordersService = ordersService;
    }

    public async Task<IActionResult> Index()
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userRole = User.FindFirstValue(ClaimTypes.Role);
        var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);

        return View(orders);
    }

    public IActionResult ShoppingCart()
    {
        var items = _shoppingCartService.GetShoppingCartItems();
        _shoppingCartService.ShoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCartService.ShoppingCart,
            ShoppingCartTotal = _shoppingCartService.GetShoppingCartTotal()
        };

        return View(response);
    }

    public async Task<IActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _moviesService.GetMovieByIdAsync(id);

        if (item != null) 
            _shoppingCartService.AddItemToCart(item); 

        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
    {
        var item = await _moviesService.GetMovieByIdAsync(id);

        if (item != null) 
            _shoppingCartService.RemoveItemFromCart(item); 

        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> CompleteOrder()
    {
        var items = _shoppingCartService.GetShoppingCartItems();
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

        await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
        await _shoppingCartService.ClearShoppingCartAsync();

        return View("OrderCompleted");
    }
}
