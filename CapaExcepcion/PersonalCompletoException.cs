using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonalCompletoException : Exception
    {
        public PersonalCompletoException(string mensaje) : base(mensaje)
        {

        }

    }
}
