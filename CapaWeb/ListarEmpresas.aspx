<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarEmpresas.aspx.cs" Inherits="CapaWeb.ListarEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empresas</h2>
    <asp:Panel ID="PnlEmpresas" runat="server">
        <asp:ObjectDataSource ID="OdsEmpresas" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsSucursales" runat="server" SelectMethod="ListarPorEmpresa" TypeName="CapaNegocio.SucursalCompletaBO">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridEmpresas" Name="rut" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridEmpresas" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="OdsEmpresas" Width="596px" CssClass="auto-style1" DataKeyNames="Rut">
            <Columns>
                <asp:CommandField SelectText="Sucursales" ShowSelectButton="True" />
                <asp:BoundField DataField="Rut" HeaderText="Rut Empresa" SortExpression="Rut" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Empresa" SortExpression="Nombre" />
                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="OdsSucursales" Height="50px" Width="421px">
            <Fields>
                <asp:BoundField DataField="NombreEmpresa" HeaderText="NombreEmpresa" SortExpression="NombreEmpresa" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
                <asp:BoundField DataField="Comuna" HeaderText="Comuna" SortExpression="Comuna" />
                <asp:BoundField DataField="Region" HeaderText="Region" SortExpression="Region" />
                <asp:BoundField DataField="Pais" HeaderText="Pais" SortExpression="Pais" />
            </Fields>
        </asp:DetailsView>
        <br />
        <br />
    </asp:Panel>
</asp:Content>
