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
        /// <summary>
        /// Constructor PaisBO
        /// </summary>
        public PaisBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

        
        #endregion
        #region Metodos
        /// <summary>
        /// Método que lista todos los paises registrados
        /// </summary>
        /// <returns></returns>
        public IList<Pais> ListarPais()
        {
            return this._objContext.Pais.ToList();
        }

        /// <summary>
        /// Método que verifica la existencia de un pais según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool VerificarPais(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Método que busca un pais según su id
        /// </summary>
        /// <param name="paisId"></param>
        /// <returns></returns>
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
