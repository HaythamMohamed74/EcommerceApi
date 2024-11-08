using Ecommerce.Data.Entities.BasketEntities;
using Ecommerce.Repository.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis.GetDatabase();
        }
        public async Task<CustomerBasket?> GetBasketAsync(string id)
        {
            var basket= await _redis.StringGetAsync(id);
            //var custBasketJson =JsonSerializer.Deserialize<CustomerBasket>(basket);
            return basket.IsNull? null: JsonSerializer.Deserialize<CustomerBasket>(basket);

        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var searilzeBasket = JsonSerializer.Serialize(customerBasket);
            var basket = await _redis.StringSetAsync(customerBasket.Id, searilzeBasket, TimeSpan.FromDays(1));
            if (!basket)
            {
                return null;
            }
            return await GetBasketAsync(customerBasket.Id);

        }

        public async Task<bool> DeleteBasketAsync(string id)
        {
            return await  _redis.KeyDeleteAsync(id);
        }

      

      
    }
}
