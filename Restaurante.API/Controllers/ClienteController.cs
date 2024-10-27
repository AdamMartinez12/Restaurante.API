using Microsoft.AspNetCore.Mvc;
using Restaurante.Application;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly RestauranteService _service;

        public ClienteController(RestauranteService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCliente")]
        public async Task<IEnumerable<Cliente>> Get()
        {
            var ClientesFromDb = await _service.GetClientes();
            return ClientesFromDb;
        }



    }
}
