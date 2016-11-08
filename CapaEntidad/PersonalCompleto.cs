using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PersonalCompleto
    {
        public int Id { get; set; }
        public string  Rut { get; set; }
        public string NombreComplet { get; set; }
        public string Sucursal { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        
        public PersonalCompleto()
        {
            this.Rut = this.Sucursal = this.Cargo = this.Departamento = string.Empty;
            this.Id = 0;
        }
    }
}
