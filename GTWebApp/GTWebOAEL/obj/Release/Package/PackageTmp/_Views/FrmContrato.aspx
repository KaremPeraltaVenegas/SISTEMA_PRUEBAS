<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmContrato.aspx.vb" Inherits="GTWebOAEL.FrmContrato" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCore.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js"></script>
    <script type="text/javascript" src="../_GTJScript/ContratistaContrato.js"></script>
     <style>
        .infoColumna {
        /*padding:0px 3px;
       
        width:26px;*/

         border-radius: 4px;
    /*padding: 0.2em 1em;*/
    padding:1px 6px;
    margin-right: auto;
    text-align: center;
        }
        .cellCenter {
         text-align: center;
        }
    </style>
    <!--#region FORMULARIO LISTA CONTRATOS -->
    <div id="#region_FrmContrato_Lista_Contratos">
        <div>
            <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
                <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCustom" />
            </dx:ASPxCallback>
        </div>
        <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
            <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
                ClientVisible="False" ClientInstanceName="iCodRegistro">
            </dx:ASPxTextBox>
            <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
            </dx:ASPxHiddenField>
            <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros">
                <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCustom" FocusedRowChanged="OnGridFocusedRowChanged"
                    Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback"></ClientSideEvents>
                <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                </SettingsPager>
                <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="270"></Settings>
                <SettingsBehavior AllowFocusedRow="True" />
                <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
                <Settings ShowVerticalScrollBar="True" GridLines="None" />
                <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <Toolbars>
                    <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                        <Items>
                            <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                                <ItemStyle HorizontalAlign="Right" Width="180px"></ItemStyle>
                                <Template>
                                    <div id="gtHeadTitle" style="">
                                        <i class="fal fa-clipboard-list"></i>
                                        <span class="gtHeadSpan">CONTRATOS</span>
                                    </div>
                                </Template>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                                <Template>
                                    <div id="div100Percent">
                                    </div>
                                </Template>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Text="Agregar" Name="BtnAgregar" ToolTip="Nuevo Registro">
                                <Image IconID="actions_new_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Text="Editar" Name="BtnEditar" ToolTip="Modificar Registro">
                                <Image IconID="actions_edit_16x16devav">
                                </Image>
                            </dx:GridViewToolbarItem>
                        <%--    <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar" ToolTip="Eliminar Registro">
                                <Image IconID="edit_delete_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>--%>
                            <dx:GridViewToolbarItem Name="BtnAnular" Text="Anular" ToolTip="Anular Registro">
                                <Image IconID="actions_cancel_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>

                            <dx:GridViewToolbarItem Image-IconID="actions_refresh_16x16office2013" Text="Refrescar" Name="BtnActualizar" ToolTip="Refrescar" Command="Refresh">
                          </dx:GridViewToolbarItem>

                            <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right" AdaptivePriority="1" BeginGroup="True" Text="">
                                <Items>
                                    <dx:GridViewToolbarItem Command="ExportToPdf" Text="Exportar a PDF">
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToDocx" Text="Exportar a DOCX">
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToRtf" Text="Exportar a RTF">
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToCsv" Text="Exportar a CSV">
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToXls" Text="Exportar a XLS">
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar a XLSX">
                                    </dx:GridViewToolbarItem>
                                </Items>
                                <Image IconID="actions_download_16x16office2013">
                                </Image>
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
                    <dx:GridViewDataTextColumn FieldName="iCodContratistaContrato" Visible="false" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                  <dx:GridViewDataTextColumn FieldName="bCerrado" Visible="True" VisibleIndex="1" Caption="Vigencia" Width="50" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate> 
                            <dx:ASPxImage runat="server" ID="EstadoCerradoContrato" OnInit="EstadoCerradoContrato_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroContrato" Visible="true" Caption="Nro Contrato" VisibleIndex="1" Width="100">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNomContrato" Visible="true" Caption="Contrato" VisibleIndex="1" Width="250">
                    </dx:GridViewDataTextColumn> 
                    <%--<dx:GridViewDataTextColumn FieldName="cNomContrata" Visible="true" Caption="Contratista" VisibleIndex="1" Width="250">
                    </dx:GridViewDataTextColumn>--%>
                    <dx:GridViewDataTextColumn FieldName="cReporteFFLL" VisibleIndex="1" Caption="Reporte FFLL" Width="56"  CellStyle-HorizontalAlign="Center" >
						<DataItemTemplate>
                             <dx:ASPxLabel runat="server" EncodeHtml="false" ID="EstadoReportarFFLL" OnInit="EstadoReportarFFLL_Init" CssClass="infoColumna">
                        </dx:ASPxLabel>
                        </DataItemTemplate>
					</dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="dFechaTermino" Visible="true" Caption="Fecha Término" VisibleIndex="1" Width="70">
                    </dx:GridViewDataTextColumn>
                      <dx:GridViewDataTextColumn FieldName="iEstado" Visible="True" VisibleIndex="2" Caption="Estado" Width="60" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="EstadoGestionContrato" OnInit="EstadoGestionContrato_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>


                    <%--  <dx:GridViewDataTextColumn FieldName="bAprobadoCED" Visible="True" VisibleIndex="2" Caption="Aprobado CED" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="AprobadoCED" OnInit="AprobadoCED_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bAprobadoCliente" Visible="True" VisibleIndex="2" Caption="Aprobado Cliente" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="AprobadoCliente" OnInit="AprobadoCliente_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>
