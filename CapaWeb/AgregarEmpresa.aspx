<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarEmpresa.aspx.cs" Inherits="CapaWeb.AgregarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 110px;
        }
        .auto-style2 {
            margin-top: 0;
        }
        .auto-style3 {
            width: 226px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Empresa nueva</h2>

    <asp:Panel ID="PnlAgregarEmpresa" runat="server">
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false" class="alert alert-info" role="alert"></asp:Label>


            <table class="nav-justified">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TxtRut" runat="server" CssClass="auto-style2" Height="21px" MaxLength="10" Width="214px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RfvRut" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligariorio">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TxtNombre" runat="server" MaxLength="250" Width="214px"></asp:TextBox>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es obligario">*</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="LblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="TxtRazonSocial" runat="server" MaxLength="250" Width="214px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style3">
                        <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Guardar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <br />

    </asp:Panel>

</asp:Content>
