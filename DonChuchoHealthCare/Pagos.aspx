<%@ Page Title="Gestión de Pagos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="DonChuchoHealthCare.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILOS GENERALES ======== */
        .pagos-container {
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
    <div class="pagos-container">

        <!-- REGISTRO DE PAGOS -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de pagos</div>
            <div class="accordion-content">
                <div class="form-grid">
                    <div class="form-group">
                        <label for="ddl_poliza">Póliza asociada</label>
                        <asp:DropDownList ID="ddl_poliza" runat="server">
                            <asp:ListItem Text="Seleccionar..." Value=""></asp:ListItem>
                            <asp:ListItem Text="POL-2025-001" Value="1"></asp:ListItem>
                            <asp:ListItem Text="POL-2025-002" Value="2"></asp:ListItem>
                        </asp:DropDownList>
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
                        <label for="txt_fecha_pago">Fecha de pago</label>
                        <asp:TextBox ID="txt_fecha_pago" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_fecha_vencimiento">Fecha de vencimiento</label>
                        <asp:TextBox ID="txt_fecha_vencimiento" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_monto">Monto (COP)</label>
                        <asp:TextBox ID="txt_monto" runat="server" placeholder="Ejemplo: 250000.00"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_forma_pago">Forma de pago</label>
                        <asp:DropDownList ID="ddl_forma_pago" runat="server">
                            <asp:ListItem Text="Efectivo" Value="Efectivo"></asp:ListItem>
                            <asp:ListItem Text="Tarjeta" Value="Tarjeta"></asp:ListItem>
                            <asp:ListItem Text="Transferencia" Value="Transferencia"></asp:ListItem>
                            <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_numero_comprobante">Número de comprobante</label>
                        <asp:TextBox ID="txt_numero_comprobante" runat="server" placeholder="Ejemplo: TRX-45321"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_estado_pago">Estado del pago</label>
                        <asp:DropDownList ID="ddl_estado_pago" runat="server">
                            <asp:ListItem Text="Completado" Value="Completado"></asp:ListItem>
                            <asp:ListItem Text="Pendiente" Value="Pendiente"></asp:ListItem>
                            <asp:ListItem Text="Atrasado" Value="Atrasado"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- GESTIÓN Y BÚSQUEDA DE PAGOS -->
        <div class="accordion-section">
            <div class="accordion-header">Gestión y búsqueda de pagos</div>
            <div class="accordion-content">
                <div class="form-group" style="max-width:300px;">
                    <label for="txt_buscarPago">Buscar por número de comprobante:</label>
                    <asp:TextBox ID="txt_buscarPago" runat="server" placeholder="Ejemplo: TRX-45321"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn" />
                </div>

                <asp:GridView ID="gv_pagos" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- COMPROBANTES E INFORMES -->
        <div class="accordion-section">
            <div class="accordion-header">Comprobantes e informes</div>
            <div class="accordion-content">
                <div class="form-group" style="max-width:300px;">
                    <label for="txt_comprobantePago">Número de comprobante:</label>
                    <asp:TextBox ID="txt_comprobantePago" runat="server" placeholder="Ejemplo: TRX-45321"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_generarComprobante" runat="server" Text="📄 Generar comprobante" CssClass="btn" />
                    <asp:Button ID="btn_exportarInforme" runat="server" Text="📊 Exportar informe" CssClass="btn" />
                </div>
            </div>
        </div>

        <!-- LISTADO GENERAL DE PAGOS -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de pagos</div>
            <div class="accordion-content">
                <div class="form-grid">
                    <div class="form-group">
                        <label>Filtrar por cliente</label>
                        <asp:DropDownList ID="ddl_clienteFiltro" runat="server">
                            <asp:ListItem Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="101 - Carlos Pérez" Value="101"></asp:ListItem>
                            <asp:ListItem Text="102 - Ana Gómez" Value="102"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Filtrar por fecha:</label>
                        <asp:TextBox ID="txt_fechaFiltro" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_filtrar" runat="server" Text="🔎 Aplicar filtros" CssClass="btn" />
                </div>

                <asp:GridView ID="gv_listadoPagos" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
