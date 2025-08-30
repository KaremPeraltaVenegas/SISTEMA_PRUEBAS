<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmFuerzaLaboral.aspx.vb" Inherits="GTWebOAEL.FrmFuerzaLaboral" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%--<script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js" ></script>--%>
  <script type="text/javascript" src="../_GTJScript/Fuerzalaboral.js" ></script> 
  <%--MODIFICAR--%>
    <%--<script type="text/javascript" src="../_GTJScript/Fuerzalaboraldetalle.js" ></script>--%> <%--MODIFICAR--%>
  <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js" ></script>  <%--MODIFICAR--%>
  <script type="text/javascript" src="../_GTJScript/_GTMainCore.js" ></script>  
  <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js" ></script>  <%--MODIFICAR--%>
     <script type="text/javascript" >

         //FUNCIONES ALTERNAS  DEL MAIN

         var cNomContratoPeriodo;
         function OnToolbarItemClickMain(s, e) {

             if (IsCustomExportToolbarCommand(e.item.name)) {
                 e.processOnServer = true;
                 e.usePostBack = true;
             }

             if (e.item.name == "BtnAgregar") {
               
                 iCodRegistro.SetText("0");

                
                 cFormMetadata.Set("cTipoOpe", "A");
                 ClearContentControls();
                 FormMainModalShow();
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEditar") {
                 cFormMetadata.Set("cTipoOpe", "M");
                 iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                 ClearContentControls();
                 viewRecord();
                 FormMainModalShow();
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnGestionarFFLL") {
                 var popupWindow = PopupFormFFLLDetalle.GetWindow(0);               
                 //popupWindow.SetHeaderText(cNomContratoPeriodo);
                 TablaRegistrosDetalle.PerformCallback('load');
                 PopupFormFFLLDetalle.ShowWindow(popupWindow);
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnRptPGSDashboard") {
                
                 CallBackPanelDashboard.PerformCallback('');

                 PopupFormDashboard.ShowWindow();
                 e.processOnServer = false;
             }
         }

         function OnGridFocusedRowChangedFFLL(s, e) {
             //alert("ingreso");
             //iCodRegistroDetalle.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
             iCodRegistro.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
             //alert(iCodRegistroDetalle.GetValue());
             s.GetRowValues(s.GetFocusedRowIndex(), 'cMes;cNroContrato', OnGetRowValueNroContrato);
             e.processOnServer = false;
         }
         function OnGetRowValueNroContrato(value) {

             cNomContratoPeriodo = value[0] + ' :: ' + value[1];
             //alert(cNomContratoPeriodo);
             var popupWindow = PopupFormFFLLDetalle.GetWindow(0);
             popupWindow.SetHeaderText(cNomContratoPeriodo);

         }
         // ************* FUNCTIONS MAIN



         // ************* FUNCTIONS CUSTOM 
         var iCommandDetalle = 0;
         var msgDetalle = "";
         function OnToolbarItemClickFFLLDetalle(s, e) {

             if (e.item.name == "BtnAgregarDetalle") {
                 var pContrata = (cFormMetadata.Get('iCodSubContrata'));
                 iCodSubContrata.SetValue(pContrata);
                 iCommandDetalle = 1;
                 msgDetalle = "El registro se guardó con éxito";
                 iCodRegistroDetalle.SetText("0");
                 cFormMetadata.Set("cTipoOpeDetalle", "A");
                 ClearContentControlsDetalle();
                 iCodCandidatoInforme.SetText("");
                 cTipoDoc.SetSelectedIndex(0);

                 $("#oaelCondicion").html("Condici&oacute;n : <b></b>");
                 $("#oaelExpediente").html("Expediente : <b></b>");
                 $("#oaelFFLL").html("Fuerza Laboral : <b></b>");
                 $("#oaelEmpresa").html("Empresa : <b></b>");


                 FormMainModalShowDetalle();
                 e.processOnServer = false;


             }
             else if (e.item.name == "BtnEditarDetalle") {
                 iCommandDetalle = 2;
                 msgDetalle = "El registro se actualizó con éxito";
                 cFormMetadata.Set("cTipoOpeDetalle", "M");
                 iCodRegistroDetalle.SetText(TablaRegistrosDetalle.GetRowKey(TablaRegistrosDetalle.GetFocusedRowIndex()));

                 $("#oaelCondicion").html("Condici&oacute;n : <b></b>");
                 $("#oaelExpediente").html("Expediente : <b></b>");
                 $("#oaelFFLL").html("Fuerza Laboral : <b></b>");
                 $("#oaelEmpresa").html("Empresa : <b></b>");


                 if (iCodRegistroDetalle.GetValue() != null) {
                     ClearContentControlsDetalle();
                     viewRecordDetalle();
                     FormMainModalShowDetalle();
                 }

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEliminarDetalle") {
                 iCommandDetalle = 3;
                 msgDetalle = "El registro se borró con éxito";
                 var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
                 PopupConfirmDeleteDetalle.ShowWindow(popupWindow);

                 e.processOnServer = false;
             }
            
             else if (e.item.name == "BtnPersonaCesar") {
                 iCommandDetalle = 4;
                 msgDetalle = "Se guardo la información correctamente.";
                 iCodRegistroDetalle.SetText(TablaRegistrosDetalle.GetRowKey(TablaRegistrosDetalle.GetFocusedRowIndex()));
                 if (iCodRegistroDetalle.GetValue() != null) {
                     ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopupCese.GetMainElement());
                     viewRecordDetalleCese();
                     var popupWindow = PopupFormCese.GetWindow(0);
                     PopupFormCese.ShowWindow(popupWindow);
                 }
                
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnPersonaCesarImportar") {
                 iCommandDetalle = 5;

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnCerrarPeriodo") {
                 iCommandDetalle = 6;
                 msgDetalle = "Se cerró el periodo correctamente.";
                 var popupWindow = PopupConfirmarCierreFFLL.GetWindow(0);
                 PopupConfirmarCierreFFLL.ShowWindow(popupWindow);
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnPersonaConsentimiento") {
                 iCommandDetalle =7;

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnFFLLReportes") {
                 iCommandDetalle = 8;
                
                 //CallBackPanelReport.PerformCallback("HHCC");
                 //PopupFormReportes.ShowWindow();
                 var popupWindow = PopupFormReportesConfig.GetWindow(0);
                 PopupFormReportesConfig.ShowWindow(popupWindow);

                 e.processOnServer = false;
             }
         }

         function OnGridFocusedRowChangedDetalleFFLL(s, e) {
             iCodRegistroDetalle.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
             //alert(iCodRegistroDetalle.GetValue());
             //s.GetRowValues(s.GetFocusedRowIndex(), 'iCodPerfilPuesto;cNomCortoPerfilPuesto', OnGetRowValuePerfilPuesto);
             e.processOnServer = false;
         }
         //function OnGetRowValuePerfilPuesto(value) {

         //    //alert(value[0]);
         //    iCodPerfilPuestoRequerido.SetText(value[0]);
         //    cFormMetadata.Set("pNombrePerfil", value[1]);

         //}
         function OnEndCallBackFunctionDetalleFFLL(s, e) {

             if (e.result == 'OK') {
                 if (iCommandDetalle == 1 || iCommandDetalle == 2) {

                     CloseFormMainModalDetalle();

                     TablaRegistrosDetalle.PerformCallback('load');

                 }
               
                 if (iCommandDetalle == 4) {

                     var popupWindow = PopupFormCese.GetWindow(0);
                     PopupFormCese.HideWindow(popupWindow);
                     TablaRegistrosDetalle.PerformCallback('load');

                 }

                 ShowAlertMessage(msgDetalle);

             }
             else {
                 ShowAlertMessage('Ocurrió un error durante la transacción.');
             }
         }


         function cOcupacion_SelectedIndexChanged(s, e) {
              
             var item = s.GetSelectedItem();
             cMOCMONC.SetValue(item.GetColumnText(0));
         }
       
         function cDNI_KeyPress(s, e) {
             if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122))
             { return true; }
             else {
                 ASPxClientUtils.PreventEvent(e.htmlEvent);
             }
             if (e.htmlEvent.keyCode == 13) {
                 s.Validate();
                 if (s.isValid) {
                     viewRecordCI();
                 }
             }
         }

         function cDNI_Validation(s, e) {
             var eText = s.GetText();
             if ((eText.length < 8) || (eText.length > 15)) {

                 e.isValid = false;
             }
             else {
                 e.isValid = true;
             }
         }
        function cDNI_OnButtonClick(s, e) {
            s.Validate();
            if (s.isValid) {
                viewRecordCI();
            }
        }

       
         function OnBtnGuardarFormCeseClick(s, e) {
             if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopupCese.GetMainElement(), null, true)) {
                 CallBackFunctionDetalle.PerformCallback('PersonaCesar');

                 e.processOnServer = false;
             }
             else {
                 e.processOnServer = false;
             }
         }
         function OnBtnCerrarFormCeseClick(s, e) {
             var popupWindow = PopupFormCese.GetWindow(0);
             PopupFormCese.HideWindow(popupWindow);
             e.processOnServer = false;
         }
         function ClearContentControlsDetalleCese() {
             ASPxClientEdit.ClearEditorsInContainer(FormLayoutPopupCese.GetMainElement());
         }
         //IMPRESIONES
         function iTipoReporte_SelectedIndexChanged(s, e) {
             //EditKmReason.PerformCallback(s.GetValue());         
             var item = s.GetSelectedItem();
             if (s.GetValue() == '1') { //FUERZA LABORAL                
                 FormLayoutPopupReportesConfig.GetItemByName('GrupoFFLLConfig').SetVisible(true);
             }
             else if (s.GetValue() == '2') {
                 FormLayoutPopupReportesConfig.GetItemByName('GrupoFFLLConfig').SetVisible(false);
             }

         }
         function OnBtnVerReporteClick(s, e) {
            
             var configTipoReporte = "";
             if (iTipoReporte.GetValue() == '1')
             {
                 if (bCesadosIncluir.GetValue() == true) {
                     configTipoReporte = "FFLLAC";
                 }
                 else {
                     configTipoReporte = "FFLLAA";
                 }
                 //configTipoReporte = "FFLLAA";
             }
             else if (iTipoReporte.GetValue() == '2') {
                 configTipoReporte = "HHCC";//FORMATO HHCC DEL PERIODO ACTUAL
             }
             CallBackPanelReport.PerformCallback(configTipoReporte);

             PopupFormReportes.ShowWindow();
             e.processOnServer = false;
         }
         function OnBtnCerrarReporteConfigClick(s, e) {
             //var popupWindow = PopupFormCese.GetWindow(0);
             //PopupFormCese.HideWindow(popupWindow);
             e.processOnServer = false;
         }

         function OnInit(s, e) {
             s.previewModel.reportPreview.zoom(0.75);
         }

         function OnBtnConfirmarCerrarPeriodoClick(s, e) {
             CallBackFunctionDetalle.PerformCallback('FFLLCerrar');
             e.processOnServer = false;
         }
          
         function OnBtnCancelarCerrarPeriodoClick(s, e) {
             var popupWindow = PopupConfirmarCierreFFLL.GetWindow(0);
             PopupConfirmarCierreFFLL.HideWindow(popupWindow);
             e.processOnServer = false;
         }
          
     </script>
    <style>
       
        .dxrd-image-parameters-inactive, .dxrd-image-parameters-active {  
       display: none;  
   }
        .gtButtonFontSmall {
        font-size:0.85em;
        }
   
 
         .dxgvHeader_Office365.HeaderColTiny {
         padding-top:6px;
         padding-bottom:6px;
         }
         .dxgvHeader_Office365.HeaderColTinyColor1 {
         padding-top:6px;
         padding-bottom:6px;
         background:#efece7;
         }
         /*#f2f0ec;*/
          .dxgvHeader_Office365.HeaderColTinyColor2 {
         padding-top:6px;
         padding-bottom:6px;
         background:#f9f8f5;
         }
    </style>
    <%-- ***************************** INI SECCION DATATABLE ***************************** --%>
      <div id="ContentTablaRegistros" style="padding:0px 15px 0px 15px;">
          <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
              <ClientSideEvents CallbackComplete="OnEndCallBackFunction" />
          </dx:ASPxCallback>
          <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True" 
            ClientVisible="False" ClientInstanceName="iCodRegistro">
          </dx:ASPxTextBox>
          <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
          </dx:ASPxHiddenField>
          <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros"  >
              <ClientSideEvents ToolbarItemClick="OnToolbarItemClickMain"   FocusedRowChanged="OnGridFocusedRowChangedFFLL" 
                >
              </ClientSideEvents>
              <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
              </SettingsPager>
              <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="242"></Settings>

              <SettingsBehavior AllowFocusedRow="True"  />
              <SettingsDataSecurity AllowDelete="False">
              </SettingsDataSecurity>
              <Settings ShowVerticalScrollBar="True" /> 
              <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
              <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
              <Toolbars>
                  <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                      <Items>
                          <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                              <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
                              <Template>
                                  <div id="gtHeadTitle" style=""> <%--***  MODIFICAR ***--%>
                                      FUERZA LABORAL
                                  </div>

                              </Template>

                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">  
                                <Template>  
                                    <div id="div100Percent"></div>  
                                </Template>  
                            </dx:GridViewToolbarItem>  
                          <dx:GridViewToolbarItem Text="Agregar" Name="BtnAgregar">
                              <Image IconID="actions_new_16x16office2013">
                              </Image>
                          </dx:GridViewToolbarItem>
                        <%--  <dx:GridViewToolbarItem Text="Editar" Name="BtnEditar">
                              <Image IconID="actions_edit_16x16devav">
                              </Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar" ClientEnabled="false" >
                              <Image IconID="edit_delete_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>--%>

                         

                          <dx:GridViewToolbarItem Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1" Name="BtnGestionarFFLL" Text="Gestionar FFLL">
                              <Image IconID="people_publicfix_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>
                       
                     <%--   <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="2" Text="PGS Status">
                        <Items>                                 
                            <dx:GridViewToolbarItem Name="BtnRptPGSResumen" Text="Reporte Resumen PGS">
                                <Image IconID="scheduling_today_16x16office2013"></Image>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Name="BtnRptPGSDashboard" Text="Dashboard Resumen PGS">
                                <Image IconID="chart_piestylepie_16x16office2013"></Image>
                            </dx:GridViewToolbarItem>
                        </Items>
                        <Image IconID="chart_chart_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>--%>


                          <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right">
                              <Template>
                                  <dx:ASPxButtonEdit ID="tbToolbarSearch" runat="server" NullText="Buscar..." Height="100%">
                                      <Buttons>
                                          <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                      </Buttons>
                                  </dx:ASPxButtonEdit>


                              </Template>
                          </dx:GridViewToolbarItem>
                      </Items>
                  </dx:GridViewToolbar>
              </Toolbars>

               <Columns>
                     <dx:GridViewDataTextColumn FieldName="iCodFuerzaLaboral" Visible="false"  VisibleIndex="0" Caption="ID">
					</dx:GridViewDataTextColumn>
                 <%-- <dx:GridViewDataTextColumn FieldName="iRespuestaNO" VisibleIndex="1" Caption="-" Width="40" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
						<DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="FeedBackStatus" OnInit="FeedBackStatus_Init" ></dx:ASPxImage>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>  --%>
                   <dx:GridViewDataTextColumn FieldName="cMes" Visible="true"  VisibleIndex="2" Caption="Mes" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroContrato" Visible="true"  VisibleIndex="3" Caption="Nro Contrato" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
					</dx:GridViewDataTextColumn>
         

                   <dx:GridViewBandColumn Caption="MOC" VisibleIndex="4" HeaderStyle-CssClass="HeaderColTinyColor1" >
                   <Columns>
                        <dx:GridViewDataSpinEditColumn  FieldName="nFLMOCLocal" Visible="true"  VisibleIndex="1" Caption="Local" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" HeaderStyle-CssClass="HeaderColTinyColor1">
					    <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="nFLMOCForaneo" Visible="true"  VisibleIndex="2" Caption="Foráneo" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="HeaderColTinyColor1" >
					     <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>

                        <dx:GridViewDataSpinEditColumn FieldName="nTasaMOCLocal" Visible="true"  VisibleIndex="2" Caption="% PGS" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="HeaderColTinyColor1" CellStyle-Font-Bold="true" >
					     <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>

                   <dx:GridViewBandColumn Caption="MONC" VisibleIndex="5" HeaderStyle-CssClass="HeaderColTinyColor2" >
                   <Columns>
                        <dx:GridViewDataSpinEditColumn FieldName="nFLMONCLocal" Visible="true"  VisibleIndex="1" Caption="Local" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" HeaderStyle-CssClass="HeaderColTinyColor2">
					     <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="nFLMONCForaneo" Visible="true"  VisibleIndex="2" Caption="Foráneo" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="HeaderColTinyColor2" >
					     <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>
                        <dx:GridViewDataSpinEditColumn FieldName="nTasaMONCLocal" Visible="true"  VisibleIndex="2" Caption="% PGS" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="HeaderColTinyColor2"  CellStyle-Font-Bold="true" >
					     <PropertiesSpinEdit DisplayFormatString="p2" />
                        </dx:GridViewDataSpinEditColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>

                    <dx:GridViewDataTextColumn FieldName="iCodEstado" Visible="false"  VisibleIndex="7" Caption="SIN Rpta."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="iPeriodo" Visible="false"  VisibleIndex="8" Caption="CON Rpta."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="iMes" Visible="false"  VisibleIndex="9"   Caption="# Cuest."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                  <%-- <dx:GridViewDataHyperLinkColumn FieldName="cRutaDifusion" VisibleIndex="10" Caption="One Drive" Width="80" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >  
                       <PropertiesHyperLinkEdit  ImageUrl="../_GTContent/icons/Click-cloud-icon.png" Target="_blank"></PropertiesHyperLinkEdit>  
                    </dx:GridViewDataHyperLinkColumn>  --%>
            </Columns>
               <FormatConditions>
          
               <dx:GridViewFormatConditionHighlight FieldName="nFLMOCLocal" Expression="[nFLMOCLocal] < [nTasaMOCLocal]" Format="LightRedFillWithDarkRedText"/>
                <dx:GridViewFormatConditionHighlight FieldName="nFLMOCLocal" Expression="[nFLMOCLocal] >= [nTasaMOCLocal]" Format="GreenFillWithDarkGreenText"/>
                   <dx:GridViewFormatConditionHighlight FieldName="nFLMOCLocal" Expression="([nFLMOCLocal] + [nFLMOCForaneo])<=0" Format="GreenFillWithDarkGreenText"/>

                   <dx:GridViewFormatConditionHighlight FieldName="nFLMONCLocal" Expression="[nFLMONCLocal] < [nTasaMONCLocal]" Format="LightRedFillWithDarkRedText"/>
                    <dx:GridViewFormatConditionHighlight FieldName="nFLMONCLocal" Expression="[nFLMONCLocal] >= [nTasaMONCLocal]" Format="GreenFillWithDarkGreenText"/>
                   <dx:GridViewFormatConditionHighlight FieldName="nFLMONCLocal" Expression="([nFLMONCLocal] + [nFLMONCForaneo])<=0" Format="GreenFillWithDarkGreenText"/>
            </FormatConditions>
          </dx:ASPxGridView>
      </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>

    <%-- ***************************** SECCION POPUPS ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli" 
        PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="660px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="660px" MaxHeight="640px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutGroup ColCount="1"  GroupBoxDecoration="Box" UseDefaultPaddings="false" Caption="">
                                          <Items>
                                          <%--***  INI FORMULARIO ***--%>
												
												
												 
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Contrato">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 <dx:ASPxComboBox ID="iCodContratistaContrato" runat="server"  ClientInstanceName="iCodContratistaContrato">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Periodo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxComboBox ID="iPeriodo" ClientInstanceName="iPeriodo"  runat="server" DropDownStyle="DropDown" ValueType="System.String">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                    <Items>
                                                                         <dx:ListEditItem Text="2020" Value="2020" />
                                                                        <dx:ListEditItem Text="2021" Value="2021" />
                                                                        <dx:ListEditItem Text="2022" Value="2022" />
                                                                        <dx:ListEditItem Text="2023" Value="2023" />
                                                                         <dx:ListEditItem Text="2024" Value="2024" />
                                                                         <dx:ListEditItem Text="2025" Value="2025" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Mes">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															 

                                                                 <dx:ASPxComboBox ID="iMes" ClientInstanceName="iMes"  runat="server" DropDownStyle="DropDown" ValueType="System.String">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
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

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 
											
																	

										
                                              <%--***  FIN FORMULARIO ***--%>


                                              <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                          <table style="margin-top:12px!important;">
                                                              <tr>
                                                                  <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardar" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnGuardarClick" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false"   EnableClientSideAPI="True">
                                                                          <ClientSideEvents Click="CloseFormMainModal">
                                                                          </ClientSideEvents>
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                              </tr>
                                                          </table>
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>
                                          </Items>
                                      </dx:LayoutGroup>
                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
          <ContentCollection>
              <dx:PopupControlContentControl runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>
          <ClientSideEvents Closing="function(s, e) {
	ClearContentControls();
}">
          </ClientSideEvents>
      </dx:ASPxPopupControl>
      <dx:ASPxPopupControl ID="PopupConfirmDelete" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDelete"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                  <ContentCollection>
                      <dx:PopupControlContentControl runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutConfirmDelete" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopup" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="LblDeleteConfirm" runat="server" Text="¿ Seguro de borrar el registro seleccionado. ?">
                                                  </dx:ASPxLabel>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                      <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <table style="margin-top:12px!important;">
                                                      <tr>
                                                          <td style="padding-right: 10px;">
                                                              <dx:ASPxButton ID="BtnDeleteConfirm" runat="server" Text="Si" Width="60"   ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="DeleteRecord" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                          <td>
                                                              <dx:ASPxButton ID="BtnDeleteCancel" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancel" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="CloseFormConfirmDelete">
                                                                  </ClientSideEvents>
                                                              </dx:ASPxButton>
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
      </dx:ASPxPopupControl>
        <%--******** POPUP NOTIFICATIONS **********************************************************--%>
      <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server"  ClientInstanceName="PopupAlertMessage"
         Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" 
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje" >
                 <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content" >
                         
                      </dx:PopupControlContentControl>
                  </ContentCollection>               
      </dx:ASPxPopupControl>
  

       <%-- ***************************** SECCION POPUPS LISTADO DE PERSONAS ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormFFLLDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormFFLLDetalle" 
        PopupElementID="PopupFormFFLLDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1240" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Fuerza Laboral :: Listado" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="gtFormArea">
                              
                                            <div id="ContentTablaRegistroDetalle" class="ContentTablaRegistroCustom" style="padding:0px 0px 0px 0px;">
                                                <dx:ASPxCallback ID="CallBackFunctionDetalle" runat="server" ClientInstanceName="CallBackFunctionDetalle">
                                                    <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalleFFLL" />
                                                </dx:ASPxCallback>
                                                <dx:ASPxTextBox ID="iCodRegistroDetalle" runat="server" Width="170px" Height="1px" Visible="True" 
                                                        ClientVisible="False" ClientInstanceName="iCodRegistroDetalle">
                                                        </dx:ASPxTextBox>
                                                <dx:ASPxGridView ID="TablaRegistrosDetalle" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosDetalle"  >
                                                    <ClientSideEvents ToolbarItemClick="OnToolbarItemClickFFLLDetalle"   FocusedRowChanged="OnGridFocusedRowChangedDetalle" 
                                                            >
                                                    </ClientSideEvents>
                                                    <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                                                    </SettingsPager>
                                                    <Settings  ShowVerticalScrollBar="True" VerticalScrollableHeight="360">
                                                    </Settings>
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsDataSecurity AllowDelete="False">
                                                    </SettingsDataSecurity>
                                                    <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%><%--<SettingsPopup>
                                                                <HeaderFilter Height="200">
                                                                    <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                                                                </HeaderFilter>
                                                            </SettingsPopup>--%>
                                                    <SettingsSearchPanel CustomEditorID="tbToolbarSearchFFLLDetalle" />
                                                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                    <Toolbars>
                                                        <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Left">
                                                            <Items>
                                                                             
                                                                <dx:GridViewToolbarItem Text="" Name="BtnAgregarDetalle" DisplayMode="Image" ToolTip="Agregar Colaborador">
                                                                    <Image IconID="actions_newemployee_16x16devav">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>
                                                                <dx:GridViewToolbarItem Text="" Name="BtnEditarDetalle" DisplayMode="Image" ToolTip="Modificar Datos">
                                                                    <Image IconID="actions_edit_16x16devav">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>
                                                                <dx:GridViewToolbarItem Text="" Name="BtnEliminarDetalle" DisplayMode="Image" ToolTip="Quitar de Lista">
                                                                    <Image IconID="edit_delete_16x16office2013">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>

                                                                <dx:GridViewToolbarItem Name="BtnPersonaCesar" Text="" BeginGroup="true" ToolTip="Cesar a Persona Seleccionada">
                                                                    <Image IconID="people_mrs_16x16devav">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>
                                                                <%-- <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" Name="BtnPersonaCesarImportar" Text="" ToolTip="Importar Lista de Cesados">
                                                                    <Image IconID="reports_none_16x16office2013">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>--%>

                                                                 <dx:GridViewToolbarItem DisplayMode="ImageWithText" Name="BtnCerrarPeriodo" BeginGroup="true"  Text="Cerrar Periodo" ToolTip="Horas Hombre" ItemStyle-CssClass="gtButtonFontSmall">
                                                                    <Image IconID="people_employeewelcome_16x16devav"  ></Image>

                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </dx:GridViewToolbarItem>

                                                            <%--  <dx:GridViewToolbarItem DisplayMode="Image" Name="BtnPersonaConsentimiento" Text="" ToolTip="Consentimiento">
                                                                    <Image IconID="tasks_newtask_16x16office2013"></Image>

                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </dx:GridViewToolbarItem>--%>

                                                                <dx:GridViewToolbarItem DisplayMode="Image" Name="BtnFFLLReportes" Text="" BeginGroup="True" ToolTip="Reportes Fuerza Laboral">
                                                                    <Image IconID="actions_printpreview_16x16devav"></Image>

                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                </dx:GridViewToolbarItem>
                                                            <%--  <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1"  Text="">
                                                                    <Items>
                                                                        <dx:GridViewToolbarItem Command="ExportToPdf"></dx:GridViewToolbarItem>
                                                                        <dx:GridViewToolbarItem Command="ExportToDocx"></dx:GridViewToolbarItem>
                                                                                    
                                                                        <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export to XLSX"></dx:GridViewToolbarItem>
                                                                                    
                                                                    </Items>

                                                                    <Image IconID="actions_download_16x16office2013"></Image>

                                                                </dx:GridViewToolbarItem>--%>

                                                                <dx:GridViewToolbarItem BeginGroup="true" >
                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    <Template>
                                                                        <dx:ASPxButtonEdit ID="tbToolbarSearchFFLLDetalle" runat="server" NullText="Buscar..." Height="100%">
                                                                            <Buttons>
                                                                                <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                                                            </Buttons>
                                                                        </dx:ASPxButtonEdit>

                                                                    </Template>
                                                                </dx:GridViewToolbarItem>
                                                            </Items>
                                                        </dx:GridViewToolbar>
                                                    </Toolbars>


                                   <Columns>
                                         <dx:GridViewDataTextColumn FieldName="iCodFuerzaLaboralDetalle" Visible="false"  VisibleIndex="0">
					                    </dx:GridViewDataTextColumn>
                                      
                                      <%-- <dx:GridViewDataTextColumn FieldName="cPerfil" Visible="true"  VisibleIndex="2" Caption="Tipo">
					                    </dx:GridViewDataTextColumn>--%>
                                        
                                        <dx:GridViewDataCheckColumn FieldName="bActivo" Visible="true"  VisibleIndex="1" Caption="Act" Width="35">
					                    </dx:GridViewDataCheckColumn>
                                        <dx:GridViewDataTextColumn FieldName="cDNI" Visible="true"  VisibleIndex="2" Caption="DNI" Width="70">
					                    </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cNomCompleto" Visible="true"  VisibleIndex="3" Caption="Apellidos y Nombres">
					                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="cCondicion" Visible="true"  VisibleIndex="3" Caption="Condición" Width="90">
					                    </dx:GridViewDataTextColumn>

                                   

                                        <dx:GridViewDataTextColumn FieldName="cOcupacion" Visible="true"  VisibleIndex="3" Caption="Cargo / Ocupación"   >
					                    </dx:GridViewDataTextColumn>
                                     
                                    
                                        <dx:GridViewDataTextColumn FieldName="cMOCMONC" Visible="true"  VisibleIndex="3" Caption="Categoría" Width="65">
					                    </dx:GridViewDataTextColumn>
                                       <dx:GridViewDataDateColumn FieldName="dFechaIni" Visible="true"  VisibleIndex="3" Caption="F. Inicio" Width="75">
					                    </dx:GridViewDataDateColumn>

                                         <dx:GridViewDataTextColumn FieldName="cEstado" Visible="true"  VisibleIndex="3" Caption="Estado" Width="70">
					                    </dx:GridViewDataTextColumn>
 

                                             </Columns>
                                                </dx:ASPxGridView>
                                            </div>
                                             


                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
          <%-- <ContentCollection>
              <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>--%><%--<ClientSideEvents Closing="function(s, e) {
	ClearContentControlsDetalle();
              
}"           Shown="function(s,e){
             
              }" >
              
          </ClientSideEvents>--%>
      </dx:ASPxPopupControl>


     <%-- ***************************** SECCION POPUPS DETALLE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormMainCliDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormMainCliDetalle" 
        PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1240" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Colaborador" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormLayoutPopupDetalle" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Datos del Colaborador">
                                          <Items>
                                             <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Nro. Doc. Id.">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															 <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True" 
                                                                        ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
                                                                      </dx:ASPxTextBox>
                                                                 <dx:ASPxButtonEdit ID="cDNI" runat="server" NullText="Buscar..."  
                                                                     ClientInstanceName="cDNI"  ClientSideEvents-ButtonClick="cDNI_OnButtonClick" AutoPostBack="false"
                                                                       >
 
                                                                      <ClientSideEvents KeyPress="cDNI_KeyPress" 
                                                                            LostFocus="function(s, e) {s.Validate();}" 
                                                                            Validation="cDNI_Validation" 
                                                                            />  
                                                                      
                                                                     <ValidationSettings RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip" ErrorText="Cantidad de caracteres inválido"   Display="Dynamic"  />
                                                                               

                                                                      <Buttons>
                                                                          <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" >
                                                                                <Image IconID="find_find_16x16gray"></Image>
                                                                          </dx:SpinButtonExtended>
                                                                      </Buttons>
                                                                  </dx:ASPxButtonEdit>
                                                                
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Tipo Doc. Id.">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cTipoDoc" runat="server" ValueType="System.String" ClientInstanceName="cTipoDoc">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																        <Items>                                                                          
                                                                        <dx:ListEditItem Text="DNI" Value="DNI" Selected="true" />                                                                        
                                                                        <dx:ListEditItem Text="CARNET EXTRANJERIA" Value="CE" />  
                                                                        <dx:ListEditItem Text="PASAPORTE" Value="PAS" />
                                                                     </Items> 
                                                                 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

										            <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Apellidos">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cApellidos" ClientInstanceName="cApellidos" CssClass="toUpper"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Nombres">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cNombres" ClientInstanceName="cNombres" CssClass="toUpper"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                               <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Sexo:">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>											
                                                                <dx:ASPxComboBox ID="cSexo" runat="server" ClientInstanceName="cSexo"   ValueType="System.String">
                                                                      <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
                                                                    <Items>
                                                                        <dx:ListEditItem Text="MASCULINO" Value="M" />
                                                                        <dx:ListEditItem Text="FEMENINO" Value="F" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                              	<%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Ubigeo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                  <dx:ASPxComboBox ID="cUbigeo" runat="server" ValueType="System.String" ClientInstanceName="cUbigeo">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Condicion">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 

                                                                 <dx:ASPxComboBox ID="cCondicion" runat="server" ValueType="System.String" ClientInstanceName="cCondicion">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="LOCAL" Value="LOCAL" />
                                                                         <dx:ListEditItem Text="FORANEO" Value="FORANEO" />
                                                                     </Items> 
																 </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                              
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="País Nacimiento">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="cPaisNacimiento" runat="server" ValueType="System.String" ClientInstanceName="cPaisNacimiento">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >                                                                   
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                               <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                             <table class="OAELStat" style="margin-top:12px!important; float:left;">
                                                              <tr>
                                                                  <td style="padding-right: 20px; padding-top:2px;">
                                                                       <span id="oaelCondicion">
                                                                          
                                                                      </span>
                                                                      <span id="oaelExpediente">
                                                                          
                                                                      </span>
                                                                      <span id="oaelFFLL">
                                                                        
                                                                      </span>
                                                                     
                                                                     <span id="oaelEmpresa">
                                                                          
                                                                      </span>
                                                                        <%--<span id="oaelConsentimiento">
                                                                         Consentimiento : SI
                                                                      </span>--%>
                                                                      
                                                                  </td>
                                                                  
                                                              </tr>
                                                          </table>
                                                          
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>
                                          </Items>
                                      </dx:LayoutGroup> 
                                                        	
                                      
                                       <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Condiciones de Contratación">
                                          <Items>
                                                
                                              <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="Inicio">
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                  <dx:ASPxDateEdit ID="dFechaIni" ClientInstanceName="dFechaIni" runat="server" AutoPostBack="false" UseMaskBehavior="False" 
                                                                     CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
<CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                      <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
                                                                  </dx:ASPxDateEdit>
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
                                                        	

                                                 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Tipo Cargo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cTipoCargo" runat="server" ValueType="System.String" ClientInstanceName="cTipoCargo">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="GERENTE - MANAGER" Value="MANAGER" />                                                                        
                                                                        <dx:ListEditItem Text="PROFESIONAL" Value="PROFESIONAL" />
                                                                         <dx:ListEditItem Text="SUPERVISOR" Value="SUPERVISOR" />                                                                        
                                                                        <dx:ListEditItem Text="ADMINISTRATIVO" Value="ADMINISTRATIVO" />   
                                                                         <dx:ListEditItem Text="WORKER" Value="WORKER" />                                                                        
                                                                       
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
											
												<%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Ocupación">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															
                                                                <dx:ASPxComboBox ID="cOcupacion" runat="server"
                                                                    ValueField="iCodOcupacion" ValueType="System.Int32" TextFormatString="{1}" ClientInstanceName="cOcupacion" >
                                                                    <ClientSideEvents SelectedIndexChanged="cOcupacion_SelectedIndexChanged">

                                                                    </ClientSideEvents>
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                     <Columns>
                                                                             <dx:ListBoxColumn Caption="iCodOcupacion" FieldName="iCodOcupacion" Visible="false" Width="1%" />
                                                                            <dx:ListBoxColumn Caption="Tipo" FieldName="cTipo" Width="45px" />
                                                                            <dx:ListBoxColumn Caption="Ocupación" FieldName="cNomOcupacion" Width="100%" />
                                                                            
                                                                        </Columns> 
																 </dx:ASPxComboBox>
                                                               
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                                
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Tipo MMOO">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cMOCMONC" runat="server" ValueType="System.String" ClientInstanceName="cMOCMONC">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="MOC" Value="MOC" />                                                                        
                                                                        <dx:ListEditItem Text="MONC" Value="MONC" />  
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

											
												
                                             <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Régimen Laboral">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cRegimenLaboral" runat="server" ValueType="System.String" ClientInstanceName="cRegimenLaboral">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="REG. CONSTRUCCION CIVIL" Value="RCC" />                                                                        
                                                                        <dx:ListEditItem Text="REG. COMUN" Value="RCO" />                                                                                                                     
                                                                        <%--<dx:ListEditItem Text="REG. GENERAL" Value="RGE" />   --%>                                                                     
                                                                        <dx:ListEditItem Text="REG. MYPE" Value="RMY" /> 
                                                                        <dx:ListEditItem Text="SERV. POR TERCEROS RXH" Value="RXH" /> 
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                               <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Tipo de Contrato">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cTipoContrato" runat="server" ValueType="System.String" ClientInstanceName="cTipoContrato">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="PLAZO INDEFINIDO" Value="PLAZO INDEFINIDO" />                                                                        
                                                                        <dx:ListEditItem Text="DETERMINADO - CARACTER TEMPORAL" Value="DETERMINADO - CARACTER TEMPORAL" />
                                                                        <dx:ListEditItem Text="DETERMINADO - PARA OBRA O SERV. ESPECIFICO" Value="DETERMINADO - PARA OBRA O SERV. ESPECIFICO" />
                                                                        <dx:ListEditItem Text="DETERMINADO - NATURAEZA ACCIDENTAL" Value="DETERMINADO - NATURAEZA ACCIDENTAL" />
                                                                        <dx:ListEditItem Text="A TIEMPO PARCIAL" Value="A TIEMPO PARCIAL" />
                                                                        <dx:ListEditItem Text="CONSTRUCCION CIVIL" Value="CONSTRUCCION CIVIL" />
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Turno">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cTurno" runat="server" ValueType="System.String" ClientInstanceName="cTurno">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="DIURNO" Value="DIURNO" />                                                                        
                                                                        <dx:ListEditItem Text="NOCTURNO" Value="NOCTURNO" /> 
                                                                         <dx:ListEditItem Text="ROTATIVO" Value="ROTATIVO" />
                                                                        <dx:ListEditItem Text="NO APLICA" Value="NA" />  
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                               <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Rotacion">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cRotacion" runat="server" ValueType="System.String" ClientInstanceName="cRotacion">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                      
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                      
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Area de Trabajo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                               <dx:ASPxTextBox runat="server" ID="cAreaTrabajo" ClientInstanceName="cAreaTrabajo" CssClass="toUpper"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
																</dx:ASPxTextBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Lugar de Pernocte">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="cLugarPernocte" runat="server" ValueType="System.String" ClientInstanceName="cLugarPernocte">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >                                                                   
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Sub Contratista">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="iCodSubContrata" runat="server" ValueType="System.String" ClientInstanceName="iCodSubContrata">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >                                                                   
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                               <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Horas Hombre">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                <dx:ASPxTextBox runat="server" ID="iHorasHombre" ClientInstanceName="iHorasHombre"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                    <MaskSettings Mask="<0..360>" /> 
																</dx:ASPxTextBox>                                                                                                                                
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 
                                               <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Status Activo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="cSituacionLaboral" runat="server" ValueType="System.String" ClientInstanceName="cSituacionLaboral">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="ACTIVO" Value="ACTIVO" />                                                                        
                                                                        <dx:ListEditItem Text="ACTIVO EN SITE" Value="ACTIVO EN SITE" /> 
                                                                         <dx:ListEditItem Text="LICENCIA CON GOCE" Value="LICENCIA CON GOCE" />
                                                                         <dx:ListEditItem Text="LICENCIA SIN GOCE" Value="LICENCIA SIN GOCE" />
                                                                         <dx:ListEditItem Text="SUSPENSIÓN PERFECTA" Value="SUSPENSIÓN PERFECTA" />
                                                                         <dx:ListEditItem Text="VACACIONES" Value="VACACIONES" />  
                                                                         <dx:ListEditItem Text="DESCANSO MÉDICO" Value="DESCANSO MÉDICO" />                                                                    
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                              <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" >
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                       
                                                          <table style="margin-top:12px!important;">
                                                              <tr>
                                                                  
                                                                  <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnGuardarDetalle" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarDetalle" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnGuardarClickDetalle" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCancelarDetalle" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelarDetalle" AutoPostBack="false">
                                                                          <ClientSideEvents Click="CloseFormMainModalDetalle">
                                                                          </ClientSideEvents>
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                              </tr>
                                                          </table>
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>
                                                 

                                          </Items>
                                      </dx:LayoutGroup>


                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
          <ContentCollection>
              <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>
          <ClientSideEvents Closing="function(s, e) {
	ClearContentControlsDetalle();
              
}"           Shown="function(s,e){
             
              }" >
              
          </ClientSideEvents>
      </dx:ASPxPopupControl>
    <%-- ******************************** POPUP DETALLE CONFIRM MODAL ********************************************** --%>
     <dx:ASPxPopupControl ID="PopupConfirmDeleteDetalle" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDeleteDetalle"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormConfirmLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupDetalle" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="¿ Seguro de borrar el registro seleccionado. ?">
                                                  </dx:ASPxLabel>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                      <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <table style="margin-top:12px!important;">
                                                      <tr>
                                                          <td style="padding-right: 10px;">
                                                              <dx:ASPxButton ID="BtnDeleteConfirmDetalle" runat="server" Text="Si" Width="60"   ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="DeleteRecordDetalle" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                          <td>
                                                              <dx:ASPxButton ID="BtnDeleteCancelDetalle" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancel" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="CloseFormConfirmDeleteDetalle">
                                                                  </ClientSideEvents>
                                                              </dx:ASPxButton>
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
      </dx:ASPxPopupControl>


    
     <%-- ***************************** SECCION POPUPS CESE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormCese" runat="server" Modal="True" ClientInstanceName="PopupFormCese" 
        PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="680" PopupVerticalAlign="WindowCenter" 
        MaxWidth="680"   MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Cese" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="divFormCese">
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupCese" CssClass="formLayout" ClientInstanceName="FormLayoutPopupCese" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutGroup ColCount="1"   GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="Condiciones de Contratación">
                                          <Items>
                                                
                                              <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="Fecha de Cese">
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                  <dx:ASPxDateEdit ID="dFechaCese" ClientInstanceName="dFechaCese" runat="server" AutoPostBack="false" UseMaskBehavior="False" 
                                                                     CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
<CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                      <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
                                                                  </dx:ASPxDateEdit>
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
                                                        	

                                             <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Motivo de Cese">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="cMotivoCese" runat="server" ValueType="System.String" ClientInstanceName="cMotivoCese">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >                                                                   
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
											
												
                                             <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Desempeño">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="iCalificacion" runat="server" ValueType="System.String" ClientInstanceName="iCalificacion">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Value="5" Text="MUY RECOMENDABLE" />     
                                                                                                                                                         
                                                                        <dx:ListEditItem Value="3" Text="RECOMENDABLE" />                                                                        
                                                                   
                                                                         <dx:ListEditItem Value="1" Text="NADA RECOMENDABLE" /> 
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                              <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="">
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                
                                                                  <dx:ASPxCheckBox ID="bDevolvioFotocheck" ClientInstanceName="bDevolvioFotocheck" runat="server" Text="Devolvio Fotocheck"></dx:ASPxCheckBox>
          
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
                                           

                                              <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                       
                                                          <table style="margin-top:12px!important;">
                                                              <tr>
                                                                  
                                                                  <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnCeseGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnCeseGuardar" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnGuardarFormCeseClick" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCeseCerrar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCeseCerrar" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnCerrarFormCeseClick">
                                                                          </ClientSideEvents>
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                              </tr>
                                                          </table>
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>
                                                 

                                          </Items>
                                      </dx:LayoutGroup>


                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
          <ContentCollection>
              <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>
          <ClientSideEvents Closing="function(s, e) {
	ClearContentControlsDetalleCese();
              
}"            >
              
          </ClientSideEvents>
      </dx:ASPxPopupControl>
    
    
     <%-- ***************************** SECCION POPUPS CONFIG REPORT***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportesConfig" runat="server" Modal="True" ClientInstanceName="PopupFormReportesConfig" 
        PopupElementID="PopupFormReportesConfig" PopupHorizontalAlign="WindowCenter" Width="680" PopupVerticalAlign="WindowCenter" 
        MaxWidth="680"   MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Reportes de Fuerza Laboral :: Configuración" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupReportesConfig" CssClass="formLayout" ClientInstanceName="FormLayoutPopupReportesConfig" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                                                                       	
                                      
                                       <dx:LayoutGroup ColCount="1" ParentContainerStyle-Paddings-PaddingBottom="20px"  GroupBoxDecoration="None" UseDefaultPaddings="true" Caption="">
                                          <Items>
                                              <%--***ITEM FORM ***--%>
                                                <dx:LayoutItem Caption="Tipo Reporte">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                 <dx:ASPxComboBox ID="iTipoReporte" runat="server" ValueType="System.String" ClientInstanceName="iTipoReporte" ClientSideEvents-SelectedIndexChanged="iTipoReporte_SelectedIndexChanged" >
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
<ClientSideEvents SelectedIndexChanged="iTipoReporte_SelectedIndexChanged"></ClientSideEvents>
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Value="1" Text="FUERZA LABORAL - FORMATO SMI" Selected="true" />     
                                                                                                                                                         
                                                                        <dx:ListEditItem Value="2" Text="HEAD COUNT - FORMATO MENSUAL AAQ" />  
                                                                         
                                                                        <%--<dx:ListEditItem Value="DESMOVILIZADO" Text="DESMOVILIZADOS" />--%>                                                                       
                                                                   
                                                                     </Items> 
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>                                  											
                                          </Items>

