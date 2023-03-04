using Microsoft.AspNetCore.Mvc;

namespace Concurrence.WebAPI.Controllers
{
    [Route("greetings")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet("name")]
        public ActionResult<string> GetGreetings(string name)
        {
            return $"Hello {name}";
        }

    }
}
