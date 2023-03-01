
namespace Models.Entities;

public class ShoppingCart
{ 
    public string Id { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } 
}