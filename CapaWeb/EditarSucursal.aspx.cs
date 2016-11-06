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
    public partial class EditarSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected ISucursalBO CrearSession()
        {
            if(Session["SucursalBO"] == null)
            {
                Session["SucursalBO"] = new SucursalBO();
            }
            ISucursalBO sucursalSession = Session["SucursalBO"] as SucursalBO;
            return sucursalSession;
        }

        protected void MostrarMensaje(string mensaje)
        {
            LblMensaje.Text = mensaje;
            LblMensaje.Visible = true;
        }

        protected void LimpiarForm()
        {
            TxtId.Text = TxtNombre.Text = TxtBuscarNombre.Text = TxtDireccion.Text = TxtTelefono.Text = TxtTipo.Text = LblPaisActual.Text = LblRegionActual.Text = LblComunaActual.Text = string.Empty;
            PnlEditarLocalidad.Visible = false;
            LblComunaActual.Visible = LblRegionActual.Visible = LblComunaActual.Visible == true;
            PnlEditar.Visible = false;
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtBuscarNombre.Text) || string.IsNullOrWhiteSpace(TxtBuscarNombre.Text))
            {
                MostrarMensaje("Debe ingresar un nombre de sucursal para buscar");
            }
            else
            {
                ISucursalBO sucursalSession = CrearSession();
                if (!sucursalSession.VerificarSucursal(TxtBuscarNombre.Text))
                {
                    MostrarMensaje("El nombre sucursal no se encuentra registrado");
                }
                else
                {
                    string nombreBuscar = TxtBuscarNombre.Text;
                    Sucursal sucursal = new Sucursal();
                    sucursal = sucursalSession.BuscarSucursal(nombreBuscar);

                    if(null != sucursal)
                    {
                        LblPaisActual.Visible = LblRegionActual.Visible = LblComunaActual.Visible = true;
                        PnlEditarLocalidad.Visible = false;
                        LblMensaje.Visible = false;
                        PnlEditar.Visible = true;
                        TxtId.Text = sucursal.Id.ToString();
                        TxtNombre.Text = sucursal.Nombre;
                        TxtTelefono.Text = sucursal.Telefono;
                        TxtDireccion.Text = sucursal.Direccion;
                        TxtTipo.Text = sucursal.Tipo;
                        
                        if(null != sucursal.EmpresaRut)
                        {
                            DdlEmpresa.SelectedItem.Value = sucursal.EmpresaRut;
                        }

                        PaisBO pais = new PaisBO();
                        string paisLetra = pais.BuscarPais(sucursal.PaisId);

                        RegionBO region = new RegionBO();
                        string regionLetra = region.BuscarRegion(sucursal.RegionId);

                        ComunaBO comuna = new ComunaBO();
                        string comunaLetra = comuna.BuscarComuna(sucursal.ComunaId);

                        LblComunaActual.Text = comunaLetra;
                        LblRegionActual.Text = regionLetra;
                        LblPaisActual.Text = paisLetra;
                    }
                    else
                    {
                        MostrarMensaje("El nombre ingresado no esta registrado");
                    }
                }
            }
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtId.Text) || string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MostrarMensaje("Debe seleccionar una sucursal para eliminar");
            }
            else
            {
                ISucursalBO sucursalSession = CrearSession();
                int id;
                Int32.TryParse(TxtId.Text, out id);

                if (!sucursalSession.VerificarSucursal(id))
                {
                    MostrarMensaje("Sucursal seleccionada no esta registrada.");
                }
                else
                {
                    bool result = sucursalSession.EliminarSucursal(id);
                    if (result)
                    {
                        MostrarMensaje("La sucursal fue eliminada con éxito");
                        LimpiarForm();
                    }
                    else
                    {
                        MostrarMensaje("Ocurrió un error. La sucursal no fue eliminada");
                    }
                }
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(TxtId.Text) || string.IsNullOrWhiteSpace(TxtId.Text))
            {
                MostrarMensaje("No hay sucursal seleccionada");
            }
            if(string.IsNullOrEmpty(TxtNombre.Text) || string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MostrarMensaje("La sucursal debe tener un nombre");
            }
            if(string.IsNullOrEmpty(DdlEmpresa.SelectedValue) || string.IsNullOrWhiteSpace(DdlEmpresa.SelectedValue))
            {
                MostrarMensaje("Debe seleccionar una empresa");
            }
            else
            {
                ISucursalBO sucursalSession = CrearSession();
                int id;
                Int32.TryParse(TxtId.Text, out id);
                string nombre = TxtNombre.Text;
                string empresaRut = DdlEmpresa.SelectedValue;
                string tipo = TxtTipo.Text;
                string telefono = TxtTelefono.Text;
                string direccion = TxtDireccion.Text;
                bool result;
                if(PnlEditarLocalidad.Visible == true)
                {
                    int pais;
                    int region;
                    int comuna;
                    Int32.TryParse(DdlPais.SelectedItem.Value, out pais);
                    Int32.TryParse(DdlRegion.SelectedItem.Value, out region);
                    Int32.TryParse(DdlComuna.SelectedItem.Value, out comuna);

                    result = sucursalSession.ModificarSucursal(id, nombre, empresaRut, tipo, direccion, pais, region, comuna, telefono);
                }
                else
                {
                    result = sucursalSession.ModificarSucursal(id, nombre, empresaRut, tipo, direccion, telefono);
                }

                if (result)
                {
                    MostrarMensaje("La sucursal fue modificada con éxito.");
                    LimpiarForm();

                }
                else
                {
                    MostrarMensaje("Ocurrió un error. No fue modificada la sucursal.");
                }
            }
        }

        protected void BtnCambiarRegion_Click(object sender, EventArgs e)
        {
            LblPaisActual.Visible = false;
            LblRegionActual.Visible = false;
            LblComunaActual.Visible = false;
            PnlEditarLocalidad.Visible = true;
        }
    }
}