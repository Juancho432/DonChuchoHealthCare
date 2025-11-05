<%@ Page Title="Módulo de Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="DonChuchoHealthCare.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Informes.css" rel="stylesheet" />

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
