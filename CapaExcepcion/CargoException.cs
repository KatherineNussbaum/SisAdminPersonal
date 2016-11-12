using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class CargoException : Exception
    {
        /// <summary>
        /// Constructor CargoException
        /// </summary>
        /// <param name="mensaje"></param>
        public CargoException(string mensaje) : base(mensaje)
        {

        }
    }
}
