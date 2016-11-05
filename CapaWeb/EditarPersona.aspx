<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="EditarPersona.aspx.cs" Inherits="CapaWeb.EditarPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Editar y Eliminar Persona</h2>
    <asp:Panel ID="PnlPersona" runat="server">
        <p>
            <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
        </p>
        <p>
            <asp:Label ID="LblBuscarRut" runat="server" Text="Rut"></asp:Label><asp:TextBox ID="TxtBuscarRut" MaxLength="10" runat="server"></asp:TextBox><asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
        </p>
        <asp:Panel ID="PnlEditarPersona" runat="server" Visible="false">
            <asp:Label ID="LblRut" runat="server" Text="Rut"></asp:Label><asp:TextBox ID="TxtRut" runat="server" MaxLength="10" ReadOnly="True"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtRut" ErrorMessage="Rut es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblNombre" runat="server" Text="Nombres"></asp:Label><asp:TextBox ID="TxtNombres" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtNombres" ErrorMessage="Nombres son obligatorios">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblApPaterno" runat="server" Text="Apellido Paterno"></asp:Label><asp:TextBox ID="TxtApPaterno" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtApPaterno" ErrorMessage="Apellido Paterno es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="LblApMaterno" runat="server" Text="Apellido Materno"></asp:Label><asp:TextBox ID="TxtApMaterno" runat="server"></asp:TextBox><br />
        <asp:Label ID="LblFechaNacimiento" runat="server" Text="Fecha de Nacimiento"></asp:Label><asp:TextBox ID="TxtFechaNacimiento" runat="server" TextMode="Datetime"></asp:TextBox><br />
        
        <asp:Label ID="LblTelefono" runat="server" Text="Telefono"></asp:Label><asp:TextBox ID="TxtTelefono" runat="server" TextMode="Phone"></asp:TextBox><br />
        <asp:Label ID="LblEmail" runat="server" Text="E-mail"></asp:Label><asp:TextBox ID="TxtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <br />
        

        <asp:Label ID="LblSexo" runat="server" Text="Sexo"></asp:Label><asp:DropDownList ID="DdlSexo" runat="server">
            <asp:ListItem Value="1">Mujer</asp:ListItem>
            <asp:ListItem Value="0">Hombre</asp:ListItem>
        </asp:DropDownList><br />
        <asp:Label ID="LblDireccion" runat="server" Text="Dirección"></asp:Label><asp:TextBox ID="TxtDireccion" runat="server"></asp:TextBox>
            <br />
            <asp:Panel ID="PnlRegionActual" runat="server">
                <asp:Label ID="Label1" runat="server" Text="Comuna"></asp:Label> 
            &nbsp;<asp:Label ID="LblComunaTexto" runat="server" Text="Label"></asp:Label><br />
            
            <asp:Label ID="Label2" runat="server" Text="Región"></asp:Label> 
            &nbsp;<asp:Label ID="LblRegionTexto" runat="server" Text="Label"></asp:Label><br />
            
            <asp:Label ID="Label3" runat="server" Text="País"></asp:Label>
            &nbsp;<asp:Label ID="LblPaisTexto" runat="server" Text="Label"></asp:Label><br />
                <asp:Button ID="BtnCambiarRegion" runat="server" Text="Cambiar Región" OnClick="BtnCambiarRegion_Click" />
            </asp:Panel>
            
            
            <asp:Panel ID="PnlPaiRegCom" Visible="false" runat="server">
                    <asp:Label ID="LblPais" runat="server" Text="Pais"></asp:Label><asp:DropDownList AutoPostBack="true" ID="DdlPais" runat="server" DataSourceID="OdsPais" DataTextField="Pais1" DataValueField="Id"></asp:DropDownList><br />
                    <asp:Label ID="LblRegion" runat="server" Text="Región"></asp:Label><asp:DropDownList AutoPostBack="true" ID="DdlRegion" runat="server" DataSourceID="OdsRegion" DataTextField="Region1" DataValueField="Id"></asp:DropDownList><br />
                    <asp:Label ID="LblComuna" runat="server" Text="Comuna"></asp:Label><asp:DropDownList AutoPostBack="true" ID="DdlComuna" runat="server" DataSourceID="OdsComuna" DataTextField="Comuna1" DataValueField="Id"></asp:DropDownList>
        
        
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
                    <br />
        

        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" />

            <asp:Button ID="BtnEditar" runat="server" Text="Editar" OnClick="BtnEditar_Click" />

        <br />

        </asp:Panel>

    </asp:Panel>
</asp:Content>
