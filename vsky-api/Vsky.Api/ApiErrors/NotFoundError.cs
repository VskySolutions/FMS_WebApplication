using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class NotFoundError : ApiError
    {
        public NotFoundError() : base(StatusCodes.Status404NotFound, "Resource not found.") { }

        public NotFoundError(string message, bool scoped = false) : base(StatusCodes.Status404NotFound, message, scoped) { }
    }
}