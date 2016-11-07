<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarPersonal.aspx.cs" Inherits="CapaWeb.AgregarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="LblMensaje" runat="server" Text="SI" Visible="False"></asp:Label>
    <br />
    R.U.T. :<asp:DropDownList ID="DdlRUTPersona" runat="server" DataSourceID="ODSRUTPersona" DataTextField="Rut" DataValueField="Rut">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RfvRut" runat="server" ControlToValidate="DdlRUTPersona" ErrorMessage="Ingrese RUT"></asp:RequiredFieldValidator>
    <asp:ObjectDataSource ID="ODSRUTPersona" runat="server" SelectMethod="ListarPersona" TypeName="CapaNegocio.PersonaBO"></asp:ObjectDataSource>
    <asp:Label ID="LblSucursal" runat="server" Text="Sucursal :"></asp:Label>
    <asp:DropDownList ID="DdlSucursal" runat="server" DataSourceID="OdsSucursal" DataTextField="Nombre" DataValueField="Id">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RfvSucursal" runat="server" ControlToValidate="DdlSucursal" ErrorMessage="Ingrese Sucursal"></asp:RequiredFieldValidator>
    <asp:ObjectDataSource ID="OdsSucursal" runat="server" SelectMethod="ListarSucursal" TypeName="CapaNegocio.SucursalBO"></asp:ObjectDataSource>
    <asp:Label ID="LblCargo" runat="server" Text="Cargo :"></asp:Label>
    <asp:DropDownList ID="DdlCargo" runat="server" DataSourceID="OdsCargo" DataTextField="Cargo1" DataValueField="Id">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RfvCargo" runat="server" ControlToValidate="DdlCargo" ErrorMessage="Ingrese Cargo"></asp:RequiredFieldValidator>
    <asp:ObjectDataSource ID="OdsCargo" runat="server" SelectMethod="ListarCargo" TypeName="CapaNegocio.CargoBO"></asp:ObjectDataSource>
    <asp:Label ID="LblDepartamento" runat="server" Text="Departamento :"></asp:Label>
    <asp:DropDownList ID="DdlDepartamento" runat="server" DataSourceID="OdsDepartamento" DataTextField="Departamento1" DataValueField="Id">
    </asp:DropDownList>
    <asp:RequiredFieldValidator ID="RfvDepartamento" runat="server" ControlToValidate="DdlDepartamento" ErrorMessage="Ingrese Departamento"></asp:RequiredFieldValidator>
    <asp:ObjectDataSource ID="OdsDepartamento" runat="server" SelectMethod="ListarDepartamento" TypeName="CapaNegocio.DepartamentoBO"></asp:ObjectDataSource>
    <asp:Button ID="lblAgregarPersonal" runat="server" OnClick="lblAgregarPersonal_Click" Text="Guardar" />
    <asp:ValidationSummary ID="VsAgregarPersona" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

