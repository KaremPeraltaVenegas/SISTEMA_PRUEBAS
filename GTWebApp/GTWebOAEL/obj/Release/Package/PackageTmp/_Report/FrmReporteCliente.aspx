<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmReporteCliente.aspx.vb" Inherits="GTWebOAEL.FrmReporteCliente" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>

    <script type="text/javascript"> 
        function OnBtnVerReporteClick(s, e) {
          
            TablaRegistros.PerformCallback();
          
        }
        function OnBtnExportarXlsx_Click(s, e) {
            BtnExportarXlsx.SetEnabled(false);
            BtnExportarXlsx.SetText('Procesando');
             TablaRegistros.ExportTo(ASPxClientGridViewExportFormat.Xlsx);
             BtnExportarXlsx.SetEnabled(true);
            BtnExportarXlsx.SetText('Exportar Reporte');
        }
        document.addEventListener('DOMContentLoaded', function () {
            //var cell = document.getElementById('celdaFechaInicio');
            //if (cell) {
            //    cell.style.display = 'none';
            //}
            //var cell2 = document.getElementById('celdaFechaFin');
            //if (cell2) {
            //    cell2.style.display = 'none';
            //}
            dFechaInicio.SetEnabled(false);
            dFechaFin.SetEnabled(false);
        });
        function iCodReporteCatalogo_SelectedIndexChanged(s, e) {

            var item = s.GetSelectedItem();
            if (item.GetColumnText(0) == 'True') { //requiere fecha
                //var cell = document.getElementById('celdaFechaInicio');
                //cell.style.display = '';
                //var cell2 = document.getElementById('celdaFechaFin');
                //cell2.style.display = '';
                
                dFechaInicio.SetEnabled(true);
                dFechaFin.SetEnabled(true);
            }
            else {
                //var cell = document.getElementById('celdaFechaInicio');
                //cell.style.display = 'none';
                //var cell2 = document.getElementById('celdaFechaFin');
                //cell2.style.display = 'none';
                
                dFechaInicio.SetEnabled(false);
                dFechaFin.SetEnabled(false);
            }

        }

    </script>

    <style>
        #tableGT td {
            padding: 2px 8px;
        }

        .dxrd-image-parameters-inactive, .dxrd-image-parameters-active {
            display: none;
        }

        .control-cell {
            /*width: 20%;*/ /* Ajustar el ancho de las celdas de control */
        }

        .custom-combobox {
            /*width: 200%;*/ /* O ajustar a un porcentaje específico */
            /*max-width: 400px;*/ /* Máxima anchura si lo deseas */
        }

        .dxmLite_Office365 .dxctToolbar_Office365.dxm-main.dxmtb {
        padding-top: 8px;
  padding-bottom: 8px;
        }

        .divResponsive {
        float :left;
        padding:0px 8px;
        margin:4px 2px;
        }
          .divResponsiveFooter {
        float :left;
        padding:0px 8px;
        display:block;
        width:auto;
        }
    </style>
    <div style="padding: 8px 14px;">
        <%--   <dx:ASPxHiddenField ID="cFormMetadta" runat="server" ClientInstanceName="cFormMetadata">
        </dx:ASPxHiddenField>--%>
       <%-- <table id="tableGT">
    <tr>
        <td>
            <dx:ASPxComboBox ID="iCodReporteCatalogo" runat="server" CssClass="custom-combobox" Width="400"
                ValueField="iCodReporteCatalogo" ValueType="System.String" TextFormatString="{1}" ClientInstanceName="cOcupacion"
                Caption="Reporte">
                <ClientSideEvents SelectedIndexChanged="iCodReporteCatalogo_SelectedIndexChanged"></ClientSideEvents>
                <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                    <RequiredField IsRequired="True"></RequiredField>
                </ValidationSettings>
                <Columns>
                    <dx:ListBoxColumn Caption="cQueryReporte" FieldName="cQueryReporte" Visible="false" Width="1%" />
                    <dx:ListBoxColumn Caption="Fecha" FieldName="bFiltroFecha" Width="0%" />
                    <dx:ListBoxColumn Caption="Reporte" FieldName="cNombreReporte" Width="100%" />
                </Columns>
            </dx:ASPxComboBox>
        </td>
        <td>
            <dx:ASPxDateEdit ID="dFechaInicio" ClientInstanceName="dFechaInicio" runat="server" AutoPostBack="false" UseMaskBehavior="False" Width="120"
                CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False"
                Caption="Fecha de Inicio">
                <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
            </dx:ASPxDateEdit>
        </td>
        <td>
            <dx:ASPxDateEdit ID="dFechaFin" ClientInstanceName="dFechaFin" runat="server" AutoPostBack="false" UseMaskBehavior="False" Width="120" Caption="Fecha de Fin"
                CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
            </dx:ASPxDateEdit>
        </td>
        <td>
            <dx:ASPxButton ID="BtnVerReporte" runat="server" Text="Ver Reporte"  ClientInstanceName="BtnVerReporte" AutoPostBack="false">
                <ClientSideEvents Click="OnBtnVerReporteClick" />
            </dx:ASPxButton>
        </td>
    </tr>
