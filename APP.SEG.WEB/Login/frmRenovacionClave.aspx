<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridadLogin.Master" AutoEventWireup="false" CodeBehind="frmRenovacionClave.aspx.cs" Inherits="APP.SEG.WEB.Login.frmRenovacionClave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="loginBox" style="min-height:300px;">
        <table border="0" cellpadding="0" cellspacing="0" class="fix rounded fixWidth330" >
            <thead>
                <tr>
                <th colspan="3"><asp:Label ID="lblTitulo" runat="server">Renovación de PASSWORD</asp:Label></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Usuario</td>
                    <td><asp:TextBox ID="txtUsuario" runat="server" CssClass="edit rounded"
                            Width="170px" MaxLength="14" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator id="rfvTxtUsuario" runat="server"
                            ControlToValidate="txtUsuario"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="" CssClass="validator"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password Anterior</td>
                    <td>
                        <asp:TextBox ID="txtPasswordAnterior" runat="server" CssClass="edit rounded"
                            TextMode="Password" Width="170px" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator id="rfvTxtPassword" runat="server"
                            ControlToValidate="txtPasswordAnterior"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password Nuevo</td>
                    <td>
                        <asp:TextBox ID="txtPasswordNuevo1" runat="server" CssClass="edit rounded"
                            TextMode="Password" Width="170px" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtPasswordNuevo1"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Confirme el Password</td>
                    <td>
                        <asp:TextBox ID="txtPasswordNuevo2" runat="server" CssClass="edit rounded"
                            TextMode="Password" Width="170px" MaxLength="16"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPasswordNuevo2"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar"
                            CssClass="btn rounded" onclick="btnActualizar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"
                            CssClass="btn rounded" onclick="btnCancelar_Click"
                            CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="lblMensaje" runat="server" class="mensaje" Visible="false"></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <asp:HiddenField ID="hdRol" runat="server" />
</asp:Content>
