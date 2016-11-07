using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using CapaDato;
using CapaExcepcion;
using CapaInterface;

namespace CapaNegocio
{

    public class PersonalBO : IPersonalBO
    {
        private SistemaPersonalEntities _objContext;

        public PersonalBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #region Métodos
        public bool AgregarPersonal(string personaRut, int sucursalId, int cargoId, int departamentoId)
        {
            if (string.IsNullOrEmpty(personaRut) || string.IsNullOrWhiteSpace(personaRut))
            {
                throw new PersonalException("Error: falta RUT");
            }
            if (sucursalId <= 0)
            {
                throw new PersonalException("Error: falta Sucursal");
            }
            if (cargoId <= 0)
            {
                throw new PersonalException("Error: falta Cargo");
            }
            if (departamentoId <= 0)
            {
                throw new PersonalException("Error: falta Departamento");
            }
            Personal personal = new Personal
            {
                PersonaRut = personaRut,
                SucursalId = sucursalId,
                CargoId = cargoId,
                DepartamentoId = departamentoId
            };
            this._objContext.Personal.Add(personal);
            return this._objContext.SaveChanges() > 0;

        }

        public Personal BuscarPersonal(string personarut)
        {
            return this._objContext.Personal.FirstOrDefault(p => p.PersonaRut == personarut);
        }

        public Personal BuscarPersonal(int id)
        {
            return this._objContext.Personal.FirstOrDefault(p => p.Id == id);
        }

        public bool EliminarPersonal(int id)
        {
            if (id <= 0)
            {
                throw new PersonalException("Error: falta id");
            }
            if (!VerificarPersonal(id))
            {
                throw new PersonalException("Error: no existe Personal registrado");
            }
            Personal personal = BuscarPersonal(id);
            this._objContext.Personal.Remove(personal);
            return this._objContext.SaveChanges() > 0;
        }

        public IList<Personal> ListarPersonal()
        {
            return this._objContext.Personal.ToList();
        }


        public bool ModificarPersonal(int id, string personaRut, int sucursalId, int cargoId, int departamentoId)
        {
            if (id <= 0)
            {
                throw new PersonalException("Error: falta id");
            }
            if (string.IsNullOrEmpty(personaRut) || string.IsNullOrWhiteSpace(personaRut))
            {
                throw new PersonalException("Error: falta nombre");
            }
            if (sucursalId <= 0)
            {
                throw new PersonalException("Error: falta Sucursal");
            }
            if (cargoId <= 0)
            {
                throw new PersonalException("Error: falta Cargo");
            }
            if (departamentoId <= 0)
            {
                throw new PersonalException("Error: falta Departamento");
            }
            Personal personal = BuscarPersonal(id);
            personal.PersonaRut = personaRut;
            personal.SucursalId = sucursalId;
            personal.DepartamentoId = departamentoId;
            personal.CargoId = cargoId;
            return this._objContext.SaveChanges() > 0;
        }

        public bool VerificarPersonal(int id)
        {
            return this._objContext.Personal.Any(p => p.Id == id);
        }

        public bool VerificarPersonal(string personaRut)
        {
            return this._objContext.Personal.Any(p => p.PersonaRut == personaRut);
        }
        #endregion
    }
}


