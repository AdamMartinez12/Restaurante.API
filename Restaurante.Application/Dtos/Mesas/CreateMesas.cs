using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Mesas
{
    public class CreateMesas
    {
        [Required]
        public int NumeroMesa { get; set; }


        [Required]
        public int Capacidad { get; set; }


    }
}
