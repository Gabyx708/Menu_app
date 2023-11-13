using Application.Interfaces.ICoordinationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Services
{
    public class CoordinatingService : ICoordinatingService
    {
        private bool _debeAutomatizar = false;

        public void IniciarAutomatizacion()
        {
            _debeAutomatizar = true;
        }

        public bool DebeAutomatizar()
        {
            return _debeAutomatizar;
        }

        public void Reiniciar()
        {
            _debeAutomatizar = false;
        }
    }
}