<%--                    <dx:GridViewDataCheckColumn FieldName="bAprobadoCED" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprobado CED" Width="90">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="bAprobadoCliente" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprobado Cliente" Width="66">
                    </dx:GridViewDataCheckColumn>--%>


                </Columns>
            </dx:ASPxGridView>
        </div>
    </div>
    <!--#endregion FORMULARIO LISTA CONTRATOS -->

     <!--#region POPUP AGREGAR Y EDITAR CONTRATO -->
    <div id="#region_FrmConvocatorias_AgregarEditar_Contrato">
        <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli"
            PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="860px" PopupVerticalAlign="WindowCenter"
            MaxWidth="860px" MaxHeight="640px" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade" AllowDragging="True">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Creación del Contrato" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup">
                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                    <Items>
                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="true" Caption="">
                                            <Items>
                                              
                                                        <%--***ITEM FORM ***--%>
                                                         
                                                         <dx:LayoutItem Caption="Nro Contrato / OS /Proy.">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                       <dx:ASPxTextBox ID="cNroContrato" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cNroContrato"  CssClass="toUpper">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                     </ValidationSettings>
                                                                       </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

<%--                                                         <dx:LayoutItem Caption="Nombre Contrato / Proy.">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                       <dx:ASPxTextBox ID="cNomContratos" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cNomContrato"  CssClass="toUpper">
                                                                       </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>
                                                 <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Fecha Término">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxDateEdit ID="dFechaTermino" ClientInstanceName="dFechaTermino" runat="server" AutoPostBack="false" UseMaskBehavior="False"  Width="80%"
                                                                        CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                            <RequiredField IsRequired="True"></RequiredField>
                                                                        </ValidationSettings>
                                                                    </dx:ASPxDateEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                   

                                             
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Zona de Trabajo">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="cZona" runat="server" ValueType="System.String" ClientInstanceName="cZona">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                        </ValidationSettings>
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                 <%--***ITEM FORM ***--%>
                                                        <%--<dx:LayoutItem Caption="Fecha Inicio">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxDateEdit ID="ASPxDateEdit1" ClientInstanceName="dFechaTermino" runat="server" AutoPostBack="false" UseMaskBehavior="False"
                                                                        CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>

                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                            <RequiredField IsRequired="True"></RequiredField>
                                                                        </ValidationSettings>
                                                                    </dx:ASPxDateEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>
                                                       


                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Cant. Estimada de Personal">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
 
                                                                     <dx:ASPxSpinEdit ID="iHeadCount" ClientInstanceName="iHeadCount" runat="server" Number="1" NumberType="Integer"
                                                                        MinValue="1" MaxValue="9999" Width="80%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
