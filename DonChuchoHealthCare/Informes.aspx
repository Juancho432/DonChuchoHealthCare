<%@ Page Title="Módulo de Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="DonChuchoHealthCare.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ======== ESTILOS GENERALES ======== */
        .reportes-container {
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

        /* ======== FORMULARIOS ======== */
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

        /* ======== ESTADÍSTICAS ======== */
        .stats-box {
            display: grid;
            grid-template-columns: repeat(auto-fit, minmax(220px, 1fr));
            gap: 15px;
            margin-top: 20px;
        }

        .stat-card {
            background-color: #3a506b;
            border-radius: 10px;
            text-align: center;
            padding: 20px;
            color: #fff;
            box-shadow: 0 3px 10px rgba(0,0,0,0.3);
        }

        .stat-card h3 {
            color: #5bc0be;
            font-size: 20px;
            margin-bottom: 10px;
        }

        .stat-card p {
            font-size: 22px;
            font-weight: bold;
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
    <div class="reportes-container">

        <!-- INFORME DE VENTAS -->
        <div class="accordion-section">
            <div class="accordion-header">Informe de ventas</div>
            <div class="accordion-content">
                <div class="form-grid">
                    <div class="form-group">
                        <label for="ddl_tipoSeguro">Tipo de seguro</label>
                        <asp:DropDownList ID="ddl_tipoSeguro" runat="server">
                            <asp:ListItem Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="Vida" Value="Vida"></asp:ListItem>
                            <asp:ListItem Text="Salud" Value="Salud"></asp:ListItem>
                            <asp:ListItem Text="Automóvil" Value="Automóvil"></asp:ListItem>
                            <asp:ListItem Text="Hogar" Value="Hogar"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_fechaInicio">Fecha inicio</label>
                        <asp:TextBox ID="txt_fechaInicio" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="txt_fechaFin">Fecha fin</label>
                        <asp:TextBox ID="txt_fechaFin" runat="server" TextMode="Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_cliente">Cliente</label>
                        <asp:DropDownList ID="ddl_cliente" runat="server">
                            <asp:ListItem Text="Todos" Value=""></asp:ListItem>
                            <asp:ListItem Text="101 - Carlos Pérez" Value="101"></asp:ListItem>
                            <asp:ListItem Text="102 - Ana Gómez" Value="102"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddl_region">Región</label>
                        <asp:DropDownList ID="ddl_region" runat="server">
                            <asp:ListItem Text="Todas" Value=""></asp:ListItem>
                            <asp:ListItem Text="Antioquia" Value="Antioquia"></asp:ListItem>
                            <asp:ListItem Text="Bogotá" Value="Bogotá"></asp:ListItem>
                            <asp:ListItem Text="Valle del Cauca" Value="Valle"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_generarVentas" runat="server" Text="📊 Generar reporte" CssClass="btn" />
                    <asp:Button ID="btn_exportarVentas" runat="server" Text="⬇️ Exportar PDF" CssClass="btn" />
                </div>

                <asp:GridView ID="gv_ventas" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- ESTADÍSTICAS DE PÓLIZAS -->
        <div class="accordion-section">
            <div class="accordion-header">Estadísticas de pólizas</div>
            <div class="accordion-content">
                <div class="stats-box">
                    <div class="stat-card">
                        <h3>Pólizas vigentes</h3>
                        <p>128</p>
                    </div>
                    <div class="stat-card">
                        <h3>En renovación</h3>
                        <p>24</p>
                    </div>
                    <div class="stat-card">
                        <h3>Canceladas</h3>
                        <p>12</p>
                    </div>
                    <div class="stat-card">
                        <h3>Vencidas</h3>
                        <p>7</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- PAGOS ATRASADOS -->
        <div class="accordion-section">
            <div class="accordion-header">Pagos atrasados</div>
            <div class="accordion-content">
                <div class="btn-group">
                    <asp:Button ID="btn_generarAtrasados" runat="server" Text="📄 Generar reporte" CssClass="btn" />
                </div>
                <asp:GridView ID="gv_pagosAtrasados" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

        <!-- SEGUROS MÁS VENDIDOS -->
        <div class="accordion-section">
            <div class="accordion-header">Seguros más vendidos</div>
            <div class="accordion-content">
                <asp:GridView ID="gv_topSeguros" runat="server" CssClass="gridview"></asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
