using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Reservaciones
{
    public class CreateReservaciones
    {
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int IdMesa { get; set; }
        [Required]
        public DateTime FechaHora { get; set; }
        [MaxLength(50)]
        public string? Estado { get; set; } = "Pendiente";
    }
}
