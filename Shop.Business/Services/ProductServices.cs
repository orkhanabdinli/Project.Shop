using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class ProductServices
{
    ShopDbContext shopDbContext = new();
    BrandServices brandServices = new();
    CategoryServices categoryServices = new();
    public async Task<Product> Create(string? name, string? description, decimal? price, string? stock, int? brandId, int? categoryId)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Product? product1 = await shopDbContext.Products.FirstOrDefaultAsync(b => b.Name == name);
        if (product1 is not null) throw new AlreadyExistsException($"{name} product is already exist");
        if (price < 0) throw new WrongFormatException("Price must be higher than 0");
        if (int.TryParse(stock, out int stock1)) throw new WrongFormatException("Wrong price format");
        if (stock1 < 0) throw new WrongFormatException("Amount in stock must be higher than 0");
        if (brandId < 0) throw new WrongFormatException("Wrong brand Id format");
        Brand? brand = await shopDbContext.Brands.FindAsync(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (brand.IsActive == false) throw new NotFoundException("Brand is not active");
        if (categoryId < 0) throw new WrongFormatException("Wrong category Id format");
        Category? category = await shopDbContext.Categories.FindAsync(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        if (category.IsActive == false) throw new NotFoundException("Category is not active");
        Product product = new Product()
        {
            Name = name,
            Description = description,
            Price = price,
            Stock = stock1,
            CategoryId = categoryId,
            BrandId = brandId
        };
        await shopDbContext.Products.AddAsync(product);
        await shopDbContext.SaveChangesAsync();
        return product;
    }
    public void ChangeName(int? productId, string? newName)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (String.IsNullOrEmpty(newName)) throw new ArgumentException("New name can not be null");
        if (product is null) throw new NotFoundException("Product is not exist");
        Product? product2 = shopDbContext.Products.FirstOrDefault(p => p.Name == newName);
        if (product2 is not null) throw new AlreadyExistsException($"{newName} product is already exist");
        product.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ChangeDescription(int? productId, string? newDescription)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        product.Description = newDescription;
        shopDbContext.SaveChanges();
    }
    public void ChangePrice(int? productId, decimal? newPrice)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newPrice < 0) throw new WrongFormatException("Price must be higher than 0");
        product.Price = newPrice;
        shopDbContext.SaveChanges();
    }
    public void ChangeStock(int? productId, int? newStock)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newStock < 0) throw new WrongFormatException("Price must be higher than 0");
        product.Stock = newStock;
        shopDbContext.SaveChanges();
    }
    public void ChangeBrand(int? productId, int? newBrandId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newBrandId < 0) throw new WrongFormatException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(newBrandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        product.BrandId = newBrandId;
        shopDbContext.SaveChanges();
    }
    public void ChangeCategory(int? productId, int? newCategoryId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newCategoryId < 0) throw new WrongFormatException("Wrong category Id format");
        Brand? brand = shopDbContext.Brands.Find(newCategoryId);
        if (brand is null) throw new NotFoundException("Category is not existing");
        product.CategoryId = newCategoryId;
        shopDbContext.SaveChanges();
    }
    public void ChangeDiscount(int? productId, int? newDiscountId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (newDiscountId < 0) throw new WrongFormatException("Wrong discount Id format");
        Brand? brand = shopDbContext.Brands.Find(newDiscountId);
        if (brand is null) throw new NotFoundException("Discount is not existing");
        product.DiscountId = newDiscountId;
        shopDbContext.SaveChanges();
    }
    public void Activate(int? productId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        Brand? brand = shopDbContext.Brands.Find(product.BrandId);
        if (brand.IsActive == false) throw new NotFoundException($"Activate {brand.Name} brand first");
        Category? category = shopDbContext.Categories.Find(product.CategoryId);
        if (category.IsActive == false) throw new NotFoundException($"Activate {category.Name} category first");
        if (product is null) throw new NotFoundException("Product is not exist");
        if (product.IsActive == true) throw new IsAlreadyException("Product is already active");
        product.IsActive = true;
        shopDbContext.SaveChanges();
    }
    public void Deactivate(int? productId)
    {
        if (productId < 0) throw new WrongFormatException("Wrong product Id format");
        Product? product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("Product is not exist");
        if (product.IsActive == false) throw new IsAlreadyException("Product is already not active");
        product.IsActive = false;
        shopDbContext.SaveChanges();
    }
    public void ShowAllProducts()
    {
        var products = shopDbContext.Products.AsNoTracking().ToList();
        foreach (var product in products)
        {
            string isActive = String.Empty;
            if (product.IsActive == true) isActive = "Active";
            else isActive = "Not active";
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("___________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              $"Status: {isActive}\n" +
                              "___________________________________________________");
            Console.ResetColor();
        }
    }
    public bool IsAnyActiveProduct()
    {
        var product = shopDbContext.Products.FirstOrDefault(p => p.IsActive == true);
        if (product is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsAnyDeactiveProduct()
    {
        var product = shopDbContext.Products.FirstOrDefault(p => p.IsActive == false);
        if (product is not null)
        { 
            return true; 
        }
        else 
        {
            return false;
        }
    }
    public void ShowActiveProducts()
    {
        var products = shopDbContext.Products.Where(p => p.IsActive == true).AsNoTracking().ToList();
        foreach (var product in products)
        {
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("___________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "___________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowDeactiveProducts()
    {
        var products = shopDbContext.Products.Where(p => p.IsActive == false).AsNoTracking().ToList();
        foreach (var product in products)
        {
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("___________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "___________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowAllProductsByBrand(int? brandId)
    {
        if (brandId < 0) throw new WrongFormatException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        var products = shopDbContext.Products.Where(p => p.BrandId == brandId && p.IsActive ==true).AsNoTracking().ToList();
        if (products is null) throw new NotFoundException("No products found");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("___________________________________\n" +
                      "\n" +
                     $"           {brand.Name}\n" +
                      "___________________________________\n" +
                      "\n"); ;
        Console.ResetColor();
        foreach (var product in products)
        {
            Category? category = shopDbContext.Categories.Find(product.CategoryId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Category: {category.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowAllProductsByCategory(int? categoryId)
    {
        if (categoryId < 0) throw new WrongFormatException("Wrong category Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        var products = shopDbContext.Products.Where(p => p.CategoryId == categoryId && p.IsActive == true).AsNoTracking().ToList();
        if (products is null) throw new NotFoundException("No products found");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine($"<<{category.Name}>>");
        Console.ResetColor();
        foreach (var product in products)
        {
            Brand? brand = shopDbContext.Brands.Find(product.BrandId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowProductsByBrandAndCategory(int? brandId, int? categoryId)
    {
        if (categoryId < 0) throw new WrongFormatException("Wrong category Id format");
        if (brandId < 0) throw new WrongFormatException("Wrong brand Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        var products = shopDbContext.Products.Where(p => p.BrandId == brandId && p.CategoryId == categoryId && p.IsActive == true).AsNoTracking().ToList();
        if (products is null) throw new NotFoundException("No products found");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("_____________________________________________________\n" + 
                          "\n" +
                         $"             {brand.Name} / {category.Name}\n"+
                         "_____________________________________________________");
        Console.ResetColor();
        foreach (var product in products)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________");
            Console.ResetColor();
        }
    }
    public bool IsProductsExist()
    {
        var products = shopDbContext.Products.Where(p => p.IsActive == true).AsNoTracking().ToList();
        if (products is not null) return true;
        else return false;
    }
    public void GetProductByName(string? name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("Name can not be null");
        var product = shopDbContext.Products.FirstOrDefault(p => p.Name == name);
        if (product is null) throw new NotFoundException("Product is not found");
        Console.WriteLine("_____________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________");
    }
}
