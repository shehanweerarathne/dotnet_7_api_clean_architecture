using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Repositories.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<Product> UpdateProductAsync(Product product);
    Task<int> DeleteProductAsync(int id);
    Task<List<Category>> GetCategoriesAsync();
}