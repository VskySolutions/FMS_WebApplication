using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class ApiResourceCreated
    {
        public ApiResourceCreated()
        {
            Code = StatusCodes.Status201Created;
            Message = "Resource is created successfully.";
        }

        public ApiResourceCreated(string message)
        {
            Code = StatusCodes.Status201Created;
            Message = message;
        }

        public int Code { get; private set; }

        public string Message { get; private set; }
    }
}