<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarPersonal.aspx.cs" Inherits="CapaWeb.ListarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Personal</h2>
    <asp:ObjectDataSource ID="OdsPersonal" runat="server" SelectMethod="ListarPersonal" TypeName="CapaNegocio.PersonalBO"></asp:ObjectDataSource>
    <asp:GridView ID="GridPersonal" runat="server" AllowPaging="True" DataSourceID="OdsPersonal"></asp:GridView>
</asp:Content>
