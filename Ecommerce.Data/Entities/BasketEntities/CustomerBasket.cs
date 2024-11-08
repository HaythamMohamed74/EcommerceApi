using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Entities.BasketEntities
{
    public class CustomerBasket
    {
        public string Id { get; set; }

        public List<BasketItem> Items { get; set; }
        public CustomerBasket(string id )
        {
            Id = id;
        }
    }
}
