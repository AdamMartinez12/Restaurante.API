using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Menu;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class MenuService
    {
        private readonly RestauranteDbContext _context;
        public MenuService(RestauranteDbContext context)
        {
            _context = context;
        }
        public async Task<List<Menu>> GetMenu()
        {
            return await _context.Menu.ToListAsync();

        }
        private async Task<Menu> GetDbMenu(int IdMenu)
        {
            return await _context.Menu.FirstOrDefaultAsync(p => p.IdMenu == IdMenu);
        }
        public async Task<MenuDto> GetMenu(int IdMenu)
        {
            var itemFromDb = await GetDbMenu(IdMenu);
            return new MenuDto { IdMenu = IdMenu, NombrePlato = itemFromDb.NombrePlato, Precio = itemFromDb.Precio};

        }

        public async Task<Menu> CreateMenu(CreateMenu model)
        {
            var newItemDb = new Menu
            {
                NombrePlato = model.NombrePlato,
                Precio = model.Precio,
               
            };

            _context.Menu.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;
        }
        public async Task<Menu> EditMenu(EditMenu model)
        {
            var itemFromDb = await GetDbMenu(model.IdMenu);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.NombrePlato = model.NombrePlato;
            itemFromDb.Precio = model.Precio;

            _context.Menu.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;
        }
        public async Task<bool> DeleteMenu(int IdMenu)
        {
            var MenufromDb = await GetDbMenu(IdMenu);
            if (MenufromDb == null)
            {
                return false;
            }

            _context.Menu.Remove(MenufromDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
