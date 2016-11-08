using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDato;
using CapaEntidad;
using CapaExcepcion;
using CapaInterface;
namespace CapaNegocio
{
    public class PersonaCompletaBO : IPersonaCompletaBO
    {
        private SistemaPersonalEntities _objContext;
        public PersonaCompletaBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

        public IList<PersonaCompleta> ListarPersonaCompleta()
        {
            IList<PersonaCompleta> personas = (from p in _objContext.Persona
                                               join a in _objContext.Pais
                                               on p.PaisId equals a.Id
                                               join r in _objContext.Region
                                               on p.RegionId equals r.Id
                                               join c in _objContext.Comuna
                                               on p.ComunaId equals c.Id
                                               select new PersonaCompleta
                                               {
                                                   Rut = p.Rut,
                                                   Nombres = p.Nombres,
                                                   ApPaterno = p.ApPaterno,
                                                   ApMaterno = p.ApMaterno,
                                                   FechaNacimiento = p.FechaNacimieto,
                                                   Sexo = p.Sexo,
                                                   Telefono = p.Telefono,
                                                   Email = p.Email,
                                                   Direccion = p.Direccion,
                                                   Comuna = c.Comuna1,
                                                   Region = r.Region1,
                                                   Pais = a.Pais1
                                               }
                                               ).ToList();
            return personas;
        }
    }
}
