using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Repositories.Extensions
{
    internal static class ProductExtension
    {
        // search product by name
        public static IQueryable<Product> Search(this IQueryable<Product> products, string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return products;

            return products.Where(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
