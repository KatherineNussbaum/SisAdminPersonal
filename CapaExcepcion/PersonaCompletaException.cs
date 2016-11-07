using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonaCompletaException : Exception
    {
        public PersonaCompletaException(string mensaje) : base(mensaje)
        {

        }
    }
}
