namespace Shop.Core.Entities;

public class CartProducts
{
    public int? ProductId { get; set; } = null!;
    public int? CartId { get; set; } = null!;
    public int AmountOfProducts { get; set; } = 1;
    public Product Product { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}
