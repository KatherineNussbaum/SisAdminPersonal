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
        bool AgregarPersonal(string PersonaRut, int SucursalId, int CargoId, int DepartamentoId)
        {
            if (string.IsNullOrEmpty(PersonaRut) || string.IsNullOrWhiteSpace(PersonaRut))
            {
                throw new PersonalException("Error: falta RUT");
            }
            if (SucursalId <= 0)
            {
                throw new PersonalException("Error: falta Sucursal");
            }

            if (CargoId <= 0)
            {
                throw new PersonalException("Error: falta Cargo");
            }

            if (DepartamentoId <= 0)
            {
                throw new PersonalException("Error: falta Departamento");
            }
            return false;

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

            return false;
        }

        public IList<Personal> ListarPersonal()
        {
            return this._objContext.Personal.ToList();
        }

        public bool ModificarPersonal(int Id, string PersonaRut, int SucursalId, int CargoId, int DepartamentoId)
        {
            if (Id <= 0)
            {
                throw new PersonalException("Error: falta id");
            }
            if (string.IsNullOrEmpty(PersonaRut) || string.IsNullOrWhiteSpace(PersonaRut))
            {
                throw new PersonalException("Error: falta nombre");
            }
            if (SucursalId <= 0)
            {
                throw new PersonalException("Error: falta Sucursal");
            }

            if (CargoId <= 0)
            {
                throw new PersonalException("Error: falta Cargo");
            }

            if (DepartamentoId <= 0)
            {
                throw new PersonalException("Error: falta Departamento");
            }

            return false;
        }

        bool IPersonalBO.AgregarPersonal(string PersonaRut, int SucursalId, int CargoId, int DepartamentoId)
        {
            throw new NotImplementedException();
        }

        public bool VerificarPersonal(int id)
        {
            throw new NotImplementedException();
        }

        public bool VerificarPersonal(string PersonaRut)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


