using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaInterface;
using CapaNegocio;
using CapaDato;
namespace CapaNegocio
{
    public class SucursalCompletaBO : ISucursalCompletaBO
    {
        #region Variables
        private SistemaPersonalEntities _objContext;
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor de SucursalCompletaBO
        /// </summary>
        public SucursalCompletaBO()
        {
            this._objContext = new SistemaPersonalEntities();
        }
        #endregion
        #region Métodos
        /// <summary>
        /// Método que lista todas las sucursales registradas
        /// </summary>
        /// <returns></returns>
        public IList<SucursalCompleta> Listar()
        {
            IList<SucursalCompleta> sucursales = (from s in _objContext.Sucursal
                                             join e in _objContext.Empresa
                                             on s.EmpresaRut equals e.Rut
                                             join p in _objContext.Pais
                                             on s.PaisId equals p.Id
                                             join r in _objContext.Region
                                             on s.RegionId equals r.Id
                                             join c in _objContext.Comuna
                                             on s.ComunaId equals c.Id
                                             select new SucursalCompleta
                                             {
                                                 Id = s.Id,
                                                 Nombre = s.Nombre,
                                                 EmpresaRut = s.EmpresaRut,
                                                 NombreEmpresa = e.Nombre,
                                                 Tipo = s.Tipo,
                                                 Telefono = s.Telefono,
                                                 Direccion = s.Direccion,
                                                 Comuna = c.Comuna1,
                                                 Region = r.Region1,
                                                 Pais = p.Pais1
                                             }
                                                 ).ToList();

            return sucursales;
        }

        /// <summary>
        /// Método que lista las sucursales según el rut empresa
        /// </summary>
        /// <param name="rut"></param>
        /// <returns></returns>
        public IList<SucursalCompleta> ListarPorEmpresa(string rut)
        {
            List<SucursalCompleta> sucursales = (from s in _objContext.Sucursal
                                                 join e in _objContext.Empresa
                                                 on s.EmpresaRut equals e.Rut
                                                 join p in _objContext.Pais
                                                 on s.PaisId equals p.Id
                                                 join r in _objContext.Region
                                                 on s.RegionId equals r.Id
                                                 join c in _objContext.Comuna
                                                 on s.ComunaId equals c.Id
                                                 where s.EmpresaRut == rut
                                                 select new SucursalCompleta
                                                 {
                                                     Id = s.Id,
                                                     Nombre = s.Nombre,
                                                     EmpresaRut = s.EmpresaRut,
                                                     NombreEmpresa = e.Nombre,
                                                     Tipo = s.Tipo,
                                                     Telefono = s.Telefono,
                                                     Direccion = s.Direccion,
                                                     Comuna = c.Comuna1,
                                                     Region = r.Region1,
                                                     Pais = p.Pais1
                                                 }
                                                 ).ToList();

            return sucursales;
        }
        #endregion
    }
}
