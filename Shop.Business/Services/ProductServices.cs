using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class ProductServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Product> Create(string name, string? description, decimal price, int stock, int brandId, int categoryId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Product? product1 = await shopDbContext.Products.FirstOrDefaultAsync(b => b.Name == name);
        if (product1 is not null) throw new AlreadyExistsException($"{name} product is already exist");
        if (price < 0) throw new WrongFormatException("Price must be higher than 0");
        if (stock < 0) throw new WrongFormatException("Amount in stock must be higher than 0");
        if (brandId < 0) throw new WrongFormatException("Wrong brand Id format");
        Brand? brand = await shopDbContext.Brands.FindAsync(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (categoryId < 0) throw new WrongFormatException("Wrong category Id format");
        Category? category = await shopDbContext.Categories.FindAsync(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        Product product = new Product()
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock,
            CategoryId = categoryId,
            BrandId = brandId
        };
        await shopDbContext.Products.AddAsync(product);
        await shopDbContext.SaveChangesAsync();
        return product;
    }
}
