<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmBienvenido.aspx.cs" Inherits="APP.SEG.WEB.Login.frmBienvenido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div class="PanelInicial">
    <span class="MsjBienvenida">
        Bienvenido
        <asp:Label ID="lbNombreUsuario" runat="server" Text="Juan Pérez" CssClass="MsjNombre"></asp:Label>
    </span>
  </div>

</asp:Content>
