using Ecommerce.Repository.Specifications;
using Ecommerce.Repository.Specifications.ProductSpec;
using Ecommerce.Service.Helper;
using Ecommerce.Service.Services.ProductService;
using Ecommerce.Service.Services.ProductService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
       
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int id)
        {
           
            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<PaginationDto<ProductDetailsDto>>>GetAllProduct([FromQuery] ProductSpecificationItems productSpecificationItems)
        {
            
            return Ok(await _productService.GetAllProductsAsync(productSpecificationItems));

            //return Ok(await _productService.GetAllProductsAsync());

        }  
        
  

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandTypeDetailsDto>>> GetAllBrands()
        {
            return Ok(await _productService.GetAllBrandsAsync());

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandTypeDetailsDto>>> GetAllTypes()
        {
          return Ok(await _productService.GetAllTypesAsync());
        }

    }
}
