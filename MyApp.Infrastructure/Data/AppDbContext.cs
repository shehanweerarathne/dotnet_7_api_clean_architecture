using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne<Category>(s => s.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(s => s.CategoryId);
        modelBuilder.Entity<Category>().HasData(
          new Category { Id = 1, Name = "Category1" },
          new Category { Id = 2, Name = "Category2" },
          new Category { Id = 3, Name = "Category3" }
      );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Product1",Price=100,  CategoryId = 1 },
            new Product { Id = 2, Name = "Product2", Price = 900,  CategoryId = 2 },
            new Product { Id = 3, Name = "Product3", Price = 150, CategoryId = 3 }
        );

    }
}