﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Domain.Models.Entities
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdOrden { get; set; }
        public int IdMenu { get; set; }
        public int Cantidad { get; set; }
    }
}