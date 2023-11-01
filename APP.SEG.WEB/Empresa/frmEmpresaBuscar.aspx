﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmEmpresaBuscar.aspx.cs" Inherits="APP.SEG.WEB.Empresa.frmEmpresaBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="panel">
            <h1 class="rounded">Búsqueda de Empresas</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Razón Social</td>
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
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Empresa"
                CssClass="btn rounded fright" style="margin-right:0px;" onclick="btnNuevo_Click"
               />
            <div class="clear"></div>
            <h2>Listado de Empresa</h2>

            <asp:GridView ID="dgvEmpresas" runat="server" AutoGenerateColumns="False"
                AllowPaging="True"
                onrowcommand="dgvEmpresas_RowCommand" CssClass="Size700"
                onselectedindexchanging="dgvEmpresas_SelectedIndexChanging"
                onpageindexchanging="dgvEmpresas_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkConsultar" runat="server" CommandArgument='<%# Eval("IdEmpresa") %>' CommandName="cmdConsultar" CssClass="consultar" ToolTip="Consultar">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("IdEmpresa") %>' CommandName="cmdModificar" CssClass="modificar"  ToolTip="Modificar">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkAnular" runat="server" CommandArgument='<%# Eval("IdEmpresa") %>' CommandName="cmdAnular" CssClass="anular"  ToolTip="Anular" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');">
                            </asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="Nombre Empresa"  DataField="NomEmpresa" />
                    <asp:BoundField HeaderText="RUC"  DataField="Ruc" />
                    <asp:BoundField HeaderText="Teléfono"  DataField="Telefono" />

                    <asp:CheckBoxField DataField="EstadoEmpresa" ReadOnly="True"
                    HeaderText="Activo" >
                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:CheckBoxField>
                 </Columns>
                <PagerStyle CssClass="pager" />
            </asp:GridView>

        </div>
    </div>

</asp:Content>
