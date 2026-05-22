using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class BadRequestError : ApiError
    {
        public BadRequestError() : base(StatusCodes.Status400BadRequest, "Bad request.") { }

        public BadRequestError(string message, bool scoped = false) : base(StatusCodes.Status400BadRequest, message, scoped) { }

        public BadRequestError(IList<string> errors, bool scoped = false) : base(StatusCodes.Status400BadRequest, errors, scoped) { }
    }
}