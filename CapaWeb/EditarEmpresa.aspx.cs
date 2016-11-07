using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaDato;
using CapaInterface;
using CapaNegocio;
using CapaExcepcion;

namespace CapaWeb
{
    public partial class EditarEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            #region Validar Rut a Buscar
            if (string.IsNullOrEmpty(TxtRutBuscar.Text) || string.IsNullOrWhiteSpace(TxtRutBuscar.Text))
            {
                MostrarMensaje("Debe ingresar un rut a buscar.");
            }
            #endregion
            else
            {
                #region Sesion
                IEmpresaBO empresaSession = CrearSession();
                #endregion
                #region Verificar Rut
                if (!empresaSession.VerificarEmpresa(TxtRutBuscar.Text))
                {
                    MostrarMensaje("El rut no esta registrado");
                }
                #endregion
                else
                {
                    #region Buscar Rut
                    string rutBuscar = TxtRutBuscar.Text;
                    Empresa empresa = new Empresa();
                    empresa = empresaSession.BuscarEmpresa(rutBuscar);
                    if (null != empresa)
                    {
                        LblMensaje.Visible = false;
                        PnlEditarEmpresa.Visible = true;
                        TxtRut.Text = empresa.Rut;
                        TxtNombre.Text = empresa.Nombre;
                        TxtRazonSocial.Text = empresa.RazonSocial;
                        TxtRutBuscar.Text = string.Empty;
                    }
                    else
                    {
                        LimpiarPnlEditar();
                        MostrarMensaje("El rut ingresado no esta registrado.");
                    }
                    #endregion
                }
            }
        }

        private IEmpresaBO CrearSession()
        {
            if (Session["EmpresaBO"] == null)
            {
                Session["EmpresaBO"] = new EmpresaBO();
            }
            IEmpresaBO empresaSession = Session["EmpresaBO"] as EmpresaBO;
            return empresaSession;
        }

        private void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("Debe ingresar un rut.");
            }
            else
            {
                #region Session
                IEmpresaBO empresaSession = CrearSession();
                #endregion
                #region verificar si existe
                if (!empresaSession.VerificarEmpresa(TxtRut.Text))
                {
                    MostrarMensaje("El rut ingresado no esta registrado.");
                }
                #endregion
                else
                {
                    #region Variables
                    string rut = TxtRut.Text;
                    #endregion
                    if(Session["SucursalBO"] == null)
                    {
                        Session["SucursalBO"] = new SucursalBO();
                    }
                    ISucursalBO sucursalSession = Session["SucursalBO"] as SucursalBO;
                    if (sucursalSession.VerificarSucursalRut(rut))
                    {
                        MostrarMensaje("La empresa tiene sucursales asignada. No puede eliminar mientras que existan esta sucursales.");
                    }
                    else
                    {
                        #region Eliminar
                        bool result = empresaSession.EliminarEmpresa(rut);
                        #endregion
                        #region Mensaje
                        if (result)
                        {
                            MostrarMensaje("La empresa fue eliminada con éxito.");
                            LimpiarPnlEditar();
                        }
                        else
                        {
                            MostrarMensaje("Ocurrió un error. La empresa no se eliminó.");
                            LimpiarPnlEditar();
                        }
                        #endregion
                    }
                }
            }
        } 
        protected void BtnEditar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TxtRut.Text) || string.IsNullOrWhiteSpace(TxtRut.Text))
            {
                MostrarMensaje("Debe ingresar un rut.");
            }
            else if (string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MostrarMensaje("Debe ingresar un nombre.");
            }
            else
            {
                #region Sesion
                IEmpresaBO empresaSession = CrearSession();
                #endregion
                #region Verificar si existe
                if (!empresaSession.VerificarEmpresa(TxtRut.Text))
                {
                    MostrarMensaje("El rut ingresado no esta registrado.");
                }
                #endregion
                else
                {
                    #region Variables
                    string rut = TxtRut.Text;
                    string nombre = TxtNombre.Text;
                    string razonSocial = TxtRazonSocial.Text;
                    #endregion

                    #region Guardar
                    bool result = empresaSession.ModificarEmpresa(rut, nombre, razonSocial);
                    #endregion
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("Empresa modificada con éxito.");
                        LimpiarPnlEditar();
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La empresa no fué modificada.");
                    }
                    #endregion
                }
            }
        }
        private void LimpiarPnlEditar()
        {
            #region Limpieza Panel Editar
            TxtRut.Text = TxtNombre.Text = TxtRazonSocial.Text = string.Empty;
            PnlEditarEmpresa.Visible = false;
            #endregion
        }
    }
}