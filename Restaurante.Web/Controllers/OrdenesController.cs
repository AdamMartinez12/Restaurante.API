using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Web.Controllers
{
    public class OrdenesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
