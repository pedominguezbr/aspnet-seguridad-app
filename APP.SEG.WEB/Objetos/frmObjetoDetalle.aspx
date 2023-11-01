﻿<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false" CodeBehind="frmObjetoDetalle.aspx.cs" Inherits="APP.SEG.WEB.Objetos.frmObjetoDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


        <div class="panel">
            <h1 class="rounded"><asp:Label ID="lbTituloPanel" runat="server">Detalle del</asp:Label>
                OBJETO</h1>
            <br/>
              <table border="0" cellpadding="0" cellspacing="0" class="fix rounded size700">
                <tbody>
                    <tr>
                        <td><asp:Label ID="lbTituloCodigo" runat="server">Código</asp:Label></td>
                        <td>
                               <asp:TextBox ID="txtCodigo" runat="server" CssClass="edit rounded"
                                Width="100px" MaxLength="14"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Nombre</td>
                        <td><div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                               <asp:TextBox ID="txtNombre" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="50"></asp:TextBox>
                               <asp:RequiredFieldValidator id="rfvTxtRol" runat="server"
                                ControlToValidate="txtNombre"
                                ErrorMessage="<span class='warning'></span>"
                                Display="Static"
                                InitialValue="" CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Descripción</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                               <asp:TextBox ID="txtDescripcion" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="150" Height="90px" TextMode="MultiLine"></asp:TextBox>
                               <asp:RequiredFieldValidator id="rfvTxtDescripcion" runat="server"
                                ControlToValidate="txtDescripcion"
                                ErrorMessage="<span class='warning'></span>"
                                Display="Static"
                                InitialValue="" CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Etiqueta</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                               <asp:TextBox ID="txtEtiqueta" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="50"></asp:TextBox>
                               <asp:RequiredFieldValidator id="rfvTxtEtiqueta" runat="server"
                                ControlToValidate="txtEtiqueta"
                                ErrorMessage="<span class='warning'></span>"
                                Display="Static"
                                InitialValue="" CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                                </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Aplicativo</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlAplicativo" runat="server" Width="305px"
                                CssClass="edit rounded" AutoPostBack="True"
                                onselectedindexchanged="ddlAplicativo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvDdlAplicativo" runat="server"
                              ControlToValidate="ddlAplicativo"
                              ErrorMessage="<span class='warning'></span>"
                              Display="Static"
                              InitialValue="-1" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                              </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Tipo de Objeto</td>
                        <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlTipoObjeto" runat="server" Width="305px"
                                CssClass="edit rounded" AutoPostBack="True"
                                onselectedindexchanged="ddlTipoObjeto_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvDdlTipoObjeto" runat="server"
                              ControlToValidate="ddlTipoObjeto"
                              ErrorMessage="<span class='warning'></span>"
                              Display="Static"
                              InitialValue="-1" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                              </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Objeto Padre</td>
                        <td>
                            <asp:DropDownList ID="ddlObjetoPadre" runat="server" Width="305px"
                                CssClass="edit rounded">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td>Estado</td>
                        <td>
                            <asp:DropDownList ID="ddlEstado" runat="server" Width="105px"
                                CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator id="rfvDdlEstado" runat="server"
                              ControlToValidate="ddlEstado"
                              ErrorMessage="<span class='warning'></span>"
                              Display="Static"
                              InitialValue="-1" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label1" runat="server">URL</asp:Label></td>
                        <td>
                               <asp:TextBox ID="txtURL" runat="server" CssClass="edit rounded"
                                Width="300px" MaxLength="100"></asp:TextBox>

                        </td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar"
                                CssClass="btn rounded" ValidationGroup="validacion"
                                onclick="btnGuardar_Click"/>
                            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar"
                                CssClass="btn rounded" onclick="btnLimpiar_Click" />
                            <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded"
                                Visible="False" ></asp:Label>
                        </td>

                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnSalir" runat="server" Text="Salir"
                CssClass="btn rounded fright" style="margin-right:0px;"
                onclick="btnSalir_Click"/>
            <div class="clear"></div>
        </div>

</asp:Content>
