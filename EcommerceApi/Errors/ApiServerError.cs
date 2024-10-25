namespace EcommerceApi.Errors
{
    public class ApiServerError:ApiResponse
    {
        public string? Details { get; set; }
        public ApiServerError(int statusCode,string? message=null,string? details=null):base(statusCode,message)
        {
            Details = details;
        }
    }
}