<RequiredField IsRequired="True"></RequiredField>
                                                                         </ValidationSettings>
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                 </Items>
                                             
                                        </dx:LayoutGroup>
                                <dx:LayoutGroup ColCount="1" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales" Paddings-PaddingTop="0">
                                <Items>        
                                                           <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Nombre Contrato / Proy.">                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo  ID="cNomContrato" runat="server" Height="42px" Width="100%" CssClass="toUpper" ClientInstanceName="cNomContrato">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                     </ValidationSettings>
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Area Usuaria">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                       <dx:ASPxTextBox ID="cAreaUsuaria" runat="server"  Visible="True" ClientVisible="True" ClientInstanceName="cAreaUsuaria"  CssClass="toUpper">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                     </ValidationSettings>
                                                                       </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                    

                                                        <dx:LayoutItem Caption="Supervisor Área Usuaria [Nombres-Teléfono-Correo]">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                        <dx:ASPxTextBox ID="cAreaUsuariaSupervisor" runat="server"   Visible="True" ClientVisible="True" ClientInstanceName="cAreaUsuariaSupervisor"  CssClass="toUpper">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                     </ValidationSettings>
                                                                        </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                 <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Datos del Encargado del Servicio / Proyecto por parte de la EECC  [Nombres-Teléfono-Correo]">                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo  ID="cDatosContacto" runat="server" Height="42px" Width="100%" CssClass="toUpper" ClientInstanceName="cDatosContacto">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" >
                                                                     </ValidationSettings>
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                     <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Observaciones Anotaciones de la OAEL">                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo  ID="cObs" runat="server" Height="42px" Width="100%" CssClass="toUpper" ClientInstanceName="cObs" Font-Size="Smaller" ReadOnly="true" ReadOnlyStyle-BackColor="WhiteSmoke" >
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***  FIN FORMULARIO ***--%>
                                    </Items>
                                </dx:LayoutGroup>

                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales" Paddings-PaddingTop="0">
                                <Items>     
                                                       
                                             <dx:LayoutItem ShowCaption="False" CaptionStyle-ForeColor="DarkRed"  HorizontalAlign="Left">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																  
                                                                <div style="font-size:0.9em;"><span style="font-weight:bold;">Importante : </span>
                                                                                  La OAEL tiene la potestad de observar el contrato registrado en caso exista algún dato faltante 
                                                                                    o este tenga información imprecisa.</div>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                    
                                     <%--*** COMMANDS BUTTON ***--%>
                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Center">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <table style="margin-top: 12px!important;">
                                                                        <tr>
                                                                            
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardar" AutoPostBack="false">
                                                                                    <ClientSideEvents Click="OnBtnGuardarClickCustom" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                            <td>
                                                                                <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false" EnableClientSideAPI="True">
                                                                                    <ClientSideEvents Click="CloseFormMainModal"></ClientSideEvents>
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

                        </dx:PopupControlContentControl>
                    </ContentCollection>
                </dx:PopupWindow>
            </Windows>
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>
            <ClientSideEvents Closing="function(s, e) { ClearContentControls();}"></ClientSideEvents>
        </dx:ASPxPopupControl>
    </div>
    <!--#endregion POPUP AGREGAR Y EDITAR CONTRATO -->

    <%--********* FORMULARIO DE CONFIRMACION DE ANULACION *********--%>
    <dx:ASPxPopupControl ID="PopupConfirmAnulacion" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmAnulacion"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormConfirmAnulacionLayoutPopup" CssClass="formLayout" ClientInstanceName="FormConfirmAnulacionLayoutPopup">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="¿ Seguro de ANULAR el registro seleccionado. ?">
                                                </dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table style="margin-top: 12px!important;">
                                                    <tr>
                                                        <td style="padding-right: 10px;">
                                                            <dx:ASPxButton ID="BtnDeleteConfirmAnulacion" runat="server" Text="Si" Width="60" ClientInstanceName="BtnDeleteConfirmAnulacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="AnularRecord" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnDeleteCancelAnulacion" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancelAnulacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="CloseFormConfirmAnulacion"></ClientSideEvents>
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
</asp:Content>
