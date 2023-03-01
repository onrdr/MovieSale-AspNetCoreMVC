using DataAccess.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Service.Abstract;

namespace Service.Concrete;

public class ShoppingCartService : IShoppingCartService
{
    private readonly AppDbContext _context;
    public ShoppingCart ShoppingCart { get; set; } = new();
    public ShoppingCartService(AppDbContext context)
    { 
        _context = context;
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart() { Id = cartId };
    }

    public void AddItemToCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(s => s.Movie.Id == movie.Id && s.ShoppingCartId == ShoppingCart.Id);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCart.Id,
                Movie = movie,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }

    public void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = _context.ShoppingCartItems
            .FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCart.Id);

        if (shoppingCartItem == null)
            return;

        if (shoppingCartItem.Amount > 1)
            shoppingCartItem.Amount--;
        else
            _context.ShoppingCartItems.Remove(shoppingCartItem);

        _context.SaveChanges();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCart.ShoppingCartItems ??= _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCart.Id)
            .Include(n => n.Movie)
            .ToList();
    }

    public double GetShoppingCartTotal()
    {
        return _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCart.Id)
            .Select(n => n.Movie.Price * n.Amount)
            .Sum();
    }

    public async Task ClearShoppingCartAsync()
    {
        var items = await _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCart.Id)
            .ToListAsync();
        _context.ShoppingCartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }
}


