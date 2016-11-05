<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="AgregarPersona.aspx.cs" Inherits="CapaWeb.AgregarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Agregar Persona nueva</h2>
    <asp:Panel ID="PnlAgregarPersona" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
        <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label><asp:TextBox ID="TxtRut" runat="server" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblNombre" runat="server" Text="Nombres"></asp:Label><asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombres" ErrorMessage="Nombres son obligatorios">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblApPaterno" runat="server" Text="Apellido Paterno"></asp:Label><asp:TextBox ID="TxtApPaterno" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtApPaterno" ErrorMessage="Apellido Paterno es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblApMaterno" runat="server" Text="Apellido Materno"></asp:Label><asp:TextBox ID="TxtApMaterno" runat="server"></asp:TextBox><br />
        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label><asp:TextBox ID="TxtFechaNacimiento" runat="server" TextMode="Date"></asp:TextBox><br />
        
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label><asp:TextBox ID="TxtTelefono" runat="server" TextMode="Phone"></asp:TextBox><br />
        <asp:Label ID="LblEmail" runat="server" Text="E-mail"></asp:Label><asp:TextBox ID="TxtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        

        <asp:Label ID="LblSexo" runat="server" Text="Sexo"></asp:Label><asp:DropDownList ID="DdlSexo" runat="server">
            <asp:ListItem Value="1">Mujer</asp:ListItem>
            <asp:ListItem Value="0">Hombre</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="LblDireccion" runat="server" Text="Dirección"></asp:Label><asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox><br />
        <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label><asp:DropDownList ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label><asp:DropDownList AutoPostBack="true" ID="DdlRegion" runat="server" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id"></asp:DropDownList><br />
        <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label><asp:DropDownList AutoPostBack="True" ID="DdlComuna" runat="server" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id"></asp:DropDownList>
        <br />
        
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
        <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" />

        <br />
    </asp:Panel>
</asp:Content>
