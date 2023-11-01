<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="true" CodeBehind="frmPermisoEmpresaBuscar.aspx.cs" Inherits="APP.SEG.WEB.Permisos.frmPermisoEmpresaBuscar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 272px;
        }
        .style2
        {
            width: 94px;
        }
        .style3
        {
            width: 65px;
        }
        .style4
        {
            width: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div>
        <div class="panel">
            <h1 class="rounded">Búsqueda de Empresa de Usuario</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
                <tbody>
                    <tr>
                        <td class="style2">Usuario</td>
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
                        <td colspan="4" align="right">
                            <asp:Button ID="btnLimpiar" runat="server" Text="Cerrar"
                                CssClass="btn rounded fright" onclick="btnLimpiar_Click" />
                        </td>

                    </tr>

                </tbody>
            </table>


        </div>

        <div>
            <div class="clear"></div>


            <div class="sub-panel">

                <div class="panel-izquierda">
                <h2 style="border-bottom:0px!important;">Empresas Asignados</h2>
                    <asp:TreeView ID="tvAplicacionesUsuario" runat="server" CssClass="tvSize rounded"
                        ImageSet="Msdn" NodeIndent="15" ShowLines="True" Width="230px">
                        <ParentNodeStyle Font-Bold="False" />
                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False"
                            HorizontalPadding="0px" VerticalPadding="0px" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black"
                            HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                    </asp:TreeView>
                </div>
                <div class="panel-derecha">

                <table border="0" cellpadding="0" cellspacing="0" class="fix rounded" style="margin-left:0px;">
                <tbody>
                    <tr>
                        <td>Aplicativo</td>
                        <td>
                               <asp:TextBox ID="txtAplicativo" runat="server" CssClass="edit rounded"
                                Width="180px" ></asp:TextBox>
                        </td>
                        <td class="style4">
                               <asp:Button ID="btnAplicativoBuscar" runat="server" Text="Buscar"
                                CssClass="btn rounded" style="margin-right:0px;"
                                   onclick="btnAplicativoBuscar_Click"/>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="3">
                            <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded"
                                Visible="False" ></asp:Label>
                        </td>
                    </tr>

                 </tbody>
                </table>
                    <br/>
                    <asp:GridView ID="dgvAplicaciones" runat="server" AutoGenerateColumns="False"

                         CssClass="Size490" onrowcommand="dgvAplicaciones_RowCommand">
                    <Columns>
                         <asp:TemplateField HeaderText="Aplicativo">
                            <ItemTemplate>
                                <asp:LinkButton CommandName="cmdAgregarRol" CommandArgument='<%# Eval("IdAplicacion") %>' DataTextField="NombreCortoAplicacion" ID="LinkButton1" runat="server" Visible='true'><%# Eval("NombreCortoAplicacion")%></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Descripción" DataField="DescripcionAplicacion" />
                    </Columns>
                        <PagerStyle CssClass="pager" />
                    </asp:GridView>
                </div>
             <div class="clear"></div>
        </div>
        </div>
    </div>

</asp:Content>
