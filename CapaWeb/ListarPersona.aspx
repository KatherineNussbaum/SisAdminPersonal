<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarPersona.aspx.cs" Inherits="CapaWeb.ListarPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-right: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Personas</h2>
    <asp:Panel ID="PnlPersonas" runat="server" CssClass="auto-style1" Height="288px" Width="1011px">

        <asp:ObjectDataSource ID="OdsPersona" runat="server" SelectMethod="ListarPersonaCompleta" TypeName="CapaNegocio.PersonaCompletaBO"></asp:ObjectDataSource>
        <asp:GridView ID="GridPersona" runat="server" AllowPaging="True" DataSourceID="OdsPersona" Width="1010px" CssClass="auto-style1"></asp:GridView>
        <br />

    </asp:Panel>
</asp:Content>
