namespace Shop.Core.Entities;

public class Discount
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal? Percentage { get; set; } = null!;
    public ICollection<Product>? Produts { get; set;}
}
