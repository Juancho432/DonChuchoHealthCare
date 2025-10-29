<%@ Page Title="Gestión de Seguros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seguros.aspx.cs" Inherits="DonChuchoHealthCare.Seguros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILOS GENERALES ======== */
        .seguros-container {
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
            transition: max-height 0.5s ease, padding 0.3s ease;
            background-color: #1c2541;
            padding: 0 20px;
        }

        .accordion-content.open {
            max-height: 2000px;
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

        .form-group input, .form-group select, .form-group textarea {
            background-color: #3a506b;
            border: 1px solid #5bc0be;
            color: white;
            border-radius: 8px;
            padding: 10px;
            font-size: 15px;
        }

        .form-group input::placeholder, .form-group textarea::placeholder {
            color: #b0c4d4;
        }

        textarea {
            resize: vertical;
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
    <div class="seguros-container">

        <!-- REGISTRO DE SEGURO -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de seguro</div>
            <div class="accordion-content">
                <div class="form-grid">

                    <div class="form-group">
                        <label for="txt_nombre">Nombre del seguro</label>
                        <asp:TextBox ID="txt_nombre" runat="server" placeholder="Ejemplo: Seguro de vida familiar"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_tipo">Tipo de seguro</label>
                        <asp:DropDownList ID="ddl_tipo" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Vida" Value="Vida"></asp:ListItem>
                            <asp:ListItem Text="Salud" Value="Salud"></asp:ListItem>
                            <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                            <asp:ListItem Text="Hogar" Value="Hogar"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_cobertura">Cobertura</label>
                        <asp:TextBox ID="txt_cobertura" runat="server" placeholder="Descripción breve de la cobertura"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_costo">Costo (COP)</label>
                        <asp:TextBox ID="txt_costo" runat="server" placeholder="Ejemplo: 120000.00"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_duracion">Duración (meses)</label>
                        <asp:TextBox ID="txt_duracion" runat="server" placeholder="Ejemplo: 12"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_aseguradora">Aseguradora</label>
                        <asp:DropDownList ID="ddl_aseguradora" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="Colseguros" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Mapfre" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Sura" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddl_estado">Estado</label>
                        <asp:DropDownList ID="ddl_estado" runat="server">
                            <asp:ListItem Text="Activo" Value="Activo"></asp:ListItem>
                            <asp:ListItem Text="Inactivo" Value="Inactivo"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_beneficios">Beneficios</label>
                        <asp:TextBox ID="txt_beneficios" runat="server" TextMode="MultiLine" Rows="3" placeholder="Describa los beneficios principales"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_exclusiones">Exclusiones</label>
                        <asp:TextBox ID="txt_exclusiones" runat="server" TextMode="MultiLine" Rows="3" placeholder="Condiciones no cubiertas"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_condiciones">Condiciones</label>
                        <asp:TextBox ID="txt_condiciones" runat="server" TextMode="MultiLine" Rows="3" placeholder="Términos y condiciones aplicables"></asp:TextBox>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- ADMINISTRACIÓN DE SEGUROS -->
        <div class="accordion-section">
            <div class="accordion-header">Administración de seguros</div>
            <div class="accordion-content">
                <div class="form-group" style="max-width:300px;">
                    <label for="txt_buscarSeguro">Buscar por ID del seguro</label>
                    <asp:TextBox ID="txt_buscarSeguro" runat="server" placeholder="Ejemplo: 101"></asp:TextBox>
                </div>

                <div class="btn-group" style="margin-bottom:15px;">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn" />
                </div>

                <div class="form-grid">
                    <div class="form-group">
                        <label for="txt_nombre_admin">Nombre</label>
                        <asp:TextBox ID="txt_nombre_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddl_tipo_admin">Tipo</label>
                        <asp:DropDownList ID="ddl_tipo_admin" runat="server" Enabled="false">
                            <asp:ListItem Text="Vida" Value="Vida"></asp:ListItem>
                            <asp:ListItem Text="Salud" Value="Salud"></asp:ListItem>
                            <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                            <asp:ListItem Text="Hogar" Value="Hogar"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txt_cobertura_admin">Cobertura</label>
                        <asp:TextBox ID="txt_cobertura_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txt_costo_admin">Costo</label>
                        <asp:TextBox ID="txt_costo_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txt_duracion_admin">Duración</label>
                        <asp:TextBox ID="txt_duracion_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txt_beneficios_admin">Beneficios</label>
                        <asp:TextBox ID="txt_beneficios_admin" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txt_exclusiones_admin">Exclusiones</label>
                        <asp:TextBox ID="txt_exclusiones_admin" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txt_condiciones_admin">Condiciones</label>
                        <asp:TextBox ID="txt_condiciones_admin" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <!-- BÚSQUEDA AVANZADA -->
        <div class="accordion-section">
            <div class="accordion-header">Búsqueda avanzada</div>
            <div class="accordion-content">
                <div class="form-grid">
                    <div class="form-group">
                        <label>Tipo</label>
                        <asp:DropDownList ID="ddl_tipoBusqueda" runat="server">
                            <asp:ListItem Text="Cualquiera" Value=""></asp:ListItem>
                            <asp:ListItem Text="Vida" Value="Vida"></asp:ListItem>
                            <asp:ListItem Text="Salud" Value="Salud"></asp:ListItem>
                            <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                            <asp:ListItem Text="Hogar" Value="Hogar"></asp:ListItem>
                            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label>Cobertura contiene:</label>
                        <asp:TextBox ID="txt_busquedaCobertura" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Costo máximo (COP):</label>
                        <asp:TextBox ID="txt_costoMax" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Duración mínima (meses):</label>
                        <asp:TextBox ID="txt_duracionMin" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Aseguradora:</label>
                        <asp:DropDownList ID="ddl_aseguradoraBusqueda" runat="server">
                            <asp:ListItem Text="Cualquiera" Value=""></asp:ListItem>
                            <asp:ListItem Text="Colseguros" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Mapfre" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Sura" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_filtrar" runat="server" Text="🔎 Buscar" CssClass="btn" />
                </div>

                <asp:GridView ID="gv_resultados" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- LISTADO GENERAL -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de seguros</div>
            <div class="accordion-content">
                <asp:GridView ID="gv_seguros" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>