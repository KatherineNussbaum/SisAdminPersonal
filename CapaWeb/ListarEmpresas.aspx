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
        <asp:GridView ID="GridEmpresas" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="OdsEmpresas" Width="596px" CssClass="auto-style1">
            <Columns>
                <asp:BoundField DataField="Rut" HeaderText="Rut Empresa" SortExpression="Rut" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre Empresa" SortExpression="Nombre" />
                <asp:BoundField DataField="RazonSocial" HeaderText="RazonSocial" SortExpression="RazonSocial" />
            </Columns>
        </asp:GridView>
        <br />
    </asp:Panel>
</asp:Content>
