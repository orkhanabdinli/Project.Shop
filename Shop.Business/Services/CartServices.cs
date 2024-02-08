using Shop.Business.Utilities.Exceptions;
using Shop.Core.Entities;
using Shop.DataAccess;

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
    public async Task AddToCart(int? userId, int? productId)
    {
        var produc = shopDbContext.Products.Find(productId);
        if (produc is null) throw new NotFoundException("The product is not exist ");
        CartProducts cartProducts = new()
        {
            CartId = userId,
            ProductId = productId
        };
        await shopDbContext.CartProducts.AddAsync(cartProducts);
        await shopDbContext.SaveChangesAsync();
    }
    public async Task RemoveFromCart(int? userId, int? productId)
    {
        var product = shopDbContext.Products.Find(productId);
        if (product is null) throw new NotFoundException("The product is not exist ");
        var cartProduct = shopDbContext.CartProducts.FirstOrDefault(x => x.ProductId  == productId);
        shopDbContext.CartProducts.Remove(cartProduct);
        await shopDbContext.SaveChangesAsync();
    }
    public async Task GetFromCart(int? userId)
    {
        var cartProducts = shopDbContext.CartProducts.Where(x => x.CartId ==  userId).ToList();
        if (cartProducts is null) throw new NotFoundException("___________________________________\n" +
                                                              "\n" +
                                                              "           Cart is empty\n" +
                                                              "___________________________________\n" +
                                                              "\n");
        foreach (var cartProduct in cartProducts) 
        {
            var product = shopDbContext.Products.Find(cartProduct.ProductId);
            var brand = shopDbContext.Brands.Find(product.BrandId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("_____________________________________________________\n" +
                              "                                                             \n" +
                              $"ID: {product.Id}\n" +
                              $"Name: {product.Name}\n" +
                              $"Brand: {brand.Name}\n" +
                              $"Description: {product.Description}\n" +
                              $"Price: {product.Price}  Stock: {product.Stock}\n" +
                              "_____________________________________________________");
        }
    }
}
