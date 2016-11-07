<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarSucursales.aspx.cs" Inherits="CapaWeb.ListarSucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="OdsSucursales" runat="server" SelectMethod="Listar" TypeName="CapaNegocio.SucursalCompletaBO"></asp:ObjectDataSource>
   
    <asp:GridView ID="GridSucursales" runat="server" AllowPaging="True" DataSourceID="OdsSucursales"></asp:GridView>
     </asp:Content>
