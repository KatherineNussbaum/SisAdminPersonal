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
        bool AgregarSucursal(string empresaRut, string tipo, string direccion, string comuna, string region, string pais, string telefono);
        bool EliminarSucursal(int id);
        bool ModificarSucursal(string empresaRut, string tipo, string direccion, string comuna, string region, string pais, string telefono);
        Sucursal BuscarSucursal(int id);

        bool VerificarSucursal(string empresaRut, string tipo, string direccion, string comuna, string region, string pais, string telefono);
        bool VerificarSucursalId(int id);
        IList<Sucursal> ListarSucursal();
    }
}
