using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class DiscountServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Discount> Create(string? name, int? percentage, int? duration)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Discount? discount1 = await shopDbContext.Discounts.FirstOrDefaultAsync(d => d.Name == name);
        if (discount1 is not null) throw new AlreadyExistsException($"{name} discount is already exist");
        if (percentage <= 0 || percentage > 100) throw new WrongFormatException("Percentage must be between 1 and 100");
        if (duration < 0) throw new WrongFormatException("Discount duration must be more than 0 day");
        Discount discount = new Discount()
        {
            Name = name,
            Percentage = percentage,
            Duration = duration
        };
        await shopDbContext.Discounts.AddAsync(discount);
        await shopDbContext.SaveChangesAsync();
        return discount;
    }
    public void ChangeName(int? discountId, string? newName)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        discount.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ChangePercentage(int? discountId, int? newPercent)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        if (newPercent <= 0 || newPercent > 100) throw new WrongFormatException("Percentage must be between 1 and 100");
        discount.Percentage = newPercent;
        shopDbContext.SaveChanges();
    }
    public void ActivateDiscount(int? discountId)
    {
        if (discountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        if (discount.IsActive == true) throw new IsAlreadyException($"{discount.Name} Discount is already active");
        discount.IsActive = true;
        shopDbContext.SaveChanges();
    }
    public void DeactivateDiscount(int? discountId)
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
                             $"ID: {discount.Id}  Name: {discount.Name}  {discount.Percentage}%\n" +
                             $"Status: {IsActive}  Duration: {discount.Duration} days\n" +
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
            Console.WriteLine("____________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {discount.Id}  Name: {discount.Name}  {discount.Percentage}%\n" +
                             $"Duration: {discount.Duration} days\n" +
                              "____________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowDeactiveDiscounts()
    {
        var discounts = shopDbContext.Discounts.Where(d => d.IsActive == false).AsNoTracking().ToList();
        foreach (var discount in discounts)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("____________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {discount.Id}  Name: {discount.Name}  {discount.Percentage}%\n" +
                             $"Duration: {discount.Duration} days\n" +
                              "____________________________________________________");
            Console.ResetColor();
        }
    }
    public void ApplyDiscounToProduct(int? productId, int? discountId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product ID format");
        if (discountId < 0) throw new WrongFormatException("Wrong discount ID format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null || product.IsActive == false) throw new NotFoundException("Product is not existing");
        Discount? discount = shopDbContext.Discounts.Find(discountId);
        TimeSpan difference = DateTime.UtcNow - discount.LastModifiedDate;
        if (discount is null || discount.IsActive == false) throw new NotFoundException("Discount is not existing");
        if (difference.Days > discount.Duration) throw new NotFoundException("The discount is expired");
        product.DiscountId = discountId;
        product.Price = product.Price - product.Price * discount.Percentage / 100;
        shopDbContext.Entry(product).State = EntityState.Modified;
        shopDbContext.SaveChanges();
    }
    public bool IsDiscountExist()
    {
        var discounts = shopDbContext.Discounts.Where(d => d.IsActive == true).AsNoTracking().ToList();
        if (discounts is not null) return true;
        else return false;
    }
    public bool IsAnyActiveDiscount()
    {
        var discount = shopDbContext.Discounts.FirstOrDefault(d => d.IsActive == true);
        if (discount is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsAnyDeactiveBrand()
    {
        var discount = shopDbContext.Discounts.FirstOrDefault(d => d.IsActive == false);
        if (discount is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
