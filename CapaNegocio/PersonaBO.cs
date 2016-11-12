using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaInterface;
using CapaExcepcion;

namespace CapaNegocio
{
    public class PersonaBO : IPersonaBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor PersonaBO
        /// </summary>
        public PersonaBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Metodo que agrega una persona 
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="nombres"></param>
        /// <param name="apPaterno"></param>
        /// <param name="apMaterno"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="direccion"></param>
        /// <param name="comuna"></param>
        /// <param name="region"></param>
        /// <param name="pais"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool AgregarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, int sexo,
            string direccion, int comuna, int region, int pais, string telefono, string email)
        {
            IngresoRut(rut);
            IngresoNombres(nombres);
            IngresoApPaterno(apPaterno);
            if (this.VerificarPersona(rut))
            {
                throw new PersonaException("Este rut ya esta registrado");
            }
            Persona persona = new Persona
            {
                Rut = rut,
                Nombres = nombres,
                ApPaterno = apPaterno,
                ApMaterno = apMaterno,
                FechaNacimieto = fechaNacimiento,
                Sexo = sexo,
                Direccion = direccion,
                ComunaId = comuna,
                RegionId = region,
                PaisId = pais,
                Telefono = telefono,
                Email = email
            };
            this._objContext.Persona.Add(persona);
            return this._objContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Método que busca una persona seún su rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public Persona BuscarPersona(string rut)
        {
            return this._objContext.Persona.FirstOrDefault(p => p.Rut == rut);
        }

        /// <summary>
        /// Método que elimina una persona según su rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool EliminarPersona(string rut)
        {
            if(string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut))
            {
                throw new PersonaException("Error: Debe ingresar un rut");
            }
            if (!this.VerificarPersona(rut))
            {
                throw new PersonaException("El rut ingresado no se encuentra registrado");
            }
            Persona persona = BuscarPersona(rut);
            this._objContext.Persona.Remove(persona);
            return this._objContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Método que lista todas las personas registradas
        /// </summary>
        /// <returns></returns>
        public IList<Persona> ListarPersona()
        {
            return this._objContext.Persona.ToList();
        }

        /// <summary>
        /// Método que modifica una persona
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="nombres"></param>
        /// <param name="apPaterno"></param>
        /// <param name="apMaterno"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="direccion"></param>
        /// <param name="comuna"></param>
        /// <param name="region"></param>
        /// <param name="pais"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ModificarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, int sexo, 
            string direccion, int comuna, int region, int pais, string telefono, string email)
        {
            IngresoRut(rut);
            IngresoNombres(nombres);
            IngresoApPaterno(apPaterno);
            if (!this.VerificarPersona(rut))
            {
                throw new PersonaException("El rut ingresado no esta registrado");
            }
            
            Persona persona = this.BuscarPersona(rut);
            persona.Nombres = nombres;
            persona.ApPaterno = apPaterno;
            persona.ApMaterno = apMaterno;
            persona.FechaNacimieto = fechaNacimiento;
            persona.Sexo = sexo;
            persona.Direccion = direccion;
            persona.ComunaId = comuna;
            persona.RegionId = region;
            persona.PaisId = pais;
            persona.Telefono = telefono;
            persona.Email = email;
            return this._objContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Método que modifica una persona
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="nombres"></param>
        /// <param name="apPaterno"></param>
        /// <param name="apMaterno"></param>
        /// <param name="fechaNacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool ModificarPersona(string rut, string nombres, string apPaterno, string apMaterno, DateTime? fechaNacimiento, 
            int sexo, string direccion, string telefono, string email)
        {
            IngresoRut(rut);
            IngresoNombres(nombres);
            IngresoApPaterno(apPaterno);
            if (!this.VerificarPersona(rut))
            {
                throw new PersonaException("El rut ingresado no esta registrado");
            }

            Persona persona = this.BuscarPersona(rut);
            persona.Nombres = nombres;
            persona.ApPaterno = apPaterno;
            persona.ApMaterno = apMaterno;
            persona.FechaNacimieto = fechaNacimiento;
            persona.Sexo = sexo;
            persona.Direccion = direccion;
            persona.Telefono = telefono;
            persona.Email = email;
            return this._objContext.SaveChanges() > 0;
        }

        /// <summary>
        /// Métoo que verifica la existencia de un registro de persona según su rut
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool VerificarPersona(string rut)
        {
            return this._objContext.Persona.Any(p => p.Rut == rut);
        }

        /// <summary>
        /// Metodo que verifica el llenado de campo rut
        /// </summary>
        /// <param name="rut"></param>
        protected void IngresoRut(string rut)
        {
            if (string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut))
            {
                throw new PersonaException("Error: Debe ingresar un rut");
            }
        }

        /// <summary>
        /// Método que verifica el llenado del campo nombres
        /// </summary>
        /// <param name="nombres"></param>
        protected void IngresoNombres(string nombres)
        {
            if (string.IsNullOrEmpty(nombres) || string.IsNullOrWhiteSpace(nombres))
            {
                throw new PersonaException("Error: Debe ingresar nombres");
            }
        }

        /// <summary>
        /// Método que verifica el llenado de campo apellido
        /// </summary>
        /// <param name="apPaterno"></param>
        protected void IngresoApPaterno(string apPaterno)
        {
            if (string.IsNullOrEmpty(apPaterno) || string.IsNullOrWhiteSpace(apPaterno))
            {
                throw new PersonaException("Error: Debe ingresar apellido paterno");
            }
        }
        #endregion
    }
}
