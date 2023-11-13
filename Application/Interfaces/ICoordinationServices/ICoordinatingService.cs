﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICoordinationServices
{
    public interface ICoordinatingService
    {
        void IniciarAutomatizacion();
        bool DebeAutomatizar();
        void Reiniciar();
    }
}
