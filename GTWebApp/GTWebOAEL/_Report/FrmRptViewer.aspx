<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FrmRptViewer.aspx.vb" Inherits="GTWebOAEL.FrmRptViewer" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div class="containerReport">
        <dx:ASPxWebDocumentViewer ID="WebReportViewer" runat="server" DisableHttpHandlerValidation="False">
         
        </dx:ASPxWebDocumentViewer>
    </div>
       
    </form>
</body>
</html>
