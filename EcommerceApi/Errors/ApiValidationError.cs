namespace EcommerceApi.Errors
{
    public class ApiValidationError:ApiResponse
    {
        public IEnumerable<string> Errors { get; set;   }
        public ApiValidationError(IEnumerable<string> errors) :base(StatusCodes.Status400BadRequest, "Validation Error occured")
        {
               Errors= errors;
        }
    }
}
