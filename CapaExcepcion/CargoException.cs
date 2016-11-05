using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class CargoException : Exception
    {
        public CargoException(string mensaje) : base(mensaje)
        {

        }
    }
}
