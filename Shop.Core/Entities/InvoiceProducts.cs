using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class InvoiceProducts 
{
    public int  Id { get; set; }
    public int? ProductId { get; set; } = null!;
    public int? InvoiceId { get; set; } = null!;
    public int? AmountOfProducts { get; set; } = 1;
    public int TotalPrice { get; set; }
    public Product Products { get; set; } = null!;
    public Invoice Invoices { get; set; } = null!;
}
