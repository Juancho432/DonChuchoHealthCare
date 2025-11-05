<%@ Page Title="Gestión de Pagos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="DonChuchoHealthCare.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Pagos.css" rel="stylesheet" />

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
