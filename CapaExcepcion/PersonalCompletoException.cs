using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonalCompletoException : Exception
    {
        /// <summary>
        /// Constructor PersonalCompletoException
        /// </summary>
        /// <param name="mensaje"></param>
        public PersonalCompletoException(string mensaje) : base(mensaje)
        {

        }

    }
}
