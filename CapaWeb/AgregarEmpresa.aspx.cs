using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaInterface;
using CapaNegocio;
using CapaExcepcion;
namespace CapaWeb
{
    public partial class AgregarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("Debe ingresar un rut.");
            }
            else if(string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MostrarMensaje("Debe ingresar un nombre.");
            }
            else
            {
                #region Session
                if (Session["EmpresaBO"] == null)
                {
                    Session["EmpresaBO"] = new EmpresaBO();
                }
                IEmpresaBO empresaSession = Session["EmpresaBO"] as EmpresaBO;
                #endregion
                if (empresaSession.VerificarEmpresa(TxtRut.Text))
                {
                    MostrarMensaje("El rut ingresado ya se encuentra registrado.");
                }
                else
                {
                    #region Variables
                    string Rut = TxtRut.Text;
                    string Nombre = TxtNombre.Text;
                    string RazonSocial = TxtRazonSocial.Text;
                    #endregion
                    #region Guardar
                    bool result = empresaSession.AgregarEmpresa(Rut, Nombre, RazonSocial);
                    #endregion
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("Empresa Agregada con éxito.");
                        LimpiarFormulario();
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La empresa no se guardó.");
                    }
                    #endregion
                }
            }
        }

        private void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        protected void LimpiarFormulario()
        {
            #region Limpieza
            TxtRut.Text = TxtNombre.Text = TxtRazonSocial.Text = string.Empty;
            #endregion
        }
    }
}