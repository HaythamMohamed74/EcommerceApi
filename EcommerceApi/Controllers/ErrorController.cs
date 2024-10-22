using EcommerceApi.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceApi.Controllers
{
    [Route("error/{Code}")]
    [ApiController]
    [ApiExplorerSettings (IgnoreApi =true)]
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error(int Code)
        {
            return NotFound(new ApiResponse(Code));
        }
    }
}
