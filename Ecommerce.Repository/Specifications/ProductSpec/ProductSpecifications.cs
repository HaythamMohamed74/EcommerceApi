using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications.ProductSpec
{
    public class ProductSpecifications : BaseSpcefication<Product>
    {
        public ProductSpecifications()
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }

        //public ProductSpecifications(ProductSpecificationItems productSpecificationItems) :
        //    base(
        //        p => (p.BrandId == productSpecificationItems.BrandId || !productSpecificationItems.BrandId.HasValue)
        //    &&  p.TypeId==productSpecificationItems.TypeId  || !productSpecificationItems.TypeId.HasValue)
        //{
        //    AddIncludes(p => p.Brand);
        //    AddIncludes(p => p.Type);
        //}

        public ProductSpecifications(int? id) : base(p=>p.Id==id)
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }
    }

}
