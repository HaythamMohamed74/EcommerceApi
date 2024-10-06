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


        Task<IEnumerable<ProductDetailsDto>> GetAllProductsAsync(); // pageSize ,page index

        Task<ProductDetailsDto> GetProductByIdAsync(int id);

        Task<IEnumerable<BrandTypeDetailsDto>> GetAllBrandsAsync(); //bool useCaching =true
        Task<IEnumerable<BrandTypeDetailsDto>> GetAllTypesAsync(); //bool useCaching =true


    }
}
