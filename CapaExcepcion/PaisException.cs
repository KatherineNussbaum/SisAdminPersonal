using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PaisException : Exception
    { 
        /// <summary>
        /// Constructor PaisException
        /// </summary>
        /// <param name="mensaje"></param>
        public PaisException(string mensaje) : base(mensaje)
        {

        }
    }
}
