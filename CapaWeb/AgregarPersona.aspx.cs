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
    public partial class AgregarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            #region Validacion de obligatorios
            if (string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("Debe ingresar un rut");
            }
            else if (string.IsNullOrEmpty(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text))
            {
                MostrarMensaje("Debe ingresar nombres");
            }
            else if (string.IsNullOrEmpty(TxtApPaterno.Text) || string.IsNullOrWhiteSpace(TxtApPaterno.Text))
            {
                MostrarMensaje("Debe ingresar apellido paterno");
            }
            #endregion
            else
            {
                #region Session
                if (Session["PersonaBO"] == null)
                {
                    Session["PersonaBO"] = new PersonaBO();
                }
                IPersonaBO personaSession = Session["PersonaBO"] as PersonaBO;
                #endregion
                #region si existe
                if (personaSession.VerificarPersona(TxtRut.Text))
                {
                    MostrarMensaje("El rut ya esta registrado");
                }
                #endregion
                
                else
                {
                    #region Variables
                    string Rut = TxtRut.Text;
                    string Nombres = TxtNombres.Text;
                    string ApPaterno = TxtApPaterno.Text;
                    string ApMaterno = TxtApMaterno.Text;
                    DateTime? FechaNacimiento = null;
                    string Telefono = TxtTelefono.Text;
                    string Email = TxtEmail.Text;
                    int Sexo = 0;
                    string Direccion = TxtDireccion.Text;
                    int PaisId = 0;
                    int RegionId = 0;
                    int ComunaId = 0;
                    Int32.TryParse(DdlSexo.SelectedItem.Value, out Sexo);
                    Int32.TryParse(DdlPais.SelectedItem.Value, out PaisId);
                    Int32.TryParse(DdlRegion.SelectedItem.Value, out RegionId);
                    Int32.TryParse(DdlComuna.SelectedItem.Value, out ComunaId);
                    if(!string.IsNullOrEmpty(TxtFechaNacimiento.Text) && !string.IsNullOrWhiteSpace(TxtFechaNacimiento.Text))
                    {
                        FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text);
                    }
                    #endregion
                    #region Guardar
                    bool result = personaSession.AgregarPersona(Rut, Nombres, ApPaterno, ApMaterno, FechaNacimiento, Sexo, Direccion, ComunaId, RegionId, PaisId, Telefono, Email);
                    #endregion
                    #region Mensajes
                    if (result)
                    {
                        MostrarMensaje("Persona fue agregada con éxito!");
                        #region Limpieza
                        TxtRut.Text = TxtNombres.Text = TxtApPaterno.Text = TxtApMaterno.Text = TxtDireccion.Text = TxtEmail.Text = TxtFechaNacimiento.Text = TxtTelefono.Text = string.Empty;
                        #endregion
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La persona no fue agregada.");
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
    }
}