<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarPersona.aspx.cs" Inherits="CapaWeb.ListarPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Personas</h2>
    <asp:Panel ID="PnlPersonas" runat="server">
        <asp:ObjectDataSource ID="OdsPersonas" runat="server" SelectMethod="ListarPersona" TypeName="CapaNegocio.PersonaBO"></asp:ObjectDataSource>

        <br />
        <asp:GridView ID="GridPersonas" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="OdsPersonas">
            <Columns>
                <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" SortExpression="Nombres" />
                <asp:BoundField DataField="ApPaterno" HeaderText="ApPaterno" SortExpression="ApPaterno" />
                <asp:BoundField DataField="ApMaterno" HeaderText="ApMaterno" SortExpression="ApMaterno" />
                <asp:BoundField DataField="FechaNacimieto" HeaderText="FechaNacimieto" SortExpression="FechaNacimieto" />
                <asp:BoundField DataField="Telefono" HeaderText="Telefono" SortExpression="Telefono" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Direccion" HeaderText="Direccion" SortExpression="Direccion" />
            </Columns>
        </asp:GridView>

    </asp:Panel>
</asp:Content>
