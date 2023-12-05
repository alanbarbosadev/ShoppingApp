using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Infra.DataContext;
using ShoppingApp.Infra.Repositories;

namespace ShoppingApp.Infra.Extensions
{
    public static class ApplicationServiceContainerExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShoppingAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
            //services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            return services;
        }
    }
}
