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
    public partial class EditarPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            #region Validar Rut a Buscar
            if (string.IsNullOrEmpty(TxtBuscarRut.Text) || string.IsNullOrWhiteSpace(TxtBuscarRut.Text))
            {
                MostrarMensaje("Debe ingresar un rut de persona para buscar.");
                PnlEditarPersona.Visible = false;
            }
            #endregion
            else
            {
                #region Session
                IPersonaBO personaSession = CrearSession();
                #endregion
                #region Verificar si existe
                if (!personaSession.VerificarPersona(TxtBuscarRut.Text))
                {
                    MostrarMensaje("El rut no esta registrado");
                }
                #endregion
                else
                {
                    #region Buscar Rut
                    string RutBuscar = TxtBuscarRut.Text;
                    Persona persona = personaSession.BuscarPersona(RutBuscar);
                    if (null != persona)
                    {
                        PaisBO pais = new PaisBO();
                        string paisLetra = pais.BuscarPais(persona.PaisId);

                        RegionBO region = new RegionBO();
                        string regionLetra = region.BuscarRegion(persona.RegionId);

                        ComunaBO comuna = new ComunaBO();
                        string comunaLetra = comuna.BuscarComuna(persona.ComunaId);

                        LblMensaje.Visible = false;
                        PnlEditarPersona.Visible = true;
                        TxtRut.Text = persona.Rut;
                        TxtNombres.Text = persona.Nombres;
                        TxtApPaterno.Text = persona.ApPaterno;
                        TxtApMaterno.Text = persona.ApMaterno;
                        TxtDireccion.Text = persona.Direccion;
                        TxtEmail.Text = persona.Email;
                        DateTime fn;
                        System.DateTime.TryParse(persona.FechaNacimieto.ToString(), out fn);
                        TxtFechaNacimiento.Text = fn.Date.ToString("d");
                        TxtTelefono.Text = persona.Telefono;
                        DdlSexo.ClearSelection();
                        DdlSexo.SelectedValue = persona.Sexo.ToString();
                        LblPaisTexto.Text = paisLetra;
                        LblRegionTexto.Text = regionLetra;
                        LblComunaTexto.Text = comunaLetra;
                    }
                    #endregion
                }
            }
        }

        private IPersonaBO CrearSession()
        {
            if (Session["PersonaBO"] == null)
            {
                Session["PersonaBO"] = new PersonaBO();
            }
            IPersonaBO personaSession = Session["PersonaBO"] as PersonaBO;
            return personaSession;
        }

        private void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            #region Validación de obligatorios
            if (string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("Debe ingresar un Rut");
            }
            else if (string.IsNullOrEmpty(TxtNombres.Text) || string.IsNullOrWhiteSpace(TxtNombres.Text))
            {
                MostrarMensaje("Debe ingresar los nombres");
            }
            else if (string.IsNullOrEmpty(TxtApPaterno.Text) || string.IsNullOrWhiteSpace(TxtApPaterno.Text))
            {
                MostrarMensaje("Debe ingresar el apellido paterno");
            }
            #endregion
            else
            {
                #region Session
                IPersonaBO personaSession = CrearSession();
                #endregion
                #region Verificar si existe
                if (!personaSession.VerificarPersona(TxtRut.Text))
                {
                    MostrarMensaje("El rut no esta registrado");
                    LimpiarFormulario();
                    PnlEditarPersona.Visible = false;
                    PnlRegionActual.Visible = false;
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
                    Int32.TryParse(DdlSexo.SelectedItem.Value, out Sexo);
                    string Direccion = TxtDireccion.Text;
                    if (!string.IsNullOrEmpty(TxtFechaNacimiento.Text) && !string.IsNullOrWhiteSpace(TxtFechaNacimiento.Text))
                    {
                        FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text);
                    }
                    PnlRegionActual.Visible = true;
                    #endregion
                    #region Guardar
                        if (PnlPaiRegCom.Visible == true)
                        {
                            int PaisId = 0;
                            int RegionId = 0;
                            int ComunaId = 0;
                            Int32.TryParse(DdlPais.SelectedItem.Value, out PaisId);
                            Int32.TryParse(DdlRegion.SelectedItem.Value, out RegionId);
                            Int32.TryParse(DdlComuna.SelectedItem.Value, out ComunaId);
                            bool result = personaSession.ModificarPersona(Rut, Nombres, ApPaterno, ApMaterno, FechaNacimiento, Sexo, Direccion, ComunaId, RegionId, PaisId, Telefono, Email);
                            Mensaje(result);
                        }
                        else
                        {
                            bool result = personaSession.ModificarPersona(Rut, Nombres, ApPaterno, ApMaterno, FechaNacimiento, Sexo, Direccion, Telefono, Email);
                            Mensaje(result);
                        }
                    #endregion
                }
            }
        }
        public void Mensaje(bool result)
        {
            #region Mensajes
            if (result)
            {
                MostrarMensaje("Persona fue modificada con éxito!");
                #region Limpieza
                LimpiarFormulario();
                #endregion
                PnlEditarPersona.Visible = false;
                PnlPaiRegCom.Visible = false;
            }
            else
            {
                MostrarMensaje("Ocurrió un error. La persona no fue modificada.");
            }
            #endregion
        }
        protected void BtnCambiarRegion_Click(object sender, EventArgs e)
        {
            PnlRegionActual.Visible = false;
            PnlPaiRegCom.Visible = true;
        }
        protected void LimpiarFormulario()
        {
            TxtRut.Text = TxtNombres.Text = TxtApPaterno.Text = TxtApMaterno.Text = TxtDireccion.Text = TxtEmail.Text = TxtFechaNacimiento.Text = TxtTelefono.Text = string.Empty;
        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            #region Debe existir Rut
            if(string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("No hay rut seleccionado.");
            }
            #endregion
            else
            {
                #region Session
                IPersonaBO personaSession = CrearSession();
                #endregion
                #region Verificar si existe
                if (!personaSession.VerificarPersona(TxtRut.Text))
                {
                    MostrarMensaje("El rut ingresado no esta registrado");
                }
                #endregion
                else
                {
                    string rut = TxtRut.Text;
                    #region Eliminar
                    bool result = personaSession.EliminarPersona(rut);
                    #endregion
                    /*
                    if(Session["PersonalBO"] == null)
                    {
                        Session["PersonalBO"] = new PersonalBO();
                    }
                    IPersonalBO sucursalSession = Session["PersonalBO"] as PersonalBO;

                    if (sucursalSession.VerificarSucursalRut(rut))
                    {
                        MostrarMensaje("Esta persona tiene datos de personal asignado. Mientras que sea así no se podrá eliminar");
                    }*/
                    #region Mensaje
                        if (result)
                    {
                        MostrarMensaje("La persona fue eliminada con éxito");
                        LimpiarFormulario();
                        PnlEditarPersona.Visible = false;
                        PnlPaiRegCom.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La persona no se eliminó.");
                        LimpiarFormulario();
                    }
                    #endregion
                }
            }
        }
    }
}