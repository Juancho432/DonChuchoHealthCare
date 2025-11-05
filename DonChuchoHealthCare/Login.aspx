<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DonChuchoHealthCare.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio de Sesión - Don Chucho HealthCare</title>
    <link href="~/css/Login.css" rel="stylesheet" />
</head>


<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Don Chucho HealthCare</h1>
            <p>Tu sistema de gestión médica y de seguros confiable</p>

            <div class="form-group">
                <label for="txt_usuario">Usuario</label>
                <asp:TextBox ID="txt_usuario" runat="server" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txt_contraseña">Contraseña</label>
                <asp:TextBox ID="txt_contraseña" runat="server" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>

            <asp:Button ID="btn_ingresar" runat="server" Text="Iniciar sesión" CssClass="btn-login" OnClick="btn_ingresar_Click" />
            <asp:Label ID="lbl_mensaje" runat="server" CssClass="error"></asp:Label>
        </div>
    </form>
</body>
</html>
