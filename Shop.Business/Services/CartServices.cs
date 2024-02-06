using Shop.Core.Entities;
using Shop.DataAccess;
using System.Reflection.Metadata.Ecma335;

namespace Shop.Business.Services;

public class CartServices
{
    ShopDbContext shopDbContext = new ShopDbContext();
    public async Task<Cart> Create(int userId)
    {
        Cart? cart1 = await shopDbContext.Carts.FindAsync(userId);
        if (cart1 is null) 
        {
            Cart cart = new Cart()
            {
              Id = userId
            };
            await shopDbContext.Carts.AddAsync(cart);
            await shopDbContext.SaveChangesAsync();
            return cart;
        }return cart1;
    }
}
