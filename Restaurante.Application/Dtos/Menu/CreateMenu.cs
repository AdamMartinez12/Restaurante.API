using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Menu
{
    public class CreateMenu
    {
        [Required]
        [MaxLength(100)]
        public string NombrePlato { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }
    }
}
