using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.DetalleOrden;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class DetalleOrdenService
    {
        private readonly RestauranteDbContext _context;
        public DetalleOrdenService(RestauranteDbContext context)
        {
            _context = context;
        }
        public async Task<List<DetalleOrden>> GetDetalleOrden()
        {
            return await _context.DetalleOrden.ToListAsync();

        }
        private async Task<DetalleOrden> GetDbDetalleOrden(int IdDetalle)
        {
            return await _context.DetalleOrden.FirstOrDefaultAsync(p => p.IdDetalle == IdDetalle);
        }
        public async Task<DetalleOrdenDto> GetDetalleOrden(int IdDetalle)
        {
            var itemFromDb = await GetDbDetalleOrden(IdDetalle);
            return new DetalleOrdenDto { IdDetalle = IdDetalle, IdOrden = itemFromDb.IdOrden, IdMenu = itemFromDb.IdMenu, Cantidad = itemFromDb.Cantidad };
        }
        public async Task<DetalleOrden> CreateDetalleOrden(CreateDetalleOrden model)
        {
            var newItemDb = new DetalleOrden
            {
                IdOrden = model.IdOrden,
                IdMenu = model.IdMenu,
                Cantidad = model.Cantidad
            };

            _context.DetalleOrden.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;
        }
        public async Task<DetalleOrden> EditDetalleOrden(EditDetalleOrden model)
        {
            var itemFromDb = await GetDbDetalleOrden(model.IdDetalle);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.IdOrden = model.IdOrden;
            itemFromDb.IdMenu = model.IdMenu;
            itemFromDb.Cantidad = model.Cantidad;

            _context.DetalleOrden.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;
        }
        public async Task<bool> DeleteDetalleOrden(int IdDetalle)
        {
            var DetalleOrdenfromDb = await GetDbDetalleOrden(IdDetalle);
            if (DetalleOrdenfromDb == null)
            {
                return false;
            }

            _context.DetalleOrden.Remove(DetalleOrdenfromDb);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
