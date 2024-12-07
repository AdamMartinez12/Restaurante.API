using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Menu
{
    public class MenuDto
    {
        public int IdMenu { get; set; }
        public string NombrePlato { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
    }
}
