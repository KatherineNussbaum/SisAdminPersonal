using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class EmpresaException : Exception
    {
        /// <summary>
        /// Constructor EmpresaException
        /// </summary>
        /// <param name="mensaje"></param>
        public EmpresaException(string mensaje) : base(mensaje)
        {

        }
    }
}
