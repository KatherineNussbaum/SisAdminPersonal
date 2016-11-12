using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaEntidad;

namespace CapaInterface
{
    public interface IPersonaCompletaBO
    {
        #region Métodos
        IList<PersonaCompleta> ListarPersonaCompleta();
        #endregion
    }
}
