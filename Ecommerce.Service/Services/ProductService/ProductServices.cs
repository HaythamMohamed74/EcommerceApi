using AutoMapper;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Repository.Specifications;
using Ecommerce.Repository.Specifications.ProductSpec;
using Ecommerce.Service.Helper;
using Ecommerce.Service.Services.ProductService.Dtos;
namespace Ecommerce.Service.Services.ProductService

{
    public class ProductServices : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ProductDetailsDto> GetProductByIdAsync(int id)
        {
            var spec = new ProductSpecifications(id);

            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(spec);

            if (product is null)
            {

                throw new DllNotFoundException($"Not Found Product with {id}");
            }

            var productDetailsMapped = _mapper.Map<ProductDetailsDto>(product);


            return productDetailsMapped;

        }

        public async Task<PaginationDto<ProductDetailsDto>> GetAllProductsAsync(ProductSpecificationItems productSpecificationItems)
        {
            var spec = new ProductSpecifications(productSpecificationItems);
            var products = await _unitOfWork.Repository<Product, int>().GetAllAsync(spec);

            IReadOnlyList<ProductDetailsDto> productDetailsMapped = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);
            var specCount=new ProductWithCountSpecefication(productSpecificationItems);
            var count= await _unitOfWork.Repository<Product, int>().GetCountAsync(specCount);

            var pag = new PaginationDto<ProductDetailsDto>(
                productDetailsMapped.ToList(),
                productSpecificationItems.PageIndex,
                productSpecificationItems.PageSize,
                count
                );
            

            return pag;
        }

        public async Task<IEnumerable<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var spec = new BaseSpcefication<ProductBrand>();
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync(spec);

            IEnumerable<BrandTypeDetailsDto> brandsMapped = _mapper.Map<IEnumerable<BrandTypeDetailsDto>>(brands);

            return brandsMapped;
        }


        public async Task<IEnumerable<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync(null);

            IEnumerable<BrandTypeDetailsDto> typesMapped = _mapper.Map<IEnumerable<BrandTypeDetailsDto>>(types);

            return typesMapped;
        }



        //public async Task<IEnumerable<ProductDetailsDto>> GetAllProductsWithSpecAsync(ProductSpecifications specification)
        //{

        //    var products = await _unitOfWork.Repository<Product, int>().GetAllWithSpecAsync(specification);
        //    IEnumerable<ProductDetailsDto> productDetailsMapped = _mapper.Map<IEnumerable<ProductDetailsDto>>(products);
        //    return productDetailsMapped;
        //}

        //public async Task<ProductDetailsDto> GetProductWithSpecAsync(ProductSpecifications specification)
        //{
        //    var product = await _unitOfWork.Repository<Product, int>().GetEntityWithSpec(specification);
        //    var  productDetailsMapped = _mapper.Map<ProductDetailsDto>(product);
        //    return productDetailsMapped;

        //}

        #region Manual Mapp
        //IEnumerable<ProductDetailsDto> productDetailsDto = products.Select(p=> new ProductDetailsDto{

        //    Id = p.Id, 
        //    Name = p.Name,
        //    CreatedAt=p.CreatedAt,
        //    PictureUrl=p.PictureUrl,
        //    Price=p.Price,
        //    Description=p.Description,
        //    Brand=p.Brand.Name,
        //    Type=p.Type.Name

        //}); 
        #endregion
    }
}

    
