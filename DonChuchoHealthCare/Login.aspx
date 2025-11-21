<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DonChuchoHealthCare.Login" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <title>Inicio de Sesión - Don Chucho HealthCare</title>
    <link rel="stylesheet" href="~/css/Login.css" runat="server" />
</head>

<body class="login-body">
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-card">
                <h1>Don Chucho HealthCare</h1>
                <h3>“Cuidamos lo que más valoras”</h3>

                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario" CssClass="login-input"></asp:TextBox>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="login-input"></asp:TextBox>

                <asp:Button ID="btnIngresar" runat="server" Text="Iniciar sesión" CssClass="btn-login" OnClick="btnIngresar_Click" />
                <asp:Label ID="lblMensaje" runat="server" CssClass="login-error"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
