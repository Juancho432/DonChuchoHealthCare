<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="DonChuchoHealthCare.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILOS GENERALES ======== */
        .clientes-container {
            color: #e0e0e0;
            font-family: 'Segoe UI', sans-serif;
        }

        /* ======== ACORDEÓN ======== */
        .accordion-section {
            background-color: #1c2541;
            border-radius: 10px;
            margin-bottom: 20px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.4);
            overflow: hidden;
        }

        .accordion-header {
            background-color: #3a506b;
            color: #5bc0be;
            padding: 15px 20px;
            font-size: 18px;
            font-weight: 600;
            cursor: pointer;
            transition: background-color 0.3s;
            user-select: none;
        }

        .accordion-header:hover {
            background-color: #465d7a;
        }

        .accordion-content {
            max-height: 0;
            overflow: hidden;
            transition: max-height 1s ease, padding 0.3s ease;
            background-color: #1c2541;
            padding: 0 20px;
        }

        .accordion-content.open {
            max-height: 1000px;
            padding: 20px;
        }

        /* ======== FORMULARIO ======== */
        .form-grid {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(260px, 1fr));
            gap: 15px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
        }

        .form-group label {
            font-weight: 500;
            margin-bottom: 5px;
        }

        .form-group input, .form-group select {
            background-color: #3a506b;
            border: 1px solid #5bc0be;
            color: white;
            border-radius: 8px;
            padding: 10px;
            font-size: 15px;
        }

        .form-group input::placeholder {
            color: #b0c4d4;
        }

        .btn-group {
            margin-top: 20px;
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

        /* ======== TABLAS ======== */
        .gridview {
            width: 100%;
            color: #fff;
            border-collapse: collapse;
            margin-top: 10px;
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
    </style>

    <script>
        // ======== SCRIPT DE ACORDEÓN ========
        document.addEventListener('DOMContentLoaded', function () {
            const headers = document.querySelectorAll('.accordion-header');
            headers.forEach(header => {
                header.addEventListener('click', () => {
                    const content = header.nextElementSibling;
                    content.classList.toggle('open');
                });
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clientes-container">

        <!-- REGISTRO DE CLIENTE -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de cliente</div>
            <div class="accordion-content">

                <div class="form-grid">
                    <div class="form-group">
                        <label for="txt_id">ID (Documento)</label>
                        <asp:TextBox ID="txt_id" runat="server" placeholder="Número de documento"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_tipoDocumento">Tipo de documento</label>
                        <asp:DropDownList ID="ddl_tipoDocumento" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Cédula de ciudadanía (CC)" Value="CC"></asp:ListItem>
                            <asp:ListItem Text="Cédula de extranjería (CE)" Value="CE"></asp:ListItem>
                            <asp:ListItem Text="NIT" Value="NIT"></asp:ListItem>
                            <asp:ListItem Text="Pasaporte" Value="PASAPORTE"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_nombres">Nombres</label>
                        <asp:TextBox ID="txt_nombres" runat="server" placeholder="Nombres del cliente"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_apellidos">Apellidos</label>
                        <asp:TextBox ID="txt_apellidos" runat="server" placeholder="Apellidos del cliente"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_fechaNacimiento">Fecha de nacimiento</label>
                        <asp:TextBox ID="txt_fechaNacimiento" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_direccion">Dirección</label>
                        <asp:TextBox ID="txt_direccion" runat="server" placeholder="Dirección de residencia"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_telefono">Teléfono</label>
                        <asp:TextBox ID="txt_telefono" runat="server" placeholder="Teléfono o celular"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_correo">Correo electrónico</label>
                        <asp:TextBox ID="txt_correo" runat="server" placeholder="ejemplo@correo.com"></asp:TextBox>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- ADMINISTRACIÓN DE CLIENTES -->
        <div class="accordion-section">
            <div class="accordion-header">Administración de clientes</div>
            <div class="accordion-content">

                <div class="form-group" style="max-width: 300px;">
                    <label for="txt_buscarId">Buscar por ID (documento):</label>
                    <asp:TextBox ID="txt_buscarId" runat="server" placeholder="Ingrese el ID del cliente"></asp:TextBox>
                </div>

                <div class="btn-group" style="margin-bottom: 20px;">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" OnClick="btn_buscar_Click" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" Enabled="false" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn" Enabled="false" />
                </div>

                <!-- CAMPOS DE INFORMACIÓN DEL CLIENTE (DESHABILITADOS POR DEFECTO) -->
                <div class="form-grid">
                    <div class="form-group">
                        <label for="txt_id_admin">ID (Documento)</label>
                        <asp:TextBox ID="txt_id_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_tipoDocumento_admin">Tipo de documento</label>
                        <asp:DropDownList ID="ddl_tipoDocumento_admin" runat="server" Enabled="false">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Cédula de ciudadanía (CC)" Value="CC"></asp:ListItem>
                            <asp:ListItem Text="Cédula de extranjería (CE)" Value="CE"></asp:ListItem>
                            <asp:ListItem Text="NIT" Value="NIT"></asp:ListItem>
                            <asp:ListItem Text="Pasaporte" Value="PASAPORTE"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_nombres_admin">Nombres</label>
                        <asp:TextBox ID="txt_nombres_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_apellidos_admin">Apellidos</label>
                        <asp:TextBox ID="txt_apellidos_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_fechaNacimiento_admin">Fecha de nacimiento</label>
                        <asp:TextBox ID="txt_fechaNacimiento_admin" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_direccion_admin">Dirección</label>
                        <asp:TextBox ID="txt_direccion_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_telefono_admin">Teléfono</label>
                        <asp:TextBox ID="txt_telefono_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_correo_admin">Correo electrónico</label>
                        <asp:TextBox ID="txt_correo_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <!-- HISTORIAL DE PÓLIZAS -->
        <div class="accordion-section">
            <div class="accordion-header">Historial de pólizas del cliente seleccionado</div>
            <div class="accordion-content">
                <asp:GridView ID="gv_polizas" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- LISTADO GENERAL -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de clientes</div>
            <div class="accordion-content">
                <asp:GridView ID="gv_clientes" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
