﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Application.Dtos.DetalleOrden
{
    public class DetalleOrdenDto
    {
        public int IdDetalle { get; set; }
        public int IdOrden { get; set; }
        public int IdMenu { get; set; }
        public int Cantidad { get; set; }
    }
}
