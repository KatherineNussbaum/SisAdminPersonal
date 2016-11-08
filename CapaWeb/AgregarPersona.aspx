<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarPersona.aspx.cs" Inherits="CapaWeb.AgregarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 220px;
        }
        .auto-style2 {
            width: 135px;
        }
        .auto-style3 {
            margin-top: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Persona nueva</h2>
    <asp:Panel ID="PnlAgregarPersona" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtRut" runat="server" MaxLength="10" Width="200px"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligatorio">*</asp:RequiredFieldValidator>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblNombre" runat="server" Text="Nombres"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtNombres" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombres" ErrorMessage="Nombres son obligatorios">*</asp:RequiredFieldValidator>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblApPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtApPaterno" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtApPaterno" ErrorMessage="Apellido Paterno es obligatorio">*</asp:RequiredFieldValidator>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblApMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtApMaterno" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtFechaNacimiento" runat="server" TextMode="Date" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtTelefono" runat="server" TextMode="Phone" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblEmail" runat="server" Text="E-mail"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="auto-style3" TextMode="Email" Width="200px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblSexo" runat="server" Text="Sexo"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DdlSexo" runat="server">
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
                <td class="auto-style1">
                    <asp:TextBox ID="TxtDireccion" runat="server" CssClass="auto-style3" Width="199px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DdlRegion" runat="server" AutoPostBack="true" CssClass="auto-style3" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id" Height="16px" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DdlComuna" runat="server" AutoPostBack="True" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id" Height="16px" Width="200px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style1">
                    <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" />
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

        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />

        <br />
    </asp:Panel>
</asp:Content>
