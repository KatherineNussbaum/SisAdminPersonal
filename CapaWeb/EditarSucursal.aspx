<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarSucursal.aspx.cs" Inherits="CapaWeb.EditarSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
        .auto-style2 {
            width: 221px;
        }
        .auto-style3 {
            width: 128px;
            height: 56px;
        }
        .auto-style4 {
            width: 221px;
            height: 56px;
        }
        .auto-style5 {
            height: 56px;
        }
        .auto-style6 {
            width: 131px;
        }
        .auto-style7 {
            width: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Sucursales</h2>
    <p>
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
    <table class="nav-justified">
        <tr>
            <td class="auto-style3">
        <asp:Label ID="LblBuscarNombre" runat="server" Text="Nombre Sucursal"></asp:Label> </td>
            <td class="auto-style4"> <asp:TextBox ID="TxtBuscarNombre" runat="server" Width="200px"></asp:TextBox> </td>
            <td class="auto-style5"> <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" Width="78px" />

        <asp:TextBox ID="TxtId" Visible="false" runat="server"></asp:TextBox>
        
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label> </td>
            <td class="auto-style2"> <asp:TextBox ID="TxtNombre" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombre" ErrorMessage="Nombre es obligatorio">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td class="auto-style1">
        <asp:Label ID="LblEmpresa" runat="server" Text="Empresa"></asp:Label>
            </td>
            <td class="auto-style2"><asp:DropDownList ID="DdlEmpresa" runat="server" DataSourceID="OdsEmpresa" DataTextField="Nombre" DataValueField="Rut" Width="200px">
            <asp:ListItem Value="0">&quot;&quot;</asp:ListItem>
        </asp:DropDownList>
            </td>
            <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="DdlEmpresa" ErrorMessage="Empresa es obligatorio">*</asp:RequiredFieldValidator>
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
    </table>

    <asp:Panel ID="PnlEditar" runat="server" Visible="false">
        <br />
        <asp:Panel ID="PnlUbicacionActual" runat="server">
            <asp:Label ID="LblComunaActual" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="LblRegionActual" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="LblPaisActual" runat="server" Text="Label"></asp:Label>
            <br />
        </asp:Panel>
        <asp:Button ID="BtnCambiarRegion" runat="server" OnClick="BtnCambiarRegion_Click" Text="Cambiar Ubicación Actual" />
        <br />
        <asp:Panel ID="PnlEditarLocalidad" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlRegion" runat="server" AutoPostBack="True" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">
                        <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource1" DataTextField="Comuna1" DataValueField="Id" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="BtnEliminar" runat="server" OnClick="BtnEliminar_Click" Text="Eliminar" Width="98px" />
                    </td>
                    <td>
                        <asp:Button ID="BtnEditar" runat="server" OnClick="BtnEditar_Click" Text="Editar" Width="88px" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>
        <asp:ObjectDataSource ID="OdsEmpresa" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="ListarPais" TypeName="CapaNegocio.PaisBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsRegion" runat="server" SelectMethod="ListarRegionPais" TypeName="CapaNegocio.RegionBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlPais" Name="paisId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListaComunaRegion" TypeName="CapaNegocio.ComunaBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="DdlRegion" Name="regionId" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:ValidationSummary ID="ValSum" runat="server" />
    </asp:Panel>
</asp:Content>
