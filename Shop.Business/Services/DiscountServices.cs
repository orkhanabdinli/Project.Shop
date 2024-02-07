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
    public void ChangeName(int discountId, string newName)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        discount.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ChangePercentage(int discountId, int newPercent)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        if (newPercent <= 0 || newPercent > 100) throw new WrongFormatException("Percentage must be between 1 and 100");
        discount.Percentage = newPercent;
        shopDbContext.SaveChanges();
    }
    public void ActivateDiscount(int discountId)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        if (discount.IsActive == true) throw new IsAlreadyException($"{discount.Name} Discount is already active");
        discount.IsActive = true;
        shopDbContext.SaveChanges();
    }
    public void DeactivateDiscount(int discountId)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        if (discount.IsActive == false) throw new IsAlreadyException($"{discount.Name} Discount is already deactive");
        discount.IsActive = false;
        shopDbContext.SaveChanges();
    }
    public void ShowAllDiscounts()
    {
        var discounts = shopDbContext.Discounts.AsNoTracking().ToList();
        foreach ( var discount in discounts )
        {
            string IsActive = String.Empty;
            if (discount.IsActive == true)
            {
                IsActive = "Active";
            }
            else IsActive = "Not active";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {discount.Id}  Name: {discount.Name}  Status: {IsActive}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowActiveDiscounts()
    {
        var discounts = shopDbContext.Discounts.Where(d => d.IsActive == true).AsNoTracking().ToList();
        foreach (var discount in discounts)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {discount.Id}  Name: {discount.Name}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowDeactiveDiscounts()
    {
        var discounts = shopDbContext.Discounts.Where(d => d.IsActive == false).AsNoTracking().ToList();
        foreach (var discount in discounts)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {discount.Id}  Name: {discount.Name}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
}
