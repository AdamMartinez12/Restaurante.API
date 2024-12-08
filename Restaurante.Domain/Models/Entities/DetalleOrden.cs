using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalle { get; set; }
        [ForeignKey("IdOrden")]
        public int IdOrden { get; set; }
        [ForeignKey("IdMenu")]
        public int IdMenu { get; set; }
        public int Cantidad { get; set; }
    }
}
