﻿using Ecommerce.Repository.Specifications;
using Ecommerce.Repository.Specifications.ProductSpec;
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
        public async Task<ActionResult<IEnumerable<ProductDetailsDto>>> GetAllProduct()
        {
            //var spec = new BaseSpcefication<Product, int>();
            return Ok(await _productService.GetAllProductsAsync());


        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDetailsDto>>> GetAllProductSpec()
        {
            var spec = new ProductSpecifications();
            return Ok(await _productService.GetAllProductsWithSpecAsync(spec));

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
        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductById(int id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));

        }
        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetProductByIdWithSpec(int? id)
        {
            var spec = new ProductSpecifications();
            return Ok(await _productService.GetProductWithSpecAsync(spec));

        }
    }
}
