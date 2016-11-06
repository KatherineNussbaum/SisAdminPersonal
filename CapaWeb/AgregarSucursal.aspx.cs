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
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }
        protected void BtnGuradar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MostrarMensaje("Debe ingresar un nombre de sucursal");
            }
            else if(DdlEmpresa.SelectedValue == null)
            {
                MostrarMensaje("Debe seleccionar una empresa");
            }
            else
            {
                if(Session["SucursalBO"] == null)
                {
                    Session["SucursalBO"] = new SucursalBO();
                }
                ISucursalBO sucursalSession = Session["SucursalBO"] as SucursalBO;

                if (sucursalSession.VerificarSucursal(TxtNombre.Text))
                {
                    MostrarMensaje("El nombre ingresado para la sucursal ya existe. Eliga otro nombre.");
                }
                else
                {
                    string nombre = TxtNombre.Text;
                    string empresaRut = DdlEmpresa.SelectedItem.Value;
                    string tipo = TxtTipo.Text;
                    string direccion = TxtDireccion.Text;
                    string telefono = TxtTelefono.Text;
                    int pais;
                    int region;
                    int comuna;
                    Int32.TryParse(DdlPais.SelectedItem.Value, out pais);
                    Int32.TryParse(DdlRegion.SelectedItem.Value, out region);
                    Int32.TryParse(DdlComuna.SelectedItem.Value, out comuna);

                    bool result = sucursalSession.AgregarSucursal(nombre, empresaRut, tipo, direccion, comuna, region, pais, telefono);

                    if (result)
                    {
                        MostrarMensaje("La sucursal se guardó con éxito.");
                        TxtNombre.Text = TxtTipo.Text = TxtDireccion.Text = TxtTelefono.Text = string.Empty;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La sucursal no se guardó.");
                    }
                }
            }
        }
    }
}