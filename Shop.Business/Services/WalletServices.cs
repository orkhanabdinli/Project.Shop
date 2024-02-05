using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class WalletServices 
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Wallet> Create(string cardName, string cardNumber, string email)
    {
        User? user = await shopDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (String.IsNullOrEmpty(cardName)) throw new ArgumentNullException("You must enter name");
        if (cardNumber.Length > 16 || cardNumber.Length < 16) throw new WrongFormatException("Card number must contain 16 digits");
        Wallet? wallet1 = await shopDbContext.Wallets.FirstOrDefaultAsync(w => w.UserId == user.Id && (w.CardName == cardName || w.CardNumber == cardNumber));
        if (wallet1 is not null && wallet1.CardName == cardName) throw new AlreadyExistsException($"{cardName} name is already in use");
        if (wallet1 is not null && wallet1.CardNumber == cardNumber) throw new AlreadyExistsException($"Card with this number is already in use");

        Wallet wallet = new Wallet()
        {
            CardName = cardName,
            CardNumber = cardNumber,
            UserId = user.Id
        };
        await shopDbContext.Wallets.AddAsync(wallet);
        await shopDbContext.SaveChangesAsync();
        return wallet;
    }
    public void ShowAllCards(string email)
    {
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        Wallet? wallet = shopDbContext.Wallets.FirstOrDefault(w => w.UserId == user.Id);
        if (wallet is null) throw new NotFoundException("No card were added");
        var cards = shopDbContext.Wallets.Where(w => w.UserId == user.Id).AsNoTracking().ToList();
        foreach (var item in cards)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                                  "                                                             \n" +
                                  $"Card ID: {item.Id}  Card Name: {item.CardName}\n" +
                                  $"Cand Number: {item.CardNumber}\n" +
                                  $"Balance: {item.Balance}\n" +
                                  "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ChangeCardName(string email, int cardId, string newCardName)
    {
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        if (cardId < 0) throw new WrongFormatException("Wrong card Id format");
        Wallet? wallet = shopDbContext.Wallets.FirstOrDefault(w => w.Id == cardId && w.UserId == user.Id);
        if (wallet is null) throw new NotFoundException("Card is not exist");
        Wallet? wallet1 = shopDbContext.Wallets.FirstOrDefault(w => w.CardName == newCardName);
        wallet.CardName = newCardName;
        shopDbContext.SaveChanges();
    }
    public void DeleteCard(string email, int cardId) 
    {
        User? user = shopDbContext.Users.FirstOrDefault(u => u.Email == email);
        if (cardId < 0) throw new WrongFormatException("Wrong card Id format");
        Wallet? wallet = shopDbContext.Wallets.FirstOrDefault(w => w.Id == cardId && w.UserId == user.Id);
        if (wallet is null) throw new NotFoundException("Card is not exist");
        if (wallet.IsActive == false) throw new 
        wallet.IsActive = false;
        shopDbContext.SaveChanges();
    }
}
