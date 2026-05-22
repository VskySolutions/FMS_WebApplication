using Microsoft.AspNetCore.Http;

namespace Vsky.Api.ApiErrors
{
    public class AmbiguousError : ApiError
    {
        public AmbiguousError() : base(StatusCodes.Status300MultipleChoices, "Ambiguous error.") { }

        public AmbiguousError(string message, bool scoped = false) : base(StatusCodes.Status300MultipleChoices, message, scoped) { }
    }
}