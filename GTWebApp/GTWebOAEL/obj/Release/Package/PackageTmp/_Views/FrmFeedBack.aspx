<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmFeedBack.aspx.vb" Inherits="GTWebOAEL.FrmFeedBack" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%--<script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js" ></script>--%>
  <script type="text/javascript" src="../_GTJScript/Feedback.js" ></script> <%--MODIFICAR--%>
   <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js" ></script>  <%--MODIFICAR--%>
  <script type="text/javascript" src="../_GTJScript/_GTMainCore.js" ></script>  
      <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js" ></script>  <%--MODIFICAR--%>

     <script type="text/javascript" > 
         // ************* FUNCTIONS CUSTOM 
         function OnToolbarItemClickCustom(s, e) {

             if (IsCustomExportToolbarCommand(e.item.name)) {
                 e.processOnServer = true;
                 e.usePostBack = true;
             }

             if (e.item.name == "BtnAgregar") {
                 //iCodRegistro.SetText("0");
                 //cFormMetadata.Set("cTipoOpe", "A");
                 //ClearContentControls();
                 //FormMainModalShow();
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEditar") {
                

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnImprimirListadoConvocatoria") {

                 CallBackPanelReport.PerformCallback("FEEDBACK01");
                 PopupFormReportes.ShowWindow();
                 e.processOnServer = false;
                 
             }
             else if (e.item.name == "BtnGestionarFeedback") {
                
                

                 //miRespuestaFeedbackNegativa.forEach(addComboBoxFeedback);

                 TablaRegistrosDetalle.PerformCallback('load');

                 //getRespuestaFeedback();
                

                 var popupWindow = PopupFormFeedbackDetalle.GetWindow(0);
                 PopupFormFeedbackDetalle.ShowWindow(popupWindow);
                 e.processOnServer = false;
             }
           
         }
   
         var iCommandDetalle = 0;
         var msgDetalle = "";
         var pFormActivo = "";

         function OnToolbarItemClickFeedbackDetalle(s, e) {

             if (e.item.name == "BtnAgregarDetalle") {
               


             }
             else if (e.item.name == "BtnEditarFeedback") {
                 
                 iCommandDetalle = 2;
                 msgDetalle = "El registro se actualizó con éxito";
                 cFormMetadata.Set("cTipoOpeDetalle", "M");
                 cSeleccionado.SetChecked(false);
                 cSeleccionado.SetText('NO SELECCIONADO');
                 iCodRegistroDetalle.SetText(TablaRegistrosDetalle.GetRowKey(TablaRegistrosDetalle.GetFocusedRowIndex()));
                 if (iCodRegistroDetalle.GetValue() != null) {
                 ClearContentControlsDetalle();
                 //
                 //miRespuestaFeedbackNegativa.forEach(addComboBoxFeedback);
                     viewRecordDetalle();
                     FormMainModalShowDetalle();
                 }

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnImprimirListadoConvocatoriaDetalle") {

                 CallBackPanelReport.PerformCallback("FEEDBACK01");
                 PopupFormReportes.ShowWindow();
                 e.processOnServer = false;

             }

             else if (e.item.name == "BtnCandidatoFicha") {

                 CallBackPanelReport.PerformCallback("FICHAPOSTULANTE");
                 PopupFormReportes.ShowWindow();
                 e.processOnServer = false;

             }

             else if (e.item.name == "BtnCandidatoCV") {

                 

             }
             else if (e.item.name == "BtnProcesoNoCumplePerfil") {

                 //msgDetalle = "Se procesó la petición con éxito";
                 //CallBackFunctionDetalleFeedback.PerformCallback('ProcesoNoCumplePerfil');

                 pFormActivo = 'PopupFeedbackMasivoNoCumple';
                 var popupWindow = PopupFeedbackMasivoNoCumple.GetWindow(0);
                 PopupFeedbackMasivoNoCumple.ShowWindow(popupWindow);

                 //PopupFeedbackMasivoNoCumple.ShowWindow();
             }
             else if (e.item.name == "BtnFormFeedbackMasivo") {

                 var cID = iCodRegistro.GetValue();

                 iCodOcupacionMasivo.ClearItems();

                 //lblCalendarClient.SetText(client);
                 //lblCalendarCampaign.SetText(campaign);

                 $.ajax({
                     type: "POST",
                     url: "FrmFeedback.aspx/ListarOcupacionesResumenConvocatoria",
                     data: "{'pID':" + cID + "}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     success: function (response) {
                         var posiciones = JSON.parse(response.d);

                         posiciones.forEach(function (item) {
                             var rowOcupacionResumen = new Array(item.iCodConvocatoria, item.cPerfil, item.iRevisados, item.iSeleccionados, item.iAprobados, item.iTotalForm);
                              iCodOcupacionMasivo.AddItem(rowOcupacionResumen)
                             delete rowOcupacionResumen;
                         });
                         
                     }
                 });

                    
                 pFormActivo = 'PopupFormFeedbackMasivo';
                 var popupWindow = PopupFormFeedbackMasivo.GetWindow(0);
                 PopupFormFeedbackMasivo.ShowWindow(popupWindow);

             }
         }

       
         function OnGridFocusedRowChangedDetalle(s, e) {


             //iCodRegistroDetalle.SetText(s.GetRowKey(s.GetFocusedRowIndex()));            
             //e.processOnServer = false;

                       
             iCodRegistroDetalle.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
             s.GetRowValues(s.GetFocusedRowIndex(), 'iCodCandidatoInforme', OnGetRowValueCodCandidato);
             e.processOnServer = false;

         }
     
         function OnGetRowValueCodCandidato(value) {
             //alert(value);
            iCodCandidatoInforme.SetText(value);

        }
         function BtnDetalleHojaVida_OnClick() {
             CallBackPanelReport.PerformCallback("FICHAPOSTULANTE");
             PopupFormReportes.ShowWindow();
             e.processOnServer = false;
         }
         function OnBtnGuardarFeedbackClickDetalle(s, e) {
             if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopupDetalle.GetMainElement(), null, true)) {
                 CallBackFunctionDetalleFeedback.PerformCallback('GuardarFeedback');

             }
             else {
                 e.processOnServer = false;
             }
         }

         function OnEndCallBackFunctionDetalleFeedback(s, e) {


             if (pFormActivo == 'PopupFeedbackMasivoNoCumple') {

                 var popupWindow = PopupFeedbackMasivoNoCumple.GetWindow(0);
                 PopupFeedbackMasivoNoCumple.HideWindow(popupWindow);


             }

             

             if (e.result == 'OK') {
                
                     
                 if (pFormActivo == 'PopupFeedbackMasivo') {
                     var popupWindow = PopupFormFeedbackMasivo.GetWindow(0);
                     PopupFormFeedbackMasivo.HideWindow(popupWindow);
                 }

                 CloseFormMainModalDetalle();
                 TablaRegistrosDetalle.PerformCallback('load');

                 ShowAlertMessage(msgDetalle);

             }
             else {
                 ShowAlertMessage('Ocurrió un error durante la transacción.');
             }

            

         }

         function OnValueChanged_cSeleccionado(s, e) {
             //var checkState = s.GetCheckState();
             var checked = s.GetChecked();
            
             cRptaContrata.ClearItems();

             if (checked == true) {              
                 miRespuestaFeedback.forEach(addComboBoxFeedback);
                 s.SetText('SELECCIONADO');
             }
             else {               
                 miRespuestaFeedbackNegativa.forEach(addComboBoxFeedback);
                 s.SetText('NO SELECCIONADO');
             }
         }

         function addComboBoxFeedback(item) {
             cRptaContrata.AddItem(item);
         }

         function BtnFeedbackMasivoNoCumple_Click(s, e) {
             msgDetalle = "Se procesó la petición con éxito";
             CallBackFunctionDetalleFeedback.PerformCallback('ProcesoNoCumplePerfil');
             e.processOnServer = false;
         }
        
         function BtnFeedbackMasivoNoCumpleCancelar_Click(s, e) {
            

             e.processOnServer = false;
         }

         function BtnGuardarFeedbackMasivo_Click(s, e) {


             var iRev = 0, iSelec = 0, iAprob = 0, iTotal = 0;
             var iTipoProceso = -1;
             iRev = iCodOcupacionMasivo.GetSelectedItem().GetColumnText("iRevisados");
             iSelec = iCodOcupacionMasivo.GetSelectedItem().GetColumnText("iSeleccionados");
             iAprob = iCodOcupacionMasivo.GetSelectedItem().GetColumnText("iAprobados");
             iTotal = iCodOcupacionMasivo.GetSelectedItem().GetColumnText("iTotalForm");

             iTipoProceso = cRptaContrataMasivo.GetSelectedIndex();

             msgDetalle = "Se procesó el feedback con éxito";
             //PARA PLAZA COBERTURADA POR LOCAL
             if (iTipoProceso == 0) {
                 if (iTotal == iAprob) {
                     CallBackFunctionDetalleFeedback.PerformCallback('ProcesoRespuestaMasiva'); 
                 }
                 else {
                     ShowAlertMessage('Error - No Cumple los requisitos para aplicar esta opción.');
                     return;
                 }
             }

             //PROCESO DE SELECCION PARALIZADO
             if (iTipoProceso == 1) {
                 if (iSelec == 0) {
                     CallBackFunctionDetalleFeedback.PerformCallback('ProcesoRespuestaMasiva'); 

                 }
                 else {
                     ShowAlertMessage('Error - No Cumple los requisitos para aplicar esta opción.');
                     return;
                 }

             }

             iRev = null;
             iSelec = null;
             iAprob = null;
             iTotal = null;
             iTipoProceso = null;

             e.processOnServer = false;
         }

         function BtnCerrarFormFeedbackMasivo_Click(s, e) {
             var popupWindow = PopupFormFeedbackMasivo.GetWindow(0);
             PopupFormFeedbackMasivo.HideWindow(popupWindow);
              e.processOnServer = false;
         }
     </script>
     <style>
       
        .dxrd-image-parameters-inactive, .dxrd-image-parameters-active {  
       display: none;  
   }
         .dxgvHeader_Office365.HeaderColTiny {
         padding-top:6px;
         padding-bottom:6px;
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
          <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros" AutoGenerateColumns="False">
              <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCustom" FocusedRowChanged="OnGridFocusedRowChanged"
                  Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback"></ClientSideEvents>
              <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
              </SettingsPager>
              <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="270"></Settings>

              <SettingsBehavior AllowFocusedRow="True" />
              <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
              <Settings ShowVerticalScrollBar="True" />
              <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
              <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

             <%-- <Columns>
                  <dx:GridViewDataTextColumn FieldName="dFechaIni" ShowInCustomizationForm="True" Caption="F. Ini" VisibleIndex="4">
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="dFechaFin" ShowInCustomizationForm="True" Caption="F. Fin" VisibleIndex="5">
                  </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="iCantEnviada" ShowInCustomizationForm="True" Caption="CV. Env." VisibleIndex="6"></dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="iRespuestaNO" ShowInCustomizationForm="True" Caption="SIN Rpta." VisibleIndex="7"></dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="iRespuestaSI" ShowInCustomizationForm="True" Caption="CON Rpta." VisibleIndex="8"></dx:GridViewDataTextColumn>
                  <dx:GridViewDataHyperLinkColumn FieldName="cRutaDifusion" ShowInCustomizationForm="True" Width="85px" Caption="One Drive" VisibleIndex="9">
                  </dx:GridViewDataHyperLinkColumn>
              </Columns>--%>
              <Toolbars>
                  <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                      <Items>
                          <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                              <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
                              <Template>
                                  <div id="gtHeadTitle" style="">
                                      <%--***  MODIFICAR ***--%>
                                      CONVOCATORIAS
                                  </div>

                              </Template>

                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                              <Template>
                                  <div id="div100Percent"></div>
                              </Template>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Text="Agregar" Name="BtnAgregar" Enabled="false" ClientEnabled="false">
                              <Image IconID="actions_new_16x16office2013">
                              </Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Text="Editar" Name="BtnEditar" Enabled="false" ClientEnabled="false">
                              <Image IconID="actions_edit_16x16devav"></Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Text="Impr. Listado" Name="BtnImprimirListadoConvocatoria">
                              <Image IconID="actions_printpreview_16x16devav"></Image>
                          </dx:GridViewToolbarItem>
                         <%-- <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar"  Enabled="false" ClientEnabled="false" >
                              <Image IconID="edit_delete_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>--%>
                          <dx:GridViewToolbarItem Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1" Name="BtnGestionarFeedback" Text="Gestionar Feedback">
                              <Image IconID="people_publicfix_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1" BeginGroup="True" Text="Export to">
                              <Items>
                                  <dx:GridViewToolbarItem Command="ExportToPdf"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Command="ExportToDocx"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Command="ExportToRtf"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Command="ExportToCsv"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Command="ExportToXls" Text="Export to XLS(DataAware)"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Name="CustomExportToXLS" Text="Export to XLS(WYSIWYG)">
                                      <Image IconID="export_exporttoxls_16x16office2013"></Image>
                                  </dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export to XLSX(DataAware)"></dx:GridViewToolbarItem>
                                  <dx:GridViewToolbarItem Name="CustomExportToXLSX" Text="Export to XLSX(WYSIWYG)">
                                      <Image IconID="export_exporttoxlsx_16x16office2013"></Image>
                                  </dx:GridViewToolbarItem>
                              </Items>

                              <Image IconID="actions_download_16x16office2013"></Image>

                          </dx:GridViewToolbarItem>
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
                     <dx:GridViewDataTextColumn FieldName="iCodConvocatoriaMain" Visible="false"  VisibleIndex="0" Caption="ID">
					</dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="iRespuestaNO" VisibleIndex="1" Caption="-" Width="40" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
						<DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="FeedBackStatus" OnInit="FeedBackStatus_Init" ></dx:ASPxImage>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>  
                   <dx:GridViewDataTextColumn FieldName="cTipo" Visible="true"  VisibleIndex="2" Caption="Tipo" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroConvocatoria" Visible="true"  VisibleIndex="3" Caption="Convocatoria" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >
					</dx:GridViewDataTextColumn>
               <dx:GridViewDataTextColumn FieldName="dFechaIni" Visible="true"  VisibleIndex="4" Caption="F. Ini"  
                    PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="dFechaFin" Visible="true"  VisibleIndex="5" Caption="F. Fin" 
                        PropertiesTextEdit-DisplayFormatString="dd/MM/yyyy">
					</dx:GridViewDataTextColumn>

                   <dx:GridViewBandColumn Caption="CVs Enviados" VisibleIndex="6" HeaderStyle-CssClass="HeaderColTiny" >
                   <Columns>
                        <dx:GridViewDataTextColumn FieldName="iSistema" Visible="true"  VisibleIndex="1" Caption="BBDD-Sistema" CellStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False" HeaderStyle-CssClass="HeaderColTiny">
					    <HeaderCaptionTemplate>  
                               <%--<img src='~/_GTContent/icons/icon-star.png' />--%>
                             <dx:ASPxImage ID="ASPxImage1" runat="server" ShowLoadingImage="false" ImageUrl="~/_GTContent/icons/star-icon.png"></dx:ASPxImage>  
                              BBDD-Sistema 
                           </HeaderCaptionTemplate>  
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="iOtros" Visible="true"  VisibleIndex="2" Caption="OAEL-Web" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  HeaderStyle-CssClass="HeaderColTiny" >
					    </dx:GridViewDataTextColumn>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" />
                    </dx:GridViewBandColumn>

                    <dx:GridViewDataTextColumn FieldName="iRespuestaNO" Visible="true"  VisibleIndex="7" Caption="SIN Rpta."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="iRespuestaSI" Visible="true"  VisibleIndex="8" Caption="CON Rpta."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="iCantCuestionarios" Visible="true"  VisibleIndex="9" Width="85" Caption="# Cuest."  CellStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center"  Settings-AllowSort="False">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataHyperLinkColumn FieldName="cRutaDifusion" VisibleIndex="10" Caption="One Drive" Width="80" CellStyle-HorizontalAlign="Center" Settings-AllowSort="False"  HeaderStyle-HorizontalAlign="Center"  >  
                       <PropertiesHyperLinkEdit  ImageUrl="../_GTContent/icons/Click-cloud-icon.png" Target="_blank"></PropertiesHyperLinkEdit>  
                    </dx:GridViewDataHyperLinkColumn>  
            </Columns>
               <FormatConditions>
          
               <dx:GridViewFormatConditionHighlight FieldName="iRespuestaNO" Expression="[iRespuestaNO] > 0" Format="LightRedFillWithDarkRedText"/>

            </FormatConditions>
          </dx:ASPxGridView>
      </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>


    <dx:ASPxPopupControl  ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli" 
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
    <%-- ***************************** SECCION POPUPS ***************************** --%>
  




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

      <%-- ***************************** SECCION POPUPS LISTADO DE PERSONAS ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormFeedbackDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormFeedbackDetalle" 
        PopupElementID="PopupFormFeedbackDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1240" MaxHeight="684px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Feedback :: Listado" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="Div1">
                              
                                            <div id="ContentTablaRegistroDetalle" class="ContentTablaRegistroCustom" style="padding:0px 0px 0px 0px;">
                                                <dx:ASPxCallback ID="CallBackFunctionDetalleFeedback" runat="server" ClientInstanceName="CallBackFunctionDetalleFeedback">
                                                    <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalleFeedback" />
                                                </dx:ASPxCallback>
                                                <dx:ASPxTextBox ID="iCodRegistroDetalle" runat="server" Width="170px" Height="10px" Visible="True" 
                                                        ClientVisible="False" ClientInstanceName="iCodRegistroDetalle">
                                                        </dx:ASPxTextBox>
                                                 <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="170px" Height="10px" Visible="True" 
                                                        ClientVisible="False" ClientInstanceName="iCodCandidatoInforme">
                                                        </dx:ASPxTextBox>
                                                <dx:ASPxGridView ID="TablaRegistrosDetalle" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosDetalle" AutoGenerateColumns="False">
                                                    <ClientSideEvents ToolbarItemClick="OnToolbarItemClickFeedbackDetalle" FocusedRowChanged="OnGridFocusedRowChangedDetalle"></ClientSideEvents>
                                                    <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                                                    </SettingsPager>
                                                    <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="360"></Settings>
                                                    <SettingsBehavior AllowFocusedRow="True" />
                                                    <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
                                                    <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%><%--<SettingsPopup>
                                                                <HeaderFilter Height="200">
                                                                    <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="768" MinHeight="300" />
                                                                </HeaderFilter>
                                                            </SettingsPopup>--%>
                                                    <SettingsSearchPanel CustomEditorID="tbToolbarSearchFeedbackDetalle" />
                                                    <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                    <%--<SettingsCustomizationDialog Enabled="true" />--%>

                                                 
                                                    <Toolbars>
                                                        <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Left">
                                                            <Items>

                                                                <dx:GridViewToolbarItem Text="" Name="BtnEditarFeedback" DisplayMode="Image" ToolTip="Modificar Datos">
                                                                    <Image IconID="actions_edit_16x16devav">
                                                                    </Image>
                                                                </dx:GridViewToolbarItem>
                                                               
                                                                 <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1"  Text="">
                                                                    <Items>
                                                                     
                                                                                    
                                                                        <dx:GridViewToolbarItem Text="Ver Ficha de Postulante" Name="BtnCandidatoFicha" >
                                                                            <Image IconID="support_product_16x16office2013">
                                                                            </Image>
                                                                        </dx:GridViewToolbarItem>
                                                                        <%-- <dx:GridViewToolbarItem Text="Ver Formato de CV" Name="BtnCandidatoCV"   >
                                                                            <Image IconID="support_packageproduct_16x16office2013">
                                                                            </Image>
                                                                        </dx:GridViewToolbarItem>--%>
                                                                                    
                                                                    </Items>

                                                                    <Image IconID="support_article_16x16office2013"></Image>

                                                                </dx:GridViewToolbarItem>

                     

                                                                <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1" Text="" BeginGroup="True" ToolTip="Procesos Masivos">
                                                                    <Items>
                                                                      <%--  <dx:GridViewToolbarItem Text="Marcar Coberturado Por Local" Name="BtnProcesoNoSeleccionado" ToolTip="Todos los candidatos NO SELECCIONADOS pero que cumplan el perfil serán marcados como PLAZA COBERTURADA POR LOCAL">
                                                                            <Image IconID="people_assignto_16x16office2013"></Image>
                                                                           
                                                                        </dx:GridViewToolbarItem>--%>
                                                                        <dx:GridViewToolbarItem Text="Marcar No Cumple Perfil" Name="BtnProcesoNoCumplePerfil" ToolTip="Todos los candidatos por debajo del 100% de cumplimiento serán marcados como NO CUMPLE EL PERFIL CURRICULAR">
                                                                            <Image IconID="view_customers_16x16devav"></Image>
                                                                            
                                                                        </dx:GridViewToolbarItem>
                                                                         <dx:GridViewToolbarItem Name="BtnFormFeedbackMasivo" Text="Feedback Masivo - Opciones" ToolTip="Opciones de respuesta masiva para Feedback">
                                                                            <Image IconID="print_contactdirectory_16x16devav"></Image>
                                                                        </dx:GridViewToolbarItem>
                                                                    </Items>

                                                                    <Image IconID="save_saveandnew_16x16office2013"></Image>

 
                                                                </dx:GridViewToolbarItem>

                                                                 

                                                                 <dx:GridViewToolbarItem Text="" Name="BtnImprimirListadoConvocatoriaDetalle">
                                                                    <Image IconID="actions_printpreview_16x16devav"></Image>
                                                                </dx:GridViewToolbarItem>

                                                              <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1"  Text="">
                                                                    <Items>
                                                                        <dx:GridViewToolbarItem Command="ExportToPdf"></dx:GridViewToolbarItem>
                                                                        <dx:GridViewToolbarItem Command="ExportToDocx"></dx:GridViewToolbarItem>
                                                                                    
                                                                        <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Export to XLSX"></dx:GridViewToolbarItem>
                                                                                    
                                                                    </Items>

                                                                    <Image IconID="actions_download_16x16office2013"></Image>

                                                                </dx:GridViewToolbarItem>

                                                                <dx:GridViewToolbarItem BeginGroup="true" >
                                                                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                                                                    <Template>
                                                                        <dx:ASPxButtonEdit ID="tbToolbarSearchFeedbackDetalle" runat="server" NullText="Buscar..." Height="100%">
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
                                         <dx:GridViewDataTextColumn FieldName="iCodCovocatoriaDetalle" Visible="false"  VisibleIndex="0">
					                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn FieldName="cSeleccionado" VisibleIndex="1" Caption="-" Width="40">
						                    <DataItemTemplate>
                                                <dx:ASPxImage runat="server" ID="PostulacionStatus" OnInit="PostulacionStatus_Init" ></dx:ASPxImage>
                                            </DataItemTemplate>
					                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="cAprobado" VisibleIndex="1" Caption="-" Width="38">
						                    <DataItemTemplate>
                                                <dx:ASPxImage runat="server" ID="AprobacionStatus" OnInit="AprobacionStatus_Init" ></dx:ASPxImage>
                                            </DataItemTemplate>
					                    </dx:GridViewDataTextColumn> 
                                      <%-- <dx:GridViewDataTextColumn FieldName="cPerfil" Visible="true"  VisibleIndex="2" Caption="Tipo"  SortIndex="2" SortOrder="Ascending">
					                    </dx:GridViewDataTextColumn>--%>
                                    <dx:GridViewDataComboBoxColumn FieldName="cPerfil" Caption="Posición"  AdaptivePriority="1"  SortIndex="2" SortOrder="Ascending">
                                        <%--<PropertiesComboBox DataSourceID="CategoriesDataSource" ValueField="CategoryID" TextField="CategoryName" ValueType="System.Int32" />--%>
                                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" />
                                        <SettingsHeaderFilter ListBoxSearchUISettings-EditorNullText="Ingrese Texto a Buscar" Mode="List" ListBoxSearchUISettings-UseCompactView="false"  />
                                    </dx:GridViewDataComboBoxColumn>

                                    <%-- INI DATOS POSTULACION--%>
                                    <dx:GridViewBandColumn Caption="Datos de Postulación" HeaderStyle-CssClass="HeaderColTiny">
                                        <Columns>

                                        <dx:GridViewDataTextColumn FieldName="cTipoPostulacion" Visible="true"  VisibleIndex="3" Caption="Tipo" Width="60" HeaderStyle-CssClass="HeaderColTiny">
					                        <DataItemTemplate>
                                                <dx:ASPxImage runat="server" ID="TipoPostulacionStatus" OnInit="TipoPostulacionStatus_Init" ></dx:ASPxImage>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cDNI" Visible="true"  VisibleIndex="3" Caption="DNI" Width="70"  HeaderStyle-CssClass="HeaderColTiny">
					                    </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="cNomCompleto" Visible="true"  VisibleIndex="3" Caption="Apellidos y Nombres"  HeaderStyle-CssClass="HeaderColTiny">
					                    </dx:GridViewDataTextColumn>
                                    <dx:GridViewDataTextColumn FieldName="cFono" Visible="true"  VisibleIndex="3" Caption="Fono" Width="100"  HeaderStyle-CssClass="HeaderColTiny">
					                    </dx:GridViewDataTextColumn>
                               
                                        <dx:GridViewDataTextColumn FieldName="dFechaCargaCV" Visible="true"  VisibleIndex="3" Caption="F. CV" Width="80"  HeaderStyle-CssClass="HeaderColTiny" >
					                    </dx:GridViewDataTextColumn>
                                     
                                     <dx:GridViewDataTextColumn FieldName="iCantCuestionarioPostulante" VisibleIndex="3" Caption="KQ" Width="40"  HeaderStyle-CssClass="HeaderColTiny">
						                    <DataItemTemplate>
                                                <dx:ASPxImage runat="server" ID="CuestionarioStatus" OnInit="CuestionarioStatus_Init" ></dx:ASPxImage>
                                            </DataItemTemplate>
					                    </dx:GridViewDataTextColumn>
                                     <dx:GridViewDataTextColumn FieldName="nRanking" Visible="true"  VisibleIndex="3" Caption="Rank"  Width="70" SortIndex="3" SortOrder="Descending"    HeaderStyle-CssClass="HeaderColTiny">
					                    <PropertiesTextEdit DisplayFormatString="p0" />
                                     </dx:GridViewDataTextColumn>

                                            </Columns>
                                            <HeaderStyle HorizontalAlign="Center" />
                                        </dx:GridViewBandColumn>
                                   <%-- FIN DATOS POSTULACION--%>

                                        <dx:GridViewDataTextColumn FieldName="iCodCandidatoInforme" Visible="false"  VisibleIndex="4">
					                    </dx:GridViewDataTextColumn>
                                      <dx:GridViewDataTextColumn FieldName="iPrioridadPostulacion" Visible="true" Width="0"  VisibleIndex="4" SortIndex="1" Settings-SortMode="Value" SortOrder="Ascending" >
					                    </dx:GridViewDataTextColumn>
   </Columns>

          <FormatConditions>
              
         <%--   <dx:GridViewFormatConditionColorScale FieldName="nRanking" Format="BlueWhiteRed" />
            <dx:GridViewFormatConditionIconSet FieldName="nRanking" Format="Ratings4" />--%>
            
                          <dx:GridViewFormatConditionHighlight FieldName="nRanking" Expression="[nRanking] <=0.4" Format="LightRedFillWithDarkRedText" />
                             <dx:GridViewFormatConditionHighlight FieldName="nRanking" Expression="[nRanking] >0.4" Format="YellowFillWithDarkYellowText" />
                    <dx:GridViewFormatConditionHighlight FieldName="nRanking" Expression="[nRanking] =1" Format="GreenFillWithDarkGreenText" />
        </FormatConditions>

                                                </dx:ASPxGridView>
                                            </div>
                                             


                          </div>
                          <%--********* END CONTENT FORM MAIN *********--%>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
              </dx:PopupWindow>
          </Windows>
      </dx:ASPxPopupControl>



      <%-- ***************************** SECCION POPUPS CESE ***************************** --%>
        <dx:ASPxPopupControl ID="PopupFormMainCliDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormMainCliDetalle" 
        PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1240" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Feedback" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="divFormFeedbackEdit">
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormLayoutPopupDetalle" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                                                               	
                                      
                                       <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="Condiciones de Contratación"  >
                                          <Items>
                                              <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Apellidos y Nombres" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cNomCompleto" ClientInstanceName="cNomCompleto" runat="server"  />                                                                   
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem> 
                                              <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Puesto al que Postula" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cPerfil" ClientInstanceName="cPerfil" runat="server"  />                                                                   
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem> 
                                              <dx:LayoutGroup ColCount="2" SettingsItemCaptions-Location="Top" GroupBoxStyle-Caption-OffsetY="12"   Width="55%" GroupBoxStyle-Caption-Paddings-PaddingBottom="10"    
                                                   GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Datos del Postulante">
                                                    <GroupBoxStyle>
                                                        <Caption Font-Bold="true" Font-Size="12" />
                                                    </GroupBoxStyle>
                                                  <Items>
                                                      <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Tipo Postulación" CaptionStyle-Font-Bold="true" >
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cTipoPostulacion" ClientInstanceName="cTipoPostulacion" runat="server"  />                                                                   
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
								                        <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Fecha Carga CV" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="dFechaCargaCV" ClientInstanceName="dFechaCargaCV"  runat="server"   /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                         
                                                        <%--***ITEM FORM ***--%>
								                       <%-- <dx:LayoutItem Caption="Apellidos" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cApellidos" ClientInstanceName="cApellidos" runat="server"  />                                                                   
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
								                      
								                        <dx:LayoutItem Caption="Nombres" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cNombres" ClientInstanceName="cNombres"  runat="server"   /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem> --%>
                                                        <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Fono de Contacto" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cFono" ClientInstanceName="cFono"  runat="server"  /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                      <%--***ITEM FORM ***--%>
								                      <%--  <dx:LayoutItem Caption="Horario Disponibilidad" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cHorarioDisp" ClientInstanceName="cHorarioDisp"  runat="server"    /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>--%>
                                                      <%--***ITEM FORM ***--%>
								                        <%--<dx:LayoutItem Caption="Dpto. Nacimiento" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cRegionNac" ClientInstanceName="cRegionNac"  runat="server"  /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>--%>

                                                      <%--***ITEM FORM ***--%>
								                        <%--<dx:LayoutItem Caption="Dpto. Residencia" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cRegionDom" ClientInstanceName="cRegionDom"  runat="server"   /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>--%>
                                                       <%--***ITEM FORM ***--%>
								                        <%--<dx:LayoutItem Caption="Fecha Nacimiento" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="dFechaNacimiento" ClientInstanceName="dFechaNacimiento"  runat="server"   /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>--%>
                                                       <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Edad" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="iEdad" ClientInstanceName="iEdad"  runat="server"  /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                       <%--***ITEM FORM ***--%>
								                       <%-- <dx:LayoutItem Caption="Laboró en EECC de AAQ" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cLaboroAAQ" ClientInstanceName="cLaboroAAQ"  runat="server" /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>--%>
                                                       <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Correo" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cCorreo" ClientInstanceName="cCorreo"  runat="server" /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>

                                                       <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
<%--                                                                    <dx:ASPxHyperLink ID="ASPxHyperLink1" ClientInstanceName="cUrlHojaVida" runat="server" Text="Ver Hoja de Vida" NavigateUrl="https://www.google.com" Target="_blank">--%>
                                                                <%--    </dx:ASPxHyperLink>--%>
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Ocupación 01" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cOcupacionPrincipal" ClientInstanceName="cOcupacionPrincipal"  runat="server" /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                       <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Tiempo Exp. Ocup. 01" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="iTiempoOcupacionPrincipal" ClientInstanceName="iTiempoOcupacionPrincipal"  runat="server"  /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>

                                                       <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Ocupación 02" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="cOcupacionAlterna" ClientInstanceName="cOcupacionAlterna"  runat="server" /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                       <%--***ITEM FORM ***--%>
								                        <dx:LayoutItem Caption="Tiempo Exp. Ocup. 02" CaptionStyle-Font-Bold="true">
									                        <LayoutItemNestedControlCollection>
										                        <dx:LayoutItemNestedControlContainer>
											                        <dx:ASPxLabel ID="iTiempoOcupacionAlterna" ClientInstanceName="iTiempoOcupacionAlterna"  runat="server"  /> 
										                        </dx:LayoutItemNestedControlContainer>
									                        </LayoutItemNestedControlCollection>
								                        </dx:LayoutItem>
                                                  </Items>
                                              </dx:LayoutGroup>
                                               <dx:LayoutGroup ColCount="1" SettingsItemCaptions-Location="Top" GroupBoxStyle-Caption-OffsetY="12"   Width="43%"   GroupBoxStyle-Caption-Paddings-PaddingBottom="10"   
                                                   GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Resultados">
                                                    <GroupBoxStyle>
                                                        <Caption Font-Bold="true" Font-Size="12" />
                                                    </GroupBoxStyle>
                                                   
                                                <Items>
                                                 <dx:LayoutItem Caption="Resultado de la Evaluación"  CaptionStyle-Font-Bold="true">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
                                                               <dx:ASPxCheckBox ID="cSeleccionado" ClientInstanceName="cSeleccionado"  Text="---" runat="server" ValueType="System.String" Checked="false" ToggleSwitchDisplayMode="Always" ValueChecked="SI" ValueUnchecked="NO">
                                                                    <ClientSideEvents ValueChanged="OnValueChanged_cSeleccionado"  />
                                                                </dx:ASPxCheckBox>                                                                                                                      
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                             <%--***ITEM FORM ***--%>
													<%--<dx:LayoutItem Caption="Tipo Respuesta">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="cRptaContratas" runat="server" ValueType="System.String" ClientInstanceName="cRptaContratas">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >                                                                   
<RequiredField IsRequired="True"></RequiredField>
                                                                     </ValidationSettings>
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>--%>
											
                                                    <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Respuesta" CaptionStyle-Font-Bold="true">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                  <dx:ASPxComboBox ID="cRptaContrata" runat="server" ValueType="System.String" ClientInstanceName="cRptaContrata">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Anotaciones" CaptionStyle-Font-Bold="true">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                <dx:ASPxMemo ID="cObs" runat="server" Height="62px" Width="100%" CssClass="toUpper" ClientInstanceName="cObs"></dx:ASPxMemo>
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
                                                                      <dx:ASPxButton ID="BtnGuardarDetalle" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarDetalle" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnGuardarFeedbackClickDetalle" />
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



        <%--******** POPUP NOTIFICATIONS **********************************************************--%>
      <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server"  ClientInstanceName="PopupAlertMessage"
         Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" 
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje" >
                 <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content" >
                         
                      </dx:PopupControlContentControl>
                  </ContentCollection>               
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
                                                <dx:ASPxWebDocumentViewer  Height="480"  ID="WebReportViewer" runat="server" DisableHttpHandlerValidation="False">
                                                        <%--<ClientSideEvents Init="OnInit" />--%>
                                  
                                                </dx:ASPxWebDocumentViewer>
                                                         
                                            </div>
                                    </dx:PanelContent>  
                                </PanelCollection>  
                            </dx:ASPxCallbackPanel>  
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
      </dx:ASPxPopupControl>



    <%--********************** POPUP CONFIRMA FEEDBACK MASIVO ******************************* --%>
    
      <dx:ASPxPopupControl ID="PopupFeedbackMasivoNoCumple" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupFeedbackMasivoNoCumple"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="LayoutPopupFeedbackMasivoNoCumple" CssClass="formLayout" ClientInstanceName="LayoutPopupFeedbackMasivoNoCumple" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="¿ Seguro de marcar como NO SELECCIONADO - NO CUMPLE EL PERFIL CURRICULAR a todas las personas por debajo del ranking (100%). ?">
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
                                                              <dx:ASPxButton ID="BtnFeedbackMasivoNoCumple" runat="server" Text="Procesar" Width="60"   ClientInstanceName="BtnFeedbackMasivoNoCumple" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="BtnFeedbackMasivoNoCumple_Click" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                          <td>
                                                              <dx:ASPxButton ID="BtnFeedbackMasivoNoCumpleCancelar" runat="server" Text="Cancelar" Width="60" ClientInstanceName="BtnFeedbackMasivoNoCumpleCancelar" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="BtnFeedbackMasivoNoCumpleCancelar_Click">
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



    
     <%-- ***************************** SECCION POPUPS CONFIG REPORT***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormFeedbackMasivo" runat="server" Modal="True" ClientInstanceName="PopupFormFeedbackMasivo" 
        PopupElementID="PopupFormFeedbackMasivoID" PopupHorizontalAlign="WindowCenter" Width="780" PopupVerticalAlign="WindowCenter" 
        MaxWidth="780"   MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Feedback Masivo :: Respuesta" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupFeedbackMasivo" CssClass="formLayout" ClientInstanceName="FormLayoutPopupFeedbackMasivo"  >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                                                                       	
                                      
                                       <dx:LayoutGroup ColCount="1" ParentContainerStyle-Paddings-PaddingBottom="20px"  GroupBoxDecoration="None" UseDefaultPaddings="true" Caption="">
                                          <Items>
                                              <%--***ITEM FORM ***--%>
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Perfil a Validar" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															
                                                                <dx:ASPxComboBox ID="iCodOcupacionMasivo" runat="server"  autocomplete="off"  
                                                                    ClientInstanceName="iCodOcupacionMasivo" ValueType="System.Int32" ValueField="iCodConvocatoria"
                                                                    TextFormatString="{1}" Font-Size="Small">  
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic"  >
                                                                    <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                    <Columns>  
                                                                        <dx:ListBoxColumn Caption="iCodConvocatoria" FieldName="iCodConvocatoria"  width="0px"    />
                                                                         <dx:ListBoxColumn Caption="Perfil" FieldName="cPerfil" Width="100%"  />
                                                                         <dx:ListBoxColumn Caption="Revis" FieldName="iRevisados" Width="35px"  />
                                                                        <dx:ListBoxColumn Caption="Selec" FieldName="iSeleccionados"  Width="35px"  />
                                                                        <dx:ListBoxColumn Caption="Aprob" FieldName="iAprobados" Width="35px"   />
                                                                        <dx:ListBoxColumn Caption="Total" FieldName="iTotalForm" width="0px" />
                                                                    </Columns>  
                                                                </dx:ASPxComboBox>  
                                                               
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>      
                                              
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Respuesta Masiva:">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>											
                                                                <dx:ASPxComboBox ID="cRptaContrataMasivo" runat="server" ClientInstanceName="cRptaContrataMasivo"   ValueType="System.String">
                                                                      <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                      </ValidationSettings>
                                                                    <Items>
                                                                        <dx:ListEditItem Text="PLAZA COBERTURADA POR LOCAL" Value="PLAZA COBERTURADA POR LOCAL" />
                                                                        <dx:ListEditItem Text="PROCESO DE SELECCION PARALIZADO" Value="PROCESO DE SELECCION PARALIZADO" />
                                                                    </Items>
                                                                </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>    
                                              
                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                             <table class="OAELStat" style="margin-top:12px!important; float:left;">
                                                              <tr>
                                                                  <td style="padding-right: 20px; padding-top:2px;">
                                                                       <b>PLAZA COBERTURADA POR LOCAL - </b>Solo aplica cuando la cantidad de personas aprobadas
                                                                      es igual a la cantidad de personas solicitadas.<br />
                                                                      <b>PROCESO DE SELECCION PARALIZADO - </b> Solo aplica si la cantidad de expedientes seleccionados es cero(0).
                                                                  </td>
                                                                  
                                                              </tr>
                                                          </table>
                                                          
                                                      </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>                   											
                                          </Items>

<ParentContainerStyle>
<Paddings PaddingBottom="20px"></Paddings>
</ParentContainerStyle>
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
                                                                      <dx:ASPxButton ID="BtnGuardarFeedbackMasivo" runat="server" Text="Guardar Respuestas" Width="120px" ClientInstanceName="BtnGuardarFeedbackMasivo" AutoPostBack="false">
                                                                          <ClientSideEvents Click="BtnGuardarFeedbackMasivo_Click" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCerrarFormFeedbackMasivo" runat="server" Text="Cerrar" Width="100" ClientInstanceName="BtnCerrarFormFeedbackMasivo" AutoPostBack="false">
                                                                          <ClientSideEvents Click="BtnCerrarFormFeedbackMasivo_Click">
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
    





</asp:Content>
