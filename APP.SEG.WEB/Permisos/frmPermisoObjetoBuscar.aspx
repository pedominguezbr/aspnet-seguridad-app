<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmPermisoObjetoBuscar.aspx.cs" Inherits="APP.SEG.WEB.Permisos.frmPermisoObjetoBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="panel">
            <h1 class="rounded">B�squeda de PERMISOS DE Objeto</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td>Aplicativo</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlAplicativo" runat="server" Width="305px"
                                CssClass="edit rounded" AutoPostBack="True"
                                   onselectedindexchanged="ddlAplicativo_SelectedIndexChanged" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvDdlAplicativo" runat="server"
                              ControlToValidate="ddlAplicativo"
                              ErrorMessage="<span class='warning'></span>"
                              Display="Static"
                              InitialValue="-1" ValidationGroup="validacion" Height="16px"></asp:RequiredFieldValidator>
                              </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Rol</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlRol" runat="server" Width="305px"
                                CssClass="edit rounded" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvDdlRol" runat="server"
                              ControlToValidate="ddlRol"
                              ErrorMessage="<span class='warning'></span>"
                              Display="Static"
                              InitialValue="-1" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                              </div>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="4">
                            <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                                CssClass="btn rounded" ValidationGroup="validacion"
                                onclick="btnBuscar_Click" />
                                <asp:Button ID="btnlimpiar" runat="server" Text="Limpiar"
                                CssClass="btn rounded" onclick="btnlimpiar_Click" />
                                <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded"
                                Visible="False" ></asp:Label>
                             </td>

                    </tr>

                </tbody>
            </table>


        </div>

        <div>

            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Permiso"
                CssClass="btn rounded fright" style="margin-right:0px;" onclick="btnNuevo_Click"
               />
            <div class="clear"></div>
             <h2>Listado de PERMISOS DE OBJETO</h2>
 <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>
             <div class="sub-panel">

                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                     CssClass="btn rounded" onclick="btnEliminar_Click"
                     />

                                  <br/>
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>



                 <asp:TreeView ID="tvPermisosObjeto" runat="server" ImageSet="XPFileExplorer"
                    NodeIndent="45" ShowLines="True" AutoGenerateDataBindings="False"
                     PopulateNodesFromClient="true"
                     ExpandDepth="0"
                      ShowExpandCollapse="true"
                    CssClass="tvSize rounded">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                    <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False"
                        HorizontalPadding="0px" VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                        HorizontalPadding="0px" NodeSpacing="0px" VerticalPadding="0px"  />
                </asp:TreeView>
                                 </ContentTemplate>
                 </asp:UpdatePanel>

            </div>
        </div>
    </div>

</asp:Content>
