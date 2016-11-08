<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="CapaWeb.EditarEmpresa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 114px;
        }
        .auto-style2 {
            width: 208px
        }
        .auto-style3 {
            width: 112px;
        }
        .auto-style4 {
            width: 224px;
        }
        .auto-style5 {
            width: 95px;
        }
        .auto-style6 {
            width: 105px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Empresa</h2>
    <asp:Panel ID="PnlEmpresa" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="LblBuscarRut" runat="server" Text="Rut"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TxtRutBuscar" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
        </table>
        
        <asp:Panel ID="PnlEditarEmpresa" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="TxtRut" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RfvRut" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligariorio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="TxtNombre" runat="server" MaxLength="250" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es obligario">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Label ID="LblRazonSocial" runat="server" Text="Razón Social"></asp:Label>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="TxtRazonSocial" runat="server" MaxLength="250" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" Width="99px" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" Width="83px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
        </asp:Panel>
    </asp:Panel>
</asp:Content>
