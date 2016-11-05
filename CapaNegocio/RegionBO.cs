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
        public RegionBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

        
        #endregion
        public IList<Region> ListarRegion()
        {
            return this._objContext.Region.ToList();
        }

        public IList<Region> ListarRegionPais(int paisId)
        {
            return this._objContext.Region.Where(r => r.PaisId == paisId).ToList();
           
        }
        public string BuscarRegion(int? regionId)
        {
            string region = (from r in _objContext.Region
                             where r.Id == regionId
                             select r.Region1).FirstOrDefault();
            return region;
        }
    }
}
