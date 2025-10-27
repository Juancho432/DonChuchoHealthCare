<%@ Page Title="Inicio - Don Chucho HealthCare" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DonChuchoHealthCare.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* ====== ESTILOS DEL DASHBOARD INICIAL ====== */
        .inicio-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 80vh;
            flex-direction: column;
            text-align: center;
        }

        .inicio-card {
            background-color: #1c2541; /* Fondo oscuro coherente */
            border-radius: 20px;
            padding: 50px 70px;
            box-shadow: 0px 8px 25px rgba(0, 0, 0, 0.4);
            transition: transform 0.3s;
            max-width: 700px;
        }

        .inicio-card:hover {
            transform: scale(1.02);
        }

        h1 {
            color: #5bc0be;
            font-size: 36px;
            margin-bottom: 10px;
        }

        p {
            font-size: 18px;
            color: #dbe4ea;
            margin-bottom: 10px;
        }

        .highlight {
            color: #9cd4d2;
        }
    </style>
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
