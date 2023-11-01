﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmTipoEmpresaAplicacion.aspx.cs" Inherits="APP.SEG.WEB.TipoEmpresa.frmTipoEmpresaAplicacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <div class="panel">
          <h1 class="rounded">
          <asp:Label ID="lbTituloPanel" runat="server">Detalle de las</asp:Label> Aplicaciones de Tipo Empresa
          </h1>
          <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Tipo Empresa</td>
                        <td>
                               <asp:TextBox ID="txtTipoEmpresa" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="200" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"
                                CssClass="btn rounded fleft" ValidationGroup="valPol" onclick="btnAceptar_Click"
                                />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                                CssClass="btn rounded fleft" onclick="btnCancelar_Click" />
                            <asp:Button ID="btnSalir" runat="server" Text="Salir"
                                CssClass="btn rounded fright" style="margin-right:0px;" Visible="False" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
        <div>
            <h2>Aplicaciones disponibles</h2>
            <asp:GridView ID="dgvAplicaciones" runat="server" AutoGenerateColumns="False"
                CssClass="Size700"
                >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdIdAplicacion" Value='<%# Eval("IdAplicacion") %>'/>
                        <asp:CheckBox runat="server" Checked='<%# Eval("EstadoAplicacionEmpresa") %>' ID="chkTieneAcceso">
                        </asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Aplicación"  DataField="NombreCortoAplicacion" />
                <asp:BoundField HeaderText="Descripcion" DataField="DescripcionAplicacion" />
             </Columns>
             <PagerStyle CssClass="pager" />
        </asp:GridView>
        </div>
</asp:Content>
