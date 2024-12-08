using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.DetalleOrden;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleOrdenController: ControllerBase
    {
        private readonly DetalleOrdenService _service;

        public DetalleOrdenController(DetalleOrdenService service)
        {
            _service = service;
        }
        [HttpGet(Name = "GetDetalleOrden")]
        public async Task<IEnumerable<DetalleOrden>> Get()
        {
            var DetalleOrdenFromDb = await _service.GetDetalleOrden();
            return DetalleOrdenFromDb;
        }

        [HttpPost(Name = "CreateDetalleOrden")]
        public async Task<IActionResult> Create([FromBody] CreateDetalleOrden model)
        {
            if (model == null)
            {
                return BadRequest("Detalle de la Orden data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateDetalleOrden(model);
                return CreatedAtRoute("GetDetalleOrden", new { id = result.IdDetalle }, result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateDetalleOrden")]
        public async Task<IActionResult> Update(int id, [FromBody] EditDetalleOrden model)
        {
            if (model == null || id != model.IdDetalle)
            {
                return BadRequest("Detalle de la orden data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditDetalleOrden(model);
                if (result == null)
                {
                    return NotFound("Detalle de Orden no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{IdDetalleOrden}", Name = "DeleteDetalleOrden")]
        public async Task<IActionResult> Delete(int IdDetalle)
        {

            bool DetalleOrdenEliminado = await _service.DeleteDetalleOrden(IdDetalle);
            if (DetalleOrdenEliminado == false)
            {
                return NotFound("Detalle de Orden no encontrado");
            }

            return NoContent();
        }
    }

}
