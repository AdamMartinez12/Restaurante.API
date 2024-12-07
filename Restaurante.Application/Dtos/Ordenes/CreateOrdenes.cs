using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Ordenes
{
    public class CreateOrdenes
    {

        [Required]
        public int ClienteId { get; set; }
        [Required]
        public int IdMesa {  get; set; }
        [Required]
        public DateTime FechaHora { get; set; }

    }
}
