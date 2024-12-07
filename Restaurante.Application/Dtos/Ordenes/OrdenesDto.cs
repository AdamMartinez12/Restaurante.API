using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Ordenes
{
    public class OrdenesDto
    {
        public int IdOrden { get; set; } // Llave primaria
        public int ClienteId { get; set; } // Llave foránea hacia Cliente
        public int IdMesa { get; set; } // Llave foránea hacia Mesas
        public DateTime FechaHora { get; set; } // Fecha y hora de la orden

    }
}
