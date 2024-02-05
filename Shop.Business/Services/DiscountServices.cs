using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class DiscountServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Discount> Create(string name, int percentage)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Discount? discount1 = await shopDbContext.Discounts.FirstOrDefaultAsync(d => d.Name == name);
        if (discount1 is not null) throw new AlreadyExistsException($"{name} discount is already exist");
        if (percentage <= 0 || percentage > 100) throw new WrongFormatException("Percentage must be between 1 and 100");
        Discount discount = new Discount()
        {
            Name = name
        };
        await shopDbContext.Discounts.AddAsync(discount);
        await shopDbContext.SaveChangesAsync();
        return discount;
    }

}
