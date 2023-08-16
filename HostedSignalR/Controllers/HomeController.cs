using Microsoft.AspNetCore.Mvc;

namespace HostedSignalR.Controllers
{
     [Route("api/home")]
     [ApiController]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
