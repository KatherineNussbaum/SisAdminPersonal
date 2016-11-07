using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;

namespace CapaInterface
{
    public interface IPersonalBO
    {
        bool AgregarPersonal(string PersonaRut, int SucursalId, int CargoId, int DepartamentoId);
        bool EliminarPersonal(int id);
        bool ModificarPersonal(int id, string PersonaRut, int SucursalId, int CargoId, int DepartamentoId);
        Personal BuscarPersonal(int id);
        Personal BuscarPersonal(string PersonaRut);
        bool VerificarPersonal(int id);
        bool VerificarPersonal(string PersonaRut);
        IList<Personal> ListarPersonal();
    }

}
