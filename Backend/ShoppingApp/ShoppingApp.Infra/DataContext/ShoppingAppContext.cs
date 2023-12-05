using Microsoft.EntityFrameworkCore;
using ShoppingApp.Domain.Entities;
using System.Reflection;

namespace ShoppingApp.Infra.DataContext
{
    public class ShoppingAppContext : DbContext
    {
        public ShoppingAppContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
