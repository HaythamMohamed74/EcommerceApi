using Ecommerce.Data.Entities.BasketEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
      public interface  IBasketRepository
    {
        public Task<CustomerBasket?> GetBasketAsync(string id);
        public Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket);

        public Task<bool> DeleteBasketAsync(string id);
    }
}
