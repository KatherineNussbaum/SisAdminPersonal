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
        private SistemaPersonalEntities _objContext;
        
        public SucursalBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #region Métodos
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

        public Sucursal BuscarSucursal(string nombre)
        {
            return this._objContext.Sucursal.FirstOrDefault(s => s.Nombre == nombre);
        }

        public Sucursal BuscarSucursal(int id)
        {
            return this._objContext.Sucursal.FirstOrDefault(s => s.Id == id);
        }

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

        public IList<Sucursal> ListarSucursal()
        {
            return this._objContext.Sucursal.ToList();
        }

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
            if (VerificarSucursal(id))
            {
                Sucursal sucursal = this.BuscarSucursal(id);
                sucursal.Nombre = nombre;
                sucursal.EmpresaRut = empresaRut;
                sucursal.Tipo = tipo;
                sucursal.Direccion = direccion;
                sucursal.ComunaId = comuna;
                sucursal.RegionId = region;
                sucursal.PaisId = pais;
                sucursal.Telefono = telefono;
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }

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

        public bool VerificarSucursal(int id)
        {
            return this._objContext.Sucursal.Any(s => s.Id == id);
        }

        public bool VerificarSucursal(string nombre)
        {
            return this._objContext.Sucursal.Any(s => s.Nombre == nombre);
        }
        #endregion
    }
}
