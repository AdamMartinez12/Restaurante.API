using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Reservaciones
    {
        [Key]
        public int IdReservacion { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [ForeignKey("IdMesa")]
        public int IdMesa {  get; set; }
        public DateTime FechaHora { get; set; }
        public string Estado { get; set; } = "Pendiente";
    }
}
