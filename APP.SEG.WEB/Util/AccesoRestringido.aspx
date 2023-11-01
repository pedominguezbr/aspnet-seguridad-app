<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="AccesoRestringido.aspx.cs" Inherits="APP.SEG.WEB.Util.AccesoRestringido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <div class="PanelInicial">
    <span class="MsjBienvenida">

        <asp:Label ID="lblMensaje" runat="server"
          Text="Ud No tiene Permiso para acceder a esta página" CssClass="mensaje"
          Font-Size="Small"></asp:Label>
    </span>
  </div>
</asp:Content>
