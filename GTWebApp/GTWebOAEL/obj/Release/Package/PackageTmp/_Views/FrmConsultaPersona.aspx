<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmConsultaPersona.aspx.vb" Inherits="GTWebOAEL.FrmConsulta" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

 
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--      <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js" ></script>--%>
  <script type="text/javascript" src="../_GTJScript/ConsultaPersona.js" ></script> <%--MODIFICAR--%>
   <%--<script type="text/javascript" src="../_GTJScript/_GTHandleMain.js" ></script>--%>  <%--MODIFICAR--%>
  <%--<script type="text/javascript" src="../_GTJScript/_GTMainCore.js" ></script>--%>  
     <script type="text/javascript" > 
         // ************* FUNCTIONS CUSTOM 
         
         function ViewData() {
             if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutConsulta.GetMainElement(), null, true)) {
                 CallBackFunction.PerformCallback();
                 //ShowAlertMessage('Registro guardado con éxito.');
                 //alert("ok");
             }
             else {
                 //alert("error");
                 e.processOnServer = false;
             }
         }
         function OnEndCallBackFunction(s, e) {
             //textBox.SetText(e.result); DEFINIR ALGUN MENSAJE
             //var popupWindow = PopupConfirmDelete.GetWindow(0);
             //PopupConfirmDelete.HideWindow(popupWindow);

             //CloseFormMainModal(e.result);
             //TablaRegistros.PerformCallback();
         }

         function OnBtnVerFichaPostulante_Click() {
             CallBackPanelReport.PerformCallback("FICHAPOSTULANTE");
             PopupFormReportes.ShowWindow();
             e.processOnServer = false;
         }
     </script>
     <style>
        .FormCustomResultado .dxflFormLayout_Office365 .dxflCaption_Office365  {
            font-weight: bold!important;
        }
         </style>
    <%-- ***************************** INI SECCION DATATABLE ***************************** --%>
      <div id="ContentTablaRegistros" style="padding:0px 15px 0px 15px;" class="FormCustomResultado">
          <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
              <ClientSideEvents CallbackComplete="OnEndCallBackFunction" />
          </dx:ASPxCallback>
          <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True" 
            ClientVisible="False" ClientInstanceName="iCodRegistro">
          </dx:ASPxTextBox>
          <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
          </dx:ASPxHiddenField>


     <%--     <dx:ASPxPanel ID="TopPanel" ClientInstanceName="TopPanel"   runat="server" Width="200px">
               <PanelCollection>
                <dx:PanelContent>
            
                </dx:PanelContent>
            </PanelCollection>
            <Paddings Padding="8px" />
          </dx:ASPxPanel>--%>
          <div style="padding-top:20px;display:block"  ></div>
      <div id="GTFormContentMain">
           <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="170px" Visible="True"
                ClientVisible="False" ClientInstanceName="iCodCandidatoInforme">
            </dx:ASPxTextBox>
          <div>
                
                      <dx:ASPxFormLayout ID="FormLayoutConsulta" runat="server" ClientInstanceName="FormLayoutConsulta"  >
                         <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                          <Items>
                              <dx:LayoutGroup ColCount="2"   GroupBoxDecoration="None" UseDefaultPaddings="false"  Caption="">
                                <Items>
                                    <dx:LayoutGroup ColCount="1" Width="30%"   GroupBoxDecoration="Box" 
                                        SettingsItemCaptions-Location="Top" 
                                         UseDefaultPaddings="false" Caption="BÚSQUEDA DE DATOS">
                                        <GroupBoxStyle>
                        <Caption Font-Bold="true" Font-Size="12" />
                    </GroupBoxStyle>
                        <Items>
                                <dx:LayoutItem Caption="Nro. Doc. Id.">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
										<%-- <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True" 
                                                    ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
                                                    </dx:ASPxTextBox>--%>
                                                <dx:ASPxButtonEdit ID="cDNI" runat="server" NullText="Buscar..."  
                                                    ClientInstanceName="cDNI" 
                                                    ClientSideEvents-ButtonClick="ViewData"                                                     
                                                    AutoPostBack="false"  >
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic"  />
                                                    <ClientSideEvents KeyPress="function(s, e) {  if( (e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90)  || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122) ) {  return true; } else {  ASPxClientUtils.PreventEvent(e.htmlEvent); } }" />  

                                                    <Buttons>
                                                        <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                                       
                                                    </Buttons>
                                                </dx:ASPxButtonEdit>
                                                                
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>          
                               
                                <%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Apellidos">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="cApellidos" runat="server" />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>
								<%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Nombres">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="cNombres" runat="server" />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>
                               <%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Ubigeo">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="cUbigeo" runat="server"  />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>
                               <%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Condición">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="cCondicion" runat="server" />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>
                               <%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Fecha Nac.">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="dFechaNac" runat="server"  />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>
                               <%--***ITEM FORM ***--%>
								<dx:LayoutItem Caption="Fono">
									<LayoutItemNestedControlCollection>
										<dx:LayoutItemNestedControlContainer>
											<dx:ASPxLabel ID="cFono" runat="server" />
										</dx:LayoutItemNestedControlContainer>
									</LayoutItemNestedControlCollection>
								</dx:LayoutItem>

                             <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
                                    <LayoutItemNestedControlCollection>
                                        <dx:LayoutItemNestedControlContainer>
                                            <table style="margin-top: 12px!important;">
                                                <tr>
                                                                            
                                                    <td style="padding-right: 10px;">
                                                        <dx:ASPxButton ID="BtnVerFichaPostulante" runat="server" Text="Ver Ficha Postulante" Width="120px" ClientInstanceName="BtnVerFichaPostulante" AutoPostBack="false">
                                                            <ClientSideEvents Click="OnBtnVerFichaPostulante_Click" />
                                                        </dx:ASPxButton>
                                                    </td> 
                                                </tr>
                                            </table>
                                        </dx:LayoutItemNestedControlContainer>
                                    </LayoutItemNestedControlCollection>
                                </dx:LayoutItem>
                               <%--***ITEM FORM ***--%>
								
                                    </Items>
                                    </dx:LayoutGroup>
                                    <dx:LayoutGroup ColCount="1" Width="69%"  SettingsItemCaptions-Location="Top" Paddings-PaddingTop="0"   GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                    <Items>
                                       <dx:LayoutItem Caption="Solicitudes RDP Anexo 5">
									        <LayoutItemNestedControlCollection>
										        <dx:LayoutItemNestedControlContainer>
											        <div id="ContentTablaRegistroDetalle" style="padding:0px 5px 0px 0px;">                                                                    
                                                        <dx:ASPxGridView ID="TablaRegistrosPGI" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosPGI"  >
                                                            <SettingsPager EnableAdaptivity="True" PageSize="50" AlwaysShowPager="False" Visible="false">
                                                            </SettingsPager>
                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="110"></Settings>
                                                            <%--<SettingsPager Visible="false" ></SettingsPager>--%>
                                                            <SettingsBehavior AllowFocusedRow="False" />
                                                            <SettingsDataSecurity AllowDelete="False">
                                                            </SettingsDataSecurity>
                                                            <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                            <Settings ShowVerticalScrollBar="True" /> 
                                                             <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                            </Styles>            
                                                        </dx:ASPxGridView>
                                                    </div>
										        </dx:LayoutItemNestedControlContainer>
									        </LayoutItemNestedControlCollection>
								        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Fuerza Laboral Historial" Paddings-PaddingTop="10">
									        <LayoutItemNestedControlCollection>
										        <dx:LayoutItemNestedControlContainer>
											        <div id="ContentTablaRegistroDetalle2" style="padding:0px 5px 0px 0px;" class="ContentTablaRegistroDetalleCustom" >                                                                    
                                                        <dx:ASPxGridView ID="TablaRegistrosFFLL" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosFFLL"  >
                                                            <SettingsPager EnableAdaptivity="True" PageSize="50" AlwaysShowPager="False" Visible="false">
                                                            </SettingsPager>
                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="110"></Settings>
                                                            <%--<SettingsPager Visible="false" ></SettingsPager>--%>
                                                            <SettingsBehavior AllowFocusedRow="False" />
                                                            <SettingsDataSecurity AllowDelete="False">
                                                            </SettingsDataSecurity>
                                                            <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                            <Settings ShowVerticalScrollBar="True" /> 
                                                             <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                            </Styles>            
                                                        </dx:ASPxGridView>
                                                    </div>
										        </dx:LayoutItemNestedControlContainer>
									        </LayoutItemNestedControlCollection>
								        </dx:LayoutItem>
                                        
                                        <dx:LayoutItem Caption="Postulaciones" Paddings-PaddingTop="10">
									        <LayoutItemNestedControlCollection>
										        <dx:LayoutItemNestedControlContainer>
											        <div id="ContentTablaRegistroPostulaciones" style="padding:0px 5px 0px 0px;" class="ContentTablaRegistroDetalleCustom" >                                                                    
                                                        <dx:ASPxGridView ID="TablaRegistroPostulaciones" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistroPostulaciones"  >
                                                            <SettingsPager EnableAdaptivity="True" PageSize="50" AlwaysShowPager="False" Visible="false" >
                                                            </SettingsPager>
                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="110"></Settings>
                                                            <%--<SettingsPager Visible="false" ></SettingsPager>--%>
                                                            <SettingsBehavior AllowFocusedRow="False" />
                                                            <SettingsDataSecurity AllowDelete="False">
                                                            </SettingsDataSecurity>
                                                            <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                            <Settings ShowVerticalScrollBar="True" /> 
                                                            <Styles>
                                                                <AlternatingRow Enabled="true" />
                                                            </Styles>
                                                                         
                                                        </dx:ASPxGridView>
                                                    </div>
										        </dx:LayoutItemNestedControlContainer>
									        </LayoutItemNestedControlCollection>
								        </dx:LayoutItem>
                                    </Items>
                                    </dx:LayoutGroup>

                                </Items>
                              
                              </dx:LayoutGroup>
                          </Items>


                           <Items>
                               
                                
                    

                        </Items>
                      </dx:ASPxFormLayout>
               </div>
                </div>
      </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>

    <%-- ***************************** SECCION POPUPS ***************************** --%>
   
     <%-- ***************************** SECCION POPUPS REPORTE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportes" runat="server" Modal="True" ClientInstanceName="PopupFormReportes" 
        PopupElementID="PopupFormReportes" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="Ficha del Postulante"  >
         <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" MinHeight="95%" MinWidth="97%" />  
                <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server" CssClass="popupSimple">
                          <%--********* INI CONTENT FORM MAIN *********--%>

                          <div id="mainReportFFLL">
                           <dx:ASPxCallbackPanel ID="CallBackPanelReport" ClientInstanceName="CallBackPanelReport" runat="server"  OnCallback="CallBackPanelReport_Callback">  
                                <PanelCollection>  
                                    <dx:PanelContent ID="PanelContent1" runat="server">  
                                         <div class="containerReport">
                                                <dx:ASPxWebDocumentViewer   Height="480"  ID="WebReportViewer" runat="server" DisableHttpHandlerValidation="False">
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

   
        <%--******** POPUP NOTIFICATIONS **********************************************************--%>
      <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server"  ClientInstanceName="PopupAlertMessage"
         Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below" 
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje" >
                 <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content" >
                         
                      </dx:PopupControlContentControl>
                  </ContentCollection>               
      </dx:ASPxPopupControl>
  
</asp:Content>
