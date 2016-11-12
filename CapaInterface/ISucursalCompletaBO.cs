using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaEntidad;
namespace CapaInterface
{
    public interface ISucursalCompletaBO
    {
        #region Métodos
        IList<SucursalCompleta> Listar();
        IList<SucursalCompleta> ListarPorEmpresa(string rut);
        #endregion
    }
}
