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
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor para PersonalBO
        /// </summary>
        public PersonalBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que agrega personal 
        /// </summary>
        /// <param name="personaRut"></param>
        /// <param name="sucursalId"></param>
        /// <param name="cargoId"></param>
        /// <param name="departamentoId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que busca un registro de personal segun el rut de la persona
        /// </summary>
        /// <param name="personarut"></param>
        /// <returns></returns>
        public Personal BuscarPersonal(string personarut)
        {
            return this._objContext.Personal.FirstOrDefault(p => p.PersonaRut == personarut);
        }

        /// <summary>
        /// Método que busca personal según el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Personal BuscarPersonal(int id)
        {
            return this._objContext.Personal.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Método que elimina personal según el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que lista todos los registros de personal
        /// </summary>
        /// <returns></returns>
        public IList<Personal> ListarPersonal()
        {
            return this._objContext.Personal.ToList();
        }

        /// <summary>
        /// Método que modifica un personal
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personaRut"></param>
        /// <param name="sucursalId"></param>
        /// <param name="departamentoId"></param>
        /// <param name="cargoId"></param>
        /// <returns></returns>
        public bool ModificarPersonal(int id, string personaRut, int sucursalId, int departamentoId, int cargoId)
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

        /// <summary>
        /// Método que verifica la existencia de registro personal según id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerificarPersonal(int id)
        {
            return this._objContext.Personal.Any(p => p.Id == id);
        }

        /// <summary>
        /// Método que verifica la existencia de registro de personal según el rut
        /// </summary>
        /// <param name="personaRut"></param>
        /// <returns></returns>
        public bool VerificarPersonal(string personaRut)
        {
            return this._objContext.Personal.Any(p => p.PersonaRut == personaRut);
        }
        #endregion
    }
}


