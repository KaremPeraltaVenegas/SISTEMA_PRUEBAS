<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmRptAnexoAdmision.aspx.vb" Inherits="GTWebOAEL.FrmRptAnexoAdmision" %>

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
                 CallBackFunction.PerformCallback();

                 BtnConfirmarEnviar.SetEnabled(true);

                 //ShowAlertMessage('Registro guardado con éxito.');
             }
             else {
                 e.processOnServer = false;
             }
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
             iCodAnexoAdmisionTipo.SetValue(15);
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
                 
                 ShowAlertMessage('PGI enviado a OAEL con éxito.');
                 BtnGuardar.SetEnabled(false);
                 BtnConfirmarEnviar.SetEnabled(false);
                 BtnImprimirFormatoPGI.SetEnabled(false);//cuando se envia a oael se deshabilita
                 iCodContratistaContrato.SetEnabled(false);

                 TablaRegistros.PerformCallback();
               
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
        /*padding-top:2px;
        padding-bottom:2px;*/
        /*padding:2px;*/
         border-radius: 4px;
    /*padding: 0.2em 1em;*/
    padding:2px 4px;
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
              <ClientSideEvents CallbackComplete="OnEndCallBackFunction" />
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
               <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
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
                                     SEGUIMIENTO RDP ANEXO 05
                                  </div>

                              </Template>

                          </dx:GridViewToolbarItem>
                          <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">  
                                <Template>  
                                    <div id="div100Percent"></div>  
                                </Template>  
                            </dx:GridViewToolbarItem>  
                         <%-- <dx:GridViewToolbarItem Text="Agregar" Name="BtnAgregar">
                              <Image IconID="actions_new_16x16office2013">
                              </Image>
                          </dx:GridViewToolbarItem>--%>
                          <dx:GridViewToolbarItem Text="Ver Datos" Name="BtnEditar">
                              <Image IconID="actions_edit_16x16devav">
                              </Image>
                          </dx:GridViewToolbarItem>
                          <%--<dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar">
                              <Image IconID="edit_delete_16x16office2013"></Image>
                          </dx:GridViewToolbarItem>--%>
                          <dx:GridViewToolbarItem Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="2" Command="Refresh" Name="BtnActualizar">
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
                  <dx:GridViewDataTextColumn FieldName="cGrupoContrato" VisibleIndex="1" Caption="Doc." Width="56"  CellStyle-HorizontalAlign="Center"  CellStyle-Font-Size="Smaller" >
						<DataItemTemplate>
                            <%--<dx:ASPxImage runat="server" ID="AnexoAdmisionTipoImg" OnInit="AnexoAdmisionTipoImg_Init" ></dx:ASPxImage>--%>
                            <dx:ASPxLabel runat="server" EncodeHtml="false" ID="AnexoAdmisionTipoImg" OnInit="AnexoAdmisionGrupoContratoImg_Init" CssClass="infoColumna">
                        </dx:ASPxLabel>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>  
                 <%-- <dx:GridViewDataTextColumn FieldName="cNomCorto" Visible="True"  VisibleIndex="2" Caption="Empresa" CellStyle-Font-Size="Smaller">
					</dx:GridViewDataTextColumn>--%>
                  <dx:GridViewDataComboBoxColumn FieldName="cNomCorto" Caption="Empresa"  VisibleIndex="2"  AdaptivePriority="1" CellStyle-Font-Size="Smaller">
                        <Settings AllowHeaderFilter="True" AllowAutoFilter="False" SortMode="DisplayText" AllowSort="False" />
                        <SettingsHeaderFilter ListBoxSearchUISettings-EditorNullText="Ingrese Texto a Buscar" Mode="List" ListBoxSearchUISettings-UseCompactView="false"  />
                    </dx:GridViewDataComboBoxColumn>
                   <dx:GridViewDataTextColumn FieldName="cNroContrato" Visible="True"  VisibleIndex="2" Caption="Nro. Contrato"  CellStyle-Font-Size="Smaller">
					</dx:GridViewDataTextColumn>
                   <dx:GridViewDataTextColumn FieldName="cCorrelativo" Visible="True"  VisibleIndex="2" Caption="Nro. Doc."  CellStyle-Font-Size="Smaller" Width="94" >
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cEstado" Visible="True"  VisibleIndex="2" Caption="Estado OAEL" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                      <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="PGIStatus" OnInit="PGIStatus_Init" ></dx:ASPxImage>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>
                  <dx:GridViewDataDateColumn FieldName="dFechaRegistro" Visible="True" VisibleIndex="2" Caption="Registro EECC"  CellStyle-Font-Size="Smaller"  Width="100" >
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>

                  <dx:GridViewDataDateColumn FieldName="dFechaValidaOAEL" Visible="True" VisibleIndex="2" Caption="Valida OAEL"  CellStyle-Font-Size="Smaller" Width="100">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>

                  <dx:GridViewDataDateColumn FieldName="dFechaSolicitudFirma" Visible="True" VisibleIndex="2" Caption="Solicita Firma"  CellStyle-Font-Size="Smaller" Width="100">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>

                  <dx:GridViewDataDateColumn FieldName="dFechaNotifica" Visible="True" VisibleIndex="2" Caption="Notificado"  CellStyle-Font-Size="Smaller" Width="100">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>

                   <dx:GridViewDataTextColumn FieldName="cDiasSinRpta" Visible="True"  VisibleIndex="2" Caption="Días Not."  CellStyle-Font-Size="Smaller" Width="94" >
					</dx:GridViewDataTextColumn>

                  <dx:GridViewDataDateColumn FieldName="dFechaApruebaAreaAAQ" Visible="True" VisibleIndex="2" Caption="Área Usuaria"  CellStyle-Font-Size="Smaller" Width="100">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>

                  <dx:GridViewDataDateColumn FieldName="dFechaAprobadoAAQ" Visible="True" VisibleIndex="2" Caption="AAQ OEL"  CellStyle-Font-Size="Smaller" Width="100">
                        <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>
                  <%--<dx:GridViewDataTextColumn FieldName="dFechaAprobacion" Visible="True"  VisibleIndex="2" Caption="F.Etapa">
					</dx:GridViewDataTextColumn>--%>
                  <%--<dx:GridViewDataTextColumn FieldName="cEstado" Visible="True"  VisibleIndex="2" Caption="Estado OAEL" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                      <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="PGIStatus" OnInit="PGIStatus_Init" ></dx:ASPxImage>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>
                  <dx:GridViewDataCheckColumn FieldName="bNotificado" Visible="True"  VisibleIndex="3" HeaderStyle-HorizontalAlign="Center"  CellStyle-HorizontalAlign="Center" Caption="Notificado a AAQ" Width="124">
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
                                                                <dx:ASPxTextBox ID="cEstado" runat="server" Width="1px" Visible="True" 
                                                                    ClientVisible="False" ClientInstanceName="cEstado">
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
                                                                     


																 </dx:ASPxComboBox>

															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
											
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
                                                                     
                                                                  </td>
                                                                  <td style="padding-right: 10px;">
                                                                      
                                                                  </td>
                                                                   <td style="padding-right: 10px;">
                                                                      
                                                                  </td>
                                                                  <td>
                                                                      <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cerrar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false"  >
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
                                                                          <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalle" />
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
                                                                                     <%-- <dx:GridViewToolbarItem Text="" Name="BtnAgregarDetalle">
                                                                                          <Image IconID="actions_new_16x16office2013">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnEditarDetalle">
                                                                                          <Image IconID="actions_edit_16x16devav">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem Name="BtnEliminarDetalle" Text="">
                                                                                          <Image IconID="edit_delete_16x16office2013"></Image>
                                                                                      </dx:GridViewToolbarItem>--%>
                                                                                      
                                                                                       
                                                                                  </Items>
                                                                              </dx:GridViewToolbar>
                                                                          </Toolbars>
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
               TablaRegistrosDetalle.PerformCallback('loading');
            
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

    <%--====================================== FORMS DETALLE ======================================--%>

 



     
      <%-- ***************************** SECCION POPUPS REPORTE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportes" runat="server" Modal="True" ClientInstanceName="PopupFormReportes" 
        PopupElementID="PopupFormReportes" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="RDP Anexo 05 - PGI: Enviar el formato FIRMADO en PDF para aprobación"  >
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
    

</asp:Content>
