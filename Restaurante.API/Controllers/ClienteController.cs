using Microsoft.AspNetCore.Mvc;
using Restaurante.Application;
using Restaurante.Application.Dtos;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;

        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCliente")]
        public async Task<IEnumerable<Cliente>> Get()
        {
            var ClientesFromDb = await _service.GetClientes();
            return ClientesFromDb;
        }

        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Create([FromBody] CreateCliente model)
        {
            if (model == null)
            {
                return BadRequest("Cliente data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateCliente(model);
                return CreatedAtRoute("GetCliente", new { id = result.ClienteId }, result);
            }

            return BadRequest(ModelState);
        }



    }
}
