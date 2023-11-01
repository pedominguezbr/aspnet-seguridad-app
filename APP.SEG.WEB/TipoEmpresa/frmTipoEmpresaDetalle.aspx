<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmTipoEmpresaDetalle.aspx.cs" Inherits="APP.SEG.WEB.TipoEmpresa.frmTipoEmpresaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="panel">
        <h1 class="rounded">
            <asp:Label ID="lbTituloPanel" runat="server">Detalle del</asp:Label>
            Tipo Empresa</h1>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
            <tbody>
                <tr>
                    <td>
                        Nombre
                    </td>
                    <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtRazonSocial" runat="server" CssClass="edit rounded" Width="210px"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtRazonSocial" runat="server" ControlToValidate="txtRazonSocial"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>


                <tr>
                    <td>
                        Estado
                    </td>
                    <td>
                    <div class="requiredInput">
                        <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="215px" CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlEstado" runat="server" ControlToValidate="ddlEstado"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>
                       </div>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn rounded"
                            ValidationGroup="validacion" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn rounded"
                            OnClick="btnLimpiar_Click" />
                        <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded" Visible="False"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:Button ID="btnSalir" runat="server" Text="Salir" CssClass="btn rounded fright"
            Style="margin-right: 0px;" OnClick="btnSalir_Click" />
        <div class="clear">
        </div>
    </div>


</asp:Content>
