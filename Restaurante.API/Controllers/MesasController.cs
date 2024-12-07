using Microsoft.AspNetCore.Mvc;
using Restaurante.Application;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Mesas;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MesasController : ControllerBase
    {
        private readonly MesasService _service;

        public MesasController(MesasService service)
        {
            _service = service;
        }
        [HttpGet(Name = "GetMesas")]
        public async Task<IEnumerable<Mesas>> Get()
        {
            var MesasFromDb = await _service.GetMesas();
            return MesasFromDb;
        }

        [HttpPost(Name = "Createmesas")]
        public async Task<IActionResult> Create([FromBody] CreateMesas model)
        {
            if (model == null)
            {
                return BadRequest("Mesa data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateMesas(model);
                return CreatedAtRoute("GetMesas", new { id = result.IdMesa }, result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateMesas")]
        public async Task<IActionResult> Update(int id, [FromBody] EditMesas model)
        {
            if (model == null || id != model.IdMesa)
            {
                return BadRequest("Los datos del cliente data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditMesas(model);
                if (result == null)
                {
                    return NotFound("Cliente no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{IdMesa}", Name = "DeleteMesas")]
        public async Task<IActionResult> Delete(int IdMesa)
        {

            bool mesaselimiado = await _service.DeleteMesas(IdMesa);
            if (mesaselimiado == false)
            {
                return NotFound("Cliente no encontrado");
            }

            return NoContent();
        }
    }
}
