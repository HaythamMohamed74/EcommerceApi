using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Services.ProductService.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.ProductService
{
    public class ProductServices : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();

            IEnumerable<BrandTypeDetailsDto> brandsDto = brands.Select(p => new BrandTypeDetailsDto
            {

                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt

            });
            return brandsDto;
        }

        public async Task<IEnumerable<ProductDetailsDto>> GetAllProductsAsync()
        {

            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync();

            IEnumerable<ProductDetailsDto> productDetailsDto = products.Select(p=> new ProductDetailsDto{
            
                Id = p.Id, 
                Name = p.Name,
                CreatedAt=p.CreatedAt,
                PictureUrl=p.PictureUrl,
                Price=p.Price,
                Description=p.Description,
                Brand=p.Brand.Name,
                Type=p.Type.Name

            });
            return productDetailsDto;
        }

        public async Task<IEnumerable<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();

            IEnumerable<BrandTypeDetailsDto> typesDtos = types.Select(p => new BrandTypeDetailsDto
            {

                Id = p.Id,
                Name = p.Name,
                CreatedAt = p.CreatedAt

            });
            return typesDtos;
        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int id)
        {
           var product= await _unitOfWork.Repository<Product,int>().GetByIdAsync(id);

            if (product is null)
            {
                throw new Exception("product not found ");
            }


            var productDetailsDto = new ProductDetailsDto
            {

                Id = product.Id,
                Name = product.Name,
                CreatedAt = product.CreatedAt,
                PictureUrl=product.PictureUrl,
                Brand=product.Brand.Name,
                Type=product.Type.Name

            };
            return productDetailsDto;

                
        }
    }
}

    
