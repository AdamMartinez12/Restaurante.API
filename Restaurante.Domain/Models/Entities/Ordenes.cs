using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Ordenes
    {
        [Key]
        public int IdOrden { get; set; } // Llave primaria
        public int ClienteId { get; set; } // Llave foránea hacia Cliente
        public int IdMesa { get; set; } // Llave foránea hacia Mesas
        public DateTime FechaHora { get; set; } // Fecha y hora de la orden

    }
}
