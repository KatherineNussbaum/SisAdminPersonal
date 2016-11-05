using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaInterface;
namespace CapaNegocio
{
    public class ComunaBO : IComunaBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        public ComunaBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }

        
        #endregion
        #region Metodos
        public IList<Comuna> ListarComuna()
        {
            return this._objContext.Comuna.ToList();
        }
        public IList<Comuna> ListaComunaRegion(int regionId)
        {
            return this._objContext.Comuna.Where(c => c.RegionId == regionId).ToList();
        }

        public string BuscarComuna(int? comunaId)
        {
            string comuna = (from c in _objContext.Comuna
                             where c.Id == comunaId
                             select c.Comuna1).FirstOrDefault();
            return comuna;
        }

        #endregion
    }
}
