using System.Collections.Generic;

namespace Vsky.Api.ApiErrors
{
    public class AuthError : ApiError
    {
        public AuthError(int code, string message, Dictionary<string, string> data = null, bool scoped = false) : base(code, message, scoped)
        {
            Data = data;
        }

        public Dictionary<string, string> Data { get; set; }
    }
}