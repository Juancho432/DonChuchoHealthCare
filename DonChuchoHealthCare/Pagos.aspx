<%@ Page Title="Gestión de Pagos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pagos.aspx.cs" Inherits="DonChuchoHealthCare.Pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Pagos.css" rel="stylesheet" />


    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const headers = document.querySelectorAll('.accordion-header');

            headers.forEach((header, index) => {
                header.addEventListener('click', () => {
                    const content = header.nextElementSibling;
                    content.classList.toggle('open');

                    if (content.classList.contains('open')) {
                        document.getElementById('<%= hfAccordion.ClientID %>').value = index;
                    } else {
                        document.getElementById('<%= hfAccordion.ClientID %>').value = "";
                    }
                });
            });

            // Restaurar acordeón abierto tras postback
            const openIndex = document.getElementById('<%= hfAccordion.ClientID %>').value;
            if (openIndex !== "") {
                const sections = document.querySelectorAll('.accordion-content');
                sections[openIndex].classList.add('open');
            }
        });
    </script>

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Para mantener qué acordeón queda abierto -->
    <asp:HiddenField ID="hfAccordion" runat="server" />

    <div class="pagos-container">

        <!-- ================= REGISTRO DE PAGOS ================= -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de pagos</div>
            <div class="accordion-content">

                <asp:Label ID="lbl_msgRegistro" runat="server" CssClass="msg"></asp:Label>

                <div class="form-grid">

                    <div class="form-group">
                        <label for="ddl_poliza">Póliza asociada</label>
                        <asp:DropDownList ID="ddl_poliza" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddl_cliente">Cliente</label>
                        <asp:DropDownList ID="ddl_cliente" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_fecha_pago">Fecha de pago</label>
                        <asp:TextBox ID="txt_fecha_pago" runat="server" TextMode="Date"></asp:TextBox>
                    </div>


                    <div class="form-group">
                        <label for="txt_monto">Monto (COP)</label>
                        <asp:TextBox ID="txt_monto" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_forma_pago">Forma de pago</label>
                        <asp:DropDownList ID="ddl_forma_pago" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_numero_comprobante">Número de comprobante</label>
                        <asp:TextBox ID="txt_numero_comprobante" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_estado_pago">Estado del pago</label>
                        <asp:DropDownList ID="ddl_estado_pago" runat="server"></asp:DropDownList>
                    </div>

                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" OnClick="btn_guardar_Click" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" />
                </div>

            </div>
        </div>




        <!-- ================= GESTIÓN DE PAGOS ================= -->
        <div class="accordion-section">
            <div class="accordion-header">Gestión y búsqueda de pagos</div>
            <div class="accordion-content">

                <asp:Label ID="lbl_msgGestion" runat="server" CssClass="msg"></asp:Label>

                <div class="form-group" style="max-width:300px;">
                    <label for="txt_buscarPago">Buscar por número de comprobante:</label>
                    <asp:TextBox ID="txt_buscarPago" runat="server"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" OnClick="btn_buscar_Click" />
                    <asp:Button ID="btn_eliminar" runat="server" Text="🗑️ Eliminar" CssClass="btn" />
                </div>

                <asp:GridView ID="gv_pagos" runat="server" CssClass="gridview"></asp:GridView>

            </div>
        </div>




        <!-- ================= COMPROBANTES ================= -->
        <div class="accordion-section">
            <div class="accordion-header">Comprobantes</div>
            <div class="accordion-content">

                <asp:Label ID="lbl_msgComprobantes" runat="server" CssClass="msg"></asp:Label>

                <div class="form-group" style="max-width:300px;">
                    <label for="txt_comprobantePago">Número de comprobante:</label>
                    <asp:TextBox ID="txt_comprobantePago" runat="server"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_generarComprobante" runat="server" Text="📄 Generar comprobante" CssClass="btn" />
                </div>

            </div>
        </div>




        <!-- ================= LISTADO GENERAL ================= -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de pagos</div>
            <div class="accordion-content">

                <asp:Label ID="lbl_msgListado" runat="server" CssClass="msg"></asp:Label>

                <div class="form-grid">

                    <div class="form-group">
                        <label>Filtrar por cliente</label>
                        <asp:DropDownList ID="ddl_clienteFiltro" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label>Filtrar por fecha</label>
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
