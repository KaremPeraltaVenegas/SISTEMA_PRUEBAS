<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmRptFuerzaLaboral.aspx.vb" Inherits="GTWebOAEL.FrmRptFuerzaLaboral" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">--%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function OnBtnVerReporteClick(s, e) {

            var configTipoReporte = "";
            if (iTipoReporte.GetValue() == '1') {
              
                    configTipoReporte = "FFLL";
              
                //configTipoReporte = "FFLLAA";
            }
            else if (iTipoReporte.GetValue() == '2') {
                configTipoReporte = "HHCC";//FORMATO HHCC DEL PERIODO ACTUAL
            }
            CallBackPanelReport.PerformCallback(configTipoReporte);

            //PopupFormReportes.ShowWindow();
            e.processOnServer = false;
        }

        function OnInit(s, e) {
            s.previewModel.reportPreview.zoom(0.75);          
        }

    </script>
    <style>
        /*.cellTable {
        
        }*/
        #tableGT td {
        padding:2px 8px;
        }
        .dxrd-image-parameters-inactive, .dxrd-image-parameters-active {  
       display: none;  
   }  
    </style>
    <div style="padding:8px 14px;">
        <table id="tableGT">
            <tr>
                <td>
                    <dx:ASPxComboBox ID="iTipoReporte" ClientInstanceName="iTipoReporte" runat="server" ValueType="System.String" Caption="Tipo Reporte" >
                        <Items>                                                                          
                            <dx:ListEditItem Text="FUERZA LABORAL" Value="1" Selected="true" />                                                                        
                            <dx:ListEditItem Text="HEAD COUNT" Value="2" />
                        </Items>
                    </dx:ASPxComboBox>
                </td>
                 <td>

                     <dx:ASPxComboBox ID="iCodContrata" ClientInstanceName="iCodContrata" runat="server" ValueType="System.String" Caption="Contratista">
                        
                    </dx:ASPxComboBox>
                </td>
                

                <td>

                    <dx:ASPxComboBox ID="iPeriodo" ClientInstanceName="iPeriodo" Caption="Periodo"  runat="server" DropDownStyle="DropDown" ValueType="System.String" >
                        <Items>
                            <dx:ListEditItem Text="2020" Value="2020" />
                            <dx:ListEditItem Text="2021" Value="2021" />
                            <dx:ListEditItem Text="2022" Value="2022" />
                             <dx:ListEditItem Text="2023" Value="2023" />
                             <dx:ListEditItem Text="2024" Value="2024" />
                             <dx:ListEditItem Text="2025" Value="2025" />
                             <dx:ListEditItem Text="2026" Value="2026" />
                        </Items>
                    </dx:ASPxComboBox>
                   <%-- <dx:ASPxDateEdit ID="dFechaIni" ClientInstanceName="dFechaIni" runat="server" Caption="Fecha Inicio"></dx:ASPxDateEdit>--%>
                </td>
                <td>
                    <dx:ASPxComboBox ID="iMes" ClientInstanceName="iMes" Caption="Mes"  runat="server" DropDownStyle="DropDown" ValueType="System.String"  >
                        
                        <Items>
                                <dx:ListEditItem Text="ENERO" Value="1" />
                                <dx:ListEditItem Text="FEBRERO" Value="2" />
                                <dx:ListEditItem Text="MARZO" Value="3" />
                                <dx:ListEditItem Text="ABRIL" Value="4" />
                                <dx:ListEditItem Text="MAYO" Value="5" />
                                <dx:ListEditItem Text="JUNIO" Value="6" />
                                <dx:ListEditItem Text="JULIO" Value="7" />
                                <dx:ListEditItem Text="AGOSTO" Value="8" />
                                <dx:ListEditItem Text="SETIEMBRE" Value="9" />
                                <dx:ListEditItem Text="OCTUBRE" Value="10" />
                                <dx:ListEditItem Text="NOVIEMBRE" Value="11" />
                                <dx:ListEditItem Text="DICIEMBRE" Value="12" />
                        </Items>
                    </dx:ASPxComboBox>
                    <%--<dx:ASPxDateEdit ID="dFechaFin" ClientInstanceName="dFechaFin" runat="server" Caption="Fecha Fin"></dx:ASPxDateEdit>--%>
                </td>
                <td>
                    <dx:ASPxButton ID="BtnGenerarReporte" runat="server" Text="Generar Reporte" AutoPostBack="false">
                        <ClientSideEvents Click="OnBtnVerReporteClick" />
                    </dx:ASPxButton>
                </td>
            </tr>
        </table>

    </div>
    <div class="containerReport">
         <div id="mainReportFFLL">
                <dx:ASPxCallbackPanel ID="CallBackPanelReport" ClientInstanceName="CallBackPanelReport" runat="server"  OnCallback="CallBackPanelReport_Callback">  
                    <PanelCollection>  
                        <dx:PanelContent ID="PanelContent1" runat="server">  
                                <div class="containerReport">
                                    <dx:ASPxWebDocumentViewer  Height="390"  ID="WebReportViewer" ClientInstanceName="WebReportViewer" runat="server" DisableHttpHandlerValidation="False">
                                        <ClientSideEvents Init="OnInit" />  
                                                <%--<ClientSideEvents Init="function(s, e) { s.previewModel.reportPreview.zoom(0.75); }"       />--%>  
                                    </dx:ASPxWebDocumentViewer>                                                 
                                </div>
                        </dx:PanelContent>  
                    </PanelCollection>  
                </dx:ASPxCallbackPanel>  
            </div>
    </div>
</asp:Content>
