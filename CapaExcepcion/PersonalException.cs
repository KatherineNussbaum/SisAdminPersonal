using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class PersonalException : Exception
    {
        /// <summary>
        /// Constructor PersonalException
        /// </summary>
        /// <param name="mensaje"></param>
        public PersonalException(string mensaje) : base(mensaje)
        {

        }
    }
}