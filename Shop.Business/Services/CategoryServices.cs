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
}
