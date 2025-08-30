<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmRequerimiento.aspx.vb" Inherits="GTWebOAEL.FrmRequerimiento" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%--<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>--%>

<%--<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.2" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>--%>
    <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCore.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js"></script>
    <script type="text/javascript" src="../_GTJScript/Requerimiento.js"></script>
    <script type="text/javascript" src="../_GTJScript/Requerimientodetalle.js"></script>

    <script type="text/javascript">

        function OnToolbarItemClickCustom(s, e) {

            if (IsCustomExportToolbarCommand(e.item.name)) {
                e.processOnServer = true;
                e.usePostBack = true;
            }

            if (e.item.name == "BtnAgregar") {

                iCodRegistro.SetText("0");
                cFormMetadata.Set("cTipoOpe", "A");
                var pContrata = (cFormMetadata.Get('iCodSubContrata'));
                iCodSubContrata.SetValue(pContrata);
                ClearContentControls();
                FormMainModalShow();
                HabilitarControlesPopupPrincipal("Habilitar");
                iCodContratistaContrato.SetEnabled(true);
                iCodSubContrata.SetEnabled(true);
                TablaRegistrosDetalle.PerformCallback();
                e.processOnServer = false;
                BtnGuardar.SetEnabled(true);
                BtnConfirmarEnviar.SetEnabled(false);
                BtnImprimirFormatoRequerimiento.SetEnabled(false);

            }
            else if (e.item.name == "BtnEditar") {
                cFormMetadata.Set("cTipoOpe", "M");
                iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                ClearContentControls();
                HabilitarControlesPopupPrincipal("Habilitar")
                viewRecord();
                FormMainModalShow();
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnEliminar") {
                var popupWindow = PopupConfirmDelete.GetWindow(0);
                PopupConfirmDelete.ShowWindow(popupWindow);
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnAnular") {
                var popupWindow = PopupConfirmAnulacion.GetWindow(0);
                PopupConfirmAnulacion.ShowWindow(popupWindow);
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnAdjudicaFeedback") {
                iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                var popupWindow = PopupFormAdjudicacion.GetWindow(0);
                PopupFormAdjudicacion.ShowWindow(popupWindow);
                 TablaRegistrosCotizacionPostor.PerformCallback();

                e.processOnServer = false;
            }

        }

        function OnToolbarItemClickDetalleCustom(s, e) {
            if (IsCustomExportToolbarCommand(e.item.name)) {
                e.processOnServer = true;
                e.usePostBack = true;
            }
            if (e.item.name == "BtnAgregarDetalle") {

                iCommandDetalle = 1;
                msgDetalle = "El registro se guardó con éxito";
                iCodRegistroDetalle.SetText("0");
                cFormMetadata.Set("cTipoOpeDetalle", "A");

                ClearContentControlsDetalle();
                FormMainModalShowDetalle();
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnEditarDetalle") {

                iCommandDetalle = 2;
                msgDetalle = "El registro se actualizó con éxito";

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
                iCommandDetalle = 3;
                msgDetalle = "El registro se eliminó con éxito";

                if (iCodRegistroDetalle.GetValue() != null && iCodRegistroDetalle.GetValue() != "0") {

                    var popupWindow = PopupConfirmDeleteDetalle.GetWindow(0);
                    PopupConfirmDeleteDetalle.ShowWindow(popupWindow);

                }
                else {
                    ShowAlertMessage('Se debe seleccionar un registro.');
                }

                e.processOnServer = false;
            }
        }
        function OnEndCallBackFunctionDetalleCustom(s, e) {

            if (e.result == 'OK') {

                TablaRegistrosDetalle.PerformCallback();
                ShowAlertMessage(msgDetalle);
                BtnConfirmarEnviar.SetEnabled(true);
                BtnGuardar.SetEnabled(true);
                //TablaRegistrosDetalle.UnselectRows();

                if (iCommandDetalle == 1 || iCommandDetalle == 2) {
                    // GUARDAR Y EDITAR CERRAR FORM DETALLE
                    CloseFormMainModalDetalle();
                }
            } else {
                BtnConfirmarEnviar.SetEnabled(false);
                BtnGuardar.SetEnabled(true);
                ShowAlertMessage('Ocurrió un error durante la transacción.');
            }
        }

        function OnBtnGuardarClickCustom(s, e) {
            if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
                CallBackFunction.PerformCallback();
                BtnGuardar.SetEnabled(false);
            }
            else {
                e.processOnServer = false;
            }
        }

        function OnEndCallBackFunctionCustom(s, e) {

            var arrayItems = e.result.split('-');

            if (arrayItems[1] == "OK") {
                if (arrayItems[2] == "EN_CED") {

                    HabilitarControlesPopupPrincipal("Deshabilitar");
                    ShowAlertMessage('Se envió el requerimiento a revisión.');
                    BtnConfirmarEnviar.SetEnabled(false);
                    BtnGuardar.SetEnabled(false);


                } else if (arrayItems[2] == "CR_CONV") {

                    HabilitarControlesPopupPrincipal("Deshabilitar");
                    ShowAlertMessage('Se creó el requerimiento con éxito.');
                    BtnGuardar.SetEnabled(true);
                    BtnConfirmarEnviar.SetEnabled(true);
                    BtnImprimirFormatoRequerimiento.SetEnabled(false);
                    cFormMetadata.Set("cTipoOpe", "M");
               
                } else if (arrayItems[2] == "UP_CONV") {

                    HabilitarControlesPopupPrincipal("Deshabilitar");
                    ShowAlertMessage('Se actualizó el requerimiento con éxito.');
                    BtnGuardar.SetEnabled(true);
                    BtnConfirmarEnviar.SetEnabled(true);
                    BtnImprimirFormatoRequerimiento.SetEnabled(false);
                    cFormMetadata.Set("cTipoOpe", "M");
                }

                iCodRegistro.SetText(arrayItems[0]);
                TablaRegistros.PerformCallback();
                TablaRegistrosDetalle.PerformCallback();
            }
            else if (arrayItems[1] == "SIN_ITEMS") {
                ShowAlertMessage('No se puede enviar, no tiene items en lista .');

            } else {
                ShowAlertMessage('Ocurrió un error durante el proceso.');
            }

        }

        function OnBtnConfirmarEnviarClick(s, e) {
            var popupWindow = PopupConfirmarEnvio.GetWindow(0);
            PopupConfirmarEnvio.ShowWindow(popupWindow);
            e.processOnServer = false;

        }

        function OnBtnGuardarEnviarClick(s, e) {

            cFormMetadata.Set("cTipoOpe", "E");
            CallBackFunction.PerformCallback();
            var popupWindow = PopupConfirmarEnvio.GetWindow(0);
            PopupConfirmarEnvio.HideWindow(popupWindow);
            e.processOnServer = false;
        }

        function OnBtnCancelarEnviarClick(s, e) {
            var popupWindow = PopupConfirmarEnvio.GetWindow(0);
            PopupConfirmarEnvio.HideWindow(popupWindow);
            e.processOnServer = false;
        }

        function nCantidad_KeyUp(s, e) {
            
            var _nCantidad = s.GetInputElement().value;
            var _nPrecio = nPrecioUnit.GetValue();

            var _nSubTotal = _nCantidad * _nPrecio

            nSubTotal.SetValue(_nSubTotal);
           
        }

        function nPrecioUnit_KeyUp(s, e) {

            var _nCantidad = nCantidad.GetValue();
            var _nPrecio = s.GetInputElement().value;

            var _nSubTotal = _nCantidad * _nPrecio

            nSubTotal.SetValue(_nSubTotal);

        }
        //**********************************************************************************************
        //************ COTIZACION Y ADJUDICACION
        //-- GRID COTIZACION POSTOR
        var iCommandToolbarCotizacionPostor;
          function OnToolbarItemClickCotizacionPostor (s, e) {
              if (IsCustomExportToolbarCommand(e.item.name)) {
                  e.processOnServer = true;
                  e.usePostBack = true;
              }

              if (e.item.name == "BtnAdjudicarCotizacionPostor") {
                  iCommandToolbarCotizacionPostor = "ADJUDICAR"
                  BtnGuardarAdjudicarPostor.SetEnabled(true);
                  var popupWindow = PopupFormAdjudicarPostor.GetWindow(0);
                  PopupFormAdjudicarPostor.ShowWindow(popupWindow);
                  e.processOnServer = false;
              }
              else if (e.item.name == "BtnFeedbackCotizacionPostor") {
                  iCommandToolbarCotizacionPostor = "FEEDBACK"
                  BtnGuardarFeedbackPostor.SetEnabled(true);
                  var popupWindow = PopupFormFeedbackPostor.GetWindow(0);
                  PopupFormFeedbackPostor.ShowWindow(popupWindow);
                  e.processOnServer = false;
              }

          }

          function OnEndCallBackFunctionCotizacionPostor(s, e) {
             
              if (iCommandToolbarCotizacionPostor == "ADJUDICAR") {
                  if (e.result == 'OK') {
                      ShowAlertMessage('Requerimiento adjudicado con éxito.');
                      TablaRegistrosCotizacionPostor.PerformCallback();
                      var popupWindow = PopupFormAdjudicarPostor.GetWindow(0);
                      PopupFormAdjudicarPostor.HideWindow(popupWindow);
                  }
                  else if (e.result == "ADJUDICADO") {
                      ShowAlertMessage('El Requerimiento ya fue adjudicado.');
                  }
                  else if (e.result == "FAILBD") {
                      ShowAlertMessage('Error de proceso actualice página e intente de nuevo.');
                  }
                  else {
                      ShowAlertMessage('Error de petición actualice página e intente de nuevo.');
                  }
              }
          }

          function OnGridFocusedRowChangedCotizacionPostor(s, e) {
              iCodRegistroCotizacionPostor.SetText(s.GetRowKey(s.GetFocusedRowIndex()));
              //alert(iCodRegistroDetalle.GetValue());
              s.GetRowValues(s.GetFocusedRowIndex(), 'cNomContrata', OnGetDataRowCotizacionPostor);
              e.processOnServer = false;
          }

          function OnGetDataRowCotizacionPostor(value) {
              var pNomContrata;
              pNomContrata = value;//value[0] + ' :: ' + value[1];
              //alert(cNomContratoPeriodo);
              //var popupWindow = PopupFormFFLLDetalle.GetWindow(0);
              //popupWindow.SetHeaderText(cNomContratoPeriodo);
              cNomContrataAdjudicada.SetText(pNomContrata);
              cNomContrataFeedback.SetText(pNomContrata);
          }

          function OnGridRowDoubleClickCotizacionPostor(s, e) {
              iCodRegistroCotizacionPostor.SetText(TablaRegistrosCotizacionPostor.GetRowKey(TablaRegistrosCotizacionPostor.GetFocusedRowIndex()));
              TablaRegistrosCotizacionDetallePostor.PerformCallback();
          }
        //--detalle cotizacion
          function OnToolbarItemClickCotizacionDetallePostor(s, e) {

          }

          function OnEndCallBackFunctionCotizacionDetallePostor(s, e) {

          }

          function OnGridFocusedRowChangedCotizacionDetallePostor(s, e) {

          }
        //-- FORM adjudicar postor
          function OnBtnGuardarAdjudicarPostor_Click(s, e) {
              CallBackFunctionCotizacionPostor.PerformCallback('Adjudicar');
              BtnGuardarAdjudicarPostor.SetEnabled(false);
              e.processOnServer = false;
          }

          function OnBtnCancelAdjudicarPostor_Click(s, e) {
              var popupWindow = PopupFormAdjudicarPostor.GetWindow(0);
              PopupFormAdjudicarPostor.HideWindow(popupWindow);
              e.processOnServer = false;
          }
          //-- FORM FEEDBACK POSTOR
          function OnBtnGuardarFeedbackPostor_Click(s, e) {
              CallBackFunctionCotizacionPostor.PerformCallback('Feedback');
              BtnGuardarFeedbackPostor.SetEnabled(false);
              e.processOnServer = false;
          }

          function OnBtnCancelFeedbackPostor_Click(s, e) {
              var popupWindow = PopupFormFeedbackPostor.GetWindow(0);
              PopupFormFeedbackPostor.HideWindow(popupWindow);
              e.processOnServer = false;
          }
        //************ FUNCION PARA IMPRIMIR LA CONVOCATORIA **********************
        function OnBtnImprimirFormatoRequerimiento_Click(s, e) {
            return;
            CallBackPanelReport.PerformCallback("CONVOCATORIA");
            PopupFormReportes.ShowWindow();

           

            e.processOnServer = false;

        }
    </script>

    <!--#region FORMULARIO LISTA CONVOCATORIAS -->
    <div id="#region_FrmRequerimiento_Lista_Convocatorias">
        <div>
            <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
                <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCustom" />
            </dx:ASPxCallback>
        </div>
        <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
            <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px"  
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
                                <ItemStyle HorizontalAlign="Right" Width="260px"></ItemStyle>
                                <Template>
                                    <div id="gtHeadTitle" style="">
                                        <i class="fal fa-clipboard-list"></i>
                                        <span class="gtHeadSpan">REQUERIMIENTOS</span>
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

                          <%--  <dx:GridViewToolbarItem Image-IconID="actions_refresh_16x16office2013" Text="Refrescar" Name="BtnActualizar" ToolTip="Refrescar" Command="Refresh">
                          </dx:GridViewToolbarItem>--%>

                            <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right"  BeginGroup="True" Text="Gestión">
                                <Items>
                                    <dx:GridViewToolbarItem Name="BtnAdjudicaFeedback" Text="Adjudicación y Feedback" ToolTip="Adjudicar y Feedback">
                                        <Image IconID="people_employeeaward_16x16devav">
                                        </Image>
                                    </dx:GridViewToolbarItem>
                                    <dx:GridViewToolbarItem Command="ExportToXlsx" Text="Exportar a XLSX">
                                    </dx:GridViewToolbarItem>
                                </Items>
                                <Image IconID="support_version_16x16office2013">
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
                    <dx:GridViewDataTextColumn FieldName="iCodRequerimiento" Visible="false" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroRequerimiento" Visible="true" Caption="Nro Requerimiento" CellStyle-HorizontalAlign="Center"  VisibleIndex="1" Width="80">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroContrato" Visible="true" Caption="Contrato" CellStyle-HorizontalAlign="Left"  VisibleIndex="1" Width="100">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn FieldName="dFechaSolicitud" Visible="true" Caption="Fecha Solic." CellStyle-HorizontalAlign="Center"  VisibleIndex="1" Width="100">
                     <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>
                     <dx:GridViewDataDateColumn FieldName="dFechaConvocatoriaIni" Visible="true" Caption="Fecha Ini" CellStyle-HorizontalAlign="Center"  VisibleIndex="1" Width="100">
                          <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                    </dx:GridViewDataDateColumn>
                     <dx:GridViewDataDateColumn FieldName="dFechaConvocatoriaFin" Visible="true" Caption="Fecha Fin" CellStyle-HorizontalAlign="Center"  VisibleIndex="1" Width="100">
                     <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" />
                     </dx:GridViewDataDateColumn>
                     <dx:GridViewDataTextColumn FieldName="iCodTipoEstadoRequerimiento" Visible="True" VisibleIndex="2" Caption="Estado" Width="60" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="EstadoRequerimiento" OnInit="EstadoRequerimiento_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                   
                    <%--  <dx:GridViewDataTextColumn FieldName="bAprobadoCED" Visible="True" VisibleIndex="2" Caption="Aprobado OAEL" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="AprobadoCED" OnInit="AprobadoCED_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="bAprobadoCliente" Visible="True" VisibleIndex="2" Caption="Aprobado Cliente" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="AprobadoCliente" OnInit="AprobadoCliente_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>--%>
                   <%-- <dx:GridViewDataCheckColumn FieldName="bAprobadoCED" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprob. OAEL" Width="95">
                    </dx:GridViewDataCheckColumn>
                    <dx:GridViewDataCheckColumn FieldName="bAprobadoCliente" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprob. AAQ" Width="95">
                    </dx:GridViewDataCheckColumn>--%>


                </Columns>
            </dx:ASPxGridView>
        </div>
    </div>
    <!--#endregionFORMULARIO LISTA REQUERIMIENTOS -->

    <!--#region POPUP AGREGAR Y EDITAR REQUERIMIENTO -->
    <div id="#region_FrmConvocatorias_AgregarEditar_Convocatoria">
        <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli"
            PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="1260px" PopupVerticalAlign="WindowCenter"
            MaxWidth="1260px" MaxHeight="650px" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade" AllowDragging="True">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Creación del Requerimiento" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup">
                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                    <Items>
                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="Box" UseDefaultPaddings="false" Caption="">
                                            <Items>
                                                <dx:LayoutGroup ColCount="1" Width="40%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                    <Items>
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="SubContratista">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iCodSubContrata" runat="server" ValueType="System.String" ClientInstanceName="iCodSubContrata">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Contrato">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iCodContratistaContrato" runat="server" ValueType="System.String" ClientInstanceName="iCodContratistaContrato">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                         
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Moneda">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iCodTipoMoneda" runat="server" ValueType="System.String" ClientInstanceName="iCodTipoMoneda">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Solicitante">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                       <dx:ASPxTextBox ID="cSolicitante" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cSolicitante"  CssClass="toUpper">
                                                                       </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Alcance">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cAlcanceRequerimiento" ClientInstanceName="cAlcanceRequerimiento" runat="server" Height="47px" CssClass="toUpper" Font-Size="Smaller" >
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Cond. Pago">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cTerminosPago" ClientInstanceName="cTerminosPago" runat="server"  Height="47px" CssClass="toUpper" Font-Size="Smaller" >
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Observaciones">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cObs" ClientInstanceName="cObs" runat="server"  Height="47px"  CssClass="toUpper"    ReadOnly="true" Font-Size="Smaller" ReadOnlyStyle-BackColor="WhiteSmoke">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <%--***  FIN FORMULARIO ***--%>


                                                        <%--*** COMMANDS BUTTON ***--%>
                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <table style="margin-top: 12px!important;">
                                                                        <tr>
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardar" AutoPostBack="false">
                                                                                    <ClientSideEvents Click="OnBtnGuardarClickCustom" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnConfirmarEnviar" runat="server" Text="Enviar a Rev." Width="100px" ClientInstanceName="BtnConfirmarEnviar" AutoPostBack="false">
                                                                                    <ClientSideEvents Click="OnBtnConfirmarEnviarClick" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                             <td style="padding-right: 10px;">
                                                                                  <dx:ASPxButton ID="BtnImprimirFormatoRequerimiento" runat="server" Text="Exportar" Width="100px" ClientInstanceName="BtnImprimirFormatoRequerimiento" AutoPostBack="false">
                                                                                      <ClientSideEvents Click="OnBtnImprimirFormatoRequerimiento_Click" />
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

                                                <dx:LayoutGroup Name="TablaPuestos" ColCount="1" Width="59%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="" Paddings-PaddingLeft="0">
                                                    <Items>

                                                        <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <div class="ContentTablaDetalle" id="ContentTablaRegistroDetalle" style="padding: 0px 0px 0px 0px;">
                                                                        <dx:ASPxCallback ID="CallBackFunctionDetalle" runat="server" ClientInstanceName="CallBackFunctionDetalle">
                                                                            <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalleCustom" />
                                                                        </dx:ASPxCallback>
                                                                        <dx:ASPxTextBox ID="iCodRegistroDetalle" runat="server" Width="170px" Height="1px" Visible="True"
                                                                            ClientVisible="False" ClientInstanceName="iCodRegistroDetalle">
                                                                        </dx:ASPxTextBox>
                                                                        <dx:ASPxGridView ID="TablaRegistrosDetalle" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosDetalle">
                                                                            <ClientSideEvents ToolbarItemClick="OnToolbarItemClickDetalleCustom" FocusedRowChanged="OnGridFocusedRowChangedDetalle"></ClientSideEvents>
                                                                            <SettingsPager EnableAdaptivity="True" PageSize="5" AlwaysShowPager="True">
                                                                            </SettingsPager>
                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="290"></Settings>
                                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                                                                            <Settings ShowVerticalScrollBar="True" />
                                                                            <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                                            <Toolbars>
                                                                                <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right" Name="ToolbarGridDetalle"  >
                                                                                    <Items>
                                                                                        <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                                                                                            <ItemStyle HorizontalAlign="Right" Width="180px"></ItemStyle>
                                                                                            <Template>
                                                                                                <div id="gtHeadTitleDetalle" style="">
                                                                                                    LISTADO ByS
                                                                                                </div>
                                                                                            </Template>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                                                                                            <Template>
                                                                                                <div id="div1"></div>
                                                                                            </Template>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem Text="" Name="BtnAgregarDetalle" ToolTip="Agregar Bien y/o Servicio">
                                                                                            <Image IconID="actions_additem_16x16office2013">
                                                                                            </Image>
                                                                                        </dx:GridViewToolbarItem>
                                                                                         <dx:GridViewToolbarItem Name="BtnEditarDetalle" Text="" ToolTip="Editar">
                                                                                            <Image IconID="actions_edit_16x16devav"></Image>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem Name="BtnEliminarDetalle" Text="" ToolTip="Eliminar">
                                                                                            <Image IconID="edit_delete_16x16office2013"></Image>
                                                                                        </dx:GridViewToolbarItem> 
                                                                                    </Items>
                                                                                </dx:GridViewToolbar>
                                                                            </Toolbars>
                                                                            <Columns>
                                                                                <dx:GridViewDataTextColumn FieldName="iCodRequerimientoDetalle" Visible="false" VisibleIndex="0">
                                                                                </dx:GridViewDataTextColumn>
                                                                         
                                                                                <dx:GridViewDataTextColumn FieldName="cDescripcionBienServicio" Visible="true" VisibleIndex="3" Caption="Bien / Servicio ">
                                                                                </dx:GridViewDataTextColumn>
                                                                                 
                                                                                <dx:GridViewDataTextColumn FieldName="nCantidad" Visible="true" VisibleIndex="3" Caption="Cantidad" Width="70">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="cNomCortoMedida" Visible="true" VisibleIndex="3" Caption="U. Med." CellStyle-HorizontalAlign="Center"  Width="60">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="nPrecioUnit" Visible="true" VisibleIndex="3" Caption="P.Unit."  Width="65">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="nSubTotal" Visible="true" VisibleIndex="3" Caption="S.Total"  Width="70">
                                                                                </dx:GridViewDataTextColumn>

                                                                                <%--<dx:GridViewDataTextColumn FieldName="cEstado" VisibleIndex="4" Caption="Estado" Width="90" CellStyle-HorizontalAlign="Center">
                                                                                    <DataItemTemplate>
                                                                                        <dx:ASPxLabel runat="server" EncodeHtml="false" ID="EstadoItemsDetalle" OnInit="EstadoItemsDetalle_Init" CssClass="infoColumna">
                                                                                        </dx:ASPxLabel>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataTextColumn>--%>
                                                                            </Columns>
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
    <!--#endregion POPUP AGREGAR Y EDITAR CONVOCATORIA -->

    <!--#region POPUP DETALLE PUESTOS SOLICITADOS -->
    <div id="#region_FrmConvocatorias_PuestosSolicitadosAgregar#">
        <dx:ASPxPopupControl ID="PopupFormMainCliDetalle" runat="server" Modal="True" ClientInstanceName="PopupFormMainCliDetalle"
            PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="900px" PopupVerticalAlign="WindowCenter"
            MaxWidth="900" MaxHeight="680px" MinWidth="300px" CloseAction="CloseButton" CloseAnimationType="Fade">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Solicitud de ByS" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server" >
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormLayoutPopupDetalle" Paddings-PaddingTop="0">
                                    <SettingsAdaptivity  AdaptivityMode="SingleColumnWindowLimit" />
                                    <Items>

                                                <dx:LayoutGroup ColCount="1" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales" Paddings-PaddingTop="0">
                                                    <Items>
                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Bien / Servicio a Requerir" Paddings-PaddingTop="0">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cDescripcionBienServicio" runat="server" Height="42px" Width="100%" CssClass="toUpper" ClientInstanceName="cDescripcionBienServicio">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Detalles Técnicos y/o TDR">                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cDetalleRequerimiento" runat="server" Height="62px" Width="100%" CssClass="toUpper" ClientInstanceName="cDetalleRequerimiento">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                    </Items>
                                                </dx:LayoutGroup>


                                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" SettingsItemCaptions-Location="Left" UseDefaultPaddings="true" Caption="Datos Principales">
                                                    
                                                    <Items>
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Cantidad">                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
 
                                                                     <dx:ASPxSpinEdit ID="nCantidad" ClientInstanceName="nCantidad" runat="server" Number="1" NumberType="Float" ClientSideEvents-KeyUp="nCantidad_KeyUp"
                                                                        MinValue="0.01" MaxValue="99999" Width="60%"  DisplayFormatString="n2" DecimalPlaces="2" >
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Unid. Medida">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxComboBox ID="iCodTipoMedida" runat="server" ValueType="System.String" ClientInstanceName="iCodTipoMedida"  Width="100%">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Precio Referencial">                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer> 
                                                                     <dx:ASPxSpinEdit ID="nPrecioUnit" ClientInstanceName="nPrecioUnit" runat="server" Number="0" NumberType="Float" ClientSideEvents-KeyUp="nPrecioUnit_KeyUp"
                                                                        MinValue="1" MaxValue="999999" Width="60%" DisplayFormatString="n2" DecimalPlaces="2" >
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>                        
                                                       

                                                        <%--***ITEM FORM ***--%>
                                                         <dx:LayoutItem Caption="Sub Total">                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                      <dx:ASPxSpinEdit ID="nSubTotal" ClientInstanceName="nSubTotal" runat="server" Number="0" NumberType="Float" ReadOnly="true" ReadOnlyStyle-BackColor="AntiqueWhite"
                                                                        MinValue="0" MaxValue="999999" Width="60%" DisplayFormatString="n2" DecimalPlaces="2" >
                                                                          
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                      <dx:LayoutItem Caption="Tiempo de Servicio (meses)">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                     <dx:ASPxSpinEdit ID="nTiempoDuracion" ClientInstanceName="nTiempoDuracion" runat="server" Number="0" NumberType="Integer"
                                                                        MinValue="0" MaxValue="1000" Width="60%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                           <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Otros Requisitos">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cOtrosRequisitos" runat="server" Height="62px" Width="100%" CssClass="toUpper" Font-Size="Smaller" ClientInstanceName="cOtrosRequisitos">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem> 
                                                    </Items>
                                                </dx:LayoutGroup>
                                         
                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                            <Items>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <table style="margin-top: 12px!important;">
                                                                <tr>
                                                                    <td style="padding-right: 10px;">
                                                                        <dx:ASPxButton ID="BtnGuardarDetalle" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarDetalle" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnGuardarClickDetalle" />
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                    <td>
                                                                        <dx:ASPxButton ID="BtnCancelarDetalle" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelarDetalle" AutoPostBack="false">
                                                                            <ClientSideEvents Click="CloseFormMainModalDetalle"></ClientSideEvents>
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
                <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>
            <ClientSideEvents Closing="function(s, e) {ClearContentControlsDetalle();}"></ClientSideEvents>
        </dx:ASPxPopupControl>
    </div>
    <!--#endregion POPUP DETALLE PUESTOS SOLICITADOS -->

    <!--#region NOTIFICACION POPUP -->
    <div id="#region_NotificacionPopup">
        <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server" ClientInstanceName="PopupAlertMessage"
            Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below"
            HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje">
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content">
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
    <!--#endregion NOTIFICACION POPUP -->

    <%--********* FORMULARIO DE CONFIRMACION DE BORRADO *********--%>
    <dx:ASPxPopupControl ID="PopupConfirmDelete" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDelete"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutConfirmDelete" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopup">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="LblDeleteConfirm" runat="server" Text="¿ Seguro de ANULAR el registro seleccionado. ?">
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
                                                            <dx:ASPxButton ID="BtnDeleteConfirm" runat="server" Text="Si , Eliminar." Width="70" ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false">
                                                                <ClientSideEvents Click="AnularRecord" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnDeleteCancel" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancel" AutoPostBack="false">
                                                                <ClientSideEvents Click="CloseFormConfirmDelete"></ClientSideEvents>
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



    <%-- ******************************** POPUP DETALLE CONFIRM MODAL ********************************************** --%>
    <dx:ASPxPopupControl ID="PopupConfirmarEnvio" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmarEnvio"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl6" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout2" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupEnvio">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="¿ Seguro de enviar el Requerimiento a revisión. ?">
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
                                                            <dx:ASPxButton ID="BtnGuardarEnviar" runat="server" Text="Si, Enviar" Width="70" ClientInstanceName="BtnGuardarEnviar" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnGuardarEnviarClick" />
                                                            </dx:ASPxButton>
                                                        </td>

                                                        <td>
                                                            <dx:ASPxButton ID="BtnCancelarEnviar" runat="server" Text="No" Width="60" ClientInstanceName="BtnCancelarEnviar" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnCancelarEnviarClick"></ClientSideEvents>
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

    <%-- ******************************** POPUP DETALLE CONFIRM MODAL ********************************************** --%>
    <dx:ASPxPopupControl ID="PopupConfirmDeleteDetalle" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDeleteDetalle"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl7" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormConfirmLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupDetalle">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="¿ Seguro de borrar el item seleccionado. ?">
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
                                                            <dx:ASPxButton ID="BtnDeleteConfirmDetalle" runat="server" Text="Si" Width="60" ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false">
                                                                <ClientSideEvents Click="DeleteRecordDetalle" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnDeleteCancelDetalle" runat="server" Text="No" Width="60" ClientInstanceName="BtnDeleteCancel" AutoPostBack="false">
                                                                <ClientSideEvents Click="CloseFormConfirmDeleteDetalle"></ClientSideEvents>
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
                                                            <dx:ASPxButton ID="BtnDeleteConfirmAnulacion" runat="server" Text="Si, Anular" Width="70" ClientInstanceName="BtnDeleteConfirmAnulacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="AnularRecord" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnDeleteCancelAnulacion" runat="server" Text="No" Width="70" ClientInstanceName="BtnDeleteCancelAnulacion" AutoPostBack="false">
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



