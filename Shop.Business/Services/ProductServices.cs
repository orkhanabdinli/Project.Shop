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
        if (price < 0) throw new ArgumentOutOfRangeException("Price must be higher than 0");
        if (stock < 0) throw new ArgumentOutOfRangeException("Amount in stock must be higher than 0");
        if (brandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = await shopDbContext.Brands.FindAsync(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (categoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
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
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        Product? product2 = shopDbContext.Products.FirstOrDefault(p => p.Name == newName);
        if (product2 is not null) throw new AlreadyExistsException($"{newName} product is already exist");
        product.Name = newName;
        shopDbContext.SaveChanges();    
    }
    public void ChangeDescription(int productId, string newDescription)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        product.Description = newDescription;   
        shopDbContext.SaveChanges();
    }
    public void ChangePrice(int productId, decimal newPrice)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newPrice < 0) throw new WrongFormatException("Price must be higher than 0");
        product.Price = newPrice;
        shopDbContext.SaveChanges();
    }
    public void ChangeStock(int productId, int newStock)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newStock < 0) throw new ArgumentOutOfRangeException("Price must be higher than 0");
        product.Stock = newStock;
        shopDbContext.SaveChanges();
    }   
    public void ChangeBrand(int productId, int newBrandId)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newBrandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(newBrandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        product.BrandId = newBrandId;
        shopDbContext.SaveChanges();
    }
    public void ChangeCategory(int productId, int newCategoryId)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newCategoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
        Brand? brand = shopDbContext.Brands.Find(newCategoryId);
        if (brand is null) throw new NotFoundException("Category is not existing");
        product.CategoryId = newCategoryId;
        shopDbContext.SaveChanges();
    }
    public void ChangeDiscount(int productId, int newDiscountId)
    {
        if (productId < 0) throw new ArgumentOutOfRangeException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newDiscountId < 0) throw new ArgumentOutOfRangeException("Wrong discount Id format");
        Brand? brand = shopDbContext.Brands.Find(newDiscountId);
        if (brand is null) throw new NotFoundException("Discount is not existing");
        product.DiscountId = newDiscountId;
        shopDbContext.SaveChanges();
    }
    public void ShowAllProducts()
    {
        var products = shopDbContext.Products.AsNoTracking().ToList();
        foreach (var product in products)
        {
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________________");
            Console.ResetColor();
        }
    }

    public void ShowAllProductsByBrand(int brandId)
    {
        if (brandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        var products = shopDbContext.Products.Where(p => p.BrandId == brandId).AsNoTracking().ToList();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"<<{brand.Name}>>");
        Console.ResetColor();
        foreach (var product in products)
        {
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" + 
                              $"Name: {product.Name}\n" + 
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowAllProductsByCategory(int categoryId)
    {
        if (categoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        var products = shopDbContext.Products.Where(p => p.CategoryId == categoryId).AsNoTracking().ToList();
        Console.ForegroundColor = ConsoleColor.DarkYellow; 
        Console.WriteLine($"<<{category.Name}>>");
        Console.ResetColor();
        foreach (var product in products)
        {
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________________");
            Console.ResetColor();
        }
    }
}
