using Microsoft.AspNetCore.Mvc;

namespace ApiItaliaMi.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get ()
        {
            return Ok();
        }
    }
}
