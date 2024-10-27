using Microsoft.EntityFrameworkCore;
using Restaurante.Application.Dtos;
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

    }
}
