using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;

namespace CapaInterface
{
    public interface IRegionBO
    {
        IList<Region> ListarRegion();
        IList<Region> ListarRegionPais(int pais);
        string BuscarRegion(int? regionId);
    }
}
