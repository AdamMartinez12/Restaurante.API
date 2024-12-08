using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Reservaciones
    {
        public int IdReservaciones { get; set; }
        public int ClienteId { get; set; }
        public int IdMesa {  get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }
}
