using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Menu
    {
        [Key]
        public int IdMenu { get; set; }
        public string NombrePlato { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
    }
}
