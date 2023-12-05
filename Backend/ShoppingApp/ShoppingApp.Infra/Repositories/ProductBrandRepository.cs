using ShoppingApp.Application.Repositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infra.DataContext;

namespace ShoppingApp.Infra.Repositories
{
    public class ProductBrandRepository : Repository<ProductBrand>, IProductBrandRepository
    {
        public ProductBrandRepository(ShoppingAppContext context) : base(context)
        {
            
        }
    }
}
