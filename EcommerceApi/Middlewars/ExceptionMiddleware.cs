using EcommerceApi.Errors;

namespace EcommerceApi.Middlewars
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _hostingEnvironment;

        public ExceptionMiddleware(RequestDelegate requestDelegate, ILogger<ExceptionMiddleware> logger, IHostEnvironment hostingEnvironment)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task  InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var response = _hostingEnvironment.IsDevelopment()
                 ? new ApiServerError(StatusCodes.Status500InternalServerError, ex.Message, ex.StackTrace)
                 : new ApiServerError(StatusCodes.Status500InternalServerError);

                await context.Response.WriteAsJsonAsync(response);


            }
        }
    }
}
