using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Ordenes;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class OrdenesService
    {
        private readonly RestauranteDbContext _context;
        public OrdenesService(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ordenes>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();

        }
        private async Task<Ordenes> GetDbOrdenes(int IdOrden)
        {
            return await _context.Ordenes.FirstOrDefaultAsync(p => p.IdOrden == IdOrden);
        }
        public async Task<OrdenesDto> GetOrdenes(int IdOrden)
        {
            var itemFromDb = await GetDbOrdenes(IdOrden);
            return new OrdenesDto { IdOrden = IdOrden, ClienteId = itemFromDb.ClienteId, IdMesa = itemFromDb.IdMesa, FechaHora = itemFromDb.FechaHora };
        }
        public async Task<Ordenes> CreateOrdenes(CreateOrdenes model)
        {
            var newItemDb = new Ordenes
            {
                ClienteId = model.ClienteId,
                IdMesa = model.IdMesa,
                FechaHora = model.FechaHora
            };

            _context.Ordenes.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;
        }
        public async Task<Ordenes> EditOrdenes(EditOrdenes model)
        {
            var itemFromDb = await GetDbOrdenes(model.IdOrden);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.ClienteId = model.ClienteId;
            itemFromDb.IdMesa = model.IdMesa;
            itemFromDb.FechaHora = model.FechaHora;

            _context.Ordenes.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;
        }
        public async Task<bool> DeleteOrdenes(int IdOrden)
        {
            var OrdenesfromDb = await GetDbOrdenes(IdOrden);
            if (OrdenesfromDb == null)
            {
                return false;
            }

            _context.Ordenes.Remove(OrdenesfromDb);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
