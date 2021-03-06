﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class EmpresaSucursal
    {
        #region Parametros
        public string EmpresaRut { get; set; }
        public string Tipo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Comuna { get; set; }
        public string Region { get; set; }
        public string Pais { get; set; }
        #endregion
        #region Constructor
        public EmpresaSucursal()
        {
            this.EmpresaRut = this.Tipo = this.Telefono = this.Direccion = this.Comuna = this.Region = this.Pais = string.Empty;
        }
        #endregion
    }
}
