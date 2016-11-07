<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarPersonal.aspx.cs" Inherits="CapaWeb.EditarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Personal</h2>
    <asp:Label ID="LblMensaje" Visible="false" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" DataKeyNames="Id" DataSourceID="OdsPersonal">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:ObjectDataSource ID="OdsPersonal" runat="server" SelectMethod="ListarPersonal" TypeName="CapaNegocio.PersonalBO"></asp:ObjectDataSource>
    <br />
    <br />

    <asp:Panel ID="PnlDatosActuales" runat="server">
        <asp:Label ID="LblId" runat="server" Text="Label" Visible="false"></asp:Label><br />
        <asp:Label ID="LblRutPersonaA" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="LblSucursalA" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="LblDepartamentoA" runat="server" Text="Label"></asp:Label><br />
        <asp:Label ID="LblCargoA" runat="server" Text="Label"></asp:Label><br />
    </asp:Panel>
    <asp:Panel ID="PnlEditar" runat="server" Visible="true">
        <asp:Label ID="LblRutPersona" runat="server" Text="Rut Persona"></asp:Label><asp:DropDownList ID="DdlRutPersona" runat="server" DataSourceID="OdsPersona" DataTextField="Rut" DataValueField="Rut"></asp:DropDownList><br />
        <asp:Label ID="LBlSucursal" runat="server" Text="Sucursal"></asp:Label><asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OdsSucursal" DataTextField="Nombre" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="LblDepartamento" runat="server" Text="Departamento"></asp:Label><asp:DropDownList ID="DdlDepartamento" runat="server" DataSourceID="OdsDepartamento" DataTextField="Departamento1" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="LblCargo" runat="server" Text="Cargo"></asp:Label><asp:DropDownList ID="DdlCargo" runat="server" DataSourceID="OdsCargo" DataTextField="Cargo1" DataValueField="Id"></asp:DropDownList><br />
        <asp:Button ID="BtnEditar" runat="server" Text="Editar" />
    </asp:Panel>
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" /> <asp:Button ID="BtnCambiar" runat="server" Text="Cambiar" />
    

    <br />
    <br />
    <asp:ObjectDataSource ID="OdsPersona" runat="server" SelectMethod="ListarPersona" TypeName="CapaNegocio.PersonaBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsSucursal" runat="server" SelectMethod="ListarSucursal" TypeName="CapaNegocio.SucursalBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsDepartamento" runat="server" SelectMethod="ListarDepartamento" TypeName="CapaNegocio.DepartamentoBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsCargo" runat="server" SelectMethod="ListarCargo" TypeName="CapaNegocio.CargoBO"></asp:ObjectDataSource>
    <br />
    

</asp:Content>
