﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
    public class PedidoPorMenuPlatilloRequest
    {
        public Guid idPedido { get; set; }
        public Guid idMenuPlatillo { get; set; }
    }
}