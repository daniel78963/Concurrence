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
            //https://localhost:7091/greetings/name?name=daniel
            return $"Hello {name}";
        }

        [HttpGet]
        public ActionResult<string> GetSaludo(string name)
        {
            return $"Hello {name}";
        }
    }
}
