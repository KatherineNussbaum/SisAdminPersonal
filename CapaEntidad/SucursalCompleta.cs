using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class SucursalCompleta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string EmpresaRut { get; set; }
        public string NombreEmpresa { get; set; }
        public string Tipo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }

        public SucursalCompleta()
        {
            this.Id = 0;
            this.Nombre = this.EmpresaRut = this.NombreEmpresa = this.Tipo = this.Telefono = this.Direccion = this.Comuna = this.Region = this.Region = this.Pais = string.Empty;
        }
    }
}
