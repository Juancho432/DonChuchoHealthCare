<%@ Page Title="Gestión de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="DonChuchoHealthCare.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Clientes.css" rel="stylesheet" />

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
                    <asp:Button ID="btn_guardar" runat="server" Text="💾 Guardar" CssClass="btn" OnClick="btn_guardar_Click" />
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