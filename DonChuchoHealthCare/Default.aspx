<%@ Page Title="Inicio - Don Chucho HealthCare" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DonChuchoHealthCare.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Default.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio-container">
        <div class="inicio-card">
            <h1>Bienvenido a <span class="highlight">Don Chucho HealthCare</span></h1>
            <p>Tu sistema integral para la gestión de seguros médicos, pólizas y pagos.</p>
            <p>Selecciona una opción en el menú lateral para comenzar.</p>
        </div>
    </div>
</asp:Content>
