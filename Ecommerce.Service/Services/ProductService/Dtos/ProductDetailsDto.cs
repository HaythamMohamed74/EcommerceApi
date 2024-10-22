using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.ProductService.Dtos
{
    public class ProductDetailsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public string PictureUrl { get; set; }

        public string Brand { get; set;}
        public string Type { get; set;}
         public int ProductBrandId { get; set; }
         public int ProductTypeId { get; set; }
        public DateTime CreatedAt { get; set; }




    }
}
