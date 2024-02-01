using Shop.Core.Abstract;
using System.Collections.ObjectModel;

namespace Shop.Core.Entities;

public class Category : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Collection<Product>? Products { get; set; }

}
