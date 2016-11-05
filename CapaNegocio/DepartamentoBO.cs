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
    public class DepartamentoBO : IDepartamentoBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        public DepartamentoBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion
        #region Métodos
        public bool AgregarDepartamento(string nombre)
        {
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new DepartamentoException("Error: falta nombre departamento");
            }

            if (!this.VerificarDepartameto(nombre))
            {
                Departamento departamento = new Departamento
                {
                    Departamento1 = nombre
                };
                this._objContext.Departamento.Add(departamento);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        public Departamento BuscarDepartamento(int id)
        {
            return this._objContext.Departamento.FirstOrDefault(d => d.Id == id);
        }
        public Departamento BuscarDepartamento(string nombre)
        {
            return this._objContext.Departamento.FirstOrDefault(d => d.Departamento1 == nombre);
        }
        public bool EliminarDepartamento(int id)
        {
            if(id <= 0)
            {
                throw new DepartamentoException("Error: falta id");
            }
            if (this.VerificarDepartameto(id))
            {
                Departamento departamento = BuscarDepartamento(id);
                this._objContext.Departamento.Remove(departamento);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        public IList<Departamento> ListarDepartamento()
        {
            return this._objContext.Departamento.ToList();
        }
        public bool ModificarDepartamento(int id, string nombre)
        {
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new DepartamentoException("Error: falta nombre de departamento");
            }
            if(id <= 0)
            {
                throw new DepartamentoException("Error: El id no es válido.");
            }
            if (this.VerificarDepartameto(id))
            {
                Departamento departamento = this.BuscarDepartamento(id);
                departamento.Departamento1 = nombre;
                return this._objContext.SaveChanges() > 0;
             
            }
            return false;
        }
        public bool VerificarDepartameto(string nombre)
        {
            return this._objContext.Departamento.Any(d => d.Departamento1 == nombre);
        }
        public bool VerificarDepartameto(int id)
        {
            return this._objContext.Departamento.Any(d => d.Id == id);
        }
        #endregion
    }
}