<%--    ************************   POPUP FORM ADJUDICACION FEEDBACK  ******************  --%>
    <dx:ASPxPopupControl ID="PopupFormAdjudicacion" runat="server" Modal="True" ClientInstanceName="PopupFormAdjudicacion" 
        PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter" 
        MaxWidth="1260" MaxHeight="680px"  MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade"  >
          <Windows>
              <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Adjudicación y Feedback" ShowFooter="False">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl10" runat="server">
                          <%--********* INI CONTENT FORM MAIN *********--%>
                          <div id="GTFormDetalleMain">
                              <dx:ASPxFormLayout runat="server" ID="FormLayoutAdjudicacion" CssClass="formLayout"  ClientInstanceName="FormLayoutAdjudicacion" SettingsItems-ShowCaption="False" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      
                                       <dx:LayoutGroup ColCount="1"   GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                          <Items>
                                              <dx:LayoutGroup ColCount="1" Width="45%"  GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="" SettingsItemCaptions-Location="Top">
                                                  <Items>
                                                         <%--INICIO GRID VIEW--%>
                                                      <dx:LayoutItem Caption="" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																  <div id="Div3" style="padding:0px 5px 0px 0px;">
                                                                      <dx:ASPxCallback ID="CallBackFunctionCotizacionPostor" runat="server" ClientInstanceName="CallBackFunctionCotizacionPostor">
                                                                          <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCotizacionPostor" />
                                                                      </dx:ASPxCallback>    
                                                                                                                                       
                                                                     <dx:ASPxTextBox ID="iCodRegistroCotizacionPostor" runat="server" Width="170px" Height="1px" Visible="True" 
                                                                        ClientVisible="False" ClientInstanceName="iCodRegistroCotizacionPostor">
                                                                      </dx:ASPxTextBox>
                                                                      <dx:ASPxGridView ID="TablaRegistrosCotizacionPostor" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosCotizacionPostor" Font-Size="Smaller" >
                                                                          <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCotizacionPostor"   FocusedRowChanged="OnGridFocusedRowChangedCotizacionPostor" RowDblClick="OnGridRowDoubleClickCotizacionPostor" 
                                                                           >
                                                                          </ClientSideEvents>
                                                                          <SettingsPager EnableAdaptivity="True" PageSize="20" AlwaysShowPager="True" Mode="ShowAllRecords">
                                                                          </SettingsPager>
                                                                          <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="200"></Settings>

                                                                          <SettingsBehavior AllowFocusedRow="True" />
                                                                          <SettingsDataSecurity AllowDelete="False">
                                                                          </SettingsDataSecurity>
                                                                          <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                                          <Settings ShowVerticalScrollBar="True" ShowFooter="false" /> 
                                                                           <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                                          <Toolbars>
                                                                              <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right" Name="ToolbarGridCotizacionPostor">
                                                                                  <Items>
                                                                                       <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo" >
                                                                                            <ItemStyle HorizontalAlign="Right" Width="170px"></ItemStyle>
                                                                                            <Template>
                                                                                                <div id="gtHeadTitle" style=""> <%--***  MODIFICAR ***--%>
                                                                                                    LISTA DE POSTORES
                                                                                                </div>
                                                                                            </Template>
                                                                                        </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">  
                                                                                            <Template>  
                                                                                                <div id="div100Percent"></div>  
                                                                                            </Template>  
                                                                                        </dx:GridViewToolbarItem>  
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnAdjudicarCotizacionPostor" ToolTip="Adjudicar - Buena Pro">
                                                                                          <Image Url="~/_GTContent/icons/Number-1-icon.png">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnFeedbackCotizacionPostor" ToolTip="Feedback del Proceso">
                                                                                          <Image IconID="programming_forcetesting_16x16office2013">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem> 
                                                                                      <dx:GridViewToolbarItem Text="" Name="BtnIMEPostor" ToolTip="Informe IME">
                                                                                          <Image Url="~/_GTContent/icons/Presentation-icon.png">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>
                                                                                  </Items>
                                                                              </dx:GridViewToolbar>
                                                                          </Toolbars>
                                                                          <Columns>
                                                                                    <dx:GridViewDataTextColumn FieldName="iCodRequerimientoCotizacion" Visible="False"  VisibleIndex="0" Caption="-">
					                                                                </dx:GridViewDataTextColumn>  
                                                                                   <dx:GridViewDataCheckColumn FieldName="bPropuestaPresenta" Visible="True"  VisibleIndex="2" Caption="Prop." Width="12">
 					                                                               <DataItemTemplate>
                                                                                        <dx:ASPxImage runat="server" ID="IconStatusPresentaPropuesta" OnInit="IconStatusPresentaPropuesta_Init" ></dx:ASPxImage>
                                                                                    </DataItemTemplate> 
                                                                                   </dx:GridViewDataCheckColumn>
                                                                                   <dx:GridViewDataTextColumn FieldName="cEstado" Visible="True"  VisibleIndex="2" Caption="BPro" Width="12">
                                                                                       <DataItemTemplate>
                                                                                        <dx:ASPxImage runat="server" ID="IconStatusEstadoAdjudicado" OnInit="IconStatusEstadoAdjudicado_Init" ></dx:ASPxImage>
                                                                                        </DataItemTemplate>
					                                                                </dx:GridViewDataTextColumn>
                                                                                    <dx:GridViewDataTextColumn FieldName="cNomContrata" Visible="True"  VisibleIndex="2" Caption="Empresa" Width="75">
					                                                                </dx:GridViewDataTextColumn>
                                                                                    
                                                                                    <dx:GridViewDataTextColumn FieldName="cFeedbackContrataDetalle" Visible="True"  VisibleIndex="2" Caption="Fdbk" Width="32" CellStyle-Font-Size="XX-Small">
					                                                                </dx:GridViewDataTextColumn>
                                                                                     
                                                                          </Columns>
                                                                          
                                                                      </dx:ASPxGridView>
                                                                  </div>
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                                      <%--FIN DE GRID VIEW--%>
												 
                                                  </Items>
                                              </dx:LayoutGroup>

                                              <%--***************************************************************--%>
                                              <%--             NUEVA REJILLA DE DATOS DETALLE COTIZACION         --%>
                                              <%--***************************************************************--%>
                                             
                                               <dx:LayoutGroup ColCount="1" Width="54%"   GroupBoxDecoration="None"  UseDefaultPaddings="false" ShowCaption="False">
                                                  <Items>
                                                         <%--INICIO GRID VIEW--%>
                                                      <dx:LayoutItem Caption="" >
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>
																  <div id="Div2" style="padding:0px 5px 0px 0px;">
                                                                      <dx:ASPxCallback ID="CallBackFunctionCotizacionDetallePostor" runat="server" ClientInstanceName="CallBackFunctionCotizacionDetallePostor">
                                                                          <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCotizacionPostor" />
                                                                      </dx:ASPxCallback>    
                                                                                                                                       
                                                                     <dx:ASPxTextBox ID="iCodRegistroCotizacionDetallePostor" runat="server" Width="170px" Height="1px" Visible="True" 
                                                                        ClientVisible="False" ClientInstanceName="iCodRegistroCotizacionDetallePostor">
                                                                      </dx:ASPxTextBox>
                                                                      <dx:ASPxGridView ID="TablaRegistrosCotizacionDetallePostor" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosCotizacionDetallePostor"   >
                                                                          <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCotizacionDetallePostor"   FocusedRowChanged="OnGridFocusedRowChangedCotizacionDetallePostor" 
                                                                           >
                                                                          </ClientSideEvents>
                                                                          <SettingsPager EnableAdaptivity="True" PageSize="6" AlwaysShowPager="True">
                                                                          </SettingsPager>
                                                                          <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="310"></Settings>

                                                                          <SettingsBehavior AllowFocusedRow="True" />
                                                                          <SettingsDataSecurity AllowDelete="False">
                                                                          </SettingsDataSecurity>
                                                                          <%--<SettingsResizing ColumnResizeMode="NextColumn" />--%>
                                                                          <Settings ShowVerticalScrollBar="True"  /> 
                                                                           <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                                          <Toolbars>
                                                                              <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right" Name="ToolbarGridCotizacionDetallePostor">
                                                                                  <Items>
                                                                                       <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo"  >
                                                                                            <ItemStyle HorizontalAlign="Right" Border-BorderStyle="None" Font-Bold="true" Font-Size="Smaller"></ItemStyle>
                                                                                           <%-- <Template>
                                                                                                <div id="gtHeadTitle" style=""> 
                                                                                                      <dx:ASPxLabel ID="LblNombreEmpresa" ClientInstanceName="LblNombreEmpresa" runat="server"></dx:ASPxLabel>
                                                                                                 
                                                                                                </div>                                                                                               
                                                                                            </Template>--%>
                                                                                        </dx:GridViewToolbarItem>
                                                                                      <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">  
                                                                                            <Template>  
                                                                                                <div id="div100Percent"></div>  
                                                                                            </Template>  
                                                                                        </dx:GridViewToolbarItem>  
                                                                                     <%-- <dx:GridViewToolbarItem Text="" Name="BtnGuardarCotizacionPostor">
                                                                                          <Image IconID="save_saveall_16x16office2013">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>--%>
                                                                                     <%-- <dx:GridViewToolbarItem Text="" Name="BtnCerrarCotizacionPostor">
                                                                                          <Image IconID="actions_buy_16x16devav">
                                                                                          </Image>
                                                                                      </dx:GridViewToolbarItem>--%>
                                                                                  </Items>
                                                                              </dx:GridViewToolbar>
                                                                          </Toolbars>
                                                                          <Columns>
                                                                                <dx:GridViewDataTextColumn FieldName="iCodRequerimientoCotizacionDetalle" Visible="False"  VisibleIndex="0" Caption="-">
					                                                            </dx:GridViewDataTextColumn>  
                                                                                 <dx:GridViewDataTextColumn FieldName="cDescripcionBienServicio" Visible="true" VisibleIndex="3" Caption="Bien / Servicio " CellStyle-Font-Size="Smaller">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="nCantidad" Visible="true" VisibleIndex="3" Caption="Cantidad" Width="70" CellStyle-Font-Size="Smaller">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="cNomCortoMedida" Visible="true" VisibleIndex="3" Caption="U. Med." CellStyle-HorizontalAlign="Center"  Width="60" CellStyle-Font-Size="Smaller">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="nPrecioUnit" Visible="true" VisibleIndex="3" Caption="P.Unit."  Width="65" CellStyle-Font-Size="Smaller">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="nSubTotal" Visible="true" VisibleIndex="3" Caption="S.Total"  Width="70" CellStyle-Font-Size="Smaller">
                                                                                </dx:GridViewDataTextColumn>
                                                                          </Columns> 
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
          <%--<ContentCollection>
              <dx:PopupControlContentControl ID="PopupControlContentControl11" runat="server">
              </dx:PopupControlContentControl>
          </ContentCollection>--%>
     <%--     <ClientSideEvents Closing="function(s, e) {
	ClearContentControls();
              
}"           Shown="function(s,e){
               TablaRegistrosDetalle.PerformCallback('LoadPrimera');
            
              }" >
              
          </ClientSideEvents>--%>
      </dx:ASPxPopupControl>

    <%--********************************   POPUP   ADJUDICAR REQUERIMIENTO    ************************************************--%>
     <!--#region POPUP ADJUDICA REQUERIMIENTO -->
    <div id="#REGION_POPUP_ADJUDICAREQUERIMIENTO">
        <dx:ASPxPopupControl ID="PopupFormAdjudicarPostor" runat="server" Modal="True" ClientInstanceName="PopupFormAdjudicarPostor"
            PopupElementID="PopupFormAdjudicarPostor" PopupHorizontalAlign="WindowCenter" Width="600px" PopupVerticalAlign="WindowCenter"
            MaxWidth="600" MaxHeight="680px" MinWidth="300px" CloseAction="CloseButton" CloseAnimationType="Fade">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Adjudicar y Buena Pro" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl11" runat="server" >
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutAdjudicarPostor" CssClass="formLayout" ClientInstanceName="FormLayoutAdjudicarPostor" Paddings-PaddingTop="0">
                                    <SettingsAdaptivity  AdaptivityMode="SingleColumnWindowLimit" />
                                    <Items>
                                         <dx:LayoutGroup ColCount="1" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales" Paddings-PaddingTop="0">
                                                    <Items>
                                                         <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Empresa Adjudicada" Paddings-PaddingTop="0">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                   <dx:ASPxTextBox ID="cNomContrataAdjudicada" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cNomContrataAdjudicada" ReadOnly="true" ReadOnlyStyle-Font-Bold="true" ReadOnlyStyle-BackColor="WhiteSmoke"  CssClass="toUpper">
                                                                       </dx:ASPxTextBox> 
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Notas y Sustento de la Adjudicación" Paddings-PaddingTop="0">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cNotasAdjudica" runat="server" Height="80px" Width="100%" CssClass="toUpper" ClientInstanceName="cDescripcionBienServicio">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                         <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Costo Total del Requerimiento Adjudicado">                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer> 
                                                                     <dx:ASPxSpinEdit ID="nTotal" ClientInstanceName="nTotal" runat="server" Number="0" NumberType="Float" ClientSideEvents-KeyUp="nPrecioUnit_KeyUp"
                                                                        MinValue="1" MaxValue="999999" Width="40%" DisplayFormatString="n2" DecimalPlaces="2" >
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>     

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                              <LayoutItemNestedControlCollection>
                                                                  <dx:LayoutItemNestedControlContainer>
                                                                         <table class="OAELStat" style="margin-top:12px!important; float:left;">
                                                                          <tr>
                                                                              <td style="padding-right: 20px; padding-top:2px;">
                                                                                   <b>IMPORTANTE - </b>Una vez adjudicado el requerimiento no podrá realizar cambios posteriores.                                                                                 
                                                                              </td>
                                                                  
                                                                          </tr>
                                                                      </table>
                                                          
                                                                  </dx:LayoutItemNestedControlContainer>
                                                              </LayoutItemNestedControlCollection>
                                                          </dx:LayoutItem>  

                                                    </Items>
                                                </dx:LayoutGroup>

                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                            <Items>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <table style="margin-top: 12px!important;">
                                                                <tr>
                                                                    <td style="padding-right: 10px;">
                                                                        <dx:ASPxButton ID="BtnGuardarAdjudicarPostor" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarAdjudicarPostor" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnGuardarAdjudicarPostor_Click" />
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                    <td>
                                                                        <dx:ASPxButton ID="BtnCancelAdjudicarPostor" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelAdjudicarPostor" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnCancelAdjudicarPostor_Click"></ClientSideEvents>
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
         <%--   <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl12" runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>--%>
            <ClientSideEvents Closing="function(s, e) {  ASPxClientEdit.ClearEditorsInContainer(FormLayoutAdjudicarPostor.GetMainElement());}"></ClientSideEvents>
        </dx:ASPxPopupControl>
    </div>
    <!--#endregion POPUP ADJUDICA REQUERIMIENTO -->

     <%--********************************   POPUP FEEDBACK REQUERIMIENTO    ************************************************--%>
     <!--#region POPUP FEEDBACK REQUERIMIENTO -->
    <div id="#REGION_POPUP_FEEDBACKREQUERIMIENTO">
        <dx:ASPxPopupControl ID="PopupFormFeedbackPostor" runat="server" Modal="True" ClientInstanceName="PopupFormFeedbackPostor"
            PopupElementID="PopupFormFeedbackPostor" PopupHorizontalAlign="WindowCenter" Width="600px" PopupVerticalAlign="WindowCenter"
            MaxWidth="600" MaxHeight="680px" MinWidth="300px" CloseAction="CloseButton" CloseAnimationType="Fade">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Feedback " ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl13" runat="server" >
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutFeedbackPostor" CssClass="formLayout" ClientInstanceName="FormLayoutFeedbackPostor" Paddings-PaddingTop="0">
                                    <SettingsAdaptivity  AdaptivityMode="SingleColumnWindowLimit" />
                                    <Items>
                                         <dx:LayoutGroup ColCount="1" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales" Paddings-PaddingTop="0">
                                                    <Items>
                                                         <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Empresa" Paddings-PaddingTop="0">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                   <dx:ASPxTextBox ID="cNomContrataFeedback" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cNomContrataFeedback" ReadOnly="true" ReadOnlyStyle-Font-Bold="true" ReadOnlyStyle-BackColor="WhiteSmoke"  CssClass="toUpper">
                                                                       </dx:ASPxTextBox> 
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                          <%--***ITEM FORM ***--%>
                                                         <%--***ITEM FORM ***--%>
													<dx:LayoutItem Caption="Respuesta Feedback">
														<LayoutItemNestedControlCollection>
															<dx:LayoutItemNestedControlContainer>																
                                                                 <dx:ASPxComboBox ID="cFeedbackContrata" runat="server" ValueType="System.String" ClientInstanceName="cFeedbackContrata">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
																 </dx:ASPxComboBox>                                                                                                                              
															</dx:LayoutItemNestedControlContainer>
														</LayoutItemNestedControlCollection>
													</dx:LayoutItem>
                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Detalles del Feedback" Paddings-PaddingTop="0">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cFeedbackContrataDetalle" runat="server" Height="80px" Width="100%" CssClass="toUpper" ClientInstanceName="cFeedbackContrataDetalle">
                                                                     <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                         <%--***ITEM FORM ***--%>
                                                       <%-- <dx:LayoutItem Caption="Costo Total del Requerimiento Adjudicado">                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer> 
                                                                     <dx:ASPxSpinEdit ID="ASPxSpinEdit1" ClientInstanceName="nTotal" runat="server" Number="0" NumberType="Float" ClientSideEvents-KeyUp="nPrecioUnit_KeyUp"
                                                                        MinValue="1" MaxValue="999999" Width="40%" DisplayFormatString="n2" DecimalPlaces="2" >
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>     --%>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                              <LayoutItemNestedControlCollection>
                                                                  <dx:LayoutItemNestedControlContainer>
                                                                         <table class="OAELStat" style="margin-top:12px!important; float:left;">
                                                                          <tr>
                                                                              <td style="padding-right: 20px; padding-top:2px;">
                                                                                   <b>IMPORTANTE - </b>Una vez adjudicado el requerimiento no podrá realizar cambios posteriores.                                                                                 
                                                                              </td>
                                                                  
                                                                          </tr>
                                                                      </table>
                                                          
                                                                  </dx:LayoutItemNestedControlContainer>
                                                              </LayoutItemNestedControlCollection>
                                                          </dx:LayoutItem>  

                                                    </Items>
                                                </dx:LayoutGroup>

                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                            <Items>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <table style="margin-top: 12px!important;">
                                                                <tr>
                                                                    <td style="padding-right: 10px;">
                                                                        <dx:ASPxButton ID="BtnGuardarFeedbackPostor" runat="server" Text="Guardar Feedback" Width="100px" ClientInstanceName="BtnGuardarFeedbackPostor" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnGuardarAdjudicarPostor_Click" />
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                    <td>
                                                                        <dx:ASPxButton ID="BtnCancelFeedbackPostor" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelFeedbackPostor" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnCancelAdjudicarPostor_Click"></ClientSideEvents>
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
          <%--  <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl14" runat="server">
                </dx:PopupControlContentControl>
            </ContentCollection>--%>
            <ClientSideEvents Closing="function(s, e) {  ASPxClientEdit.ClearEditorsInContainer(FormLayoutFeedbackPostor.GetMainElement());}"></ClientSideEvents>
        </dx:ASPxPopupControl>
    </div>
    <!--#endregion POPUP ADJUDICA REQUERIMIENTO -->
         <%-- ***************************** SECCION POPUPS REPORTE ***************************** --%>
      <dx:ASPxPopupControl ID="PopupFormReportes" runat="server" Modal="True" ClientInstanceName="PopupFormReportes" 
        PopupElementID="PopupFormReportes" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
        Height="90%" Width="90%" CloseAction="CloseButton" CloseAnimationType="Fade" HeaderText="Formato de Requerimiento de Personal - OAEL AAQ"  >
         <SettingsAdaptivity Mode="Always" VerticalAlign="WindowCenter" MinHeight="95%" MinWidth="97%" />  
                <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server" CssClass="popupSimple">
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