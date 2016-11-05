<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarEmpresas.aspx.cs" Inherits="CapaWeb.ListarEmpresas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Empresas</h2>
    <asp:Panel ID="PnlEmpresas" runat="server">
        <asp:ObjectDataSource ID="OdsEmpresas" runat="server" SelectMethod="ListarEmpresa" TypeName="CapaNegocio.EmpresaBO"></asp:ObjectDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="OdsEmpresas">
            <Columns>
                <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
