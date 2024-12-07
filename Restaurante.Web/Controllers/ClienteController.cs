using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Web.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
