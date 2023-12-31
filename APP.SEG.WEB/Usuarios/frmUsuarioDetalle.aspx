<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridad.Master" AutoEventWireup="false"
    CodeBehind="frmUsuarioDetalle.aspx.cs" Inherits="APP.SEG.WEB.Usuarios.frmUsuarioDetalle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 97px;
        }
        .style2
        {
        }
    </style>

    <script language="javascript" type="text/javascript">
        function GenerarCodigoUsuario() {
            var nombre = document.getElementById("<%=txtNombre.ClientID %>").value;
            var apellido = document.getElementById("<%=txtApellidoPaterno.ClientID %>").value;
            var codigousuario = nombre.substr(0, 1) + apellido;


            document.getElementById("<%=txtCodigo.ClientID %>").innerText = codigousuario.toLowerCase();
            document.getElementById("<%=txtPassword.ClientID %>").innerText = codigousuario.toLowerCase();
        }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel">
        <h1 class="rounded">
            <asp:Label ID="lbTituloPanel" runat="server">Detalle del</asp:Label>
            Usuario</h1>
        <br />
        <table border="0" cellpadding="0" cellspacing="0" class="fix rounded Size700">
            <tbody>
                <tr>
                    <td class="style1">
                        Nombre
                    </td>
                    <td class="style2">
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="edit rounded" Width="210px"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtNombre" runat="server" ControlToValidate="txtNombre"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lbTituloCodigo" runat="server">C�digo</asp:Label>
                    </td>
                    <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="edit rounded" Width="100px"
                                MaxLength="14" TabIndex="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtCodigo" runat="server" ControlToValidate="txtCodigo"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Ap. Paterno
                    </td>
                    <td class="style2">
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="edit rounded" Width="210px"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtApellidoPaterno" runat="server" ControlToValidate="txtApellidoPaterno"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                    <td>
                        Ap. Materno
                    </td>
                    <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="edit rounded" Width="210px"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtApellidoMaterno" runat="server" ControlToValidate="txtApellidoMaterno"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Tipo de Usuario
                    </td>
                    <td class="style2">

                            <asp:DropDownList ID="ddlTipoUsuario" runat="server" Width="215px" CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlTipoUsuario" runat="server" ControlToValidate="ddlTipoUsuario"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        �rea
                    </td>
                    <td class="style2">

                            <asp:DropDownList ID="ddlArea" runat="server" Width="215px" CssClass="edit rounded"
                                OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlArea" runat="server" ControlToValidate="ddlArea"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                        Oficina
                    </td>
                    <td>

                            <asp:DropDownList ID="ddlOficina" runat="server" Width="215px" CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlOficina" runat="server" ControlToValidate="ddlOficina"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        Cambiar Password en el siguiente inicio de sesi�n
                    </td>
                    <td colspan="2">
                        <asp:CheckBox ID="chkCambiarPasswordInicio" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                      <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="edit rounded" Width="210px"
                            MaxLength="50" TabIndex="51"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvTxtPassword" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                            CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                            </div>
                    </td>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Password caduca
                    </td>
                    <td class="style2">
                        <asp:CheckBox ID="chkPasswordCaduca" runat="server" />
                    </td>
                    <td>
                        Fecha Caducidad
                    </td>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:TextBox ID="txtFechaCaducidad" runat="server" CssClass="edit rounded" Width="100px"
                            MaxLength="50"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFechaCaducidad_CalendarExtender" runat="server" TargetControlID="txtFechaCaducidad"
                            Enabled="True" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <asp:RequiredFieldValidator ID="rfvFechaCaducidad" runat="server" ErrorMessage="<span class='warning'></span>"
                            InitialValue="" CssClass="validator" ValidationGroup="validacion" ControlToValidate="txtFechaCaducidad"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revTxtFechaCaducidad" runat="server" ControlToValidate="txtFechaCaducidad"
                            ErrorMessage="<span class='warning'></span>" Display="Static" SetFocusOnError="false"
                            ValidationExpression="\d{2}/\d{2}/\d{4}" CssClass="validator" ValidationGroup="validacion"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Estado
                    </td>
                    <td class="style2">

                            <asp:DropDownList ID="ddlEstado" runat="server" Width="215px" CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlEstado" runat="server" ControlToValidate="ddlEstado"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>

                    </td>
                    <td>
                        Acceso Tercero
                    </td>
                    <td>
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:DropDownList ID="ddlAccesoTercero" runat="server" Width="215px" CssClass="edit rounded">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvDdlAccesoTercero" runat="server" ControlToValidate="ddlAccesoTercero"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue="-1"
                                ValidationGroup="validacion"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        Correo Electr�nico
                    </td>
                    <td class="style2">
                        <div class="requiredInput">
                            <div class="requiredBlock">
                            </div>
                            <asp:TextBox ID="txtCorreoElectronico" runat="server" CssClass="edit rounded" Width="210px"
                                MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RfvTxtCorreoElectronico" runat="server" ControlToValidate="txtCorreoElectronico"
                                ErrorMessage="<span class='warning'></span>" Display="Static" InitialValue=""
                                CssClass="validator" ValidationGroup="validacion"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RevTxtCorreoElectronico" ControlToValidate="txtCorreoElectronico"
                                runat="server" ErrorMessage="<span class='warning'></span>" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="validacion"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn rounded"
                            ValidationGroup="validacion" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn rounded"
                            OnClick="btnLimpiar_Click" />
                        <asp:Label ID="lbResultados" runat="server" CssClass="infoResultado rounded" Visible="False"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
        <asp:Button ID="btnSalir" runat="server" Text="Salir" CssClass="btn rounded fright"
            Style="margin-right: 0px;" OnClick="btnSalir_Click" />
        <div class="clear">
        </div>
    </div>

    <script language="javascript">

        function habilitaFecha(checkbox) {
            if (checkbox.checked) {
                document.getElementById(txtCuenta).disabled = false;
            }
            else {
                document.getElementById(txtCuenta).disabled = true;
            }
        }

    </script>

</asp:Content>
