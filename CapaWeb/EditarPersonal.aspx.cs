using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaInterface;
using CapaNegocio;
namespace CapaWeb
{
    public partial class EditarPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        private IPersonalBO CrearSession()
        {
            if (Session["PersonalBO"] == null)
            {
                Session["PersonalBO"] = new PersonalBO();
            }
            IPersonalBO personalSession = Session["PersonalBO"] as PersonalBO;
            return personalSession;
        }
    }
}