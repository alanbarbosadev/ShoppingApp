using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Infra.DataContext;
using ShoppingApp.Infra.Repositories;

namespace ShoppingApp.Api.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ShoppingAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddCors(options => options.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

            return services;
        }
    }
}
