using Ecommerce.Data.Entities.BasketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.BasketService
{
    public interface  IBasketService
    {
        public Task<CustomerBasket?>GetBasket(string id);

        public Task<CustomerBasket?> UpdateBasket(CustomerBasket customerBasket);
        public Task<bool> DeleteBasket(string id);



    }
}
