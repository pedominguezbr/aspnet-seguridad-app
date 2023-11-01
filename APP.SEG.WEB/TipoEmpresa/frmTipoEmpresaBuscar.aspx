﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmTipoEmpresaBuscar.aspx.cs" Inherits="APP.SEG.WEB.TipoEmpresa.frmTipoEmpresaBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div>
        <div class="panel">
            <h1 class="rounded">Búsqueda de Tipo Empresas</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Nombre</td>
                        <td>
                           <asp:TextBox ID="txtNombre" runat="server" CssClass="edit rounded"
                                Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                                CssClass="btn rounded" ValidationGroup="valPol" onclick="btnBuscar_Click"
                                />
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"
                                CssClass="btn rounded" onclick="btnLimpiar_Click" />
                            <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded"
                                Visible="False" ></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Tipo Empresa"
                CssClass="btn rounded fright" style="margin-right:0px;" onclick="btnNuevo_Click"
               />
            <div class="clear"></div>
            <h2>Listado de Empresa</h2>

            <asp:GridView ID="dgvTipoEmpresas" runat="server" AutoGenerateColumns="False"
                AllowPaging="True"
                onrowcommand="dgvTipoEmpresas_RowCommand" CssClass="Size700"
                onselectedindexchanging="dgvTipoEmpresas_SelectedIndexChanging"
                onpageindexchanging="dgvTipoEmpresas_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkConsultar" runat="server" CommandArgument='<%# Eval("IdTipoEmpresa") %>' CommandName="cmdConsultar" CssClass="consultar" ToolTip="Consultar">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("IdTipoEmpresa") %>' CommandName="cmdModificar" CssClass="modificar"  ToolTip="Modificar">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAnular" runat="server" CommandArgument='<%# Eval("IdTipoEmpresa") %>' CommandName="cmdAnular" CssClass="anular"  ToolTip="Anular" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>


                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificarPermiso" runat="server" CommandArgument='<%# Eval("IdTipoEmpresa") %>' CommandName="cmdModificarPermiso" CssClass="modificarPermisos"  ToolTip="Modificar Aplicación">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Nombre Tipo Empresa"  DataField="NomTipoEmpresa" />



                    <asp:CheckBoxField DataField="EstadoTipoEmpresa" ReadOnly="True"
                    HeaderText="Activo" >
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:CheckBoxField>
                 </Columns>
                <PagerStyle CssClass="pager" />
            </asp:GridView>

        </div>
    </div>
</asp:Content>
