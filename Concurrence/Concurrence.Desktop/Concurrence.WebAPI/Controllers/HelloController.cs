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

            //Ejemplo de antipatrones
            //OperationVoidAsync();
            //OperationTaskAsync();
            return $"Hello, {name}!";
        }

        /// <summary>
        /// Antipatrón
        /// </summary>
        private async void OperationVoidAsync()
        {
            await Task.Delay(1);
            throw new ApplicationException();
        }

        /// <summary>
        ///   Tener un try catch no soluciona el problema tampoco.
        ///   Así, la exception queda dentro del hilo del Task
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        private async Task OperationTaskAsync()
        {
            await Task.Delay(1);
            throw new ApplicationException();
        }


        [HttpGet("delaybye/{name}")]
        public async Task<ActionResult<string>> GetDelayBye(string name)
        {
            var wait = RandomGen.NextDouble() * 10 + 1; //me trae un numero entre 1 y 10
            await Task.Delay((int)wait * 1000);//* 1000 para que sean segundos
            return $"Bye, {name}!";
        }
    }
}
