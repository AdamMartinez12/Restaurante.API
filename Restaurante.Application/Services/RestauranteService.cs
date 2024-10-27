using Microsoft.EntityFrameworkCore;
using Restaurante.Domain.Data;
using Restaurante.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Services
{
    public class RestauranteService
    {
        private readonly RestauranteDbContext _context;
        public RestauranteService(RestauranteDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await _context.Cliente.ToListAsync();

        }

    }
}
