using ShoppingApp.Domain.Entities;
using System.Text.Json;

namespace ShoppingApp.Infra.DataContext.Seed
{
    public class ShoppingAppContextSeed
    {
        public static async Task SeedAsync(ShoppingAppContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsFile = File.ReadAllText("../ShoppingApp.Infra/DataContext/Seed/Data/brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsFile);

                context.ProductBrands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesFile = File.ReadAllText("../ShoppingApp.Infra/DataContext/Seed/Data/types.json");

                var types = JsonSerializer.Deserialize<List<ProductType>>(typesFile);

                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var productsFile = File.ReadAllText("../ShoppingApp.Infra/DataContext/Seed/Data/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsFile);

                context.Products.AddRange(products);
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
