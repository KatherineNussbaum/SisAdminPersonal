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
    public class SucursalBO : ISucursalBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor SucursalBO
        /// </summary>
        public SucursalBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Método que agrega una sucursal
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="empresaRut"></param>
        /// <param name="tipo"></param>
        /// <param name="direccion"></param>
        /// <param name="comuna"></param>
        /// <param name="region"></param>
        /// <param name="pais"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>
        public bool AgregarSucursal(string nombre, string empresaRut, string tipo, 
            string direccion, int comuna, int region, int pais, string telefono)
        {
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new SucursalException("Error: falta nombre");
            }
            if(string.IsNullOrEmpty(empresaRut) || string.IsNullOrWhiteSpace(empresaRut))
            {
                throw new SucursalException("Error: falta rut de empresa");
            }
            if (!VerificarSucursal(nombre))
            {
                Sucursal sucursal = new Sucursal
                {
                    Nombre = nombre,
                    EmpresaRut = empresaRut,
                    Tipo = tipo,
                    Direccion = direccion,
                    ComunaId = comuna,
                    RegionId = region,
                    PaisId = pais,
                    Telefono = telefono
                };
                this._objContext.Sucursal.Add(sucursal);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// Método que busca una sucursal según su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Sucursal BuscarSucursal(string nombre)
        {
            return this._objContext.Sucursal.FirstOrDefault(s => s.Nombre.ToUpper() == nombre.ToUpper());
        }

        /// <summary>
        /// Método que busa sucursal según id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Sucursal BuscarSucursal(int id)
        {
            return this._objContext.Sucursal.FirstOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Método que elimina sucursal según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EliminarSucursal(int id)
        {
            if(id <= 0)
            {
                throw new SucursalException("Error: falta id");
            }
            if (VerificarSucursal(id))
            {
                Sucursal sucursal = BuscarSucursal(id);
                this._objContext.Sucursal.Remove(sucursal);
                return this._objContext.SaveChanges() > 0;
            }
            return false;            
        }

        /// <summary>
        /// Métod que lista todas las sucursales registrados
        /// </summary>
        /// <returns></returns>
        public IList<Sucursal> ListarSucursal()
        {
            return this._objContext.Sucursal.ToList();
        }

        /// <summary>
        /// Método que modifica una sucursal con su localización
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="empresaRut"></param>
        /// <param name="tipo"></param>
        /// <param name="direccion"></param>
        /// <param name="comuna"></param>
        /// <param name="region"></param>
        /// <param name="pais"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>
        public bool ModificarSucursal(int id, string nombre, string empresaRut, string tipo, 
            string direccion, int comuna, int region, int pais, string telefono)
        {
            if(id <= 0)
            {
                throw new SucursalException("Error: falta id");
            }
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new SucursalException("Error: falta nombre");
            }
            if(string.IsNullOrEmpty(empresaRut) || string.IsNullOrWhiteSpace(empresaRut))
            {
                throw new SucursalException("Error: falta rut de empresa");
            }
            if (!this.VerificarSucursal(id))
            {
                throw new SucursalException("La sucursal no se encuebtra registrada");
            }
           
            Sucursal sucursal = this.BuscarSucursal(id);
            sucursal.Nombre = nombre;
            sucursal.EmpresaRut = empresaRut;
            sucursal.Tipo = tipo;
            sucursal.Direccion = direccion;
            sucursal.PaisId = pais;
            sucursal.RegionId = region;
            sucursal.ComunaId = comuna;
            sucursal.Telefono = telefono;
            return this._objContext.SaveChanges() > 0;
      }
      
        /// <summary>
        /// Método que modifica una sucursal sin la localización 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="empresaRut"></param>
        /// <param name="tipo"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <returns></returns>
        public bool ModificarSucursal(int id, string nombre, string empresaRut, string tipo,
            string direccion, string telefono)
        {
            if (id <= 0)
            {
                throw new SucursalException("Error: falta id");
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new SucursalException("Error: falta nombre");
            }
            if (string.IsNullOrEmpty(empresaRut) || string.IsNullOrWhiteSpace(empresaRut))
            {
                throw new SucursalException("Error: falta rut de empresa");
            }
            if (VerificarSucursal(id))
            {
                Sucursal sucursal = this.BuscarSucursal(id);
                sucursal.Nombre = nombre;
                sucursal.EmpresaRut = empresaRut;
                sucursal.Tipo = tipo;
                sucursal.Direccion = direccion;
                sucursal.Telefono = telefono;
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// Método que verifica la existencia de una sucursal según su id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerificarSucursal(int id)
        {
            return this._objContext.Sucursal.Any(s => s.Id == id);
        }

        /// <summary>
        /// Método que verifica la existencia del registro de una sucursal según su nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool VerificarSucursal(string nombre)
        {
            return this._objContext.Sucursal.Any(s => s.Nombre.ToUpper() == nombre.ToUpper());
        }

        /// <summary>
        /// Método que verifica la existencia de registro de sucursales según el rut de empresa
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public bool VerificarSucursalRut(string rut)
        {
            return this._objContext.Sucursal.Any(s => s.EmpresaRut == rut);
        }
        #endregion
    }
}
