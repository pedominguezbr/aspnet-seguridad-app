<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmRolBuscar.aspx.cs" Inherits="APP.SEG.WEB.Roles.frmRolBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="panel">
            <h1 class="rounded">Búsqueda de Roles</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Rol</td>
                        <td>
                               <asp:TextBox ID="txtRol" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Aplicativo</td>
                        <td>

                            <asp:DropDownList ID="ddlAplicativo" runat="server" Width="305px"
                                CssClass="edit rounded" >
                            </asp:DropDownList>

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

            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Rol"
                CssClass="btn rounded fright" style="margin-right:0px;" onclick="btnNuevo_Click"
               />
            <div class="clear"></div>
            <h2>Listado de roles</h2>

            <asp:GridView ID="dgvRoles" runat="server" AutoGenerateColumns="False"
                AllowPaging="True"
                onrowcommand="dgvRoles_RowCommand" CssClass="Size700"
                onselectedindexchanging="dgvRoles_SelectedIndexChanging"
                onpageindexchanging="dgvRoles_PageIndexChanging">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkConsultar" runat="server" CommandArgument='<%# Eval("IdRol") %>' CommandName="cmdConsultar" CssClass="consultar" ToolTip="Consultar">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("IdRol") %>' CommandName="cmdModificar" CssClass="modificar"  ToolTip="Modificar">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkAnular" runat="server" CommandArgument='<%# Eval("IdRol") %>' CommandName="cmdAnular" CssClass="anular"  ToolTip="Anular" OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                </asp:TemplateField>
                <asp:BoundField HeaderText="Código"  DataField="IdRol">
                <ItemStyle HorizontalAlign="Right" Width="50px" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Rol"  DataField="NombreRol" />
                <asp:TemplateField HeaderText="Aplicativo">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("Aplicacion.NombreCortoAplicacion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="EstadoRol" ReadOnly="True" HeaderText="Estado" >
                <ItemStyle HorizontalAlign="Center" Width="40px" />
                </asp:CheckBoxField>
            </Columns>
                <PagerStyle CssClass="pager" />
        </asp:GridView>

        </div>
    </div>

</asp:Content>
