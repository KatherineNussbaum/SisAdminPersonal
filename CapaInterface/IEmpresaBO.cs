using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;

namespace CapaInterface
{
    public interface IEmpresaBO
    {
        #region Métodos
        bool AgregarEmpresa(string rut, string nombre, string razonSocial);
        bool EliminarEmpresa(string rut);
        bool ModificarEmpresa(string rut, string nombre, string razonSocial);
        Empresa BuscarEmpresa(string rut);
        bool VerificarEmpresa(string rut);
        IList<Empresa> ListarEmpresa();
        #endregion
    }
}
