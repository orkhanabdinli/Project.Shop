using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;

namespace Shop.DataAccess;

public class ShopDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ShopDb;Trusted_Connection=True;Encrypt=false");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.Id);

        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<User>()
            .Property(u => u.IsAdmin)
            .HasDefaultValue(false);

        modelBuilder.Entity<User>()
            .Property(u => u.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<User>()
            .Property(u => u.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);

        modelBuilder.Entity<Cart>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Cart>()
            .Property(c => c.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Cart>()
            .Property(c => c.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Brand>()
            .Property(b => b.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Brand>()
            .Property(b => b.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Brand>()
            .Property(b => b.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Discount>()
            .Property(d => d.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Discount>()
            .Property(d => d.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Discount>()
            .Property(d => d.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);

        modelBuilder.Entity<Invoice>()
            .Property(i => i.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Invoice>()
            .Property(i => i.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Invoice>()
            .Property(i => i.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);

        modelBuilder.Entity<Product>()
            .Property(p => p.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Stock)
            .HasDefaultValue(0);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.DiscountId)
            .HasDefaultValue(null);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Wallet>()
            .Property(w => w.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<Wallet>()
            .Property(w => w.Balance)
            .HasDefaultValue(0);

        modelBuilder.Entity<Wallet>()
            .Property(w => w.CreatedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<Wallet>()
            .Property(w => w.LastModifiedDate)
            .HasDefaultValue(DateTime.Now);
        
        modelBuilder.Entity<CartProducts>()
            .Property(w => w.AmountOfProducts)
            .HasDefaultValue(1);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Wallet>()
            .Property(w => w.Balance).HasPrecision(8, 2);

        modelBuilder.Entity<Wallet>()
            .HasKey(w => w.Id);

        modelBuilder.Entity<Wallet>()
            .HasOne(w => w.User)
            .WithMany(u => u.Wallets)
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<Invoice>()
            .HasKey(i => i.Id);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.User)
            .WithMany(u => u.Invoices);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Wallet)
            .WithMany(w => w.Invoices);
            
        modelBuilder.Entity<InvoiceProducts>()
            .HasKey(ip => new { ip.InvoiceId, ip.ProductId });

        modelBuilder.Entity<Invoice>()
           .HasMany(i => i.InvoiceProducts)
           .WithOne(ip => ip.Invoice)
           .HasForeignKey(i => i.InvoiceId);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price).HasPrecision(8,2);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.InvoiceProducts)
            .WithOne(ip => ip.Product)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<CartProducts>()
            .HasKey(cp => new { cp.CartId, cp.ProductId });

        modelBuilder.Entity<Product>()
            .HasMany(p => p.CartProducts)
            .WithOne(cp => cp.Product)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<Cart>()
            .HasMany(c => c.CartProducts)
            .WithOne(cp => cp.Cart)
            .HasForeignKey(c => c.CartId);

        modelBuilder.Entity<Product>()
           .HasOne(p => p.Category)
           .WithMany(c => c.Products)
           .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
           .HasOne(p => p.Brand)
           .WithMany(b => b.Products)
           .HasForeignKey(p => p.BrandId);
        
        modelBuilder.Entity<Product>()
           .HasOne(p => p.Discount)
           .WithMany(d => d.Products)
           .HasForeignKey(p => p.DiscountId);
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Brand> Brands { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartProducts> CartProducts { get; set; } = null!;
    public DbSet<Discount> Discounts { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<InvoiceProducts> InvoiceProducts { get; set; } = null!;
    public DbSet<Wallet> Wallets { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;



}
