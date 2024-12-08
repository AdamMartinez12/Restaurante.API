using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Reservaciones;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservacionesController: ControllerBase
    {
        private readonly ReservacionesService _service;

        public ReservacionesController(ReservacionesService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetReservaciones")]
        public async Task<IEnumerable<Reservaciones>> Get()
        {
            var ReservacionesFromDb = await _service.GetReservaciones();
            return ReservacionesFromDb;
        }

        [HttpPost(Name = "CreateReservaciones")]
        public async Task<IActionResult> Create([FromBody] CreateReservaciones model)
        {
            if (model == null)
            {
                return BadRequest("Reservacion data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateReservaciones(model);
                return CreatedAtRoute("GetReservaciones", new { id = result.IdReservacion }, result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateReservaciones")]
        public async Task<IActionResult> Update(int id, [FromBody] EditReservaciones model)
        {
            if (model == null || id != model.IdReservacion)
            {
                return BadRequest("Reservacion data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditReservaciones(model);
                if (result == null)
                {
                    return NotFound("Reservacion no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{IdReservacion}", Name = "DeleteReservacion")]
        public async Task<IActionResult> Delete(int IdReservacion)
        {

            bool ReservacionEliminado = await _service.DeleteReservaciones(IdReservacion);
            if (ReservacionEliminado == false)
            {
                return NotFound("Reservacion no encontrado");
            }

            return NoContent();
        }

    }
}
