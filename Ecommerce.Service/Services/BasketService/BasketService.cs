using Ecommerce.Data.Entities.BasketEntities;
using Ecommerce.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services.BasketService
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<bool> DeleteBasket(string id)
        {
            return await _basketRepository.DeleteBasketAsync(id);
        }

        public async Task<CustomerBasket?> GetBasket(string id)
        {
            var basket= await _basketRepository.GetBasketAsync(id);
            return basket ?? new CustomerBasket(id);
        }

        public async Task<CustomerBasket?> UpdateBasket(CustomerBasket customerBasket)
        {
            var CreatedOrUpdate= await _basketRepository.UpdateBasketAsync(customerBasket);

            return CreatedOrUpdate is null ?null  : CreatedOrUpdate;
        }
    }
}
