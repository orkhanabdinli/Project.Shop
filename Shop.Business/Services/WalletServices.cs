using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class WalletServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Wallet> Create(string cardName, string cardNumber, int userId)
    {
        if (String.IsNullOrEmpty(cardName)) throw new ArgumentNullException("You must enter name");
        Wallet? wallet1 = await shopDbContext.Wallets.FirstOrDefaultAsync(w => w.UserId == userId && (w.CardName == cardName || w.CardNumber == cardNumber));
        if (wallet1 is not null) throw new AlreadyExistsException($"{cardName} name is already in use");


        Wallet wallet = new Wallet()
        {
            CardName = cardName,
            CardNumber = cardNumber,
            UserId = userId
        };
        await shopDbContext.Wallets.AddAsync(wallet);
        await shopDbContext.SaveChangesAsync();
        return wallet;
    }
}
