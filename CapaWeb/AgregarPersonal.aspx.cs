using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDato;
using CapaInterface;
using CapaNegocio;

namespace CapaWeb
{
    public partial class AgregarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["PersonalBO"] == null)
            {
                Session["PersonalBO"] = new PersonalBO();
            }
            IPersonalBO personalSession = Session["PersonalBO"] as PersonalBO;


            string personalRut = DdlRUTPersona.SelectedItem.Value;
            int sucursal;
            int cargo;
            int departamento;
            Int32.TryParse(DdlSucursal.SelectedItem.Value, out sucursal);
            Int32.TryParse(DdlCargo.SelectedItem.Value, out cargo);
            Int32.TryParse(DdlDepartamento.SelectedItem.Value, out departamento);
            bool result = personalSession.AgregarPersonal(personalRut, sucursal, cargo, departamento);
            if (result)
            {
                MostrarMensaje("El Personal se guardó con éxito.");

            }
            else
            {
                MostrarMensaje("Ocurrió un error. El Personal no se guardó.");
            }
        }
    }
}
