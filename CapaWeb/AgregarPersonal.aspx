<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarPersonal.aspx.cs" Inherits="CapaWeb.AgregarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 130px;
        }
        .auto-style2 {
            width: 207px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Personal</h2>
    <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <table class="nav-justified">
        <tr>
            <td class="auto-style1">R.U.T. :&nbsp;</td>
            <td class="auto-style2"><asp:DropDownList ID="DdlRUTPersona" runat="server" DataSourceID="ODSRUTPersona" DataTextField="Rut" DataValueField="Rut" Height="16px" Width="200px">
    </asp:DropDownList>&nbsp;</td>
            <td><asp:RequiredFieldValidator ID="RfvRut" runat="server" ControlToValidate="DdlRUTPersona" ErrorMessage="Ingrese RUT"></asp:RequiredFieldValidator>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
    <asp:Label ID="LblSucursal" runat="server" Text="Sucursal :"></asp:Label>
            </td>
            <td class="auto-style2">
    <asp:DropDownList ID="DdlSucursal" runat="server" DataSourceID="OdsSucursal" DataTextField="Nombre" DataValueField="Id" Height="19px" Width="200px">
    </asp:DropDownList>
            </td>
            <td><asp:RequiredFieldValidator ID="RfvSucursal" runat="server" ControlToValidate="DdlSucursal" ErrorMessage="Ingrese Sucursal"></asp:RequiredFieldValidator>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"><asp:Label ID="LblDepartamento" runat="server" Text="Departamento :"></asp:Label>&nbsp;</td>
            <td class="auto-style2"><asp:DropDownList ID="DdlDepartamento" runat="server" DataSourceID="OdsDepartamento" DataTextField="Departamento1" DataValueField="Id" Height="16px" Width="200px">
    </asp:DropDownList>&nbsp;</td>
            <td><asp:RequiredFieldValidator ID="RfvDepartamento" runat="server" ControlToValidate="DdlDepartamento" ErrorMessage="Ingrese Departamento"></asp:RequiredFieldValidator>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style1">

    <asp:Label ID="LblCargo" runat="server" Text="Cargo :"></asp:Label>
             </td>
            <td class="auto-style2">
    <asp:DropDownList ID="DdlCargo" runat="server" DataSourceID="OdsCargo" DataTextField="Cargo1" DataValueField="Id" Width="200px">
    </asp:DropDownList>
             </td>
            <td><asp:RequiredFieldValidator ID="RfvCargo" runat="server" ControlToValidate="DdlCargo" ErrorMessage="Ingrese Cargo"></asp:RequiredFieldValidator>&nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2"><asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" />&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ODSRUTPersona" runat="server" SelectMethod="ListarPersona" TypeName="CapaNegocio.PersonaBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsSucursal" runat="server" SelectMethod="ListarSucursal" TypeName="CapaNegocio.SucursalBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsDepartamento" runat="server" SelectMethod="ListarDepartamento" TypeName="CapaNegocio.DepartamentoBO"></asp:ObjectDataSource>

    
    <asp:ObjectDataSource ID="OdsCargo" runat="server" SelectMethod="ListarCargo" TypeName="CapaNegocio.CargoBO"></asp:ObjectDataSource>
    
    <asp:ValidationSummary ID="VsAgregarPersona" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>

