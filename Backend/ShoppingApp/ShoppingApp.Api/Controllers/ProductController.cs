using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Api.Dtos;
using ShoppingApp.Api.Helpers;
using ShoppingApp.Application.Repositories;
using ShoppingApp.Application.Specifications;
using ShoppingApp.Domain.Entities;

namespace ShoppingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProductsAsync([FromQuery] ProductSpecificationParams productSpecificationParams)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(productSpecificationParams);

            //a new specification for count is needed, cause if you use the ProductsWithTypesAndBrandsSpecification, only the paginated result will be counted
            var specificationForCount = new ProductsWithFiltersForCountSpecification(productSpecificationParams);

            var products = await _productRepository.GetAllWithSpecificationAsync(specification);

            var count = await _productRepository.CountAsync(specificationForCount);

            var data = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);

            return Ok(new Pagination<ProductToReturnDto>(productSpecificationParams.PageIndex, productSpecificationParams.PageSize, count, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetAllProductsAsync(Guid id)
        {
            var specification = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _productRepository.GetByIdWithSpecificationAsync(specification);

            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }

        //[HttpGet("brands")]
        //public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllProductBrandsAsync()
        //{
        //    return Ok(await _productRepository.GetAllProductBrandsAsync());
        //}

        //[HttpGet("types")]
        //public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllProductTypeAsync()
        //{
        //    return Ok(await _productRepository.GetAllProductTypesAsync());
        //}
    }
}
