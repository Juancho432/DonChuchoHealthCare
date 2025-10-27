<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="DonChuchoHealthCare.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILO GENERAL ======== */
        .clientes-container {
            color: #e0e0e0;
            font-family: 'Segoe UI', sans-serif;
        }

        .panel {
            background-color: #1c2541;
            border-radius: 10px;
            margin-bottom: 15px;
            overflow: hidden;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.5);
            transition: all 0.3s ease-in-out;
        }

        .panel-header {
            background-color: #3a506b;
            color: #5bc0be;
            padding: 15px 20px;
            font-size: 18px;
            cursor: pointer;
            user-select: none;
            display: flex;
            align-items: center;
            justify-content: space-between;
            transition: background-color 0.3s;
        }

        .panel-header:hover {
            background-color: #5bc0be;
            color: #0b132b;
        }

        .panel-content {
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.5s ease, opacity 0.4s ease;
            opacity: 0;
            padding: 0 20px;
        }

        .panel.active .panel-content {
            max-height: 900px;
            opacity: 1;
            padding: 20px;
        }

        .form-group {
            margin-bottom: 15px;
            display: flex;
            flex-direction: column;
        }

        .form-group label {
            font-weight: 500;
            margin-bottom: 5px;
        }

        .form-group input,
        .form-group select {
            background-color: #3a506b;
            border: 1px solid #5bc0be;
            color: #fff;
            border-radius: 8px;
            padding: 10px;
            font-size: 15px;
        }

        .form-group input::placeholder {
            color: #b0c4d4;
        }

        .btn-group {
            margin-top: 15px;
        }

        .btn {
            background-color: #5bc0be;
            color: #0b132b;
            border: none;
            padding: 10px 18px;
            border-radius: 8px;
            font-size: 15px;
            cursor: pointer;
            margin-right: 10px;
            transition: background-color 0.3s;
        }

        .btn:hover {
            background-color: #4aa3a1;
        }

        .gridview {
            width: 100%;
            border-collapse: collapse;
            color: #fff;
        }

        .gridview th {
            background-color: #3a506b;
            padding: 10px;
            text-align: left;
        }

        .gridview td {
            padding: 10px;
            background-color: #1c2541;
            border-top: 1px solid #3a506b;
        }

        .gridview tr:hover td {
            background-color: #3a506b;
        }

        .arrow {
            transition: transform 0.4s ease;
        }

        .panel.active .arrow {
            transform: rotate(90deg);
        }
    </style>

    <script>
        document.addEventListener("DOMContentLoaded", () => {
            const panels = document.querySelectorAll(".panel-header");
            panels.forEach(header => {
                header.addEventListener("click", () => {
                    const parent = header.parentElement;
                    parent.classList.toggle("active");
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clientes-container">

        <!-- PANEL 1 - REGISTRO -->
        <div class="panel">
            <div class="panel-header">
                <span>🧾 Registro de cliente</span>
                <span class="arrow">▶</span>
            </div>
            <div class="panel-content">
                <div class="form-group">
                    <label for="txt_id">ID (Documento):</label>
                    <asp:TextBox ID="txt_id" runat="server" placeholder="Ingrese el número de documento"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="ddl_tipoDocumento">Tipo de documento:</label>
                    <asp:DropDownList ID="ddl_tipoDocumento" runat="server">
                        <asp:ListItem Text="Seleccionar..." Value="" />
                        <asp:ListItem Text="Cédula de Ciudadanía (CC)" Value="CC" />
                        <asp:ListItem Text="Cédula de Extranjería (CE)" Value="CE" />
                        <asp:ListItem Text="NIT" Value="NIT" />
                        <asp:ListItem Text="Pasaporte" Value="PASAPORTE" />
                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label for="txt_nombres">Nombres:</label>
                    <asp:TextBox ID="txt_nombres" runat="server" placeholder="Ingrese los nombres del cliente"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txt_apellidos">Apellidos:</label>
                    <asp:TextBox ID="txt_apellidos" runat="server" placeholder="Ingrese los apellidos del cliente"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txt_fechaNacimiento">Fecha de nacimiento:</label>
                    <asp:TextBox ID="txt_fechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txt_direccion">Dirección:</label>
                    <asp:TextBox ID="txt_direccion" runat="server" placeholder="Ingrese la dirección del cliente"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txt_telefono">Teléfono:</label>
                    <asp:TextBox ID="txt_telefono" runat="server" placeholder="Ingrese el número de teléfono"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label for="txt_correo">Correo electrónico:</label>
                    <asp:TextBox ID="txt_correo" runat="server" placeholder="ejemplo@correo.com"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- PANEL 2 - ADMINISTRACIÓN -->
        <div class="panel">
            <div class="panel-header">
                <span>⚙️ Administración de clientes</span>
                <span class="arrow">▶</span>
            </div>
            <div class="panel-content">
                <div class="form-group">
                    <label for="txt_buscarCliente">Buscar cliente por documento o nombre:</label>
                    <asp:TextBox ID="txt_buscarCliente" runat="server" placeholder="Buscar cliente..."></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- PANEL 3 - HISTORIAL DE PÓLIZAS -->
        <div class="panel">
            <div class="panel-header">
                <span>📜 Historial de pólizas del cliente seleccionado</span>
                <span class="arrow">▶</span>
            </div>
            <div class="panel-content">
                <asp:GridView ID="gv_polizas" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- PANEL 4 - LISTADO GENERAL -->
        <div class="panel">
            <div class="panel-header">
                <span>📋 Listado general de clientes</span>
                <span class="arrow">▶</span>
            </div>
            <div class="panel-content">
                <asp:GridView ID="gv_clientes" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
