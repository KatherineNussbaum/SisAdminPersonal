using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonalException : Exception
    {
        public PersonalException(string mensaje) : base(mensaje)
        {

        }
    }
}