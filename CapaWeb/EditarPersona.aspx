<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarPersona.aspx.cs" Inherits="CapaWeb.EditarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
        .auto-style2 {
            width: 146px
        }
        .auto-style3 {
            width: 145px
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Persona</h2>
    <asp:Panel ID="PnlPersona" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="LblBuscarRut" runat="server" Text="Rut"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtBuscarRut" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="BtnBuscar" runat="server" OnClick="BtnBuscar_Click" Text="Buscar" />
                </td>
            </tr>
        </table>

        <asp:Panel ID="PnlEditarPersona" runat="server" Visible="false">
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtRut" runat="server" MaxLength="10" ReadOnly="True" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligatorio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblNombre" runat="server" Text="Nombres"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtNombres" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombres" ErrorMessage="Nombres son obligatorios">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblApPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApPaterno" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtApPaterno" ErrorMessage="Apellido Paterno es obligatorio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblApMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtApMaterno" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtFechaNacimiento" runat="server" TextMode="Datetime" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtTelefono" runat="server" TextMode="Phone" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblEmail" runat="server" Text="E-mail"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblSexo" runat="server" Text="Sexo"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlSexo" runat="server" Width="200px">
                            <asp:ListItem Value="1">Mujer</asp:ListItem>
                            <asp:ListItem Value="0">Hombre</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="LblDireccion" runat="server" Text="Dirección"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TxtDireccion" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="PnlRegionActual" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label1" runat="server" Text="Comuna"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblComunaTexto" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label2" runat="server" Text="Región"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblRegionTexto" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="Label3" runat="server" Text="País"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblPaisTexto" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">&nbsp;</td>
                        <td>
                            <asp:Button ID="BtnCambiarRegion" runat="server" OnClick="BtnCambiarRegion_Click" Text="Cambiar Región" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </asp:Panel>
            
            
            <asp:Panel ID="PnlPaiRegCom" Visible="false" runat="server">
                <table class="nav-justified">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlPais" runat="server" AutoPostBack="true" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlRegion" runat="server" AutoPostBack="true" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="true" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id" Width="200px">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

                    <asp:ObjectDataSource ID="OdsPais" runat="server" SelectMethod="ListarPais" TypeName="CapaNegocio.PaisBO"></asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="OdsRegion" runat="server" SelectMethod="ListarRegionPais" TypeName="CapaNegocio.RegionBO">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DdlPais" DefaultValue="" Name="paisId" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="OdsComuna" runat="server" SelectMethod="ListaComunaRegion" TypeName="CapaNegocio.ComunaBO">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DdlRegion" Name="regionId" PropertyName="SelectedValue" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    </asp:Panel>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />
            &nbsp;<asp:Button ID="BtnEditar" runat="server" Text="Editar" OnClick="BtnEditar_Click" Width="74px" />
        </asp:Panel>

    </asp:Panel>
</asp:Content>
