using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Vsky.Api.ApiErrors
{
    public class ValidationError : ApiError
    {
        public ValidationError() : base(StatusCodes.Status400BadRequest, "Validation failed.") { }

        public ValidationError(string message, bool scoped = false) : base(StatusCodes.Status400BadRequest, message, scoped) { }

        public ValidationError(ModelStateDictionary modelState, bool scoped = false) : base(StatusCodes.Status400BadRequest, modelState, scoped) { }
    }
}