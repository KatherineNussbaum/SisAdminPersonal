<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="ListarSucursales.aspx.cs" Inherits="CapaWeb.ListarSucursales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ObjectDataSource ID="OdsSucursales" runat="server" SelectMethod="Listar" TypeName="CapaNegocio.SucursalCompletaBO"></asp:ObjectDataSource>
   
    <asp:ObjectDataSource ID="ObsPersonal" runat="server" SelectMethod="ListarPersonalPorSucursal" TypeName="CapaNegocio.PersonalCompletoBO">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridSucursales" Name="sucursal" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
   
    <asp:GridView ID="GridSucursales" runat="server" AllowPaging="True" DataSourceID="OdsSucursales" Width="916px" DataKeyNames="Nombre">
        <Columns>
            <asp:CommandField SelectText="Ver Personal" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
     <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" DataSourceID="ObsPersonal" Height="50px" Width="511px">
        <Fields>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Rut" HeaderText="Rut" SortExpression="Rut" />
            <asp:BoundField DataField="NombreComplet" HeaderText="NombreComplet" SortExpression="NombreComplet" />
            <asp:BoundField DataField="Sucursal" HeaderText="Sucursal" SortExpression="Sucursal" />
            <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
            <asp:BoundField DataField="Departamento" HeaderText="Departamento" SortExpression="Departamento" />
        </Fields>
    </asp:DetailsView>
    <br />
     </asp:Content>
