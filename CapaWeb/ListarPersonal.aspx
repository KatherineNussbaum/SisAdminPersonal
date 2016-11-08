﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarPersonal.aspx.cs" Inherits="CapaWeb.ListarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Personal</h2>
    <asp:ObjectDataSource ID="OdsPersonal" runat="server" SelectMethod="ListarPersonal" TypeName="CapaNegocio.PersonalCompletoBO"></asp:ObjectDataSource>
    <asp:GridView ID="GridPersonal" runat="server" AllowPaging="True" DataSourceID="OdsPersonal" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
            <asp:BoundField DataField="NombreComplet" HeaderText="NombreComplet" SortExpression="NombreComplet" />
            <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" SortExpression="Departamento" />
        </Columns>
    </asp:GridView>
</asp:Content>
