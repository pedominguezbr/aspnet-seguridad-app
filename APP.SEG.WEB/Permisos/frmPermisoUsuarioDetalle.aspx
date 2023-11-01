<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmPermisoUsuarioDetalle.aspx.cs" Inherits="APP.SEG.WEB.Permisos.frmPermisoUsuarioDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div>
    <style type="text/css">
.ColumnaOculta {display:none;}
</style>
        <div class="panel">
            <h1 class="rounded"><asp:Label ID="lbTituloPanel" runat="server">Detalle de los</asp:Label> Roles del Usuario</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Aplicativo</td>
                        <td>
                               <asp:TextBox ID="txtAplicativo" runat="server" CssClass="edit rounded"
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
            <br/>
        <div>

            <h2>Roles disponibles</h2>

            <asp:GridView ID="dgvRoles" runat="server" AutoGenerateColumns="False"
                CssClass="Size700"
                >
            <Columns>

                <asp:TemplateField >
                <ItemTemplate>
                    <asp:CheckBox runat="server" Checked='<%# DataBinder.Eval(Container.DataItem, "BePermisoUsuario.Estado") %>' ID="chkTieneAcceso">
                    </asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="IdRol"  DataField="IdRol" >
                <HeaderStyle CssClass="ColumnaOculta" />
<ItemStyle CssClass="ColumnaOculta" />
                </asp:BoundField>

                <asp:TemplateField>
                <ItemTemplate>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BePermisoUsuario.IdPermisoUsuario")%>' ID="lblIdPermisoUsuario">
                </asp:Label>

                </ItemTemplate>
                         <HeaderStyle CssClass="ColumnaOculta" />
<ItemStyle CssClass="ColumnaOculta" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Rol"  DataField="NombreRol" />
                <asp:BoundField HeaderText="Descripcion" DataField="DescripcionRol" />
            </Columns>
                <PagerStyle CssClass="pager" />
        </asp:GridView>

        </div>
    </div>

</asp:Content>
