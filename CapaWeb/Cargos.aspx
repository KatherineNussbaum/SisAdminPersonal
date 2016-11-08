<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Cargos.aspx.cs" Inherits="CapaWeb.Cargos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 144px;
        }
        .auto-style2 {
            width: 115px;
        }
        .auto-style3 {
            width: 216px;
        }
        .auto-style4 {
            width: 215px;
        }
        .auto-style5 {
            width: 114px;
        }
        .auto-style6 {
            width: 143px;
        }
        .auto-style7 {
            width: 60px;
        }
        .auto-style8 {
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Cargos</h2>
    <p>
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridCargos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EmptyDataText="No hay datos para mostrar." Width="242px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Cargo1" HeaderText="Cargo" SortExpression="Cargo1" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="CapaNegocio.CargoBO" SelectMethod="ListarCargo"></asp:ObjectDataSource>
    </p>
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
    <asp:Button ID="btnAbrirAgregar" runat="server" Text="Nuevo Cargo" OnClick="btnAbrirAgregar_Click" />
            </td>
            <td>
    <asp:Button ID="BtnAbrirEditar" runat="server" Text="Editar Cargo" OnClick="BtnAbrirEditar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
        </table>
&nbsp;<asp:Panel ID="PnlAgregar" runat="server" Visible="false">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2">
                <asp:Label ID="LblNombreCargoAgregar" runat="server" Text="Nombre Cargo"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:TextBox ID="TxtNombreAgregar" runat="server" AutoPostBack="False" CssClass="col-xs-offset-0" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombreAgregar" ErrorMessage="Nombre Cargo es obligatorio">*</asp:RequiredFieldValidator>
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
                    <asp:Label ID="LblNombreBuscar" runat="server" Text="Nombre Cargo: "></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="TxtNombreBuscar" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnBuscar" runat="server" CssClass="col-xs-offset-0" OnClick="BtnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
        </table>

        <asp:Panel ID="PnlEditarEliminar" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="NombreNuevo" runat="server" Text="Nombre Cargo"></asp:Label>
                    </td>
                    <td class="auto-style4" colspan="2">
                        <asp:TextBox ID="TxtNombreCargoNuevo" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtId" runat="server" Visible="false"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style8">
                        <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" />
                        &nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />

    </asp:Panel>
</asp:Content>
