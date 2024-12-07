using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Ordenes;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
 

    public class OrdenesController : ControllerBase
    {
        private readonly OrdenesService _service;

        public OrdenesController(OrdenesService service)
        {
            _service = service;
        }
        [HttpGet(Name = "GetOrdenes")]
        public async Task<IEnumerable<Ordenes>> Get()
        {
            var OrdenesFromDb = await _service.GetOrdenes();
            return OrdenesFromDb;
        }

        [HttpPost(Name = "CreateCliente")]
        public async Task<IActionResult> Create([FromBody] CreateOrdenes model)
        {
            if (model == null)
            {
                return BadRequest("Orden data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateOrdenes(model);
                return CreatedAtRoute("GetOrdenes", new { id = result.IdOrden }, result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{IdOrden}", Name = "UpdateOrden")]
        public async Task<IActionResult> Update(int id, [FromBody] EditOrdenes model)
        {
            if (model == null || id != model.IdOrden)
            {
                return BadRequest("Los datos de la orden data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditOrdenes(model);
                if (result == null)
                {
                    return NotFound("Orden no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{IdOrden}", Name = "DeleteOrdenes")]
        public async Task<IActionResult> Delete(int IdOrden)
        {

            bool OrdenEliminado = await _service.DeleteOrdenes(IdOrden);
            if (OrdenEliminado == false)
            {
                return NotFound("Orden no encontrado");
            }

            return NoContent();
        }
    }
}
