namespace Shop.Core.Entities;

public class CartProducts
{
    public int Id { get; set; }
    public int? ProductId { get; set; } = null!;
    public int? CartId { get; set; } = null!;
    public int AmountOfProducts { get; set; } = 1;
    public Product Products { get; set; } = null!;
    public Cart Carts { get; set; } = null!;
}
