using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vsky.Api.ApiErrors;
using Vsky.Api.Extensions;

namespace Vsky.Api.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        [NonAction]
        public virtual ObjectResult InternalServerError(string error = null)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                return new ObjectResult(new InternalServerError(error)) { StatusCode = StatusCodes.Status500InternalServerError };
            }
            else
            {
                return new ObjectResult(new InternalServerError()) { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        [NonAction]
        public virtual ObjectResult InternalServerError(IEnumerable<IdentityError> identityErrors)
        {
            var error = identityErrors.GetErrorMessages();

            return new ObjectResult(new InternalServerError(error)) { StatusCode = StatusCodes.Status500InternalServerError };
        }

        [NonAction]
        public virtual ObjectResult AmbiguousError(string error = null)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                return new ObjectResult(new AmbiguousError(error)) { StatusCode = StatusCodes.Status300MultipleChoices };
            }
            else
            {
                return new ObjectResult(new AmbiguousError()) { StatusCode = StatusCodes.Status300MultipleChoices };
            }
        }

        [NonAction]
        public virtual ObjectResult ModelStateError(ModelStateDictionary modelState)
        {
            var error = modelState.GetErrorMessages();

            return new ObjectResult(new BadRequestError(error)) { StatusCode = StatusCodes.Status400BadRequest };
        }

        protected IActionResult AccessDenied()
        {
            return BadRequest(new BadRequestError("You do not have permission to perform the selected operation."));
        }
    }
}