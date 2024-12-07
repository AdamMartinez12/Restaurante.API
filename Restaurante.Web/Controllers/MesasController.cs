using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Web.Controllers
{
    public class MesasController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
