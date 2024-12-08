using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Web.Controllers
{
    public class ClienteViewController : Controller
    {
        private readonly ILogger<ClienteViewController> _logger;


        public ClienteViewController(ILogger<ClienteViewController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
