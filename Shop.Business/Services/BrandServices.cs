using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class BrandServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async void Create(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Brand? brand1 = await shopDbContext.Brands.FirstOrDefaultAsync(b => b.Name == name);
        if (brand1 is not null) throw new AlreadyExistsException($"{name} brand is already exist");
        Brand brand = new Brand()
        {
            Name = name,
            CreatedDate = DateTime.Now,
            LastModifiedDate = DateTime.Now
        };
        await shopDbContext.Brands.AddAsync(brand);
        await shopDbContext.SaveChangesAsync();
    }
}
