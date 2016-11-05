<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarEmpresa.aspx.cs" Inherits="CapaWeb.AgregarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Empresa nueva</h2>

    <asp:Panel ID="PnlAgregarEmpresa" runat="server">
        <div class="row" ><asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false" class="alert alert-info" role="alert"></asp:Label></div>
        <div class="row">
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
        <asp:Button ID="BtnAgregar" runat="server" Text="Guardar" OnClick="BtnAgregar_Click" />

        <br />
        </div>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <br />

    </asp:Panel>

</asp:Content>
