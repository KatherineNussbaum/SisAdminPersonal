//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDato
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personal
    {
        public int Id { get; set; }
        public string PersonaRut { get; set; }
        public Nullable<int> SucursalId { get; set; }
        public Nullable<int> CargoId { get; set; }
        public Nullable<int> DepartamentoId { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        public virtual Departamento Departamento { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Sucursal Sucursal { get; set; }
    }
}
