using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class ApiSuccess
    {
        public ApiSuccess()
        {
            Code = StatusCodes.Status200OK;
            Message = "Your request is processed successfully.";
        }

        public ApiSuccess(string message)
        {
            Code = StatusCodes.Status200OK;
            Message = message;
        }

        public ApiSuccess(IList<string> message)
        {
            Code = StatusCodes.Status200OK;
            Message = message;
        }

        public int Code { get; private set; }

        public object Message { get; private set; }
    }
}