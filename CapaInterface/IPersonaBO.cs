using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
namespace CapaInterface
{
    public interface IPersonaBO
    {
        bool AgregarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, int sexo, string direccion, int comuna, int region, int pais, string telefono, string email);
        bool EliminarPersona(string rut);
        bool ModificarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, int sexo, string direccion, int comuna, int region, int pais, string telefono, string email);
        bool ModificarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, int sexo, string direccion, string telefono, string email);
        Persona BuscarPersona(string rut);
        bool VerificarPersona(string rut);
        IList<Persona> ListarPersona();
    }
}
