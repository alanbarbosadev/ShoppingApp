using ShoppingApp.Application.Repositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infra.DataContext;

namespace ShoppingApp.Infra.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingAppContext context) : base(context)
        {
            
        }
    }
}
