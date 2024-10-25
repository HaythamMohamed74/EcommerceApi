namespace EcommerceApi.Errors
{
    public class ApiValidationError:ApiResponse
    {
        public IEnumerable<string> Errors { get; set;   }
        public ApiValidationError(int statusCode, IEnumerable<string> errors) :base(statusCode,"Validation Error occured")
        {
               Errors= errors;
        }
    }
}
