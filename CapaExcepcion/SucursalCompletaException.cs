using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class SucursalCompletaException : Exception
    {
        public SucursalCompletaException(string mensaje) : base(mensaje)
        {

        }
    }
}
