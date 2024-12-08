using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Reservaciones
{
    public class ReservacionesDto
    {
        public int IdReservacion { get; set; }
        public int ClienteId { get; set; }
        public int IdMesa {  get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado {  get; set; } = "Pendiente";
    }
}
