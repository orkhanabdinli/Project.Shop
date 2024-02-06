using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class CategoryServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Category> Create(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Category? category1 = await shopDbContext.Categories.FirstOrDefaultAsync(c => c.Name == name);
        if (category1 is not null) throw new AlreadyExistsException($"{name} category is already exist");
        Category category = new Category()
        {
            Name = name
        };
        await shopDbContext.Categories.AddAsync(category);
        await shopDbContext.SaveChangesAsync();
        return category;
    }
    public void ChangeName(int categoryId, string newName)
    {
        if (categoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        Category? category1 = shopDbContext.Categories.FirstOrDefault(c => c.Name == newName);
        if (category1 is not null) throw new AlreadyExistsException($"{newName} category is already exist");
        category.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ShowAllCategories()
    {
        var categories = shopDbContext.Categories.AsNoTracking().ToList();
        foreach (var category in categories)
        {
            string isActive = String.Empty;
            if (category.IsActive == true)
            {
                isActive = "Active";
            }
            else isActive = "Not active";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {category.Id}  Name: {category.Name}  Status: {isActive}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
   
    public void ActivateCategory(int categoryId)
    {
        if (categoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        if (category.IsActive == true) throw new IsAlreadyException($"{category.Name} Category is already active");
        category.IsActive = false;
        shopDbContext.SaveChanges();
    }
    public void DeactivateCategory(int categoryId)
    {
        if (categoryId < 0) throw new ArgumentOutOfRangeException("Wrong category Id format");
        Category? category = shopDbContext.Categories.Find(categoryId);
        if (category is null) throw new NotFoundException("Category is not existing");
        if (category.IsActive == false) throw new IsAlreadyException($"{category.Name} Category is already deactive");
        category.IsActive = false;
        shopDbContext.SaveChanges();
    }
}
