<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Departamentos.aspx.cs" Inherits="CapaWeb.Departamentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Departamentos</h2>
    <p>
        <asp:Label ID="LblMensaje" runat="server" Text="Label" Visible="false"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="GridDepartamentos" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" EmptyDataText="No hay datos para mostrar.">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Departamento1" HeaderText="Departamento1" SortExpression="Departamento1" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" TypeName="CapaNegocio.DepartamentoBO" SelectMethod="ListarDepartamento"></asp:ObjectDataSource>
    </p>

    <asp:Button ID="btnAbrirAgregar" runat="server" Text="Nuevo Departamento" OnClick="btnAbrirAgregar_Click" />
    <asp:Button ID="BtnAbrirEditar" runat="server" Text="Editar Departamento" OnClick="BtnAbrirEditar_Click" />
&nbsp;<asp:Panel ID="PnlAgregar" runat="server" Visible="false">
        <asp:Label ID="LblNombreDepartamentoAgregar" runat="server" Text="Nombre Departamento"></asp:Label>
        <asp:TextBox ID="TxtNombreAgregar" runat="server" AutoPostBack="False"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtNombreAgregar" ErrorMessage="Nombre Departamento es obligatorio">*</asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="BtnGuardar" runat="server" Text="Guardar" OnClick="BtnGuardar_Click" />
    </asp:Panel>

    <asp:Panel ID="PnlEditar" runat="server" Visible="false">
        <asp:Label ID="LblNombreBuscar" runat="server" Text="Nombre Departamento: "></asp:Label><asp:TextBox ID="TxtNombreBuscar" runat="server"></asp:TextBox>

        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

        <asp:Panel ID="PnlEditarEliminar" runat="server" Visible="false">
            <asp:Label ID="NombreNuevo" runat="server" Text="Nombre Departamento"></asp:Label>
            <asp:TextBox ID="TxtNombreDepartamentoNuevo" runat="server"></asp:TextBox>
            <asp:TextBox ID="TxtId" runat="server" Visible="false"></asp:TextBox>
            <br />
            <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" /> <asp:Button ID="BtnEditar" runat="server" Text="Editar" OnClick="BtnEditar_Click" />
        </asp:Panel>
        <asp:ValidationSummary ID="ValSum" runat="server" ShowMessageBox="True" ShowSummary="False" />

    </asp:Panel>

</asp:Content>
