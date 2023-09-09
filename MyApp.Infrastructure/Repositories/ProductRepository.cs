using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;
using MyApp.Infrastructure.Repositories.Interfaces;

namespace MyApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetProductsAsync()
    {
        List<Product> products = await _context.Products
            .Include(x => x.Category).ToListAsync();
        return products;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        try
        {
            var product = await _context.Products
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        try
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        try
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<int> DeleteProductAsync(int id)
    {
        try
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                return await _context.SaveChangesAsync();
            }
            return  0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        catch (Exception)
        {

            throw;
        }
    }
}