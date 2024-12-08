using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.DetalleOrden
{
    public class CreateDetalleOrden
    {
        [Required]
        public int IdOrden { get; set; }
        [Required]
        public int IdMenu { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
