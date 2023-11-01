<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmUsuarioBuscar.aspx.cs" Inherits="APP.SEG.WEB.Usuarios.frmUsuarioBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div>
        <div class="panel">
            <h1 class="rounded">Búsqueda de Usuarios</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Nombre</td>
                        <td>
                               <asp:TextBox ID="txtNombre" runat="server" CssClass="edit rounded"
                                Width="250px" MaxLength="50"></asp:TextBox>
                        </td>
                        <td><!--Código--></td>
                        <td>
                               <!--<asp:TextBox ID="txtCodigo" runat="server" CssClass="edit rounded"
                                Width="100px" MaxLength="50"></asp:TextBox>-->
                        </td>
                    </tr>
                    <tr>
                        <td>Apellido Paterno</td>
                        <td>

                            <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="edit rounded"
                                Width="250px" MaxLength="50"></asp:TextBox>

                        </td>
                        <td>Apellido Materno</td>
                        <td>

                            <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="edit rounded"
                                Width="250px" MaxLength="50"></asp:TextBox>

                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                                CssClass="btn rounded" ValidationGroup="valPol"
                                onclick="btnBuscar_Click"/>
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

            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Usuario"
                CssClass="btn rounded fright" style="margin-right:0px;" onclick="btnNuevo_Click"
               />
            <div class="clear"></div>
            <h2>Listado de Usuarios</h2>

            <asp:GridView ID="dgvUsuarios" runat="server" AutoGenerateColumns="False"
                AllowPaging="True"
                onrowcommand="dgvUsuarios_RowCommand" CssClass="Size700"
                onselectedindexchanging="dgvUsuarios_SelectedIndexChanging"
                onpageindexchanging="dgvUsuarios_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkConsultar" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="cmdConsultar" CssClass="consultar" ToolTip="Consultar">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="cmdModificar" CssClass="modificar"  ToolTip="Modificar">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkAnular" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="cmdAnular" CssClass="anular"  ToolTip="Anular" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificarPermiso" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="cmdModificarPermiso" CssClass="modificarPermisos"  ToolTip="Modificar Permisos">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificarEmpresa" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' CommandName="cmdModificarEmpresa" CssClass="modificarEmpresas"  ToolTip="Modificar Empresas">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>

                <asp:BoundField HeaderText="Código"  DataField="CodigoUsuario">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Nombre"  DataField="Nombres" />
                <asp:BoundField DataField="ApellidoPaterno" HeaderText="Ap. Paterno" />
                <asp:BoundField DataField="ApellidoMaterno" HeaderText="Ap. Materno" />
                <asp:CheckBoxField DataField="EstadoUsuario" ReadOnly="True"
                    HeaderText="Activo" >
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:CheckBoxField>
            </Columns>
                <PagerStyle CssClass="pager" />
        </asp:GridView>

        </div>
    </div>

</asp:Content>
