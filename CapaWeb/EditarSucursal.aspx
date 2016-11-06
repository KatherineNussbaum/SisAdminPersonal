<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarSucursal.aspx.cs" Inherits="CapaWeb.EditarSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Sucursales</h2>
    <p>
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
        <asp:Label ID="LblBuscarNombre" runat="server" Text="Nombre Sucursal"></asp:Label> <asp:TextBox ID="TxtBuscarNombre" runat="server"></asp:TextBox> <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

    <asp:Panel ID="PnlEditar" runat="server" Visible="false">
        <asp:TextBox ID="TxtId" Visible="false" runat="server"></asp:TextBox>
        
        <br />
        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label> <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es obligatorio">*</asp:RequiredFieldValidator><br />
        <asp:Label ID="LblEmpresa" runat="server" Text="Empresa"></asp:Label>
        &nbsp;<asp:DropDownList ID="DdlEmpresa" runat="server" DataSourceID="OdsEmpresa" DataTextField="Nombre" DataValueField="Rut">
            <asp:ListItem Value="0">&quot;&quot;</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlEmpresa" ErrorMessage="Empresa es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblTipo" runat="server" Text="Tipo"></asp:Label>
        <asp:TextBox ID="TxtTipo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
        <asp:TextBox ID="TxtTelefono" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblDireccion" runat="server" Text="Dirección"></asp:Label>
        <asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
        <br />
        <asp:Panel ID="PnlUbicacionActual" runat="server">
            <asp:Label ID="LblComunaActual" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LblRegionActual" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LblPaisActual" runat="server" Text="Label"></asp:Label>
        <br />
        </asp:Panel>
        
        <asp:Button ID="BtnCambiarRegion" runat="server" Text="Cambiar Ubicación Actual" OnClick="BtnCambiarRegion_Click" />
        <br />
        <asp:Panel ID="PnlEditarLocalidad" runat="server" Visible="false">
             <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
        &nbsp;<asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
        &nbsp;<asp:DropDownList ID="DdlRegion" runat="server" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
             &nbsp;<asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Comuna1" DataValueField="Id">
             </asp:DropDownList>
        <br />
        </asp:Panel>
        <br />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
        &nbsp;&nbsp;<asp:Button ID="BtnEditar" runat="server" Text="Editar" OnClick="BtnEditar_Click" />
        <asp:ObjectDataSource ID="OdsEmpresa" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        &nbsp;<asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="ListarPais" TypeName="CapaNegocio.PaisBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsRegion" runat="server" SelectMethod="ListarRegionPais" TypeName="CapaNegocio.RegionBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlPais" Name="paisId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListaComunaRegion" TypeName="CapaNegocio.ComunaBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlRegion" Name="regionId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:ValidationSummary ID="ValSum" runat="server" />
        <br />
    </asp:Panel>
</asp:Content>
