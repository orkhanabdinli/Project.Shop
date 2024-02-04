using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class InvoiceProducts 
{
    public int? ProductId { get; set; } = null!;
    public int? InvoiceId { get; set; } = null!;
    public int? AmountOfProducts { get; set; }
    public int TotalPrice { get; set; }
    public Product Product { get; set; } = null!;
    public Invoice Invoice { get; set; } = null!;
}
