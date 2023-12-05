using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Application.Specifications
{
    public class ProductsWithFiltersForCountSpecification : Specification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecificationParams productSpecificationParams) 
            : base(x => (string.IsNullOrEmpty(productSpecificationParams.Search) || x.Name.ToLower().Contains(productSpecificationParams.Search)) && (!productSpecificationParams.TypeId.HasValue || x.ProductTypeId == productSpecificationParams.TypeId) && (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId))
        {
            
        }
    }
}
