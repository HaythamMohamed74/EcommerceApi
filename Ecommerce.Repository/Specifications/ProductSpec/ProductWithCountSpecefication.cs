using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications.ProductSpec
{
    public class ProductWithCountSpecefication:BaseSpcefication<Product>
    {
        public ProductWithCountSpecefication(ProductSpecificationItems productSpecificationItems) : base(p =>
         (string.IsNullOrEmpty(productSpecificationItems.SearchName) || p.Name.ToLower().Contains(productSpecificationItems.SearchName.ToLower())) &&
         (!productSpecificationItems.BrandId.HasValue || p.BrandId == productSpecificationItems.BrandId) &&
         (!productSpecificationItems.TypeId.HasValue || p.TypeId == productSpecificationItems.TypeId))
        {

        }
    }
}
