using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos
{
    public class CreateCliente
    {
        [Required]
        [MaxLength(50)]
        public string   Nombre { get; set; }

       
        [MaxLength(15)]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }
    }
}
