using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class DepartamentoException : Exception
    {
        /// <summary>
        /// Constructor DepartamentoException
        /// </summary>
        /// <param name="mensaje"></param>
        public DepartamentoException(string mensaje) : base(mensaje)
        {

        }
    }
}
