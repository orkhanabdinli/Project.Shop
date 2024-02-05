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
    public void ChangeName(int productId, string newName)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        Product? product2 = shopDbContext.Products.FirstOrDefault(p => p.Name == newName);
        if (product2 is not null) throw new AlreadyExistsException($"{newName} product is already exist");
        product.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ChangeDescription(int productId, string newDescription)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        product.Description = newDescription;
        shopDbContext.SaveChanges();
    }
    public void ChangePrice(int productId, decimal newPrice)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newPrice < 0) throw new WrongFormatException("Price must be higher than 0");
        product.Price = newPrice;
        shopDbContext.SaveChanges();
    }public void ChangeStock(int productId, int newStock)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newStock < 0) throw new WrongFormatException("Price must be higher than 0");
        product.Stock = newStock;
        shopDbContext.SaveChanges();
    }
}
