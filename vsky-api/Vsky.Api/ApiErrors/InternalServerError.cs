using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class InternalServerError : ApiError
    {
        public InternalServerError() : base(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.") { }

        public InternalServerError(string message, bool scoped = false) : base(StatusCodes.Status500InternalServerError, message, scoped) { }

        public InternalServerError(IList<string> errors, bool scoped = false) : base(StatusCodes.Status500InternalServerError, errors, scoped) { }
    }
}