<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarSucursales.aspx.cs" Inherits="CapaWeb.ListarSucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="OdsSucursales" runat="server" SelectMethod="ListarSucursal" TypeName="CapaNegocio.SucursalBO"></asp:ObjectDataSource>
    <asp:GridView ID="GridSucursales" runat="server" AllowPaging="True" DataSourceID="OdsSucursales" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="EmpresaRut" HeaderText="EmpresaRut" SortExpression="EmpresaRut" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
            <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
        </Columns>
    </asp:GridView>
</asp:Content>
