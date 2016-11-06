using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class SucursalException : Exception
    {
        public SucursalException(string mensaje) : base(mensaje)
        {

        }
    }
}
