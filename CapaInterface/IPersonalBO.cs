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
        bool AgregarPersonal(string personaRut, int sucursalId, int cargoId, int departamentoId);
        bool EliminarPersonal(int id);
        bool ModificarPersonal(int id, string personaRut, int sucursalId, int cargoId, int departamentoId);
        Personal BuscarPersonal(int id);
        Personal BuscarPersonal(string personaRut);
        bool VerificarPersonal(int id);
        bool VerificarPersonal(string personaRut);
        IList<Personal> ListarPersonal();
    }

}