</table>--%>

      <div id="FormCatalogoReporte">
          <div class="divResponsive" >
            <dx:ASPxComboBox ID="iCodReporteCatalogo" runat="server" CssClass="custom-combobox" Width="400"  Font-Size="Small"
                ValueField="iCodReporteCatalogo" ValueType="System.String" TextFormatString="{1}" ClientInstanceName="cOcupacion"
                Caption="Reporte">
                <ClientSideEvents SelectedIndexChanged="iCodReporteCatalogo_SelectedIndexChanged"></ClientSideEvents>
                <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                    <RequiredField IsRequired="True"></RequiredField>
                </ValidationSettings>
                <Columns>
                    <dx:ListBoxColumn Caption="cQueryReporte" FieldName="cQueryReporte" Visible="false" Width="1%" />
                    <dx:ListBoxColumn Caption="Fecha" FieldName="bFiltroFecha" Width="0%" />
                    <dx:ListBoxColumn Caption="Reporte" FieldName="cNombreReporte" Width="100%" />
                </Columns>
            </dx:ASPxComboBox>
              
       </div >
          <div  class="divResponsive" >
            <dx:ASPxDateEdit ID="dFechaInicio" ClientInstanceName="dFechaInicio" runat="server" AutoPostBack="false" UseMaskBehavior="False" Width="120"  Font-Size="Small"   DisabledStyle-BackColor="WhiteSmoke" 
                CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False"
                Caption="Fecha de Inicio">
                <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
            </dx:ASPxDateEdit>
       </div>
           <div class="divResponsive" >
            <dx:ASPxDateEdit ID="dFechaFin" ClientInstanceName="dFechaFin" runat="server" AutoPostBack="false" UseMaskBehavior="False" Width="120" Caption="Fecha de Fin"  Font-Size="Small" DisabledStyle-BackColor="WhiteSmoke"
                CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
            </dx:ASPxDateEdit>
                </div>
            <div>
            <dx:ASPxButton ID="BtnVerReporte" runat="server" Text="Ver Reporte"  ClientInstanceName="BtnVerReporte" AutoPostBack="false" Font-Size="Small">
                <ClientSideEvents Click="OnBtnVerReporteClick" />
            </dx:ASPxButton>
            </div>
        </div>
        <div class="containerReport">
            <div id="mainReportFFLL">
                <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros" Font-Size="X-Small"    >
                    <SettingsPager EnableAdaptivity="True" PageSize="40" AlwaysShowPager="True">
                    </SettingsPager>
                    <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="285"></Settings>
                    
                    <SettingsBehavior AllowFocusedRow="False" />
                    <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                    <Settings ShowVerticalScrollBar="True" />
                    <SettingsSearchPanel CustomEditorID="tbToolbarSearch"  />
                    <SettingsExport EnableClientSideExportAPI="true"   ExcelExportMode="WYSIWYG"  />

                    <Templates>  
                        <PagerBar>  
                            <div class="divResponsiveFooter">
                                <div class="divResponsiveFooter">
                                  <dx:ASPxButton ID="BtnExportarXlsx" runat="server" Text="Exportar Reporte"  ClientInstanceName="BtnExportarXlsx" AutoPostBack="false" Font-Size="Small">
                <ClientSideEvents Click="OnBtnExportarXlsx_Click"/>
            </dx:ASPxButton>
                                    </div>
                                <div style="float:left;">
                              <dx:ASPxButtonEdit ID="tbToolbarSearch" runat="server" NullText="Buscar Datos..." Height="100%">
                                            <Buttons>
                                                <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                            </Buttons>
                                        </dx:ASPxButtonEdit>
                                </div>
                            </div>
                            <div  class="divResponsiveFooter">
                            <dx:ASPxGridViewTemplateReplacement ID="ASPxGridViewTemplateReplacement" runat="server" ReplacementType="Pager"  />  
                            </div>
                             
                        </PagerBar>  
                    </Templates>  

                     


                </dx:ASPxGridView>
            </div>
        </div>
    </div>


</asp:Content>
