using Microsoft.AspNetCore.Mvc;
using Restaurante.Application;
using Restaurante.Application.Dtos.Cliente;
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
            var ClientesFromDb = await _service.GetClientes
                ();
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


        [HttpPut("{id}", Name = "UpdateCliente")]
        public async Task<IActionResult> Update(int id, [FromBody] EditCliente model)
        {
            if (model == null || id != model.ClienteId)
            {
                return BadRequest("Los datos del cliente data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditCliente(model);
                if (result == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{ClienteId}", Name = "DeleteCliente")]
        public async Task<IActionResult> Delete(int ClienteId)
        {

            bool clienteEliminado = await _service.DeleteCliente(ClienteId);
            if (clienteEliminado == false)
            {
                return NotFound("Cliente no encontrado");
            }

           return NoContent();
        }



    }
}
