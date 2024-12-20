﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string? Telefono { get; set; }

        public string? Email { get; set; }
    }
}
