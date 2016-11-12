using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;

namespace CapaInterface
{
    public interface ICargoBO
    {
        #region Métodos
        bool AgregarCargo(string nombre);
        bool EliminarCargo(int id);
        bool ModificarCargo(int id, string nombre);
        Cargo BuscarCargo(int id);
        Cargo BuscarCargo(string nombre);
        bool VerificarCargo(int id);
        bool VerificarCargo(string nombre);
        IList<Cargo> ListarCargo();
        #endregion
    }
}
