using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class Invoice : BaseEntities
{
    public int Id { get; set; }
    public int? UserId { get; set; } = null!;
    public int? WalletId { get; set; } = null!;
    public User User { get; set; } = null!;
    public Wallet Wallet { get; set; } = null!;
}
