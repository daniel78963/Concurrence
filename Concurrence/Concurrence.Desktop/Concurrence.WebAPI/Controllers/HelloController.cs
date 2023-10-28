using Concurrence.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Concurrence.WebAPI.Controllers
{
    [Route("greetings")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet("{name}")]
        public ActionResult<string> GetGreetings(string name)
        {
            //https://localhost:7091/greetings/name?name=daniel
            //si se colocan las llaves al HttpGet
            //https://localhost:7091/greetings/daniel
            return $"Hello {name}";
        }

        [HttpGet]
        public ActionResult<string> GetSaludo(string name)
        {
            return $"Hello {name}";
        }

        [HttpGet("delay/{name}")]
        public async Task<ActionResult<string>> GetGreetingsDelay(string name)
        {
            Console.WriteLine($"Thread before await: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(500);
            Console.WriteLine($"Thread after await: {Thread.CurrentThread.ManagedThreadId}");

            return $"Hello {name}";
        }

        [HttpGet("delayCancell/{name}")]
        public async Task<ActionResult<string>> GetGreetingsDelayCancell(string name)
        {
            var wait = RandomGen.NextDouble() * 10 + 1; //me trae un numero entre 1 y 10
            await Task.Delay((int)wait * 1000);//* 1000 para que sean segundos
            return $"Hello, {name}!";
        }
    }
}
