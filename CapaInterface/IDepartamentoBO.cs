using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
namespace CapaInterface
{
    public interface IDepartamentoBO
    {
        bool AgregarDepartamento(string nombre);
        bool EliminarDepartamento(int id);
        bool ModificarDepartamento(int id, string nombre);
        Departamento BuscarDepartamento(int id);
        Departamento BuscarDepartamento(string nombre);
        bool VerificarDepartameto(string nombre);
        bool VerificarDepartameto(int id);
        IList<Departamento> ListarDepartamento();
    }
}
