using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Application.Dtos.Reservaciones;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class ReservacionesService
    {
        private readonly RestauranteDbContext _context;
        public ReservacionesService(RestauranteDbContext context)
        {
            _context = context;
        }
        public async Task<List<Reservaciones>> GetReservaciones()
        {
            return await _context.Reservaciones.ToListAsync();

        }
        private async Task<Reservaciones> GetDbReservaciones(int IdReservacion)
        {
            return await _context.Reservaciones.FirstOrDefaultAsync(p => p.IdReservacion == IdReservacion);
        }
        public async Task<ReservacionesDto> GetReservaciones(int IdReservacion)
        {
            var itemFromDb = await GetDbReservaciones(IdReservacion);
            return new ReservacionesDto { IdReservacion = IdReservacion, ClienteId = itemFromDb.ClienteId, IdMesa = itemFromDb.IdMesa, FechaHora = itemFromDb.FechaHora, Estado = itemFromDb.Estado };
        }

        public async Task<Reservaciones> CreateReservaciones(CreateReservaciones model)
        {
            var newItemDb = new Reservaciones
            {
                ClienteId = model.ClienteId,
                IdMesa = model.IdMesa,
                FechaHora = model.FechaHora,
                Estado = model.Estado
            };

            _context.Reservaciones.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;
        }
        public async Task<Reservaciones> EditReservaciones(EditReservaciones model)
        {
            var itemFromDb = await GetDbReservaciones(model.IdReservacion);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.ClienteId = model.ClienteId;
            itemFromDb.IdMesa = model.IdMesa;
            itemFromDb.FechaHora = model.FechaHora;
            itemFromDb.Estado = model.Estado;

            _context.Reservaciones.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;
        }
        public async Task<bool> DeleteReservaciones(int IdReservacion)
        {
            var ReservacionesfromDb = await GetDbReservaciones(IdReservacion);
            if (ReservacionesfromDb == null)
            {
                return false;
            }

            _context.Reservaciones.Remove(ReservacionesfromDb);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
