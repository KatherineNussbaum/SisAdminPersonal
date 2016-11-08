<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="CapaWeb.Departamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 227px;
        }
        .auto-style2 {
            width: 164px
        }
        .auto-style3 {
            width: 214px;
        }
        .auto-style4 {
            width: 163px;
        }
        .auto-style7 {
            width: 114px;
        }
        .auto-style8 {
            width: 102px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Departamentos</h2>
    <p>
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridDepartamentos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EmptyDataText="No hay datos para mostrar." Width="244px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Departamento1" HeaderText="Departamento" SortExpression="Departamento1" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="CapaNegocio.DepartamentoBO" SelectMethod="ListarDepartamento"></asp:ObjectDataSource>
    </p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">

    <asp:Button ID="btnAbrirAgregar" runat="server" Text="Nuevo Departamento" OnClick="btnAbrirAgregar_Click" />
                </td>
                <td>
    <asp:Button ID="BtnAbrirEditar" runat="server" Text="Editar Departamento" OnClick="BtnAbrirEditar_Click" CssClass="col-xs-offset-0" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </p>
<asp:Panel ID="PnlAgregar" runat="server" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LblNombreDepartamentoAgregar" runat="server" Text="Nombre Departamento"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TxtNombreAgregar" runat="server" AutoPostBack="False" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombreAgregar" ErrorMessage="Nombre Departamento es obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Panel ID="PnlEditar" runat="server" Visible="false">
        <table style="width: 100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblNombreBuscar" runat="server" Text="Nombre Departamento: "></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="TxtNombreBuscar" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
        </table>

        <asp:Panel ID="PnlEditarEliminar" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="NombreNuevo" runat="server" Text="Nombre Departamento"></asp:Label>
                    </td>
                    <td class="auto-style7" colspan="2">
                        <asp:TextBox ID="TxtNombreDepartamentoNuevo" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtId" runat="server" CssClass="col-xs-offset-0" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" Width="100px" />
                    </td>
                    <td class="auto-style8">
                        <asp:Button ID="BtnEditar" runat="server" CssClass="col-xs-offset-0" OnClick="BtnEditar_Click" Text="Editar" Width="92px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />

    </asp:Panel>

</asp:Content>
