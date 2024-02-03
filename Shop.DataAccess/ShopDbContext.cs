using Microsoft.EntityFrameworkCore;
using Shop.Core.Entities;
using System.Text.RegularExpressions;

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
            .HasKey(x => x.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.IsActive)
            .HasDefaultValue(true);
        modelBuilder.Entity<User>()
            .HasOne(u => u.Cart)
            .WithOne(c => c.User)
            .HasForeignKey<Cart>(c => c.Id);

    }
    public DbSet<User> Users { get; set; } = null!;
}
