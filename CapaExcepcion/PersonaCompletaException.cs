using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonaCompletaException : Exception
    {
        /// <summary>
        /// Constructor PersonaCompletaException
        /// </summary>
        /// <param name="mensaje"></param>
        public PersonaCompletaException(string mensaje) : base(mensaje)
        {

        }
    }
}
