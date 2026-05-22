using Microsoft.AspNetCore.Mvc;

namespace Vsky.Api.Controllers
{
    [ApiController]
    [Route("keep-alive")]
    public class KeepAliveController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("I am alive");
        }
    }
}