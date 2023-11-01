<%@ Page Title="" Language="C#" MasterPageFile="~/APPSeguridadLogin.Master" AutoEventWireup="false" CodeBehind="Encriptar.aspx.cs" Inherits="APP.SEG.WEB.Util.Encriptar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="loginBox" style="min-height:300px;">
        <table border="0" cellpadding="0" cellspacing="0" class="fix rounded" >
            <thead>
                <tr>
                <th colspan="3">Encriptar - DesEncriptar Valor</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Valor</td>
                    <td><asp:TextBox ID="txtValor" runat="server" CssClass="edit rounded"
                            Width="500px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator id="rfvTxtUsuario" runat="server"
                            ControlToValidate="txtValor"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="" CssClass="validator"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Clave</td>
                    <td>
                        <asp:TextBox ID="txtClave" runat="server" CssClass="edit rounded"
                             Width="300px" MaxLength="500"></asp:TextBox>

                    </td>
                    <td>
                          <asp:RequiredFieldValidator id="rfvTxtClave" runat="server"
                            ControlToValidate="txtClave"
                            ErrorMessage="<span class='warning'></span>"
                            Display="Static"
                            InitialValue="" CssClass="validator"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Resultado</td>
                    <td>
                        <asp:TextBox ID="txtResultado" runat="server" CssClass="edit rounded"
                            Width="500px" MaxLength="500"></asp:TextBox>
                    </td>
                    <td>

                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td colspan="2">
                        <asp:Button ID="btnEncrptar" runat="server" Text="Encriptar"
                            CssClass="btn rounded" onclick="btnEncrptar_Click" />

                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                            <asp:Button ID="btnDesEncriptar" runat="server" Text="DesEncriptar"
                            CssClass="btn rounded" onclick="btnDesEncriptar_Click" />
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
</asp:Content>
