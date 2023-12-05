using ShoppingApp.Application.Repositories;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Infra.DataContext;

namespace ShoppingApp.Infra.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(ShoppingAppContext context) : base(context)
        {
            
        }
    }
}
