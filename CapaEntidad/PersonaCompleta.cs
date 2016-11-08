using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PersonaCompleta
    {
        public string Rut { get; set; }
        public string Nombres { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? Sexo { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }

        public PersonaCompleta()
        {
            this.Rut = this.Nombres = this.ApPaterno = this.ApMaterno = this.Telefono = this.Email = this.Direccion = this.Comuna = this.Region = this.Pais = string.Empty;

        }
    }
}
