<%@ Page Title="Gestión de Seguros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Seguros.aspx.cs" Inherits="DonChuchoHealthCare.Seguros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Seguros.css" rel="stylesheet" />

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
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" OnClick="btn_guardar_Click" />
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
                    <asp:Button ID="btn_buscar" runat="server" Text="🔍 Buscar" CssClass="btn" OnClick="btn_buscar_Click" />
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