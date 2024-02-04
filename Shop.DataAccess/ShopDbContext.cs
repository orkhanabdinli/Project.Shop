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
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Cart>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Brand>()
            .Property(b => b.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Category>()
            .Property(c => c.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Discount>()
            .Property(d => d.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Invoice>()
            .Property(i => i.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Product>()
            .Property(p => p.IsActive)
            .HasDefaultValue(true);
        
        modelBuilder.Entity<Wallet>()
            .Property(w => w.IsActive)
            .HasDefaultValue(true);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.PhoneNumber)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.Id);

        modelBuilder.Entity<CartProducts>()
            .HasOne(cp => cp.Carts)
            .WithMany(c => c.CartProducts)
            .HasForeignKey(c => c.Id);

        modelBuilder.Entity<Wallet>()
            .Property(w => w.Balance).HasPrecision(8, 2);

        modelBuilder.Entity<Wallet>()
            .HasOne(w => w.User)
            .WithMany(u => u.Wallets)
            .HasForeignKey(u => u.Id);
        
        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.User)
            .WithMany(u => u.Invoices)
            .HasForeignKey(u => u.Id);

        modelBuilder.Entity<Invoice>()
            .HasOne(i => i.Wallet)
            .WithMany(w => w.Invoices)
            .HasForeignKey(w => w.Id);

        modelBuilder.Entity<InvoiceProducts>()
            .HasOne(ip => ip.Invoices)
            .WithMany(i => i.InvoiceProducts)
            .HasForeignKey(i => i.Id);

        modelBuilder.Entity<Product>()
            .Property(p => p.Price).HasPrecision(8,2);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.InvoiceProducts)
            .WithOne(ip => ip.Products)
            .HasForeignKey(p => p.Id);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.CartProducts)
            .WithOne(cp => cp.Products)
            .HasForeignKey(p => p.Id);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(c => c.Id);

        modelBuilder.Entity<Brand>()
           .HasMany(b => b.Products)
           .WithOne(p => p.Brand)
           .HasForeignKey(b => b.Id);

        modelBuilder.Entity<Discount>()
           .HasMany(d => d.Products)
           .WithOne(p => p.Discount)
           .HasForeignKey(d => d.Id);
    }
    public DbSet<User> Users { get; set; } = null!;
}
