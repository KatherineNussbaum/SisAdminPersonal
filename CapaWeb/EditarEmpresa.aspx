<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="CapaWeb.EditarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Empresa</h2>
    <asp:Panel ID="PnlEmpresa" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>

        <asp:Label ID="LblBuscarRut" runat="server" Text="Rut"></asp:Label><asp:TextBox ID="TxtRutBuscar" runat="server" MaxLength="10"></asp:TextBox>
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
        
        <asp:Panel ID="PnlEditarEmpresa" runat="server" Visible="false">
            <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label>
        <asp:TextBox ID="TxtRut" runat="server" Width="128px" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RfvRut" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligariorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="TxtNombre" runat="server" MaxLength="250"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es obligario">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
        <asp:TextBox ID="TxtRazonSocial" runat="server" MaxLength="250"></asp:TextBox><br />

            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />  
            <asp:Button ID="BtnEditar" runat="server" Text="Editar" OnClick="BtnEditar_Click" />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
