<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmRptDashboardViewer.aspx.vb" Inherits="GTWebOAEL.FrmRptDashboardViewer" %>

<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" ColorScheme="light.compact" WorkingMode="ViewerOnly" Height="600px"></dx:ASPxDashboard>

</asp:Content>
