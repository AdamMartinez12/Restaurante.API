using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Mesas;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class MesasService
    {
        private readonly RestauranteDbContext _context;
        public MesasService(RestauranteDbContext context)
        {
            _context = context;
        }
        public async Task<List<Mesas>> GetMesas()
        {
            return await _context.Mesas.ToListAsync();
        }

        private async Task<Mesas> GetDbMesas(int IdMesa)
        {
            return await _context.Mesas.FirstOrDefaultAsync(p => p.IdMesa == IdMesa);
        }

   
        public async Task<MesasDto> GetMesas(int IdMesa)
        {
            var itemFromDb = await GetDbMesas(IdMesa);
            return new MesasDto { IdMesa = IdMesa, NumeroMesa = itemFromDb.NumeroMesa, Capacidad = itemFromDb.Capacidad, };

        }
        public async Task<Mesas> CreateMesas(CreateMesas model)
        {
            var newItemDb = new Mesas
            {
                NumeroMesa = model.NumeroMesa,
                Capacidad = model.Capacidad,

            };

            _context.Mesas.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;

        }
        public async Task<Mesas> EditMesas(EditMesas model)
        {
            var itemFromDb = await GetDbMesas(model.IdMesa);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.NumeroMesa = model.NumeroMesa;
            itemFromDb.Capacidad = model.Capacidad;
      

            _context.Mesas.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;

        }
        public async Task<bool> DeleteMesas(int IdMesa)
        {
            var MesasfromDb = await GetDbMesas(IdMesa);
            if (MesasfromDb == null)
            {
                return false;
            }

            _context.Mesas.Remove(MesasfromDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
