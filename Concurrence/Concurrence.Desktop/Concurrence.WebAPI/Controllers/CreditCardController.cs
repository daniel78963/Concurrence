using Concurrence.WebAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Concurrence.WebAPI.Controllers
{
    [ApiController]
    [Route("creditcards")]
    public class CreditCardController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ProcessCreditCard([FromBody] string card)
        {
            var randomValue = RandomGen.NextDouble();
            //el randomGen me da valores entre 0 y 1, y le vamos a decir que nos apruebe el 
            //10%
            var approved = randomValue > 0.1;
            await Task.Delay(1000);
            Console.WriteLine($"Credit card {card} processed");
            //return Ok(new { card, approved });
            return Ok(new { Card = card, IsApproved = approved });
        }
    }
}
