using Microsoft.AspNetCore.Mvc;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Menu;
using Restaurante.Application.Services;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _service;

        public MenuController(MenuService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetMenu")]
        public async Task<IEnumerable<Menu>> Get()
        {
            var MenuFromDb = await _service.GetMenu();
            return MenuFromDb;
        }


        [HttpPost(Name = "CreateMenu")]
        public async Task<IActionResult> Create([FromBody] CreateMenu model)
        {
            if (model == null)
            {
                return BadRequest("Menu data es nula");
            }


            if (ModelState.IsValid)
            {
                var result = await _service.CreateMenu(model);
                return CreatedAtRoute("GetMenu", new { id = result.IdMenu }, result);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}", Name = "UpdateMenu")]
        public async Task<IActionResult> Update(int id, [FromBody] EditMenu model)
        {
            if (model == null || id != model.IdMenu)
            {
                return BadRequest("Los datos del Menu data son invalidos");
            }
            if (ModelState.IsValid)
            {

                var result = await _service.EditMenu(model);
                if (result == null)
                {
                    return NotFound("Menu no encontrado");
                }

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{IdMenu}", Name = "DeleteMenu")]
        public async Task<IActionResult> Delete(int IdMenu)
        {

            bool MenuEliminado = await _service.DeleteMenu(IdMenu);
            if (MenuEliminado == false)
            {
                return NotFound("Menu no encontrado");
            }

            return NoContent();
        }
    }
}
