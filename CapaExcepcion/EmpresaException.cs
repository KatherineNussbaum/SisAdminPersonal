using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaExcepcion
{
    public class EmpresaException : Exception
    {
        public EmpresaException(string mensaje) : base(mensaje)
        {

        }
    }
}
