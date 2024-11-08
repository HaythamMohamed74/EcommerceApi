using Ecommerce.Data.Entities.BasketEntities;
using Ecommerce.Service.Services.BasketService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket?>> GetCustomerBasket(string id)
        {
            return Ok(await _basketService.GetBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket?>> UpdateCustomerBasket(CustomerBasket basket)
        {
            return Ok(await _basketService.UpdateBasket(basket));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCustomerBasket(string id)
        {
            return Ok (await _basketService.DeleteBasket(id));
        }

    }
}
