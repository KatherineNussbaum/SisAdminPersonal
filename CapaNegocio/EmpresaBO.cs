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
    public class EmpresaBO : IEmpresaBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion

        #region Constructor
        public EmpresaBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion

        #region Métodos
        public bool AgregarEmpresa(string rut, string nombre, string razonSocial)
        {
            if(string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut))
            {
                throw new EmpresaException("Error: debe ingresar un rut");
            }
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new EmpresaException("Error: debe ingresar un nombre");
            }

            if (!this.VerificarEmpresa(rut))
            {
                Empresa empresa = new Empresa
                {
                    Rut = rut,
                    Nombre = nombre,
                    RazonSocial = razonSocial
                };
                this._objContext.Empresa.Add(empresa);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        public bool EliminarEmpresa(string rut)
        {
            if(string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut))
            {
                throw new EmpresaException("Error: debe ingrese un rut");
            }
            if (this.VerificarEmpresa(rut))
            {
                Empresa empresa = BuscarEmpresa(rut);
                this._objContext.Empresa.Remove(empresa);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        public Empresa BuscarEmpresa(string rut)
        {
            return this._objContext.Empresa.FirstOrDefault(e => e.Rut == rut);
        }
        public bool ModificarEmpresa(string rut, string nombre, string razonSocial)
        {
            if(string.IsNullOrEmpty(rut) || string.IsNullOrWhiteSpace(rut))
            {
                throw new EmpresaException("Error: dene ingresar un rut");
            }
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new EmpresaException("Error; debe ingresar un nombre");
            }
            if (this.VerificarEmpresa(rut))
            {
                Empresa empresa = this.BuscarEmpresa(rut);
                empresa.Nombre = nombre;
                if(null == razonSocial)
                {
                    razonSocial = string.Empty;
                }
                empresa.RazonSocial = razonSocial;
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        public IList<Empresa> ListarEmpresa()
        {
            return this._objContext.Empresa.ToList();
        }
        public bool VerificarEmpresa(string rut)
        {
            return this._objContext.Empresa.Any(e => e.Rut == rut);
        }
        #endregion
    }
}
