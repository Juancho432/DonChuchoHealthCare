<%@ Page Title="Gestión de Pólizas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Polizas.aspx.cs" Inherits="DonChuchoHealthCare.Polizas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Polizas.css" rel="stylesheet" />

    <!-- Campo oculto para recordar acordeón abierto -->
    <asp:HiddenField ID="hfAccordion" runat="server" />

    <script>
        document.addEventListener('DOMContentLoaded', function () {

            const headers = document.querySelectorAll('.accordion-header');

            headers.forEach((header, index) => {
                header.addEventListener('click', () => {
                    const content = header.nextElementSibling;
                    content.classList.toggle('open');

                    // Guardar el acordeón abierto
                    if (content.classList.contains('open')) {
                        document.getElementById('<%= hfAccordion.ClientID %>').value = index;
                    } else {
                        document.getElementById('<%= hfAccordion.ClientID %>').value = "";
                    }
                });
            });

            // Restaurar acordeón tras postback
            const openIndex = document.getElementById('<%= hfAccordion.ClientID %>').value;
            if (openIndex !== "") {
                const contents = document.querySelectorAll('.accordion-content');
                contents[openIndex].classList.add('open');
            }

        });
    </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="polizas-container">

        <!-- ======================= REGISTRO ======================= -->
        <div class="accordion-section">
            <div class="accordion-header">Registro de póliza</div>

            <div class="accordion-content">

                <asp:Label ID="lbl_msgRegistro" runat="server" CssClass="msg"></asp:Label>

                <div class="form-grid">

                    <div class="form-group">
                        <label for="txt_numero_poliza">Número de póliza</label>
                        <asp:TextBox ID="txt_numero_poliza" runat="server"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_cliente">Cliente</label>
                        <asp:DropDownList ID="ddl_cliente" runat="server"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="ddl_seguro">Seguro asociado</label>
                        <asp:DropDownList ID="ddl_seguro" runat="server"></asp:DropDownList>
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
                        <label for="txt_motivo_cancelacion">Motivo de cancelación</label>
                        <asp:TextBox ID="txt_motivo_cancelacion" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </div>

                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" OnClick="btn_guardar_Click" />
                    <asp:Button ID="btn_limpiar" runat="server" Text="🧹 Limpiar" CssClass="btn" OnClick="btn_limpiar_Click" />
                </div>

            </div>
        </div>



        <!-- ======================= ADMINISTRACIÓN ======================= -->
        <div class="accordion-section">
            <div class="accordion-header">Administración de pólizas</div>

            <div class="accordion-content">

                <asp:Label ID="lbl_msgAdmin" runat="server" CssClass="msg"></asp:Label>

                <div class="form-group" style="max-width:300px;">
                    <label for="txt_buscarPoliza">Buscar por número de póliza</label>
                    <asp:TextBox ID="txt_buscarPoliza" runat="server"></asp:TextBox>
                </div>

                <div class="btn-group" style="margin-bottom:15px;">
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" OnClick="btn_buscar_Click" />
                    <asp:Button ID="btn_actualizar" runat="server" Text="✏️ Actualizar" CssClass="btn" />
                    <asp:Button ID="btn_cancelar" runat="server" Text="❌ Cancelar póliza" CssClass="btn" OnClick="btn_cancelar_Click" />
                </div>

                <div class="form-grid">

                    <div class="form-group">
                        <label for="txt_numero_admin">Número de póliza</label>
                        <asp:TextBox ID="txt_numero_admin" runat="server" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <label for="ddl_estado_admin">Estado actual</label>
                        <asp:DropDownList ID="ddl_estado_admin" runat="server" Enabled="false">
                            <asp:ListItem Text="Vigente" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Vencida" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Renovación" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Cancelada" Value="3"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <label for="txt_motivo_admin">Motivo cancelación</label>
                        <asp:TextBox ID="txt_motivo_admin" runat="server" TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>

                </div>

            </div>
        </div>



        <!-- ======================= CERTIFICADOS ======================= -->
        <div class="accordion-section">
            <div class="accordion-header">Certificados y documentos</div>

            <div class="accordion-content">

                <asp:Label ID="lbl_msgCertificados" runat="server" CssClass="msg"></asp:Label>

                <div class="form-group" style="max-width:300px;">
                    <label for="txt_certificadoPoliza">Número de póliza</label>
                    <asp:TextBox ID="txt_certificadoPoliza" runat="server"></asp:TextBox>
                </div>

                <div class="btn-group">
                    <asp:Button ID="btn_generarCertificado" runat="server" Text="📄 Generar certificado" CssClass="btn" />
                    <asp:Button ID="btn_exportarPDF" runat="server" Text="⬇️ Exportar PDF" CssClass="btn" />
                </div>

            </div>
        </div>



        <!-- ======================= LISTADO GENERAL ======================= -->
        <div class="accordion-section">
            <div class="accordion-header">Listado general de pólizas</div>

            <div class="accordion-content">

                <asp:Label ID="lbl_msgListado" runat="server" CssClass="msg"></asp:Label>

                <asp:GridView ID="gv_polizas" runat="server" CssClass="gridview"></asp:GridView>

            </div>
        </div>

    </div>
</asp:Content>
