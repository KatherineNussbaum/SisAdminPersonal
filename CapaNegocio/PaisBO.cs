using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaInterface;

namespace CapaNegocio
{
    public class PaisBO : IPaisBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        public PaisBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

        
        #endregion
        #region Metodos
        public IList<Pais> ListarPais()
        {
            return this._objContext.Pais.ToList();
        }

        public bool VerificarPais(int id)
        {
            throw new NotImplementedException();
        }
        public string BuscarPais(int? paisId)
        {
            string pais = (from p in _objContext.Pais
                               where p.Id == paisId
                               select p.Pais1).FirstOrDefault();
            return pais;
        }
        #endregion

    }
}
