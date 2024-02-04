using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class ProductServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async void Create(string name, string? description, string price, string stock, string brandId, string categoryId, string discountId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Product? product1 = await shopDbContext.Products.FirstOrDefaultAsync(b => b.Name == name);
        if (product1 is not null) throw new AlreadyExistsException($"{name} product is already exist");
        if (Decimal.TryParse(price, out decimal priceValue)) throw new WrongFormatException("Wrong format for price");
        if (Int32.TryParse(stock, out int stockValue)) throw new WrongFormatException("Wrong format for amount instock");
        if (Int32.TryParse(brandId, out int brandIdValue) || brandIdValue < 1) throw new WrongFormatException("Wrong format for Brand Id");
        Brand? brand = await shopDbContext.Brands.FindAsync(brandIdValue);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (Int32.TryParse(categoryId, out int categoryIdVale) || categoryIdVale < 1) throw new WrongFormatException("Wrong format for Category Id");
        Category? category = await shopDbContext.Categories.FindAsync(categoryIdVale);
        if (category is null) throw new NotFoundException("Category is not existing");
        if (Int32.TryParse(discountId, out int discountIdValue) || discountIdValue < 1) throw new WrongFormatException("Wrong format for Discount Id");
        Discount? discount = await shopDbContext.Discounts.FindAsync(discountIdValue);
        if (discount is null) throw new NotFoundException("Discount is not existing");
        Product product = new Product()
        {
            Name = name,
            Description = description,
            Price = priceValue,
            Stock = stockValue,
            CategoryId = categoryIdVale,
            BrandId = brandIdValue,
            DiscountId = discountIdValue,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now
        };
        await shopDbContext.Products.AddAsync(product);
        await shopDbContext.SaveChangesAsync();
    }
}
