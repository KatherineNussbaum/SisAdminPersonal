using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class SucursalException : Exception
    {
        /// <summary>
        /// Constructor SucursalException
        /// </summary>
        /// <param name="mensaje"></param>
        public SucursalException(string mensaje) : base(mensaje)
        {

        }
    }
}
