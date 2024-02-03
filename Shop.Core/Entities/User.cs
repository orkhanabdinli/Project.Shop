using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class User : BaseEntities
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public DateTime? Birthday { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public ICollection<Wallet>? Wallets { get; set; }
    public Cart? Cart { get; set; }
}
