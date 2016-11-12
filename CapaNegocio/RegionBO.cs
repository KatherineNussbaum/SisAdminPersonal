using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaInterface;
namespace CapaNegocio
{
    public class RegionBO : IRegionBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor RegionBO
        /// </summary>
        public RegionBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que lista todas las regiones registradas
        /// </summary>
        /// <returns></returns>
        public IList<Region> ListarRegion()
        {
            return this._objContext.Region.ToList();
        }

        /// <summary>
        /// Método que lista las regiones según el pais
        /// </summary>
        /// <param name="paisId"></param>
        /// <returns></returns>
        public IList<Region> ListarRegionPais(int paisId)
        {
            return this._objContext.Region.Where(r => r.PaisId == paisId).ToList();
           
        }

        /// <summary>
        /// Método que busca una región según su nombre
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns></returns>
        public string BuscarRegion(int? regionId)
        {
            string region = (from r in _objContext.Region
                             where r.Id == regionId
                             select r.Region1).FirstOrDefault();
            return region;
        }
        #endregion
    }
}
