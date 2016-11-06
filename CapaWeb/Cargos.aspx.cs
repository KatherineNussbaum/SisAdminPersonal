using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaInterface;
using CapaNegocio;
using CapaDato;

namespace CapaWeb
{
    public partial class Cargos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridCargos.DataSourceID = "ObjectDataSource1";
            if (!IsPostBack)
            {
                GridCargos.EmptyDataText = "No hay cargos registrados";
            }
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
            if (string.IsNullOrEmpty(TxtNombreAgregar.Text) || string.IsNullOrWhiteSpace(TxtNombreAgregar.Text))
            {
                MostrarMensaje("Debe ingresar un nombre para cargo.");
            }
            else
            {
                #region Session
                ICargoBO cargoSession = CrearSession();
                #endregion
                #region Verificar si ya existe
                if (cargoSession.VerificarCargo(TxtNombreAgregar.Text))
                {
                    MostrarMensaje("Cargo ya existe.");
                }
                #endregion
                else
                {
                    string nombre = TxtNombreAgregar.Text;
                    bool result = cargoSession.AgregarCargo(nombre);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("Cargo fue agregado con éxito.");
                        LimpiarFormAgregar();
                        PnlAgregar.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. Cargo no se guardo.");
                        LimpiarFormAgregar();
                        PnlAgregar.Visible = false;
                    }
                    #endregion
                }
            }
            #endregion
        }

        private ICargoBO CrearSession()
        {
            if (Session["CargoBO"] == null)
            {
                Session["CargoBO"] = new CargoBO();
            }
            ICargoBO cargoSession = Session["CargoBO"] as CargoBO;
            return cargoSession;
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
            TxtNombreCargoNuevo.Text = string.Empty;
            TxtId.Text = 0.ToString();
        }
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            #region Validar si hay nombre
            if (string.IsNullOrEmpty(TxtNombreBuscar.Text) || string.IsNullOrWhiteSpace(TxtNombreBuscar.Text))
            {
                MostrarMensaje("Debe ingresar un nombre para el cargo.");
            }
            #endregion
            else
            {
                #region Session
                ICargoBO cargoSession = CrearSession();
                #endregion
                #region Verificar existencia
                if (!cargoSession.VerificarCargo(TxtNombreBuscar.Text))
                {
                    MostrarMensaje("El cargo ingresado no se encuentra registrado");
                }
                #endregion
                else
                {
                    #region Buscar Departamento
                    string nombre = TxtNombreBuscar.Text;
                    Cargo cargo = new Cargo();
                    cargo = cargoSession.BuscarCargo(nombre);
                    #endregion
                    #region Mensaje
                    if (null != cargo)
                    {
                        LblMensaje.Visible = false;
                        PnlEditarEliminar.Visible = true;
                        TxtNombreCargoNuevo.Text = cargo.Cargo1;
                        TxtId.Text = cargo.Id.ToString();
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
            if (string.IsNullOrEmpty(TxtNombreCargoNuevo.Text) || string.IsNullOrWhiteSpace(TxtNombreCargoNuevo.Text))
            {
                MostrarMensaje( "Debe ingresar un nombre para el cargo.");
            }
            else
            {
                #region Session
                ICargoBO cargoSession = CrearSession();
                #endregion
                #region Variables
                string nombre = TxtNombreCargoNuevo.Text;
                int id;
                Int32.TryParse(TxtId.Text, out id);
                #endregion
                #region Verificar si existe
                if (!cargoSession.VerificarCargo(id))
                {
                    MostrarMensaje("El departamento ingresado no existe");
                }
                else if (cargoSession.VerificarCargo(nombre))
                {
                    MostrarMensaje("El cargo ya existe.");
                }
                else
                {
                    bool result = cargoSession.ModificarCargo(id, nombre);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("El cargo fue modificado con éxito.");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. El cargo no se guardó");
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
            if (string.IsNullOrEmpty(TxtNombreCargoNuevo.Text) || string.IsNullOrWhiteSpace(TxtNombreCargoNuevo.Text))
            {
                MostrarMensaje("Debe ingresar un nombre de cargo");
            }
            else
            {
                #region Session
                ICargoBO cargoSession = CrearSession();
                #endregion
                #region Variables
                string nombre = TxtNombreCargoNuevo.Text;
                int id;
                Int32.TryParse(TxtId.Text, out id);
                #endregion
                #region Verificar que existe
                if (!cargoSession.VerificarCargo(id))
                {
                    MostrarMensaje("Cargo no existe");
                }
                else
                {
                    bool result = cargoSession.EliminarCargo(id);
                    #region Mensaje
                    if (result)
                    {
                        MostrarMensaje("El cargo fue eliminado con exito");
                        LimpiarFormBuscar();
                        LimpiarFormEditar();
                        PnlEditarEliminar.Visible = false;
                        PnlEditar.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. El cargo no fue eliminado.");
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