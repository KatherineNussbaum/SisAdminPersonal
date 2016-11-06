using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;

namespace CapaInterface
{
    public interface ISucursalBO
    {
        bool AgregarSucursal(string nombre, string empresaRut, string tipo, string direccion, int comuna, int region, int pais, string telefono);
        bool EliminarSucursal(int id);
        bool ModificarSucursal(int id, string nombre, string empresaRut, string tipo, string direccion, int comuna, int region, int pais, string telefono);
        bool ModificarSucursal(int id, string nomber, string empresaRut, string tipo, string direccion, string telefono);
        Sucursal BuscarSucursal(int id);
        Sucursal BuscarSucursal(string nombre);
        bool VerificarSucursal(int id);
        bool VerificarSucursal(string nombre);
        IList<Sucursal> ListarSucursal();
    }
}
