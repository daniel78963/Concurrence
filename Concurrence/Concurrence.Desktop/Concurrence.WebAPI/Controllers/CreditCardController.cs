using Microsoft.AspNetCore.Mvc;

namespace Concurrence.WebAPI.Controllers
{
    [ApiController]
    [Route("creditcards")]
    public class CreditCardController
    {
        [HttpPost]
        public async Task<ActionResult> PorcessCreditCard([FromBody] string card)
        {

        }
    }
}
