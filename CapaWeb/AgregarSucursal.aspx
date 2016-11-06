<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="CapaWeb.AgregarSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Sucursal</h2>
    <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    <br />
    <asp:Panel ID="PnlAgregar" runat="server">
        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es requerido">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblEmpresa" runat="server" Text="Empresa"></asp:Label>
        <asp:DropDownList ID="DdlEmpresa" runat="server" DataSourceID="OdsEmpresa" DataTextField="Nombre" DataValueField="Rut">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlEmpresa" ErrorMessage="Empresa  es obligatorio">*</asp:RequiredFieldValidator>
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
        <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
        <asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
        <asp:DropDownList ID="DdlRegion" runat="server" AutoPostBack="True" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
        <asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="True" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id">
        </asp:DropDownList>
        <br />
        <asp:Button ID="BtnGuradar" runat="server" Text="Guardar" OnClick="BtnGuradar_Click" />
        <br />
        <asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="ListarPais" TypeName="CapaNegocio.PaisBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsRegion" runat="server" SelectMethod="ListarRegionPais" TypeName="CapaNegocio.RegionBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlPais" Name="paisId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsComuna" runat="server" SelectMethod="ListaComunaRegion" TypeName="CapaNegocio.ComunaBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlRegion" Name="regionId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
        <asp:ObjectDataSource ID="OdsEmpresa" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </asp:Panel>
</asp:Content>
