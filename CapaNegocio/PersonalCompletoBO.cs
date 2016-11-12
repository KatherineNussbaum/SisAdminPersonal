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
    public class PersonalCompletoBO : IPersonalCompletoBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de PersonalCompletoBO
        /// </summary>
        public PersonalCompletoBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Método que lista todo el Personal registrado
        /// </summary>
        /// <returns></returns>
        public IList<PersonalCompleto> ListarPersonal()
        {
            IList<PersonalCompleto> personal = (from p in _objContext.Personal
                                                join per in _objContext.Persona
                                                on p.PersonaRut equals per.Rut
                                                join s in _objContext.Sucursal
                                                on p.SucursalId equals s.Id
                                                join c in _objContext.Cargo
                                                on p.CargoId equals c.Id
                                                join d in _objContext.Departamento
                                                on p.DepartamentoId equals d.Id
                                                select new PersonalCompleto
                                                {
                                                    Id = p.Id,
                                                    Rut = p.PersonaRut,
                                                    NombreComplet = per.Nombres + " " + per.ApPaterno + " " + per.ApMaterno,
                                                    Sucursal = s.Nombre,
                                                    Cargo = c.Cargo1,
                                                    Departamento = d.Departamento1
                                                }).ToList();
            return personal;
        }

        /// <summary>
        /// Método que lista todo el Personal regisrado según sucursal
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns></returns>
        public IList<PersonalCompleto> ListarPersonalPorSucursal(string sucursal)
        {
            IList<PersonalCompleto> personal = (from p in _objContext.Personal
                                                join per in _objContext.Persona
                                                on p.PersonaRut equals per.Rut
                                                join s in _objContext.Sucursal
                                                on p.SucursalId equals s.Id
                                                join c in _objContext.Cargo
                                                on p.CargoId equals c.Id
                                                join d in _objContext.Departamento
                                                on p.DepartamentoId equals d.Id
                                                where s.Nombre.ToUpper() == sucursal.ToUpper()
                                                select new PersonalCompleto
                                                {
                                                    Id = p.Id,
                                                    Rut = p.PersonaRut,
                                                    NombreComplet = per.Nombres + " " + per.ApPaterno + " " + per.ApMaterno,
                                                    Sucursal = s.Nombre,
                                                    Cargo = c.Cargo1,
                                                    Departamento = d.Departamento1
                                                }).ToList();
            return personal;
        }

        /// <summary>
        /// Método que buscar Personal según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonalCompleto BuscarPersonal(int id)
        {
            PersonalCompleto personal = (from p in _objContext.Personal
                                         join per in _objContext.Persona
                                         on p.PersonaRut equals per.Rut
                                         join s in _objContext.Sucursal
                                         on p.SucursalId equals s.Id
                                         join c in _objContext.Cargo
                                         on p.CargoId equals c.Id
                                         join d in _objContext.Departamento
                                         on p.DepartamentoId equals d.Id
                                         where p.Id == id
                                         select new PersonalCompleto
                                         {
                                             Id = p.Id,
                                             Rut = p.PersonaRut,
                                             NombreComplet = per.Nombres + " " + per.ApPaterno + " " + per.ApMaterno,
                                             Sucursal = s.Nombre,
                                             Cargo = c.Cargo1,
                                             Departamento = d.Departamento1
                                         }).FirstOrDefault();
            return personal;
        }
        #endregion
    }
}
