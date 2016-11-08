<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarPersonal.aspx.cs" Inherits="CapaWeb.EditarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 179px;
        }
        .auto-style2 {
            width: 117px;
        }
        .auto-style4 {
            width: 126px;
        }
        .auto-style6 {
            width: 126px;
            height: 13px;
        }
        .auto-style7 {
            width: 370px;
            height: 13px;
        }
        .auto-style8 {
            height: 13px;
        }
        .auto-style10 {
            width: 370px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Personal</h2>
    <asp:Label ID="LblMensaje" Visible="false" runat="server" Text="Label"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">Seleccionar Personal:</td>
            <td class="auto-style2">
                <asp:DropDownList ID="DdlPersonal" runat="server" DataSourceID="OdsPersonal" DataTextField="NombreComplet" DataValueField="Id" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
            </td>
        </tr>
        </table>
    <asp:ObjectDataSource ID="OdsPersonal" runat="server" SelectMethod="ListarPersonal" TypeName="CapaNegocio.PersonalCompletoBO"></asp:ObjectDataSource>
    <asp:Panel ID="PnlDatosActuales" runat="server" Visible="false">
        <asp:TextBox ID="TxtId" Visible="false" runat="server" Width="36px"></asp:TextBox>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style4">Rut Persona:</td>
                <td class="auto-style10" colspan="2">
                    <asp:Label ID="LblRut" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Sucursal:</td>
                <td class="auto-style10" colspan="2">
                    <asp:Label ID="LblSucursal" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="DdlSucursal" Visible="false" runat="server" DataSourceID="OdsSucursal" DataTextField="Nombre" DataValueField="Id" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Departamento:</td>
                <td class="auto-style10" colspan="2">
                    <asp:Label ID="LblDepartamento" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="DdlDepartamento" Visible="false" runat="server" DataSourceID="OdsDepartamento" DataTextField="Departamento1" DataValueField="Id" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">Cargo:</td>
                <td class="auto-style7" colspan="2">
                    <asp:Label ID="LblCargo" runat="server" Text="Label"></asp:Label>
                    <asp:DropDownList ID="DdlCargo" Visible="false" runat="server" DataSourceID="OdsCargo" DataTextField="Cargo1" DataValueField="Id" Width="200px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" Width="95px" />
                </td>
                <td class="auto-style10">
                    <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" Width="89px" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
    <asp:ObjectDataSource ID="OdsSucursal" runat="server" SelectMethod="ListarSucursal" TypeName="CapaNegocio.SucursalBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsDepartamento" runat="server" SelectMethod="ListarDepartamento" TypeName="CapaNegocio.DepartamentoBO"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsCargo" runat="server" SelectMethod="ListarCargo" TypeName="CapaNegocio.CargoBO"></asp:ObjectDataSource>
    <br />
    

</asp:Content>
