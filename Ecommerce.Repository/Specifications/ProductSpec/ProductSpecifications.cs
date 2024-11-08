using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.IdentityModel.Tokens;
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
        public ProductSpecifications(ProductSpecificationItems productSpecificationItems) : base(p =>
        //left is false make condition on right
          (string.IsNullOrEmpty(productSpecificationItems.SearchName) || p.Name.ToLower().Contains(productSpecificationItems.SearchName.ToLower()))&&
            (!productSpecificationItems.BrandId.HasValue || p.BrandId == productSpecificationItems.BrandId) &&
            (!productSpecificationItems.TypeId.HasValue || p.TypeId == productSpecificationItems.TypeId))
        {
            AddIncludes(p => p.Brand);
            AddIncludes(p => p.Type);
            //AddSearching(productSpecificationItems.SearchName);
            //AddSearching(p=>p.Name.Contains(productSpecificationItems.SearchName));
            if (!string.IsNullOrEmpty(productSpecificationItems.Sort))
            {
                switch (productSpecificationItems.Sort)
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

            AddPagination(productSpecificationItems.PageIndex, productSpecificationItems.PageSize);







        }



    }
}
