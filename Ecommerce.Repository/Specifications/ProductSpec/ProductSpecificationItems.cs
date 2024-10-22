using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Specifications.ProductSpec
{
    public class ProductSpecificationItems
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }

        public string? Sort { get; set; }

        private int pageSize=10;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value>10?10:value; }
        }

        public int PageIndex { get; set; } = 1;



    }
}
