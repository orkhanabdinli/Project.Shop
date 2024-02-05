using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class Product : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public decimal? Price { get; set; } = null!;
    public int? Stock { get; set; } 
    public int? BrandId { get; set; } = null!;
    public int? CategoryId { get; set; } = null!;
    public int? DiscountId { get; set; }
    public Brand Brand { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public Discount? Discount { get; set; }
    public ICollection<CartProducts>? CartProducts { get; set; }
    public ICollection<InvoiceProducts>? InvoiceProducts { get; set;}
}
