<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmAnexoAdmision.aspx.vb" Inherits="GTWebOAEL.FrmAnexoAdmision" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <%--<script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js" ></script>--%>
        <script type="text/javascript" src="../_GTJScript/AnexoAdmision.js" ></script> <%--MODIFICAR--%>
          <script type="text/javascript" src="../_GTJScript/_GTHandleMainDetalle.js" ></script>  <%--MODIFICAR--%>

  <script type="text/javascript" src="../_GTJScript/_GTMainCore.js" ></script>  

    <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js" ></script>  <%--MODIFICAR--%>

     <script type="text/javascript" > 
         // ************* FUNCTIONS CUSTOM 
         //************* PERSONALIZADO
         //ValidationExpression = "^[a-zA-Z0-9_]*$"
         //<RegularExpression ValidationExpression="^[^-\s][a-zA-Z0-9_\s-]+$" ErrorText="" />
         function OnToolbarItemClickCustomMain(s, e) {

             if (IsCustomExportToolbarCommand(e.item.name)) {
                 e.processOnServer = true;
                 e.usePostBack = true;
             }

             if (e.item.name == "BtnAgregar") {
                 iCodRegistro.SetText("0");
                 BtnGuardar.SetEnabled(true);
                 BtnConfirmarEnviar.SetEnabled(false);
                 BtnImprimirFormatoPGI.SetEnabled(false);
                 iCodContratistaContrato.SetEnabled(true);

                 
                 iCodAnexoAdmisionTipo.SetEnabled(false);
                 //BtnGuardarEnviar.SetEnabled(false);
                 cFormMetadata.Set("cTipoOpe", "A");
                 ClearContentControls();

               
                 FormMainModalShow();
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEditar") {
                 cFormMetadata.Set("cTipoOpe", "M");
                 iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                 iCodAnexoAdmisionTipo.SetEnabled(false);
                 ClearContentControls();
                 viewRecord();
                 //var text = cEstado.GetText();
                 //alert("a " + text);
                 //alert(cEstado.GetText());
                 //cFormMetadata.Set("pEstado", text);
                 FormMainModalShow();
                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEliminar") {
                 var popupWindow = PopupConfirmDelete.GetWindow(0);
                 PopupConfirmDelete.ShowWindow(popupWindow);
                
                 //PopupConfirmDelete.ShowAtPos(document.documentElement.clientWidth, document.documentElement.clientHeight);
                 //setTimeout(function () { PopupConfirmDelete.Hide(); }, 4000);
                 e.processOnServer = false;
             }
         }

         function OnBtnGuardarClickCustom(s, e) {
             if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
                 s.SetEnabled(false);
                 CallBackFunction.PerformCallback();

                 BtnConfirmarEnviar.SetEnabled(true);

                 //ShowAlertMessage('Registro guardado con éxito.');
             }
             else {
                 e.processOnServer = false;
             }
         }


         function OnEndCallBackFunctionCustom(s, e) {


             var Resultado = e.result;

             if (Resultado != "OK") {

             }
             CloseFormMainModal(e.result);
             TablaRegistros.PerformCallback();
             BtnGuardar.SetEnabled(true);


         }

         function OnGridFocusedRowChangedCustomMain(s, e) {
             //cEstadoMain.SetText("");
             iCodRegistro.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
           
             //s.GetRowValues(s.GetFocusedRowIndex(), 'cEstado', OnGetRowValueEstado);
             e.processOnServer = false;

         }

         function iCodContratistaContrato_SelectedIndexChanged(s, e) {
                    
             //var item = s.GetSelectedItem();
             //var tipoContrato = item.GetColumnText(0).substring(0, 3);
             //if (tipoContrato == 'AAQ') {
             //    iCodAnexoAdmisionTipo.SetValue(15);
             //}
             //else {
             //    iCodAnexoAdmisionTipo.SetValue(1);
             //}
             //iCodAnexoAdmisionTipo.SetValue(15);
             //iCodAnexoAdmisionTipo.SetEnabled(false);
             //tipoContrato = null;
         }
         function iCodAnexoAdmisionTipo_SelectedIndexChanged(s, e) {
            

             //var iRow = s.GetSelectedIndex();
             //iCodAnexoAdmisionTipoDet.SetSelectedIndex(iRow);

          
         }
      



         //**************** DETALLE ************************
        
         function OnToolbarItemClickDetalleCustom(s, e) {
             if (IsCustomExportToolbarCommand(e.item.name)) {
                 e.processOnServer = true;
                 e.usePostBack = true;
             }
             //TablaRegistrosDetalle.PerformCallback('clear');

             if (e.item.name == "BtnAgregarDetalle") {

                 $("#oaelCondicion").html("");
                 $("#oaelExpediente").html("");
                 $("#oaelEmpresa").html("");
                 $("#pgiData").html("");
                 $("#pgiFecha").html("");
                 BtnGuardarDetalle.SetEnabled(false);
                 cDNI.SetEnabled(true);

                 var pContrata = (cFormMetadata.Get('iCodSubContrata'));
                 iCodSubContrata.SetValue(pContrata);

                 iCodRegistroDetalle.SetText("0");
                 iCodCandidatoInforme.SetText("0");
                 cFormMetadata.Set("cTipoOpeDetalle", "A");
                 cTipoDoc.SetSelectedIndex(0);

                 //Tipo de Anexo
                 //var pCodTipoAnexo = iCodAnexoAdmisionTipo.GetText();
                 //iCodAnexoAdmisionTipoDet.SetText(pCodTipoAnexo);

                 ClearContentControlsDetalle();
                 FormMainModalShowDetalle();
                 e.processOnServer = false;


             }
             else if (e.item.name == "BtnEditarDetalle") {
                 $("#oaelCondicion").html("");
                 $("#oaelExpediente").html("");
                 $("#oaelEmpresa").html("");
                 $("#pgiData").html("");
                 $("#pgiFecha").html("");
                 cDNI.SetEnabled(false);

                 cFormMetadata.Set("cTipoOpeDetalle", "M");
                 iCodRegistroDetalle.SetText(TablaRegistrosDetalle.GetRowKey(TablaRegistrosDetalle.GetFocusedRowIndex()));
                 if (iCodRegistroDetalle.GetValue() != null) {
                     ClearContentControlsDetalle();
                     viewRecordDetalle();
                     FormMainModalShowDetalle();
                 }

                 e.processOnServer = false;
             }
             else if (e.item.name == "BtnEliminarDetalle") {
                 var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
                 PopupConfirmDeleteDetalle.ShowWindow(popupWindow);

                 e.processOnServer = false;
             }
         }

         function OnEndCallBackFunctionDetalleCustom(s, e) {
             //alert("cerrar");
             CloseFormMainModalDetalle();
             TablaRegistrosDetalle.PerformCallback('load');
         }
         function OnBtnGuardarEnviarClick(s, e) {
             //if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
             CallBackFunctionEnvio.PerformCallback();
             var popupWindow = PopupConfirmarEnvio.GetWindow(0);
             PopupConfirmarEnvio.HideWindow(popupWindow);

             //}
             //else {
                 e.processOnServer = false;
             //}
         }
         function OnBtnConfirmarEnviarClick(s, e) {
             var popupWindow = PopupConfirmarEnvio.GetWindow(0);
             PopupConfirmarEnvio.ShowWindow(popupWindow);
                 e.processOnServer = false;
              
         }  
         function OnBtnCancelarEnviarClick(s, e) {
             var popupWindow = PopupConfirmarEnvio.GetWindow(0);
             PopupConfirmarEnvio.HideWindow(popupWindow);
             e.processOnServer = false;
              
         }
       
       
          
         function OnBtnImprimirFormatoPGIClick(s, e) {
             
             CallBackPanelReport.PerformCallback("PGI");
             PopupFormReportes.ShowWindow();
             e.processOnServer = false;
            
         }
         function OnEndCallBackFunctionEnvio(s, e) {
             //textBox.SetText(e.result); DEFINIR ALGUN MENSAJE
             //var popupWindow = PopupConfirmDelete.GetWindow(0);
             //PopupConfirmDelete.HideWindow(popupWindow);
             if (e.result == 'OK') {
                 //var popupWindow = PopupFormMainCli.GetWindow(0);
                 //PopupFormMainCli.HideWindow(popupWindow);
                 
                 ShowAlertMessage('RDP Anexo 05 enviado a OAEL con éxito.');
                 BtnGuardar.SetEnabled(false);
                 BtnConfirmarEnviar.SetEnabled(false);
                 BtnImprimirFormatoPGI.SetEnabled(false);//cuando se envia a oael se deshabilita
                 iCodContratistaContrato.SetEnabled(false);

                 TablaRegistros.PerformCallback();
                 TablaRegistrosDetalle.PerformCallback('EnvioOAEL');
             }
             else {
                 ShowAlertMessage('Ocurrió un error durante el proceso.');
             }
            


         }
         function cOcupacion_SelectedIndexChanged(s, e) {
             //EditKmReason.PerformCallback(s.GetValue());         
             var item = s.GetSelectedItem();          
             cMOCMONC.SetValue(item.GetColumnText(0));
         }

         function cDNI_KeyPress(s, e) {
             if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122))
             { return true; }
             else {
                 ASPxClientUtils.PreventEvent(e.htmlEvent);
             }
             if (e.htmlEvent.keyCode == 13)
             {
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
     </script>
    <style>
        .infoColumna {
        /*padding:0px 3px;
       
        width:26px;*/

         border-radius: 4px;
    /*padding: 0.2em 1em;*/
    padding:1px 3px;
    margin-right: auto;
    text-align: center;
        }
        .cellCenter {
         text-align: center;
        }
    </style>
    <%-- ***************************** INI SECCION DATATABLE ***************************** --%>
      <div id="ContentTablaRegistros" style="padding:0px 15px 0px 15px;">
          <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
              <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCustom" />
          </dx:ASPxCallback>
          <dx:ASPxCallback ID="CallBackFunctionEnvio" runat="server" ClientInstanceName="CallBackFunctionEnvio">
              <ClientSideEvents CallbackComplete="OnEndCallBackFunctionEnvio" />
          </dx:ASPxCallback>
          <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True" 
            ClientVisible="False" ClientInstanceName="iCodRegistro">
          </dx:ASPxTextBox>
          <dx:ASPxTextBox ID="cEstadoMain" runat="server" Width="1px" Visible="True" 
            ClientVisible="False" ClientInstanceName="cEstadoMain">
            </dx:ASPxTextBox>
          <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
          </dx:ASPxHiddenField>
          <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros"  >
              <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCustomMain"   FocusedRowChanged="OnGridFocusedRowChangedCustomMain" 
                Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback" >
              </ClientSideEvents>
              <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
              </SettingsPager>
              <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="270"></Settings>

              <SettingsBehavior AllowFocusedRow="True" />
              <SettingsDataSecurity AllowDelete="False">
              </SettingsDataSecurity>
              <Settings ShowVerticalScrollBar="True" /> 
              <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
              <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
              <Toolbars>
                  <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                      <Items>
                          <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                              <ItemStyle HorizontalAlign="Right" Width="260px"></ItemStyle>
                              <Template>
                                  <div id="gtHeadTitle" style=""> <%--***  MODIFICAR ***--%>
                                      SOLICITUDES DE RDP ANEXO 05
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
                          <dx:GridViewToolbarItem Text="Editar" Name="BtnEditar">
                              <Image IconID="actions_edit_16x16devav">
                              </Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar">
                              <Image IconID="edit_delete_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="2" Command="Refresh" Name="BtnActualizar">
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
                   <dx:GridViewDataTextColumn FieldName="iCodAnexoAdmision" Visible="False"  VisibleIndex="0" Caption="ID">
					</dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="cGrupoContrato" VisibleIndex="1" Caption="Doc." Width="56"  CellStyle-HorizontalAlign="Center" >
						<DataItemTemplate>
                            <%--<dx:ASPxImage runat="server" ID="AnexoAdmisionTipoImg" OnInit="AnexoAdmisionTipoImg_Init" ></dx:ASPxImage>--%>
                            <dx:ASPxLabel runat="server" EncodeHtml="false" ID="AnexoAdmisionTipoImg" OnInit="AnexoAdmisionGrupoContratoImg_Init" CssClass="infoColumna">
                        </dx:ASPxLabel>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>  
                   <dx:GridViewDataTextColumn FieldName="cNroContrato" Visible="True"  VisibleIndex="2" Caption="Nro. Contrato">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="cCorrelativo" Visible="True"  VisibleIndex="2" Caption="Nro. Doc.">
					</dx:GridViewDataTextColumn>
                   <%--<dx:GridViewDataTextColumn FieldName="cTipo" Visible="True"  VisibleIndex="2" Caption="Tipo" Width="52" HeaderStyle-HorizontalAlign="Center"  CellStyle-CssClass="cellCenter">
					</dx:GridViewDataTextColumn>--%>
              <%--     <dx:GridViewDataTextColumn FieldName="cDetalle" Visible="True"  VisibleIndex="2" Caption="Motivo">
					</dx:GridViewDataTextColumn>--%>
                 <%--  <dx:GridViewDataTextColumn FieldName="dFechaSolicitud" Visible="True"  VisibleIndex="2" Caption="F.Solic.">
					</dx:GridViewDataTextColumn>--%>
                   <dx:GridViewDataDateColumn FieldName="cFechaUsuarioContrataEnvia" Visible="True" VisibleIndex="2" Caption="Enviado a OAEL">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>
                  <%--<dx:GridViewDataTextColumn FieldName="dFechaAprobacion" Visible="True"  VisibleIndex="2" Caption="F.Etapa">
					</dx:GridViewDataTextColumn>--%>
                  <dx:GridViewDataTextColumn FieldName="cEstado" Visible="True"  VisibleIndex="2" Caption="Estado OAEL" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                      <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="PGIStatus" OnInit="PGIStatus_Init" ></dx:ASPxImage>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>
               <%--   <dx:GridViewDataCheckColumn FieldName="bNotificado" Visible="True"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  CellStyle-HorizontalAlign="Center" Caption="Notificado a AAQ" Width="124">
					</dx:GridViewDataCheckColumn>
                   <dx:GridViewDataCheckColumn FieldName="bApruebaAreaAAQ" Visible="True"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  CellStyle-HorizontalAlign="Center" Caption="A. Usu. AAQ" Width="90">
					</dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="bAprobadoAAQ" Visible="True"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  CellStyle-HorizontalAlign="Center" Caption="AAQ" Width="66">
					</dx:GridViewDataCheckColumn>--%>
                 
              </Columns>
               
          </dx:ASPxGridView>
      </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>

    <%-- ***************************** SECCION POPUPS ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli" 
        PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1260" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="GTFormContentMain">
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      
                                       <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="Box" UseDefaultPaddings="false" Caption="">
                                          <Items>
                                              <dx:LayoutGroup ColCount="2" Width="40%"  GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="" SettingsItemCaptions-Location="Top">
                                                  <Items>
                                                        	 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Contrato">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																
                                                                <dx:ASPxComboBox ID="iCodContratistaContrato" runat="server" ValueType="System.String" ClientInstanceName="iCodContratistaContrato">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     <ClientSideEvents SelectedIndexChanged="iCodContratistaContrato_SelectedIndexChanged">
                                                                    </ClientSideEvents>
																 </dx:ASPxComboBox>
                                                                <dx:ASPxTextBox ID="cEstado" runat="server" Width="30px" Visible="True"
                                                                    ClientInstanceName="cEstado" ClientVisible="false" >
                                                                </dx:ASPxTextBox>
                                                                
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Formato">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                 <dx:ASPxComboBox ID="iCodAnexoAdmisionTipo" runat="server" ValueType="System.String" ClientInstanceName="iCodAnexoAdmisionTipo"   >
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                      <%--<ClientSideEvents SelectedIndexChanged="iCodAnexoAdmisionTipo_SelectedIndexChanged">
                                                                    </ClientSideEvents>--%>


																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<%--<dx:LayoutItem Caption="Nro Convocatoria">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>

																<dx:ASPxComboBox ID="iCodConvocatoriaMain" runat="server" ValueType="System.String" ClientInstanceName="iCodConvocatoriaMain">
                                                                    
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>--%>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Categoría">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>

																 <dx:ASPxComboBox ID="cGrupo" runat="server" ValueType="System.String" ClientInstanceName="cGrupo">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
											
												 <%--***ITEM FORM ***--%>
													<%--<dx:LayoutItem Caption="Nro Solicitud">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cNroAnexo" ClientInstanceName="cNroAnexo"  >
                                                                     <MaskSettings Mask="0000-0000"  IncludeLiterals="All" />
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>--%>
												
												 
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Solicitante">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cPersonaSolicita" ClientInstanceName="cPersonaSolicita"  >
																	  
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic"   />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Cargo">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cPersonaSolicitaCargo" ClientInstanceName="cPersonaSolicitaCargo"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic"   />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Area Usuaria AAQ">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cAreaUsuaria" ClientInstanceName="cAreaUsuaria"  >
                                                                    <ValidationSettings RequiredField-IsRequired="false" Display="Dynamic"  />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Notas" ColSpan="2" RowSpan="3" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																  
                                                                <dx:ASPxMemo ID="cNotas" runat="server" Height="120px" Width="100%" CssClass="toUpper" ClientInstanceName="cNotas">

                                                                </dx:ASPxMemo>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                      <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Obs. OAEL">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                <dx:ASPxMemo ID="cObsDocumento" runat="server" Height="120px" Width="100%" CssClass="Font80" ClientInstanceName="cObsDocumento" ReadOnly="true" Font-Size="Smaller" ReadOnlyStyle-BackColor="WhiteSmoke"></dx:ASPxMemo>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                      <dx:LayoutItem ShowCaption="False" CaptionStyle-ForeColor="DarkRed"  HorizontalAlign="Left" Width="100%" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																  
                                                                 <div style="color:darkred;font-weight:bold;"><span style="font-weight:bold;">Importante : </span>Exporte el Formato Aprobado, adjunte la <span style="font-size:1.2em;font-weight:bolder;">FIRMA</span> de su representante y proceda a subir el archivo a Web Control.</div>
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
                                                                      <dx:ASPxButton ID="BtnGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardar" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnGuardarClickCustom" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnConfirmarEnviar" runat="server" Text="Enviar a OAEL" Width="100px" ClientInstanceName="BtnConfirmarEnviar" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnConfirmarEnviarClick" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                   <td style="padding-right: 10px;">
                                                                      <dx:ASPxButton ID="BtnImprimirFormatoPGI" runat="server" Text="Exportar" Width="100px" ClientInstanceName="BtnImprimirFormatoPGI" AutoPostBack="false">
                                                                          <ClientSideEvents Click="OnBtnImprimirFormatoPGIClick" />
                                                                      </dx:ASPxButton>
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false"  >
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

                                              <%--***************************************************************--%>
                                              <%--                  NUEVA REJILLA DE DATOS--%>
                                              <%--***************************************************************--%>
                                             
                                               <dx:LayoutGroup ColCount="1" Width="59%"   GroupBoxDecoration="None"  UseDefaultPaddings="false" Caption="">
                                                  <Items>
                                                      <%--INICIO GRID VIEW--%>
                                                      <dx:LayoutItem Caption="" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																  <div id="ContentTablaRegistroDetalle" style="padding:0px 5px 0px 0px;">
                                                                      <dx:ASPxCallback ID="CallBackFunctionDetalle" runat="server" ClientInstanceName="CallBackFunctionDetalle">
                                                                          <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalleCustom" />
                                                                      </dx:ASPxCallback>    
                                                                                                                                       
                                                                     <dx:ASPxTextBox ID="iCodRegistroDetalle" runat="server" Width="170px" Height="1px" Visible="True" 
                                                                        ClientVisible="False" ClientInstanceName="iCodRegistroDetalle">
                                                                      </dx:ASPxTextBox>
                                                                      <dx:ASPxGridView ID="TablaRegistrosDetalle" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosDetalle"  >
                                                                          <ClientSideEvents ToolbarItemClick="OnToolbarItemClickDetalleCustom"   FocusedRowChanged="OnGridFocusedRowChangedDetalle" 
                                                                           >
                                                                          </ClientSideEvents>
                                                                          <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                                                                          </SettingsPager>
                                                                          <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="300"></Settings>

                                                                          <SettingsBehavior AllowFocusedRow="True" />
                                                                          <SettingsDataSecurity AllowDelete="False">
                                                                          </SettingsDataSecurity>
                                                                          <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                                          <Settings ShowVerticalScrollBar="True" /> 
                                                                           <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                                          <Toolbars>
                                                                              <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right" Name="ToolbarGridDetalle">
                                                                                  <Items>
                                                                                      <%--<dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                                                                                          <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
                                                                                          <Template>
                                                                                              <div id="gtHeadTitle" style="">
                                                                                                  PERFILES DE PUESTO
                                                                                              </div>

                                                                                          </Template>

                                                                                      </dx:GridViewToolbarItem>--%>
                                                                                      <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">  
                                                                                            <Template>  
                                                                                                <div id="div100Percent"></div>  
                                                                                            </Template>  
                                                                                        </dx:GridViewToolbarItem>  
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnAgregarDetalle">
                                                                                          <Image IconID="actions_new_16x16office2013">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnEditarDetalle">
                                                                                          <Image IconID="actions_edit_16x16devav">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem Name="BtnEliminarDetalle" Text="">
                                                                                          <Image IconID="edit_delete_16x16office2013"></Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      
                                                                                       
                                                                                  </Items>
                                                                              </dx:GridViewToolbar>
                                                                          </Toolbars>
                                                                          <Columns>
                                                                                    <dx:GridViewDataTextColumn FieldName="iCodAnexoAdmisionDetalle" Visible="False"  VisibleIndex="0" Caption="-">
					                                                                </dx:GridViewDataTextColumn>  
                                                                                   <dx:GridViewDataTextColumn FieldName="cProcesoEtapa" Visible="True"  VisibleIndex="2" Caption="-" Width="30">
                                                                                        <PropertiesTextEdit EncodeHtml="false"></PropertiesTextEdit> 
					                                                                </dx:GridViewDataTextColumn>
                                                                                   <dx:GridViewDataTextColumn FieldName="cNomCompleto" Visible="True"  VisibleIndex="2" Caption="Datos del Postulante">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cDNI" Visible="True"  VisibleIndex="2" Caption="Nro Doc." Width="75">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cModIngreso" Visible="True"  VisibleIndex="2" Caption="ModIngr." CellStyle-Font-Size="X-Small" Width="64">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cCargo" Visible="True"  VisibleIndex="2" Caption="Cargo" CellStyle-Font-Size="XX-Small">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cMOCMONC" Visible="True"  VisibleIndex="2" Caption="MMOO" Width="56" CellStyle-Font-Size="X-Small">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cCondicion" Visible="True"  VisibleIndex="2" Caption="Condición" Width="74" CellStyle-Font-Size="X-Small">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="Doc" Visible="True"  VisibleIndex="2" Caption="Doc" Width="34" CellStyle-Font-Size="X-Small">
					                                                                </dx:GridViewDataTextColumn>
                                                                                

                                                                          </Columns>
                                                                           <FormatConditions>          
                                                                               <dx:GridViewFormatConditionHighlight FieldName="cProcesoEtapa" Expression="[cProcesoEtapa] = 'O'" Format="YellowFillWithDarkYellowText"/>
                                                                               <dx:GridViewFormatConditionHighlight FieldName="cProcesoEtapa" Expression="[cProcesoEtapa] = 'R'" Format="LightRedFillWithDarkRedText"/>
                                                                               <dx:GridViewFormatConditionHighlight FieldName="cProcesoEtapa" Expression="[cProcesoEtapa] = 'A'" Format="GreenFillWithDarkGreenText"/>
                                                                               <dx:GridViewFormatConditionHighlight FieldName="cProcesoEtapa" Expression="[cProcesoEtapa] = 'P'" Format="Custom" >
                                                                             <%--  <RowStyle BackColor="#0066FF" ForeColor="White" />  --%>
                                                                                   <CellStyle BackColor="White" ForeColor="Black" /> 
                                                                                </dx:GridViewFormatConditionHighlight> 
                                                                            </FormatConditions>
                                                                      </dx:ASPxGridView>
                                                                  </div>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                                      <%--FIN DE GRID VIEW--%>
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
              <dx:PopupControlContentControl runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>
          <ClientSideEvents Closing="function(s, e) {
	ClearContentControls();
              
}"           Shown="function(s,e){
               TablaRegistrosDetalle.PerformCallback('LoadPrimera');
            
              }" >
              
          </ClientSideEvents>
      </dx:ASPxPopupControl>
      <dx:ASPxPopupControl ID="PopupConfirmDelete" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDelete"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación" 
                  HeaderStyle-CssClass="AlertSuccess">
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
    <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server"  ClientInstanceName="PopupAlertMessage"
         Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" 
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje" >
                 <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content" >
                         
                      </dx:PopupControlContentControl>
                  </ContentCollection>               
      </dx:ASPxPopupControl>
    <%--******** POPUP NOTIFICATIONS **********************************************************--%>
     <dx:ASPxPopupControl ID="PopupNotification" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupNotification"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Mensaje" HeaderStyle-Font-Size="Small">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopup" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="¿ Seguro de borrar el registro seleccionado. ?">
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
                                                              <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Si" Width="60"   ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="DeleteRecord" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                          <td>
                                                              <dx:ASPxButton ID="ASPxButton2" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancel" AutoPostBack="false" >
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
    <%--====================================== FORMS DETALLE ======================================--%>

        <%-- ***************************** SECCION POPUPS DETALLE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormMainCliDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormMainCliDetalle" 
        PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1240" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Colaborador" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormLayoutPopupDetalle" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      
                                       <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="Box" UseDefaultPaddings="false" Caption="">
                                          <Items>
                                             
                                                        	 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Nro. Doc. Id.">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															 <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True" 
                                                                        ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
                                                                      </dx:ASPxTextBox>
                                                                 <dx:ASPxButtonEdit ID="cDNI" runat="server" NullText="Buscar..."  ClientInstanceName="cDNI"  ClientSideEvents-ButtonClick="cDNI_OnButtonClick" AutoPostBack="false">
                                                                       <%--<ClientSideEvents KeyPress="function(s, e) {  if( (e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90)  || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122) ) {  return true; } else {  ASPxClientUtils.PreventEvent(e.htmlEvent); } }" />--%>  
                                                                       <ClientSideEvents KeyPress="cDNI_KeyPress" 
                                                                            LostFocus="function(s, e) {s.Validate();}" 
                                                                            Validation="cDNI_Validation" 
                                                                            />  
                                                                      
                                                                     <ValidationSettings RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip" ErrorText="Cantidad de caracteres inválido" Display="Dynamic"  />
                                                                               

                                                                     <Buttons>
                                                                          <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
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
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>
                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

										            <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Apellidos">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cApellidos" ClientInstanceName="cApellidos" CssClass="toUpper"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Nombres">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																<dx:ASPxTextBox runat="server" ID="cNombres" ClientInstanceName="cNombres" CssClass="toUpper"  >
																	<ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																</dx:ASPxTextBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
											
												<%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Ocupación">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
															
                                                                <dx:ASPxComboBox ID="cOcupacion" runat="server"
                                                                    ValueField="iCodOcupacion"  ValueType="System.Int32"  TextFormatString="{1}" ClientInstanceName="cOcupacion" >
                                                                    <ClientSideEvents SelectedIndexChanged="cOcupacion_SelectedIndexChanged">

                                                                    </ClientSideEvents>
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     <Columns>
                                                                         <dx:ListBoxColumn Caption="ID" FieldName="iCodOcupacion" Width="1%" Visible="false" />
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
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     <Items>                                                                          
                                                                        <dx:ListEditItem Text="MOC" Value="MOC" />                                                                        
                                                                        <dx:ListEditItem Text="MONC" Value="MONC" />  
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
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

												 <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Condicion">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 

                                                                 <dx:ASPxComboBox ID="cCondicion" runat="server" ValueType="System.String" ClientInstanceName="cCondicion">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
												
                                              	 
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Sub Contratista">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="iCodSubContrata" runat="server" ValueType="System.String" ClientInstanceName="iCodSubContrata">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />                                                                   
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                             
                                              <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Modalidad Ingr.">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                 <dx:ASPxComboBox ID="iCodAnexoAdmisionTipoDet" runat="server" ValueType="System.String" ClientInstanceName="iCodAnexoAdmisionTipoDet">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>

                                                
                                              
												<%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Notas">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                <dx:ASPxMemo ID="cNota" runat="server" Height="62px" Width="100%" CssClass="toUpper" ClientInstanceName="cNota"></dx:ASPxMemo>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>


                                              
												<%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Obs">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																 
                                                                <dx:ASPxMemo ID="cObs" runat="server" Height="62px" Width="100%" CssClass="toUpper" ClientInstanceName="cObs" ReadOnly="true" Font-Size="Smaller" ReadOnlyStyle-BackColor="WhiteSmoke"></dx:ASPxMemo>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>


                                                <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" >
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                           <table class="OAELStat" style="">
                                                              <tr>
                                                                  <td style="padding-right: 15px; padding-top:4px;">
                                                                       <span id="oaelCondicion">
                                                                          asd
                                                                      </span>
                                                                      <span id="oaelExpediente">
                                                                        asd
                                                                      </span>
                                                                     <%-- <span id="oaelFFLL">
                                                                        asd
                                                                      </span>--%>
                                                                     
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


                                               <%--*** COMMANDS BUTTON ***--%>
                                              <dx:LayoutItem ShowCaption="False" >
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                           <table class="OAELStat" style="">
                                                              <tr>
                                                                  <td style="padding-right: 15px; padding-top:4px;">
                                                                      <%-- <span id="pgiLabel">
                                                                          INFORMACIÓN :
                                                                      </span>--%>
                                                                      <span id="pgiData">
                                                                        
                                                                      </span>
                                                                    
                                                                     
                                                                     <span id="pgiFecha">
                                                                          
                                                                      </span>
                                                                      
                                                                      
                                                                  </td>
                                                                  
                                                              </tr>
                                                          </table>
                                                       </dx:LayoutItemNestedControlContainer>
                                                  </LayoutItemNestedControlCollection>
                                              </dx:LayoutItem>
												 
                                            

                                              <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%"  >
                                                  <LayoutItemNestedControlCollection>
                                                      <dx:LayoutItemNestedControlContainer>
                                                         
                                                          <table  style="margin-top:12px!important;">
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
              <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
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
                      <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
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


     
      <%-- ***************************** SECCION POPUPS REPORTE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportes" runat="server" Modal="True" ClientInstanceName="PopupFormReportes" 
        PopupElementID="PopupFormReportes" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="RDP Anexo 05 - PGI: Enviar el formato FIRMADO en PDF para su aprobación en Web Control."  >
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
                                                        
                                  
                                                </dx:ASPxWebDocumentViewer>                                                 
                                            </div>
                                    </dx:PanelContent>  
                                </PanelCollection>  
                            </dx:ASPxCallbackPanel>  
                          </div>
                      </dx:PopupControlContentControl>
                  </ContentCollection>
      </dx:ASPxPopupControl>
    

        <%-- ******************************** POPUP DETALLE CONFIRM MODAL ********************************************** --%>
     <dx:ASPxPopupControl ID="PopupConfirmarEnvio" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmarEnvio"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout2" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupEnvio" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="¿ Seguro de enviar el PGI a revisión de OAEL. ?">
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
                                                              <dx:ASPxButton ID="BtnGuardarEnviar" runat="server" Text="Si" Width="60"   ClientInstanceName="BtnGuardarEnviar" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="OnBtnGuardarEnviarClick" />
                                                              </dx:ASPxButton>
                                                          </td>
                                                           
                                                          <td>
                                                              <dx:ASPxButton ID="BtnCancelarEnviar" runat="server" Text="No" Width="60" ClientInstanceName="BtnCancelarEnviar" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="OnBtnCancelarEnviarClick">
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

    <!-- FORMULARIO DE OBSERVACIONES -->
    <style type="text/css">
        .InfoTable td
        {
            padding: 0 4px;
            vertical-align: top;
            font-size:0.9em;
            color:#666;
        }
    </style>
    <script type="text/javascript">
        var keyValue;
        function OnMoreInfoClick(element, key) {
            CallbackPanelObs.SetContentHtml("");
            popup.ShowAtElement(element);
            keyValue = key;
        }
        function PopupObs_Shown(s, e) {
            CallbackPanelObs.PerformCallback(keyValue);
        }
    </script>
    <dx:ASPxPopupControl ID="popup" ClientInstanceName="popup" runat="server" AllowDragging="true"
        PopupHorizontalAlign="OutsideRight" HeaderText="Observaciones">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
                <dx:ASPxCallbackPanel ID="CallbackPanelObs" ClientInstanceName="CallbackPanelObs" runat="server"
                    Width="320px" Height="100px" OnCallback="CallbackPanelObs_Callback" RenderMode="Table">
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent2" runat="server">
                            <table class="InfoTable">
                                <tr>
                                    <td>
                                        <asp:Literal ID="litText" runat="server" Text=""  />
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxCallbackPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <SettingsAdaptivity Mode="OnWindowInnerWidth" SwitchAtWindowInnerWidth="800" />
        <ClientSideEvents Shown="PopupObs_Shown" />
    </dx:ASPxPopupControl>



</asp:Content>
