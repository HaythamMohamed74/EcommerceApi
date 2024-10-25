using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("server-error")]
        public IActionResult ServerError()
        {
            // Simulate an unhandled exception to trigger a 500 Internal Server Error.
            throw new Exception("This is a fake server error.");
        }
    }
}
