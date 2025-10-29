<%@ Page Title="Gestión de Pólizas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Polizas.aspx.cs" Inherits="DonChuchoHealthCare.Polizas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILOS GENERALES ======== */
        .polizas-container {
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
    <div class="polizas-container">

        <!-- REGISTRO DE PÓLIZA -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de póliza</div>
            <div class="accordion-content">
                <div class="form-grid">
                    <div class="form-group">
                        <label for="txt_numero_poliza">Número de póliza</label>
                        <asp:TextBox ID="txt_numero_poliza" runat="server" placeholder="Ejemplo: POL-2025-001"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_cliente">Cliente</label>
                        <asp:DropDownList ID="ddl_cliente" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="101 - Carlos Pérez" Value="101"></asp:ListItem>
                            <asp:ListItem Text="102 - Ana Gómez" Value="102"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddl_seguro">Seguro asociado</label>
                        <asp:DropDownList ID="ddl_seguro" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="1 - Seguro de Vida" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2 - Seguro de Salud" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_fecha_inicio">Fecha de inicio</label>
                        <asp:TextBox ID="txt_fecha_inicio" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_fecha_fin">Fecha de fin</label>
                        <asp:TextBox ID="txt_fecha_fin" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_estado">Estado</label>
                        <asp:DropDownList ID="ddl_estado" runat="server">
                            <asp:ListItem Text="Vigente" Value="Vigente"></asp:ListItem>
                            <asp:ListItem Text="Vencida" Value="Vencida"></asp:ListItem>
                            <asp:ListItem Text="Renovación" Value="Renovacion"></asp:ListItem>
                            <asp:ListItem Text="Cancelada" Value="Cancelada"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_motivo_cancelacion">Motivo de cancelación (si aplica)</label>
                        <asp:TextBox ID="txt_motivo_cancelacion" runat="server" TextMode="MultiLine" Rows="3" placeholder="Describe el motivo en caso de cancelación"></asp:TextBox>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- ADMINISTRACIÓN DE PÓLIZAS -->
        <div class="accordion-section">
            <div class="accordion-header">Administración de pólizas</div>
            <div class="accordion-content">
                <div class="form-group" style="max-width:300px;">
                    <label for="txt_buscarPoliza">Buscar por número de póliza:</label>
                    <asp:TextBox ID="txt_buscarPoliza" runat="server" placeholder="Ejemplo: POL-2025-001"></asp:TextBox>
                </div>

                <div class="btn-group" style="margin-bottom:15px;">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="❌ Cancelar póliza" CssClass="btn" />
                </div>

                <div class="form-grid">
                    <div class="form-group">
                        <label for="txt_numero_admin">Número de póliza</label>
                        <asp:TextBox ID="txt_numero_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddl_estado_admin">Estado actual</label>
                        <asp:DropDownList ID="ddl_estado_admin" runat="server" Enabled="false">
                            <asp:ListItem Text="Vigente" Value="Vigente"></asp:ListItem>
                            <asp:ListItem Text="Vencida" Value="Vencida"></asp:ListItem>
                            <asp:ListItem Text="Renovación" Value="Renovacion"></asp:ListItem>
                            <asp:ListItem Text="Cancelada" Value="Cancelada"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="txt_motivo_admin">Motivo cancelación</label>
                        <asp:TextBox ID="txt_motivo_admin" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <!-- CERTIFICADOS Y DOCUMENTOS -->
        <div class="accordion-section">
            <div class="accordion-header">Certificados y documentos</div>
            <div class="accordion-content">
                <div class="form-group" style="max-width:300px;">
                    <label for="txt_certificadoPoliza">Número de póliza:</label>
                    <asp:TextBox ID="txt_certificadoPoliza" runat="server" placeholder="Ejemplo: POL-2025-001"></asp:TextBox>
                </div>
                <div class="btn-group">
                    <asp:Button ID="btn_generarCertificado" runat="server" Text="📄 Generar certificado" CssClass="btn" />
                    <asp:Button ID="btn_exportarPDF" runat="server" Text="⬇️ Exportar PDF" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- LISTADO GENERAL -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de pólizas</div>
            <div class="accordion-content">
                <asp:GridView ID="gv_polizas" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>