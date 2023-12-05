using ShoppingApp.Domain.Entities;
using System.Linq;

namespace ShoppingApp.Application.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : Specification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(Guid id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productSpecificationParams) 
            : base(x => (string.IsNullOrEmpty(productSpecificationParams.Search) || x.Name.ToLower().Contains(productSpecificationParams.Search)) && (!productSpecificationParams.TypeId.HasValue || x.ProductTypeId == productSpecificationParams.TypeId) && (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name); //Default OrderBy -> Name
            ApplyPagination(productSpecificationParams.PageSize, productSpecificationParams.PageSize * (productSpecificationParams.PageIndex - 1));

            if (!string.IsNullOrEmpty(productSpecificationParams.Sort))
            {
                switch (productSpecificationParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
        }
    }
}
