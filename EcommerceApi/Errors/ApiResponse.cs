
namespace EcommerceApi.Errors
{
    public class ApiResponse
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int? _statusCode, string? _message = null)
        {
            StatusCode = _statusCode;
            Message = _message ?? GetDefultMessageForStatusCode(_statusCode);
        }

        private string? GetDefultMessageForStatusCode(int? statusCode)
        {
            return statusCode switch
            {
                500 => "Internal Server Error",
                400 => "Bad Request", ///validationError
                401 => "UnAuthrized",
                404 => "NotFound",
                _ => null,
            };
        }
    }
}