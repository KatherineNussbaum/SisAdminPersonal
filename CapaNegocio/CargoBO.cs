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
        private SistemaPersonalEntities _objContext;

        public CargoBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

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

        public Cargo BuscarCargo(string nombre)
        {
            return this._objContext.Cargo.FirstOrDefault(c => c.Cargo1 == nombre);
        }

        public Cargo BuscarCargo(int id)
        {
            return this._objContext.Cargo.FirstOrDefault(c => c.Id == id);
        }

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

        public IList<Cargo> ListarCargo()
        {
            return this._objContext.Cargo.ToList();
        }

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

        public bool VerificarCargo(string nombre)
        {
            return this._objContext.Cargo.Any(c => c.Cargo1 == nombre);
        }

        public bool VerificarCargo(int id)
        {
            return this._objContext.Cargo.Any(c => c.Id == id);
        }
    }
}
