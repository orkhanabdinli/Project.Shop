using Shop.Core.Abstract;

namespace Shop.Core.Entities;

public class Wallet : BaseEntities
{
    public int Id { get; set; }
    public string CardName { get; set; } = null!;
    public string CardNumber { get; set; } = null!;
    public decimal? Balance { get; set; } = null!;
    public int? UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}
