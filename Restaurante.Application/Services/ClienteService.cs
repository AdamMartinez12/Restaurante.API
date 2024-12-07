using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos.Cliente;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class ClienteService
    {
        private readonly RestauranteDbContext _context;
        public ClienteService(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();

        }

        private async Task<Cliente> GetDbCliente(int ClienteId)
        {
            return await _context.Cliente.FirstOrDefaultAsync(p => p.ClienteId == ClienteId);
        }

        public async Task<ClienteDto> GetCliente(int ClienteId)
        {
            var itemFromDb = await GetDbCliente(ClienteId);
            return new ClienteDto { ClienteId = ClienteId, Nombre = itemFromDb.Nombre, Telefono = itemFromDb.Telefono, Email = itemFromDb.Email };
        }

        public async Task<Cliente> CreateCliente(CreateCliente model)
        {
            var newItemDb = new Cliente
            {
                Nombre = model.Nombre,
                Telefono = model.Telefono,
                Email = model.Email
            };

            _context.Cliente.Add(newItemDb);
            await _context.SaveChangesAsync();
            return newItemDb;
        }

        public async Task<Cliente> EditCliente(EditCliente model)
        {
            var itemFromDb = await GetDbCliente(model.ClienteId);
            if (itemFromDb == null)
            {
                return null;
            }
            itemFromDb.Nombre = model.Nombre;
            itemFromDb.Telefono = model.Telefono;
            itemFromDb.Email = model.Email;

            _context.Cliente.Update(itemFromDb);
            await _context.SaveChangesAsync();
            return itemFromDb;
        }

        public async Task<bool> DeleteCliente(int ClienteId)
        {
            var ClientefromDb = await GetDbCliente(ClienteId);
            if (ClientefromDb == null)
            {
                return false;
            }

            _context.Cliente.Remove(ClientefromDb);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
