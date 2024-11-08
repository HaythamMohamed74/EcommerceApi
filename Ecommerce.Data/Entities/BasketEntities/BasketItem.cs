﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities.BasketEntities
{
    public class BasketItem
    {
        public int Id { get; set; }   //productId
        public string Name { get; set; } 
        public string PicUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
