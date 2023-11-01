﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmPermisoEmpresaDetalle.aspx.cs" Inherits="APP.SEG.WEB.Permisos.frmPermisoEmpresaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div>
     <div class="panel">
       <h1 class="rounded">
       <asp:Label ID="lbTituloPanel" runat="server">
       Detalle de las
       </asp:Label>
       Empresas del Usuario
       </h1>
       <br/>
        <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>

                    <tr>
                        <td class="style2">Nombre de Usuario</td>
                        <td class="style1">
                               <asp:TextBox ID="txtNombre" runat="server" CssClass="edit rounded"
                                Width="250px" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td class="style3">Código</td>
                        <td>
                               <asp:TextBox ID="txtCodigo" runat="server" CssClass="edit rounded"
                                Width="100px" MaxLength="50" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Aplicativo</td>
                        <td>
                               <asp:TextBox ID="txtAplicativo" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="200" ReadOnly="True" Enabled="False"></asp:TextBox>
                        </td>
                        <td>Tipo Empresa</td>
                        <td>
                            <asp:DropDownList ID="ddlTipoEmpresa" runat="server" Width="215px"
                                CssClass="edit rounded" AutoPostBack="True"
                                onselectedindexchanged="ddlTipoEmpresa_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">

                            <asp:Button ID="btnSalir" runat="server" Text="Salir"
                                CssClass="btn rounded fright" style="margin-right:0px;" Visible="False"
                                onclick="btnSalir_Click" />

                        </td>

                    </tr>

                </tbody>
            </table>
        </div>
           <div class="clear"></div>
            <div class="sub-panel">

                <div class="panel-izquierda">
                Nombre Empresa :
                <asp:TextBox ID="txtBuscarEmpresa" runat="server"></asp:TextBox>

                <asp:Button ID="btnBuscar" runat="server" Text="Buscar"
                                CssClass="btn rounded " onclick="btnBuscar_Click"
                                />

                <h2 style="border-bottom:0px!important;">Empresas</h2>



                <asp:GridView ID="dgvEmpresa" runat="server" AutoGenerateColumns="False"
                         CssClass="Size240" AllowPaging="True"
                        onpageindexchanging="dgvEmpresa_PageIndexChanging"
                        ClientIDMode="Static"
                         >
                    <Columns>
                      <asp:TemplateField ItemStyle-Width="20px">
                        <ItemTemplate>
                            <asp:HiddenField runat="server" ID="hdIDEmpresa" Value='<%# Eval("IdEmpresa") %>' />
                            <asp:CheckBox ID="ckSelect" runat="server"
                            CssClass="checkBoxes"  Checked = '<%# Eval("checkValor") %>'
                            />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="cbSelectAll" runat="server" Text="" />
                        </HeaderTemplate>
                       </asp:TemplateField>

                        <asp:BoundField HeaderText="Empresa" DataField="NomEmpresa" />
                    </Columns>
                        <PagerStyle CssClass="pager" />
                 </asp:GridView>



                </div>

                <div class="panel-derecha_01">
                     <asp:Button ID="btnAgregar" runat="server" Text="Agregar"
                                CssClass="btn rounded " onclick="btnAgregar_Click"
                                ClientIDMode="Static"
                                />
                </div>

                <script type="text/javascript">
                    $(document).ready(function () {
                        $('#btnAgregar').click(function (e) {
                            var cantidadFilas = $('#dgvEmpresa tr').length;
                            if (cantidadFilas == 1) {
                                alert("Tiene que ver al menos una empresa a Escoger");
                                return false;
                            } else {
                                var Seleccion = false;
                                $('#dgvEmpresa input[type=checkbox]').each(function () {
                                    if ($(this).attr('checked')) {
                                        Seleccion = true;
                                        return false;
                                    }
                                });
                                if (!Seleccion) {
                                    alert("Tiene que Seleccionar al menos una empresa");
                                }
                                return Seleccion;
                            }
                        });
                    });
                </script>


                <div class="panel-derecha_02">

                <br />
                <br />
                <br />


                <h2 style="border-bottom:0px!important;margin-top:20px;">Empresas Seleccionadas</h2>



                <asp:GridView ID="gvEmpresasSeleccionadas" runat="server" AutoGenerateColumns="False"
                         CssClass="Size350"
                         onrowcommand="gvEmpresasSeleccionadas_RowCommand"
                         >
                    <Columns>
                       <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HiddenField runat="server" ID="hdIdEmpresa" Value='<%# Eval("IdEmpresa") %>'/>
                        <asp:LinkButton ID="lnkAnular" runat="server" CommandArgument='<%# Eval("IdEmpresa") %>' CommandName="cmdAnular" CssClass="anular"  ToolTip="Anular" OnClientClick="return confirm('¿Esta seguro que desea eliminar el registro?');">
                        </asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle CssClass="fixWidthDgvCmd" />
                    </asp:TemplateField>

                        <asp:BoundField HeaderText="Empresa" DataField="NomEmpresa" />
                    </Columns>
                        <PagerStyle CssClass="pager" />
                 </asp:GridView>

                </div>

                 <div class="clear"></div>


                </div>

                <asp:Button ID="btnSalir02" runat="server" Text="Salir"
                                CssClass="btn rounded fright" onclick="btnSalir02_Click" />
    </div>
</asp:Content>
