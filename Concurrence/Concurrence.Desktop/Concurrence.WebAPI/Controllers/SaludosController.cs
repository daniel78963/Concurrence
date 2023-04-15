using Microsoft.AspNetCore.Mvc;

namespace Concurrence.WebAPI.Controllers
{
    [Route("saludos")]
    [ApiController]
    public class SaludosController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet("{name}")]
        public ActionResult<string> GetSaludos(string name)
        {
            //https://localhost:7091/saludos/dani
            return $"Hello {name}";
        }
    }
}
