using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
namespace CapaInterface
{
    public interface IPaisBO
    {
        bool VerificarPais(int id);
        IList<Pais> ListarPais();
        string BuscarPais(int? paisId);

    }
}
