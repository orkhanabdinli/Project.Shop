namespace Shop.Core.Entities;

public class CartProducts
{
    public int? ProductId { get; set; } = null!;
    public int? CartId { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
}
