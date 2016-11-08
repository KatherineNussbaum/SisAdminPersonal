<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="CapaWeb.AgregarSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 108px;
        }
        .auto-style2 {
            width: 219px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Sucursal</h2>
    <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    <br />
    <table style="width:100%;">
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:TextBox ID="TxtNombre" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es requerido">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblEmpresa" runat="server" Text="Empresa"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:DropDownList ID="DdlEmpresa" runat="server" DataSourceID="OdsEmpresa" DataTextField="Nombre" DataValueField="Rut" Width="200px">
        </asp:DropDownList>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DdlEmpresa" ErrorMessage="Empresa  es obligatorio">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblTipo" runat="server" Text="Tipo"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:TextBox ID="TxtTipo" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:TextBox ID="TxtTelefono" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblDireccion" runat="server" Text="Dirección"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:TextBox ID="TxtDireccion" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id" Width="200px">
        </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:DropDownList ID="DdlRegion" runat="server" AutoPostBack="True" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id" Width="200px">
        </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
            </td>
            <td class="auto-style2">
        <asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="True" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id" Width="200px">
        </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
        <asp:Button ID="BtnGuradar" runat="server" Text="Guardar" OnClick="BtnGuradar_Click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="PnlAgregar" runat="server">
        <asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="ListarPais" TypeName="CapaNegocio.PaisBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsRegion" runat="server" SelectMethod="ListarRegionPais" TypeName="CapaNegocio.RegionBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlPais" Name="paisId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsComuna" runat="server" SelectMethod="ListaComunaRegion" TypeName="CapaNegocio.ComunaBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlRegion" Name="regionId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsEmpresa" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
    </asp:Panel>
</asp:Content>
