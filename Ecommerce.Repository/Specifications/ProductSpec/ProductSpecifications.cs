using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
        
        // ctor used for get specific Product by id 
        public ProductSpecifications(int? id) : base(p => p.Id == id)
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
        }

        //ctor to sort with Filter
        public ProductSpecifications(string? sort,int?  brandId, int? typeId) : base(p =>
            (!brandId.HasValue || p.BrandId == brandId) &&
            (!typeId.HasValue || p.TypeId == typeId))
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDesc(p => p.Price);
                        break;
                    case "Name":
                        AddOrderBy(p => p.Name);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }






        }



    }
}
