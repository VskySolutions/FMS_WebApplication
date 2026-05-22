using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Vsky.Api.ApiErrors
{
    public class ApiError
    {
        public ApiError()
        {
            Code = StatusCodes.Status500InternalServerError;
            Message = "An error occurred while processing your request.";
        }

        public ApiError(string message, bool scoped = false)
        {
            Code = StatusCodes.Status500InternalServerError;
            Message = message;
            Scoped = scoped;
        }

        public ApiError(int code, string message, bool scoped = false)
        {
            Code = code;
            Message = message;
            Scoped = scoped;
        }

        public ApiError(int code, ModelStateDictionary modelState, bool scoped = false)
        {
            Code = code;
            Message = string.Join('~', modelState.Keys.SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage)).ToList());
            Scoped = scoped;
        }

        public ApiError(int code, IList<string> errors, bool scoped = false)
        {
            Code = code;
            Message = string.Join('~', errors);
            Scoped = scoped;
        }

        public int Code { get; private set; }

        public string Message { get; private set; }

        public bool Scoped { get; set; }
    }
}