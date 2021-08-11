<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportProducido.ascx.cs" Inherits="AppWebHojaCosto.Views.Reportes.ReportProducido" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=14.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<h1>Holis</h1>

<form id="formCustomerReport" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:reportviewer id="reporte" runat="server" ProcessingMode="Remote" ShowCredentialPrompts="False" width="100%"></rsweb:reportviewer>  
    </div>
</form>