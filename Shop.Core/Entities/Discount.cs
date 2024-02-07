using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class Discount : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? Percentage { get; set; } = null!;
    public int? Duration { get; set; } = null!;
    public ICollection<Product>? Products { get; set;}
}
