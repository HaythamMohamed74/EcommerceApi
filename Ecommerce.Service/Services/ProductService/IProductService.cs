using Ecommerce.Repository.Specifications;
using Ecommerce.Repository.Specifications.ProductSpec;
using Ecommerce.Service.Helper;
using Ecommerce.Service.Services.ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.ProductService
{
    public interface IProductService
    {


        Task<PaginationDto<ProductDetailsDto>> GetAllProductsAsync(ProductSpecificationItems productSpecificationItems); // pageSize ,page index
        //Task<IEnumerable<ProductDetailsDto>> GetAllProductsFilterAsync(int? brandId, int? typeId); // pageSize ,page index
        //Task<ProductDetailsDto> GetAllProductsAsyncOrderingByPrice(); // pageSize ,page index
        //Task<IEnumerable<ProductDetailsDto>> GetAllProductsWithSpecAsync(ProductSpecifications specification);

        Task<ProductDetailsDto> GetProductByIdAsync(int id);
        //Task<ProductDetailsDto> GetProductWithSpecAsync(ProductSpecifications productSpecifications );

        Task<IEnumerable<BrandTypeDetailsDto>> GetAllBrandsAsync(); //bool useCaching =true
        Task<IEnumerable<BrandTypeDetailsDto>> GetAllTypesAsync(); //bool useCaching =true


    }
}
