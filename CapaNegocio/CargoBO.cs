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
    public class CargoBO : ICargoBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Métodos
        
        /// <summary>
        /// Constructor CargoBO
        /// </summary>
        public CargoBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        
        /// <summary>
        /// Método que agrega cargo
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool AgregarCargo(string nombre)
        {
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new CargoException("Error: falta nombre cargo");
            }
            else if (!this.VerificarCargo(nombre))
            {
                Cargo cargo = new Cargo
                {
                    Cargo1 = nombre
                };
                this._objContext.Cargo.Add(cargo);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }
        
        /// <summary>
        /// Método que busca cargo por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public Cargo BuscarCargo(string nombre)
        {
            return this._objContext.Cargo.FirstOrDefault(c => c.Cargo1.ToUpper() == nombre.ToUpper());
        }

        /// <summary>
        /// Método que busca Cargo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cargo BuscarCargo(int id)
        {
            return this._objContext.Cargo.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Método que elimina cargo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EliminarCargo(int id)
        {
            if(id <= 0)
            {
                throw new CargoException("Error: Falta id");
            }
            else if (this.VerificarCargo(id))
            {
                Cargo cargo = BuscarCargo(id);
                this._objContext.Cargo.Remove(cargo);
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// Método que lista todos los cargos registrados
        /// </summary>
        /// <returns></returns>
        public IList<Cargo> ListarCargo()
        {
            return this._objContext.Cargo.ToList();
        }

        /// <summary>
        /// Método para modificar nombre de cargo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool ModificarCargo(int id, string nombre)
        {
            if(id <= 0)
            {
                throw new CargoException("Error: falta id");
            }
            else if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
            {
                throw new CargoException("Error: falta nombre cargo");
            }
            if(this.VerificarCargo(id))
            {
                Cargo cargo = this.BuscarCargo(id);
                cargo.Cargo1 = nombre;
                return this._objContext.SaveChanges() > 0;
            }
            return false;
        }

        /// <summary>
        /// Método para verificar si existe cargo busando por nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public bool VerificarCargo(string nombre)
        {
            return this._objContext.Cargo.Any(c => c.Cargo1.ToUpper() == nombre.ToUpper());
        }

        /// <summary>
        /// Método para verificar si existe cargo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerificarCargo(int id)
        {
            return this._objContext.Cargo.Any(c => c.Id == id);
        }

        #endregion
    }
}
