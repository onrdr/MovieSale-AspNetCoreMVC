using Models.Entities;

namespace Service.Abstract;

public interface IShoppingCartService
{
    public ShoppingCart ShoppingCart { get; set; }
    void AddItemToCart(Movie movie);
    void RemoveItemFromCart(Movie movie);
    List<ShoppingCartItem> GetShoppingCartItems();
    double GetShoppingCartTotal();
    Task ClearShoppingCartAsync(); 
}
