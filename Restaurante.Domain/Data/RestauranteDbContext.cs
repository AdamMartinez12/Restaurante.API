using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Restaurante.Domain.Models.Entities;

namespace Restaurante.Domain.Data
{
    public class RestauranteDbContext : DbContext
    {
        public RestauranteDbContext(DbContextOptions<RestauranteDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Mesas> Mesas { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        //public DbSet<CliDetalleOrdenente> CliDetalleOrdenente { get; set; }
        //public DbSet<Reservaciones> Reservaciones { get; set; }

    }
}
