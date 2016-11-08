using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaInterface;
using CapaNegocio;
using CapaDato;
using CapaEntidad;
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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (Session["PersonalCompletoBO"] == null)
            {
                Session["PersonalCompletoBO"] = new PersonalCompletoBO();
            }
            IPersonalCompletoBO personalSession = Session["PersonalCompletoBO"] as PersonalCompletoBO;
            int id;
            Int32.TryParse(DdlPersonal.SelectedValue, out id);

            PersonalCompleto personalActual = personalSession.BuscarPersonal(id);
            if(null != personalActual)
            {
                TxtId.Text = personalActual.Id.ToString();
                LblRut.Text = personalActual.Rut;
                LblSucursal.Text = personalActual.Sucursal;
                LblDepartamento.Text = personalActual.Departamento;
                LblCargo.Text = personalActual.Cargo;
                LblRut.Visible = LblSucursal.Visible= LblDepartamento.Visible = LblCargo.Visible = true;
                DdlCargo.Visible = DdlDepartamento.Visible = DdlSucursal.Visible = false;
                PnlDatosActuales.Visible = true;
            }
            else
            {
                MostrarMensaje("No esta registrado el personal");
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if(DdlSucursal.Visible == false)
            {
                LblSucursal.Visible = LblDepartamento.Visible = LblCargo.Visible = false;
                DdlCargo.Visible = DdlDepartamento.Visible = DdlSucursal.Visible = true;
            }
            else
            {
                int id;
                Int32.TryParse(TxtId.Text, out id);
                IPersonalBO personalSession = CrearSession();
                if (!personalSession.VerificarPersonal(id))
                {
                    MostrarMensaje("El personal seleccionado no existe");
                }
                else
                {
                    string rut = LblRut.Text;
                    int sucursalId;
                    int departamentoId;
                    int cargoId;
                    Int32.TryParse(DdlSucursal.SelectedItem.Value, out sucursalId);
                    Int32.TryParse(DdlDepartamento.SelectedItem.Value, out departamentoId);
                    Int32.TryParse(DdlCargo.SelectedItem.Value, out cargoId);

                    bool result = personalSession.ModificarPersonal(id, rut, sucursalId, departamentoId, cargoId);
                    if (result)
                    {
                        MostrarMensaje("Modificado con éxito");
                        LblRut.Visible = LblSucursal.Visible = LblDepartamento.Visible = LblCargo.Visible = true;
                        DdlCargo.Visible = DdlDepartamento.Visible = DdlSucursal.Visible = false;
                        PnlDatosActuales.Visible = false;
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. No fue modificado");
                    }
                }
            }
           
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            IPersonalBO personalSession = CrearSession();
            int id;
            Int32.TryParse(TxtId.Text, out id);
            if (!personalSession.VerificarPersonal(id))
            {
                MostrarMensaje("Personal seleccionado no existe");
            }
            else
            {
                bool result = personalSession.EliminarPersonal(id);
                if (result)
                {
                    MostrarMensaje("Personal eliminado con éxito");
                    LblRut.Visible = LblSucursal.Visible = LblDepartamento.Visible = LblCargo.Visible = true;
                    DdlCargo.Visible = DdlDepartamento.Visible = DdlSucursal.Visible = false;
                    PnlDatosActuales.Visible = false;
                    DdlPersonal.DataSourceID = "OdsPersonal";
                }
                else
                {
                    MostrarMensaje("Ocurrió un error. Personal no se elimino.");
                }
            }
        }
    }
}