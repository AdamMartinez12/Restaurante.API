using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Mesas
    {
        [Key]
        public int IdMesa { get; set; }
        public int NumeroMesa { get; set; }
        public int Capacidad {  get; set; }
    }
}
