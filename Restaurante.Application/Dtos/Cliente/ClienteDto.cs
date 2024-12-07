using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.Cliente
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string? Telefono { get; set; }

        public string? Email { get; set; }
    }
}
