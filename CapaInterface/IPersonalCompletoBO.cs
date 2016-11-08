using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDato;
namespace CapaInterface
{
    public interface IPersonalCompletoBO
    {
        IList<PersonalCompleto> ListarPersonal();
        PersonalCompleto BuscarPersonal(int id);
    }
}
