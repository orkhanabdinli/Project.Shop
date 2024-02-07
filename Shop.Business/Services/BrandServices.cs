using Microsoft.EntityFrameworkCore;
using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

namespace Shop.Business.Services;

public class BrandServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Brand> Create(string name)
    {
        if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("You must enter name");
        Brand? brand1 = await shopDbContext.Brands.FirstOrDefaultAsync(b => b.Name == name);
        if (brand1 is not null) throw new AlreadyExistsException($"{name} brand is already exist");
        Brand brand = new Brand()
        {
            Name = name
        };
        await shopDbContext.Brands.AddAsync(brand);
        await shopDbContext.SaveChangesAsync();
        return brand;
    }
    public void ChangeName(int brandId, string newName)
    {
        if (brandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        Brand? brand1 = shopDbContext.Brands.FirstOrDefault(b => b.Name == newName);
        if (brand1 is not null) throw new AlreadyExistsException($"{newName} Brand is already exist");
        brand.Name = newName;
        shopDbContext.SaveChanges();
    }
    public void ShowAllBrands()
    {
        var brands = shopDbContext.Brands.AsNoTracking().ToList();
        foreach (var brand in brands) 
        {
            string IsActive = String.Empty;
            if (brand.IsActive == true) IsActive = "Active";
            else IsActive = "Not active";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {brand.Id}  Name: {brand.Name}  Status: {IsActive}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowActiveBrands()
    {
        var brands = shopDbContext.Brands.Where(b => b.IsActive == true).AsNoTracking().ToList();
        foreach (var brand in brands)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {brand.Id}  Name: {brand.Name}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ShowDeactiveBrands()
    {
        var brands = shopDbContext.Brands.Where(b => b.IsActive == false).AsNoTracking().ToList();
        foreach (var brand in brands)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("______________________________________________________________\n" +
                              "                                                             \n" +
                             $"ID: {brand.Id}  Name: {brand.Name}\n" +
                              "______________________________________________________________");
            Console.ResetColor();
        }
    }
    public void ActivateBrand(int brandId)
    {
        if (brandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (brand.IsActive == true) throw new IsAlreadyException($"{brand.Name} Brand is already active");
        brand.IsActive = true;
        shopDbContext.SaveChanges();
    }
    public void DeactivateBrand(int brandId)
    {
        if (brandId < 0) throw new ArgumentOutOfRangeException("Wrong brand Id format");
        Brand? brand = shopDbContext.Brands.Find(brandId);
        if (brand is null) throw new NotFoundException("Brand is not existing");
        if (brand.IsActive == false) throw new IsAlreadyException($"{brand.Name} Brand is already deactive");
        brand.IsActive = false;
        shopDbContext.SaveChanges();
    }
    public bool IsBrandsExist()
    {
        var brands = shopDbContext.Brands.Where(b => b.IsActive == true).AsNoTracking().ToList(); 
        if (brands is not null) return true;
        else return false;
    }
    public bool IsAnyActiveBrand()
    {
        var brand = shopDbContext.Brands.FirstOrDefault(b => b.IsActive == true);
        if (brand is not null)
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
        var brand = shopDbContext.Brands.FirstOrDefault(b => b.IsActive == false);
        if (brand is not null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