<ParentContainerStyle>
<Paddings PaddingBottom="20px"></Paddings>
</ParentContainerStyle>
                                      </dx:LayoutGroup>

                                      <dx:LayoutGroup ColCount="2" Name="GrupoFFLLConfig"  GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Opciones del Reporte">
                                          <Items>                                             

                                              <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="Inicio" >
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                
                                                                  <dx:ASPxDateEdit ID="dFechaIniReport" ClientInstanceName="dFechaIniReport" runat="server" AutoPostBack="false" UseMaskBehavior="False" 
                                                                     CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False"  >

<CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                  </dx:ASPxDateEdit>
          
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
                                                        

                                            <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="Fin">
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                
                                                                  <dx:ASPxDateEdit ID="dFechaFinReport" ClientInstanceName="dFechaFinReport" runat="server" AutoPostBack="false" UseMaskBehavior="False" 
                                                                     CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False"  >

<CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                  </dx:ASPxDateEdit>
          
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
											
												 <%--***ITEM FORM ***--%>
                                                      <dx:LayoutItem Caption="">
                                                          <LayoutItemNestedControlCollection>
                                                              <dx:LayoutItemNestedControlContainer>
                                                                
                                                                  <dx:ASPxCheckBox ID="bCesadosIncluir" ClientInstanceName="bCesadosIncluir" runat="server" Text="Incluir cesados dentro del periodo seleccionado."></dx:ASPxCheckBox>
          
                                                              </dx:LayoutItemNestedControlContainer>
                                                          </LayoutItemNestedControlCollection>
                                                      </dx:LayoutItem>
                                           

                                                                                  

                                          </Items>
                                      </dx:LayoutGroup>

                                      <dx:LayoutGroup ColCount="1" Name="GrupoBotones"  GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                          <Items>     
                                                <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                       
                                                          <table style="margin-top:12px!important;">
                                                              <tr>
                                                                  
                                                                  <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnVerReporte" runat="server" Text="Ver Reporte" Width="100px" ClientInstanceName="BtnVerReporte" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnVerReporteClick" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCerrarReporteConfig" runat="server" Text="Cerrar" Width="100" ClientInstanceName="BtnCerrarReporteConfig" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnCerrarReporteConfigClick">
                                                                          </ClientSideEvents>
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                              </tr>
                                                          </table>
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>            
                                          </Items>
                                      </dx:LayoutGroup>                                       
                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
        
      </dx:ASPxPopupControl>
    


       <%-- ******************************** POPUP CONFIRMAR CIERRE FFLL ********************************************** --%>
     <dx:ASPxPopupControl ID="PopupConfirmarCierreFFLL" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmarCierreFFLL"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación - Cierre de FFLL">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FrmLayoutConfirmarCierreFFLL" CssClass="formLayout" ClientInstanceName="FrmLayoutConfirmarCierreFFLL" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="¿ Seguro de cerrar el periodo seleccionado. No podrá realizar modificaciones posteriores al cierre ?">
                                                  </dx:ASPxLabel>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                      <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <table style="margin-top:12px!important;">
                                                      <tr>
                                                          <td style="padding-right: 10px;">
                                                              <dx:ASPxButton ID="BtnConfirmarCerrarPeriodo" runat="server" Text="Sí , Cerrar." Width="70"   ClientInstanceName="BtnConfirmarCerrarPeriodo" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="OnBtnConfirmarCerrarPeriodoClick" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                           
                                                          <td>
                                                              <dx:ASPxButton ID="BtnCancelarCerrarPeriodo" runat="server" Text="No" Width="60" ClientInstanceName="BtnCancelarCerrarPeriodo" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="OnBtnCancelarCerrarPeriodoClick">
                                                                  </ClientSideEvents>
                                                              </dx:ASPxButton>
                                                          </td>
                                                      </tr>
                                                  </table>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                  </Items>
                              </dx:ASPxFormLayout>
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
      </dx:ASPxPopupControl>


      <%-- ***************************** SECCION POPUPS REPORTE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportes" runat="server" Modal="True" ClientInstanceName="PopupFormReportes" 
        PopupElementID="PopupFormReportes" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="Reportes de Fuerza Laboral"  >
         <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" MinHeight="95%" MinWidth="97%" />  
                <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server" CssClass="popupSimple">
                          <%--********* INI CONTENT FORM MAIN *********--%>

                          <div id="mainReportFFLL">
                           <dx:ASPxCallbackPanel ID="CallBackPanelReport" ClientInstanceName="CallBackPanelReport" runat="server"  OnCallback="CallBackPanelReport_Callback">  
                                <PanelCollection>  
                                    <dx:PanelContent ID="PanelContent1" runat="server">  
                                         <div class="containerReport">
                                                <dx:ASPxWebDocumentViewer  Height="550"  ID="WebReportViewer" runat="server" DisableHttpHandlerValidation="False">
                                                        <ClientSideEvents Init="OnInit" />
                                  
                                                </dx:ASPxWebDocumentViewer>                                                 
                                            </div>
                                    </dx:PanelContent>  
                                </PanelCollection>  
                            </dx:ASPxCallbackPanel>  
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
      </dx:ASPxPopupControl>


  <%-- ***************************** SECCION POPUPS DASHBOARD***************************** --%>

  <dx:ASPxPopupControl ID="PopupFormDashboard" runat="server" Modal="True" ClientInstanceName="PopupFormDashboard" 
        PopupElementID="PopupFormDashboard" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="Reportes de Fuerza Laboral"  >
         <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" MinHeight="90%" MinWidth="95%" />  
                <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server" CssClass="popupSimple">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="DashboardMain">
                               <dx:ASPxCallbackPanel ID="CallBackPanelDashboard" ClientInstanceName="CallBackPanelDashboard" runat="server" OnCallback="CallBackPanelDashboard_Callback">  
                                    <PanelCollection>  
                                        <dx:PanelContent ID="PanelContentDashboard" runat="server">  
                                             <div class="ContainerDashboard">
                                                  <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" ColorScheme="light.compact" WorkingMode="ViewerOnly" Height="600px"></dx:ASPxDashboard>
                                              </div>
                                        </dx:PanelContent>  
                                    </PanelCollection>  
                                </dx:ASPxCallbackPanel>  


                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                     </dx:PopupControlContentControl>
                  </ContentCollection>
      </dx:ASPxPopupControl>

</asp:Content>
