<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarAdmin.aspx.cs" Inherits="DonChuchoHealthCare.RegistrarAdmin" %>

<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="UTF-8" />
    <title>Registrar Administrador - Don Chucho HealthCare</title>

    <link href="css/Registrar_admin.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div class="reg-container">

            <h1>Registrar Administrador</h1>
            <p>No se detectaron usuarios. Crea el primer administrador del sistema.</p>

            <!-- NOMBRE DE USUARIO -->
            <div class="form-group">
                <label for="txtUsuario">Nombre de usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" placeholder="Ej: admin01"></asp:TextBox>
            </div>

            <!-- CONTRASEÑA -->
            <div class="form-group">
                <label for="txtClave">Contraseña</label>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" placeholder="Contraseña segura"></asp:TextBox>
            </div>

            <!-- CONFIRMAR CONTRASEÑA -->
            <div class="form-group">
                <label for="txtConfirmar">Confirmar contraseña</label>
                <asp:TextBox ID="txtConfirmar" runat="server" TextMode="Password" placeholder="Repita la contraseña"></asp:TextBox>
            </div>

            <!-- NOMBRE -->
            <div class="form-group">
                <label for="txtNombre">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" placeholder="Ej: Carlos Andrés"></asp:TextBox>
            </div>

            <!-- APELLIDOS -->
            <div class="form-group">
                <label for="txtApellidos">Apellidos</label>
                <asp:TextBox ID="txtApellidos" runat="server" placeholder="Ej: Ramírez López"></asp:TextBox>
            </div>

            <!-- CORREO -->
            <div class="form-group">
                <label for="txtCorreo">Correo electrónico</label>
                <asp:TextBox ID="txtCorreo" runat="server" placeholder="Ej: admin@donchucho.com"></asp:TextBox>
            </div>

            <asp:Button ID="btnRegistrar" runat="server"
                        Text="Crear Administrador"
                        CssClass="btn-registrar"
                        OnClick="btnRegistrar_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="msg"></asp:Label>

        </div>
    </form>
</body>
</html>

</html>
