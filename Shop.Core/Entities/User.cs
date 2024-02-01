using Shop.Core.Abstract;
using System.Collections.ObjectModel;

namespace Shop.Core.Entities;

public class User : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public Collection<Wallet>? Wallets { get; set; }
    public Cart Cart { get; set; } = null!;
}
