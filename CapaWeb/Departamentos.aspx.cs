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
    public partial class Departamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAbrirAgregar_Click(object sender, EventArgs e)
        {
            PnlAgregar.Visible = true;
        }
        protected void BtnAbrirEditar_Click(object sender, EventArgs e)
        {
            PnlEditar.Visible = true;
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            #region revisar si hay datos
            if(string.IsNullOrEmpty(TxtNombreAgregar.Text) || string.IsNullOrWhiteSpace(TxtNombreAgregar.Text))
            {
                MostrarMensaje("Debe ingresar un nombre para departamento.");
            }
            else
            {
                #region Session
                IDepartamentoBO departamentoSession = CrearSession();
                #endregion
                #region Verificar si ya existe
                if (departamentoSession.VerificarDepartameto(TxtNombreAgregar.Text))
                {
                    MostrarMensaje("Departamento ya existe.");
                }
                #endregion
                else
                {
                    string nombre = TxtNombreAgregar.Text;
                    bool result = departamentoSession.AgregarDepartamento(nombre);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("Departamento fue agregado con éxito.");
                        LimpiarFormAgregar();
                        PnlAgregar.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. Departamento no se guardo.");
                        LimpiarFormAgregar();
                        PnlAgregar.Visible = false;
                    }
                    #endregion
                }
            }
            #endregion
        }

        private IDepartamentoBO CrearSession()
        {
            if (Session["DepartamentoBO"] == null)
            {
                Session["DepartamentoBO"] = new DepartamentoBO();
            }
            IDepartamentoBO departamentoSession = Session["DepartamentoBO"] as DepartamentoBO;
            return departamentoSession;
        }

        private void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje; 
            LblMensaje.Visible = true;
        }

        protected void LimpiarFormAgregar()
        {
            TxtNombreAgregar.Text = string.Empty;
        }
        protected void LimpiarFormBuscar()
        {
            TxtNombreBuscar.Text = string.Empty;
        }
        protected void LimpiarFormEditar()
        {
            TxtNombreDepartamentoNuevo.Text = string.Empty;
            TxtId.Text = 0.ToString();
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            #region Validar si hay nombre
            if(string.IsNullOrEmpty(TxtNombreBuscar.Text) || string.IsNullOrWhiteSpace(TxtNombreBuscar.Text))
            {
                MostrarMensaje("Debe ingresar un nombre para el departamento.");
            }
            #endregion
            else
            {
                #region Session
                IDepartamentoBO departamentoSession = CrearSession();
                #endregion
                #region Verificar existencia
                if (!departamentoSession.VerificarDepartameto(TxtNombreBuscar.Text))
                {
                   MostrarMensaje("El departamento ingresado no se encuentra registrado");
                }
                #endregion
                else
                {
                    #region Buscar Departamento
                    string nombre = TxtNombreBuscar.Text;
                    Departamento departamento = new Departamento();
                    departamento = departamentoSession.BuscarDepartamento(nombre);
                    #endregion
                    #region Mensaje
                    if(null != departamento)
                    {
                        LblMensaje.Visible = false;
                        PnlEditarEliminar.Visible = true;
                        TxtNombreDepartamentoNuevo.Text = departamento.Departamento1;
                        TxtId.Text = departamento.Id.ToString();
                        LimpiarFormBuscar();
                        PnlEditar.Visible = true;
                    }
                    else
                    {
                        LimpiarFormBuscar();
                        MostrarMensaje("El nombre ingresado no esta registrado.");
                    }
                    #endregion
                }
            }
        }
        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtNombreDepartamentoNuevo.Text) || string.IsNullOrWhiteSpace(TxtNombreDepartamentoNuevo.Text))
            {
                MostrarMensaje("Debe ingresar un nombre para el departamento.");
            }
            else
            {
                #region Session
                IDepartamentoBO departamentoSession = CrearSession();
                #endregion
                #region Variables
                string nombre = TxtNombreDepartamentoNuevo.Text;
                int id;
                Int32.TryParse(TxtId.Text, out id);
                #endregion
                #region Verificar si existe
                if (!departamentoSession.VerificarDepartameto(id))
                {
                    MostrarMensaje("El departamento ingresado no existe");
                }
                else if (departamentoSession.VerificarDepartameto(nombre))
                {
                    MostrarMensaje("El departamento ya existe.");
                }
                else
                {
                    bool result = departamentoSession.ModificarDepartamento(id, nombre);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("El departamento fue modificado con éxito.");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;                        
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. El departamento no se guardó");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;
                    }
                    #endregion
                }

                #endregion
            }
        }
        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtNombreDepartamentoNuevo.Text) || string.IsNullOrWhiteSpace(TxtNombreDepartamentoNuevo.Text))
            {
                MostrarMensaje("Debe ingresar un nombre de departamento");
            }
            else
            {
                #region Session
                IDepartamentoBO departamentoSession = CrearSession();
                #endregion
                #region Variables
                string nombre = TxtNombreDepartamentoNuevo.Text;
                int id;
                Int32.TryParse(TxtId.Text, out id);
                #endregion
                #region Verificar que existe
                if (!departamentoSession.VerificarDepartameto(id))
                {
                    MostrarMensaje("Departamento no existe");
                }
                else
                {
                    bool result = departamentoSession.EliminarDepartamento(id);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("El departamento fue eliminado con exito");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. El departamento no fue eliminado.");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;
                    }
                    #endregion
                }
                #endregion
            }
        }
    }
}