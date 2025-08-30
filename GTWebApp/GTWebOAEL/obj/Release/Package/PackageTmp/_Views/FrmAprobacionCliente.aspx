<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmAprobacionCliente.aspx.vb" Inherits="GTWebOAEL.FrmAprobacionCliente" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCore.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCoreDetalle.js"></script>
    <script type="text/javascript" src="../_GTJScript/AprobacionCliente.js"></script>

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
                TablaRegistrosDetalle.PerformCallback();
                e.processOnServer = false;
                BtnGuardar.SetEnabled(true);
                BtnConfirmarEnviar.SetEnabled(false);
            }
            else if (e.item.name == "BtnEditar") {
                cFormMetadata.Set("cTipoOpe", "M");
                iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                ClearContentControls();
                viewRecord();
                FormMainModalShow();
                TablaRegistrosDetalle.PerformCallback();
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnEliminar") {
                var popupWindow = PopupConfirmDelete.GetWindow(0);
                PopupConfirmDelete.ShowWindow(popupWindow);
                e.processOnServer = false;
        }
            else if (e.item.name == "BtnVerTodo") {
                cTipoVerGrilla.SetText("VER_TODO");
                TablaRegistros.PerformCallback("VerTodo");
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
            else if (e.item.name == "BtnAprobarReqDetalle") {
                iCommandDetalle = 4;
                msgDetalle = "Requerimiento Aprobado";

                if (iCodRegistroDetalle.GetValue() != null && iCodRegistroDetalle.GetValue() != "0") {

                    var popupWindow = PopupFormAprobarReqDetalle.GetWindow(0);
                    PopupFormAprobarReqDetalle.ShowWindow(popupWindow);
                }
                else {
                    ShowAlertMessage('Se debe seleccionar un registro.');
                }

                e.processOnServer = false;
            }
            else if (e.item.name == "BtnNotificarReqDetalle") {
                iCommandDetalle = 5;
                msgDetalle = "El requerimiento fue liberado.";

                if (iCodRegistroDetalle.GetValue() != null && iCodRegistroDetalle.GetValue() != "0") {

                    var popupWindow = PopupFormNotificarReqDetalle.GetWindow(0);
                    obtenerDatosNotificacion();
                    PopupFormNotificarReqDetalle.ShowWindow(popupWindow);
                }
                else {
                    ShowAlertMessage('Se debe seleccionar un registro.');
                }

                e.processOnServer = false;
            }
            else if (e.item.name == "BtnAsignarReqDetalle") {
                iCommandDetalle = 6;
                msgDetalle = "Requerimiento asignado con éxito";

                if (iCodRegistroDetalle.GetValue() != null && iCodRegistroDetalle.GetValue() != "0") {
                    var popupWindow = PopupFormAsignarReqDetalle.GetWindow(0);
                    PopupFormAsignarReqDetalle.ShowWindow(popupWindow);
                }
                else {
                    ShowAlertMessage('Se debe seleccionar un registro.');
                }

                e.processOnServer = false;
            }
            else if (e.item.name == "BtnCancelarReqDetalle") {
                iCommandDetalle = 7;
                msgDetalle = "El requerimiento fue cancelado.";

                if (iCodRegistroDetalle.GetValue() != null && iCodRegistroDetalle.GetValue() != "0") {
                    var popupWindow = PopupFormCancelarReqDetalle.GetWindow(0);
                    PopupFormCancelarReqDetalle.ShowWindow(popupWindow);
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

                if (iCommandDetalle == 1 || iCommandDetalle == 2) {
                    // GUARDAR Y EDITAR CERRAR FORM DETALLE
                    CloseFormMainModalDetalle();
                }

                if (iCommandDetalle == 4) {
                    // FORM APROBAR
                    var popupWindow = PopupFormAprobarReqDetalle.GetWindow(0);
                    PopupFormAprobarReqDetalle.HideWindow(popupWindow);
                }

                if (iCommandDetalle == 5) {
                    // FORM LIBERAR
                    var popupWindow = PopupFormNotificarReqDetalle.GetWindow(0);
                    PopupFormNotificarReqDetalle.HideWindow(popupWindow);
                }

                if (iCommandDetalle == 6) {
                    // FORM ASIGNAR
                    var popupWindow = PopupFormAsignarReqDetalle.GetWindow(0);
                    PopupFormAsignarReqDetalle.HideWindow(popupWindow);
                }
                if (iCommandDetalle == 7) {
                    // FORM CANCELAR
                    var popupWindow = PopupFormCancelarReqDetalle.GetWindow(0);
                    PopupFormCancelarReqDetalle.HideWindow(popupWindow);
                }

            } else if (Resultado == "FRDCVNC") {
                ShowAlertMessage('Campo Nro Vacantes no es v\u00E1lido.');
            } else if (Resultado == "FRDCSNC") {
                ShowAlertMessage('Campo Salario no es v\u00E1lido.');
            } else if (Resultado == "FRDCCNC") {
                ShowAlertMessage('Campo Comentarios no es v\u00E1lido.');
            } else if (Resultado == "FRDCPNC") {
                ShowAlertMessage('Campo Persona Remplazar no es v\u00E1lido.');
            }
            else if (Resultado == "FRACPNC") {
                ShowAlertMessage('Campo Persona Aprueba no es v\u00E1lido.');
            } else if (Resultado == "FRACONC") {
                ShowAlertMessage('Campo Observacion no es v\u00E1lido.');
            }
            else if (Resultado == "FRECCCONC") {
                ShowAlertMessage('Campo Destinatario Consultor no es v\u00E1lido.');
            } else if (Resultado == "FRECCCLNC") {
                ShowAlertMessage('Campo Destinatario Cliente no es v\u00E1lido.');
            }
            else if (Resultado == "FRCCONC") {
                ShowAlertMessage('Campo Observacion no es v\u00E1lido.');
            }
            else {
                ShowAlertMessage('Ocurrió un error durante la transacción.');
            }
        }

        function OnBtnGuardarClickCustom(s, e) {
            if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {
                CallBackFunction.PerformCallback();

                //BtnConfirmarEnviar.SetEnabled(true);

                //ShowAlertMessage('Registro guardado con éxito.');
            }
            else {
                e.processOnServer = false;
            }
        }

        function OnEndCallBackFunctionCustom(s, e) {

            var arrayItems = e.result.split('-');

            if (arrayItems[1] == "OK") {
                if (arrayItems[2] == "EN_CED") {

                    ShowAlertMessage('Se envio la convocatoria al OAEL.');
                    BtnConfirmarEnviar.SetEnabled(false);

                } else if (arrayItems[2] == "CR_CONV") {

                    ShowAlertMessage('Se creo la convocatoria con éxito.');
                } else if (arrayItems[2] == "AP_CONV") {

                    ShowAlertMessage('Se aprobó y finalizó la convocatoria con éxito.');
                    BtnAprobarFinalizar.SetEnabled(false);
                    BtnDesaprobarFinalizar.SetEnabled(false);
                }
                else if (arrayItems[2] == "DAP_CONV") {

                    ShowAlertMessage('Se Desaprobó y finalizó la convocatoria con éxito.');
                    BtnAprobarFinalizar.SetEnabled(false);
                    BtnDesaprobarFinalizar.SetEnabled(false);
                }

                iCodRegistro.SetText(arrayItems[0]);
                TablaRegistros.PerformCallback();
                TablaRegistrosDetalle.PerformCallback();
            }
            else {

                ShowAlertMessage('Ocurrió un error durante el proceso.');
            }
            //if (e.result > 0) {

            //    iCodRegistro.SetText(e.result);
            //    ShowAlertMessage('Se aprobó y finalizó la convocatoria con éxito.');
            //    BtnAprobarFinalizar.SetEnabled("false");
            //    TablaRegistros.PerformCallback();
            //    TablaRegistrosDetalle.PerformCallback();
                
            //}
            //else {
            //    ShowAlertMessage('Ocurrió un error durante el proceso.');
            //}

        }


        function OnBtnConfirmarEnviarClick(s, e) {
            var popupWindow = PopupConfirmarEnvio.GetWindow(0);
            PopupConfirmarEnvio.ShowWindow(popupWindow);
            e.processOnServer = false;

        }

        function OnBtnAprobarFinalizarClick(s, e) {
            var popupWindow = PopupConfirmarAprobacion.GetWindow(0);
            PopupConfirmarAprobacion.ShowWindow(popupWindow);
            e.processOnServer = false;

        }

        function OnBtnDesaprobarFinalizarClick(s, e) {
            var popupWindow = PopupConfirmarDesaprobacion.GetWindow(0);
            PopupConfirmarDesaprobacion.ShowWindow(popupWindow);
            e.processOnServer = false;
        }

        function OnBtnGuardarEnviarClick(s, e) {
            //if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopup.GetMainElement(), null, true)) {

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

        function OnBtnGuardarAprobacionClick(s, e) {

            cFormMetadata.Set("cTipoOpe", "AC");
            CallBackFunction.PerformCallback();
            var popupWindow = PopupConfirmarAprobacion.GetWindow(0);
            PopupConfirmarAprobacion.HideWindow(popupWindow);

            e.processOnServer = false;

        }

        function OnBtnCancelarAprobacionClick(s, e) {
            var popupWindow = PopupConfirmarAprobacion.GetWindow(0);
            PopupConfirmarAprobacion.HideWindow(popupWindow);
            e.processOnServer = false;

        }

        function OnBtnGuardarDesaprobacionClick(s, e) {

            cFormMetadata.Set("cTipoOpe", "DC");
            CallBackFunction.PerformCallback();
            var popupWindow = PopupConfirmarDesaprobacion.GetWindow(0);
            PopupConfirmarDesaprobacion.HideWindow(popupWindow);

            e.processOnServer = false;

        }

        function OnBtnCancelarDesaprobacionClick(s, e) {
            var popupWindow = PopupConfirmarDesaprobacion.GetWindow(0);
            PopupConfirmarDesaprobacion.HideWindow(popupWindow);
            e.processOnServer = false;

        }
    </script>

    <!--#region FORMULARIO LISTA CONVOCATORIAS -->
    <div id="#region_FrmConvocatorias_Lista_Convocatorias">
        <div>
            <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
                <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCustom" />
            </dx:ASPxCallback>
        </div>
        <div id="ContentTablaRegistros" style="padding: 15px 15px 0px 15px;">
            <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
                ClientVisible="False" ClientInstanceName="iCodRegistro">
            </dx:ASPxTextBox>
             <dx:ASPxTextBox ID="cTipoVerGrilla" runat="server" Width="170px" Visible="True"
                ClientVisible="False" ClientInstanceName="cTipoVerGrilla">
            </dx:ASPxTextBox>
            <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
            </dx:ASPxHiddenField>
            <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros">
                <ClientSideEvents ToolbarItemClick="OnToolbarItemClickCustom" FocusedRowChanged="OnGridFocusedRowChanged"
                    Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback"></ClientSideEvents>
                <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                </SettingsPager>
                <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="350"></Settings>
                <SettingsBehavior AllowFocusedRow="True" />
                <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
                <Settings ShowVerticalScrollBar="True" GridLines="None" />
                <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
                <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

                <Toolbars>
                    <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                        <Items>
                            <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                                <ItemStyle HorizontalAlign="Right" Width="380px"></ItemStyle>
                                <Template>
                                    <div id="gtHeadTitle" style="">
                                        <i class="fal fa-clipboard-list"></i>
                                        <span class="gtHeadSpan">CONVOCATORIAS PENDIENTES</span>
                                    </div>
                                </Template>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                                <Template>
                                    <div id="div100Percent">
                                    </div>
                                </Template>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Text="Agregar" Name="BtnAgregar" ToolTip="Nuevo Registro" ClientVisible="false">
                                <Image IconID="actions_additem_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Text="Ver" Name="BtnEditar" ToolTip="Ver Registro">
                                <Image IconID="actions_show_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar" ToolTip="Eliminar Registro" ClientVisible="false">
                                <Image IconID="edit_delete_16x16office2013">
                                </Image>
                            </dx:GridViewToolbarItem>
                            <dx:GridViewToolbarItem Name="BtnVerTodo" Text="Ver Todo" ToolTip="Ver todo">
                                <Image IconID="miscellaneous_windows_16x16office2013">
                                </Image>
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
                    <dx:GridViewDataTextColumn FieldName="iCodConvocatoriaMain" Visible="false" VisibleIndex="0">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cNroConvocatoria" Visible="true" Caption="Nro Requerimiento" VisibleIndex="1" Width="150">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="dFechaSolicitud" Visible="true" Caption="Fecha Sol." VisibleIndex="1" Width="150">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="iEstado" Visible="True" VisibleIndex="2" Caption="Estado OAEL" Width="94" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center">
                        <DataItemTemplate>
                            <dx:ASPxImage runat="server" ID="EstadoConvocatoriaMain" OnInit="EstadoConvocatoriaMain_Init"></dx:ASPxImage>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cSubContratista" Visible="true" Caption="SubContratista" VisibleIndex="1" Width="150">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="cContrato" Visible="true" Caption="Contrato" VisibleIndex="1" Width="150">
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
             <%--       <dx:GridViewDataCheckColumn FieldName="bAprobadoCED" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprobado CED" Width="90">
                    </dx:GridViewDataCheckColumn>--%>
                    <dx:GridViewDataCheckColumn FieldName="bAprobadoCliente" Visible="True" VisibleIndex="3" HeaderStyle-HorizontalAlign="Center" CellStyle-HorizontalAlign="Center" Caption="Aprobado AAQ" Width="66">
                    </dx:GridViewDataCheckColumn>


                </Columns>
            </dx:ASPxGridView>
        </div>
    </div>
    <!--#endregionFORMULARIO LISTA CONVOCATORIAS -->

    <!--#region POPUP AGREGAR Y EDITAR CONVOCATORIA -->
    <div id="#region_FrmConvocatorias_AgregarEditar_Convocatoria">
        <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli"
            PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="1260px" PopupVerticalAlign="WindowCenter"
            MaxWidth="1260px" MaxHeight="640px" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade" AllowDragging="True">
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

                                                                    <dx:ASPxComboBox ID="iCodSubContrata" runat="server" ValueType="System.String" ClientInstanceName="iCodSubContrata" ClientEnabled="false">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Contrato">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iCodContratistaContrato" runat="server" ValueType="System.String" ClientInstanceName="iCodContratistaContrato" ClientEnabled="false">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Fecha Inicio">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxDateEdit ID="dFechaIni" ClientInstanceName="dFechaIni" runat="server" AutoPostBack="false" UseMaskBehavior="False" ClientEnabled="false"
                                                                        CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False" ></CalendarProperties>

                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                            <RequiredField IsRequired="True"></RequiredField>
                                                                        </ValidationSettings>
                                                                    </dx:ASPxDateEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Fecha Fin">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxDateEdit ID="dFechaFin" ClientInstanceName="dFechaFin" runat="server" AutoPostBack="false" UseMaskBehavior="False" ClientEnabled="false"
                                                                        CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False" ></CalendarProperties>

                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                            <RequiredField IsRequired="True"></RequiredField>
                                                                        </ValidationSettings>
                                                                    </dx:ASPxDateEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                         <dx:LayoutItem Caption="Solicitante">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                       <dx:ASPxTextBox ID="cSolicitante" runat="server"  Height="1px" Visible="True" ClientVisible="True" ClientInstanceName="cSolicitante"  CssClass="toUpper">
                                                                       </dx:ASPxTextBox>
                                                                    </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Observaciones">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cObs" ClientInstanceName="cObs" runat="server" CssClass="toUpper"  Width="100%" ClientEnabled="false" >
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
                                                                           <%-- <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnGuardar" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardar" AutoPostBack="false" ClientVisible="false">
                                                                                    <ClientSideEvents Click="OnBtnGuardarClickCustom" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnConfirmarEnviar" runat="server" Text="Enviar a CED" Width="100px" ClientInstanceName="BtnConfirmarEnviar" AutoPostBack="false" ClientVisible="false">
                                                                                    <ClientSideEvents Click="OnBtnConfirmarEnviarClick" />
                                                                                </dx:ASPxButton>
                                                                            </td>--%>
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnAprobarFinalizar" runat="server" Text="Aprobar y Finalizar" Width="100px" ClientInstanceName="BtnAprobarFinalizar" AutoPostBack="false">
                                                                                    <ClientSideEvents Click="OnBtnAprobarFinalizarClick" />
                                                                                </dx:ASPxButton>
                                                                            </td>
                                                                            <td style="padding-right: 10px;">
                                                                                <dx:ASPxButton ID="BtnDesaprobarFinalizar" runat="server" Text="Desaprobar y Finalizar" Width="100px" ClientInstanceName="BtnDesaprobarFinalizar" AutoPostBack="false">
                                                                                    <ClientSideEvents Click="OnBtnDesaprobarFinalizarClick" />
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
                                                                    <div class="ContentTablaDetalle" id="ContentTablaRegistroDetalle" style="padding: 10px 0px 0px 0px;">
                                                                        <dx:ASPxCallback ID="CallBackFunctionDetalle" runat="server" ClientInstanceName="CallBackFunctionDetalle">
                                                                            <ClientSideEvents CallbackComplete="OnEndCallBackFunctionDetalleCustom" />
                                                                        </dx:ASPxCallback>
                                                                        <dx:ASPxTextBox ID="iCodRegistroDetalle" runat="server" Width="170px" Height="1px" Visible="True"
                                                                            ClientVisible="False" ClientInstanceName="iCodRegistroDetalle">
                                                                        </dx:ASPxTextBox>
                                                                        <dx:ASPxGridView ID="TablaRegistrosDetalle" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosDetalle">
                                                                            <ClientSideEvents ToolbarItemClick="OnToolbarItemClickDetalleCustom" FocusedRowChanged="OnGridFocusedRowChangedDetalle"></ClientSideEvents>
                                                                            <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
                                                                            </SettingsPager>
                                                                            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="200"></Settings>
                                                                            <SettingsBehavior AllowFocusedRow="True" AllowSort="false" />
                                                                            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>

                                                                            <Settings ShowVerticalScrollBar="True" />
                                                                            <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
                                                                            <Toolbars>
                                                                                <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right" Name="ToolbarGridDetalle">
                                                                                    <Items>
                                                                                        <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                                                                                            <ItemStyle HorizontalAlign="Right" Width="180px"></ItemStyle>
                                                                                            <Template>
                                                                                                <div id="gtHeadTitleDetalle" style="">
                                                                                                    PUESTOS SOLICITADOS
                                                                                                </div>
                                                                                            </Template>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                                                                                            <Template>
                                                                                                <div id="div100Percent"></div>
                                                                                            </Template>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem Text="" Name="BtnAgregarDetalle" ToolTip="Agregar Puesto" ClientVisible="false">
                                                                                            <Image IconID="actions_additem_16x16office2013">
                                                                                            </Image>
                                                                                        </dx:GridViewToolbarItem>
                                                                                         <dx:GridViewToolbarItem Text="" Name="BtnEditarDetalle" ToolTip="Ver Puesto">
                                                                                            <Image IconID="actions_show_32x32office2013">
                                                                                            </Image>
                                                                                        </dx:GridViewToolbarItem>

                                                                                        <%--<dx:GridViewToolbarItem Name="BtnEliminarDetalle" Text="" ToolTip="Eliminar Puesto">
                                                                                            <Image IconID="edit_delete_16x16office2013"></Image>
                                                                                        </dx:GridViewToolbarItem>--%>
                                                                                        <%-- <dx:GridViewToolbarItem Name="BtnAprobarReqDetalle" Text="" ToolTip="Aprobar" ItemStyle-CssClass="aprobarReq" BeginGroup="true">
                                                                                            <Image Url="../Content/Icon16/Accept-icon.png"></Image>
                                                                                        </dx:GridViewToolbarItem>--%>
                                                                                        <%--  <dx:GridViewToolbarItem Name="BtnAsignarReqDetalle" Text="" ToolTip="Asignar">
                                                                                            <Image Url="../Content/Icon16/Teachers-icon.png"></Image>
                                                                                        </dx:GridViewToolbarItem>
                                                                                        <dx:GridViewToolbarItem Name="BtnNotificarReqDetalle" Text="" ToolTip="Notificar">
                                                                                            <Image Url="../Content/Icon16/send-mail-icon.png"></Image>
                                                                                        </dx:GridViewToolbarItem>

                                                                                        <dx:GridViewToolbarItem Name="BtnCancelarReqDetalle" Text="" ToolTip="Cancelar">
                                                                                            <Image Url="../Content/Icon16/cancel-icon.png"></Image>
                                                                                        </dx:GridViewToolbarItem>--%>
                                                                                    </Items>
                                                                                </dx:GridViewToolbar>
                                                                            </Toolbars>
                                                                            <Columns>
                                                                               <%-- <dx:GridViewDataTextColumn FieldName="iCodConvocatoria" Visible="false" VisibleIndex="0">
                                                                                </dx:GridViewDataTextColumn>--%>
                                                                                <%--  <dx:GridViewDataTextColumn FieldName="cEstadoProceso" VisibleIndex="1" Caption="-" Width="40">
                                                                            <DataItemTemplate>
                                                                                <dx:ASPxImage runat="server" ID="RDetalleStatus" OnInit="RDetalleStatus_Init"></dx:ASPxImage>
                                                                            </DataItemTemplate>
                                                                        </dx:GridViewDataTextColumn>--%>
                                                                                <%--  <dx:GridViewDataTextColumn FieldName="cNroRequerimientoDetalle" Width="180"
                                                                            Visible="true" Caption="Nro Requerimiento Detalle" VisibleIndex="2">
                                                                        </dx:GridViewDataTextColumn>--%>

                                                                                <%--   <dx:GridViewDataTextColumn FieldName="iCodEtapaProceso" Visible="false" VisibleIndex="3" Caption="Etapa">
                                                                        </dx:GridViewDataTextColumn>--%>
                                                                               <dx:GridViewDataTextColumn FieldName="iCodConvocatoria" Visible="false" VisibleIndex="0">
                                                                                </dx:GridViewDataTextColumn>
                                                                         
                                                                                <dx:GridViewDataTextColumn FieldName="cPerfil" Visible="true" VisibleIndex="3" Caption="Puesto">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="cMOCMONC" Visible="true" VisibleIndex="3" Caption="Tipo MMOO" Width="82">
                                                                                </dx:GridViewDataTextColumn>
                                                                                <dx:GridViewDataTextColumn FieldName="iCantidad" Visible="true" VisibleIndex="3" Caption="Cantidad" Width="75">
                                                                                </dx:GridViewDataTextColumn>

                                                                                <dx:GridViewDataTextColumn FieldName="cEstado" VisibleIndex="4" Caption="Estado" Width="90" CellStyle-HorizontalAlign="Center">
                                                                                    <DataItemTemplate>
                                                                                        <dx:ASPxLabel runat="server" EncodeHtml="false" ID="EstadoPuestos" OnInit="EstadoPuestos_Init" CssClass="infoColumna">
                                                                                        </dx:ASPxLabel>
                                                                                    </DataItemTemplate>
                                                                                </dx:GridViewDataTextColumn>
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
            PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="1240px" PopupVerticalAlign="WindowCenter"
            MaxWidth="1240" MaxHeight="680px" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Solicitud de Puesto" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                           <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormLayoutPopupDetalle">
                                    <SettingsAdaptivity  AdaptivityMode="SingleColumnWindowLimit" />
                                    <Items>

                                        <dx:TabbedLayoutGroup Caption="" Width="100%">
                                            <Items>
                                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Principales">
                                                    
                                                    <Items>
                                                        <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Puesto">
                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iCodOcupacion" runat="server" ValueType="System.String" ClientInstanceName="iCodOcupacion"  Width="100%">
                                                                        <%--<ClientSideEvents SelectedIndexChanged="iCodOcupacion_SelectedIndexChanged" />--%>
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                                                                               <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Grado Instruccion">
                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iGradoInstruccion" runat="server" ValueType="System.String" ClientInstanceName="iGradoInstruccion"  Width="100%">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                      
                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Cantidad">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
 
                                                                     <dx:ASPxSpinEdit ID="iCantidad" ClientInstanceName="iCantidad" runat="server" Number="1" NumberType="Integer"
                                                                        MinValue="1" MaxValue="60" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>

                                                       

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        <%--***ITEM FORM ***--%>
                                                         <dx:LayoutItem Caption="Experiencia Mínima (Meses)">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                      <dx:ASPxSpinEdit ID="iTiempoExpRequerida" ClientInstanceName="iTiempoExpRequerida" runat="server" Number="0" NumberType="Integer"
                                                                        MinValue="1" MaxValue="200" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>


                                                      

                                                          <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Detalle Puesto:">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                <%--    <dx:ASPxHtmlEditor ID="cDesPerfil" runat="server" Width="100%" Height="50%" ClientInstanceName="cDesPerfil" ClientEnabled="true">
                                                                        <Settings AllowDesignView="True" AllowHtmlView="False" />
                                                                    </dx:ASPxHtmlEditor>--%>
                                                                     <%--<dx:ASPxMemo ID="cDesPerfil" runat="server" Height="100px" Width="200%" CssClass="toUpper" ClientInstanceName="cDesPerfil">
                                                                    </dx:ASPxMemo>--%>

                                                                     <dx:ASPxHtmlEditor runat="server" Width="200%" Height="260" ID="cDesPerfil" ClientInstanceName="cDesPerfil" ClientEnabled="true" >
                                                                         <Settings AllowDesignView="True" AllowHtmlView="False" AllowPreview="False"  />
                                                                         <SettingsHtmlEditing EnterMode="BR" PasteMode="MergeFormatting" AllowFormElements="false" AllowIFrames="false" AllowScripts="false" AllowStyleAttributes="false" AllowIdAttributes="false" AllowedDocumentType="HTML5" UpdateBoldItalic="false" UpdateDeprecatedElements="false">  
                                                                            <ContentElementFiltering TagFilterMode="WhiteList" Tags="b, i, u, ul, li, strong,  br, em, code, strike" />  
                                                                        </SettingsHtmlEditing>  
                                                                         <Toolbars>
                                                                <dx:HtmlEditorToolbar>
                                                                    <Items>
                                                                        <dx:ToolbarCutButton>
                                                                        </dx:ToolbarCutButton>
                                                                        <dx:ToolbarCopyButton>
                                                                        </dx:ToolbarCopyButton>
                                                                        <dx:ToolbarPasteButton>
                                                                        </dx:ToolbarPasteButton>

                                                                        <dx:ToolbarUndoButton BeginGroup="True">
                                                                        </dx:ToolbarUndoButton>
                                                                        <dx:ToolbarRedoButton>
                                                                        </dx:ToolbarRedoButton>

                                                                        <dx:ToolbarBoldButton BeginGroup="True">
                                                                        </dx:ToolbarBoldButton>
                                                                        <dx:ToolbarItalicButton>
                                                                        </dx:ToolbarItalicButton>
                                                                        <dx:ToolbarUnderlineButton>
                                                                        </dx:ToolbarUnderlineButton>

                                                                       <%-- <dx:ToolbarInsertOrderedListButton BeginGroup="True">
                                                                        </dx:ToolbarInsertOrderedListButton>--%>
                                                                        <dx:ToolbarInsertUnorderedListButton BeginGroup="True">
                                                                        </dx:ToolbarInsertUnorderedListButton>

                                                                     </Items>
                                                                </dx:HtmlEditorToolbar>
                                                            
                                                            </Toolbars>
                                                                     </dx:ASPxHtmlEditor>


<%--<dx:ASPxHtmlEditor runat="server"></dx:ASPxHtmlEditor>--%>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>



                                                           <%-- <dx:LayoutItem Caption="">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
 
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>


                                                        
                                                              <%--***ITEM FORM ***--%>
                                                     <%--   <dx:LayoutItem Caption="Experiencia">
                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cExperiencia" runat="server" Height="70px" Width="100%" CssClass="toUpper" ClientInstanceName="cExperiencia">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>

                                                                              <%--***ITEM FORM ***--%>
                                                        <%--<dx:LayoutItem Caption="Requisitos Deseables">
                                                           
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cCompetencias" runat="server" Height="70px" Width="100%" CssClass="toUpper" ClientInstanceName="cCompetencias">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>

                                                  
                                                        
                                                       

                                                                           <%--***ITEM FORM ***--%>
                                                       <%-- <dx:LayoutItem Caption="Escala Remunerativa">
                                                        
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="iEscalaRemunerativa" runat="server" ValueType="System.String" ClientInstanceName="iEscalaRemunerativa">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>


                                                              
                                                       <%--***ITEM FORM ***--%>
                                                   <%--     <dx:LayoutItem Caption="Funciones del Puesto" ClientVisible="false">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                    <dx:ASPxMemo ID="cFuncionesPuesto" runat="server" Height="62px" Width="100%" CssClass="toUpper" ClientInstanceName="cFuncionesPuesto" ClientEnabled="false" Visible="false">
                                                                    </dx:ASPxMemo>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>--%>
                                                     
                                                     

                                                            

                                       

                                                       



                                       

                                                      


                                                    </Items>
                                                </dx:LayoutGroup>


                                                <%--TAB DEL SEGUNDO GRUPO NO CONTIENE INFORMACION--%>

                                                <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" SettingsItemCaptions-Location="Top" UseDefaultPaddings="true" Caption="Datos Complementarios">
                                                    <Items>
                                                       
                                                        
                                                        <dx:LayoutItem Caption="Escala Remunerativa Mínima(Soles)">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                     <dx:ASPxSpinEdit ID="iBandaSalarialMin" ClientInstanceName="iBandaSalarialMin" runat="server" Number="930" NumberType="Integer"
                                                                        MinValue="930" MaxValue="20000" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                      
                                                 
                                                          
                                                        <dx:LayoutItem Caption="Escala Remunerativa Máxima(Soles)">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                     <dx:ASPxSpinEdit ID="iBandaSalarialMax" ClientInstanceName="iBandaSalarialMax" runat="server" Number="930" NumberType="Integer"
                                                                        MinValue="930" MaxValue="20000" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                         
                                                   
                                                     
                                                        <dx:LayoutItem Caption="Edad Minima Requerida">
                                                          
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>
                                                                     <dx:ASPxSpinEdit ID="iEdadMinimaRequerida" ClientInstanceName="iEdadMinimaRequerida" runat="server" Number="25" NumberType="Integer"
                                                                        MinValue="18" MaxValue="60" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                      
                                                 
                                                        
                                                        <dx:LayoutItem Caption="Edad Maxima Requerida">                                                         
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>     
                                                                     <dx:ASPxSpinEdit ID="iEdadMaximaRequerida" ClientInstanceName="iEdadMaximaRequerida" runat="server" Number="25" NumberType="Integer"
                                                                        MinValue="18" MaxValue="60" Width="25%">
                                                                         <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                     </dx:ASPxSpinEdit>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                       

                                                      

                                                           <%--***ITEM FORM ***--%>
                                                        <dx:LayoutItem Caption="Genero">
                                                            
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer>

                                                                    <dx:ASPxComboBox ID="cGenero" runat="server" ValueType="System.String" ClientInstanceName="cGenero"  Width="100%">
                                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                                        <Items>                                                                          
                                                                        <dx:ListEditItem Text="INDISTINTO" Value="I"  Selected="true"  />
                                                                         <dx:ListEditItem Text="MASCULINO" Value="M" />
                                                                            <dx:ListEditItem Text="FEMENINO" Value="F" />
                                                                        </Items> 
                                                                    </dx:ASPxComboBox>

                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>

                                                        
                                                         

                                                       
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:TabbedLayoutGroup>
                                        <dx:LayoutGroup ColCount="2" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                            <Items>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>

                                                            <table style="margin-top: 12px!important;">
                                                                <tr>
                                                                    <td style="padding-right: 10px;">
                                                                       <%-- <dx:ASPxButton ID="BtnGuardarDetalle" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarDetalle" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnGuardarClickDetalle" />
                                                                        </dx:ASPxButton>--%>
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
                                                <dx:ASPxLabel ID="LblDeleteConfirm" runat="server" Text="¿ Seguro de borrar el registro seleccionado. ?">
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
                                                            <dx:ASPxButton ID="BtnDeleteConfirm" runat="server" Text="Si" Width="60" ClientInstanceName="BtnDeleteConfirm" AutoPostBack="false">
                                                                <ClientSideEvents Click="DeleteRecord" />
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
                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="¿ Seguro de enviar la Convocatoria al CED. ?">
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
                                                            <dx:ASPxButton ID="BtnGuardarEnviar" runat="server" Text="Si" Width="60" ClientInstanceName="BtnGuardarEnviar" AutoPostBack="false">
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
                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="¿ Seguro de borrar el registro seleccionado. ?">
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

      <%-- ******************************** POPUP APROBACION CONFIRM MODAL ********************************************** --%>
    <dx:ASPxPopupControl ID="PopupConfirmarAprobacion" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmarAprobacion"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl8" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout1" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupAprobacion">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="¿ Seguro de aprobar y finalizar la Convocatoria. ?">
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
                                                            <dx:ASPxButton ID="BtnGuardarAprobacion" runat="server" Text="Si" Width="60" ClientInstanceName="BtnGuardarAprobacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnGuardarAprobacionClick" />
                                                            </dx:ASPxButton>
                                                        </td>

                                                        <td>
                                                            <dx:ASPxButton ID="BtnCancelarAprobacion" runat="server" Text="No" Width="60" ClientInstanceName="BtnCancelarAprobacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnCancelarAprobacionClick"></ClientSideEvents>
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

       <%-- ******************************** POPUP DESAPROBACION CONFIRM MODAL ********************************************** --%>
    <dx:ASPxPopupControl ID="PopupConfirmarDesaprobacion" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmarDesaprobacion"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl9" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout3" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupDesaprobacion">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="¿ Seguro de Desaprobar y finalizar la Convocatoria. ?">
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
                                                            <dx:ASPxButton ID="BtnGuardarDesaprobacion" runat="server" Text="Si" Width="60" ClientInstanceName="BtnGuardarDesaprobacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnGuardarDesaprobacionClick" />
                                                            </dx:ASPxButton>
                                                        </td>

                                                        <td>
                                                            <dx:ASPxButton ID="BtnCancelarDesaprobacion" runat="server" Text="No" Width="60" ClientInstanceName="BtnCancelarDesaprobacion" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnCancelarDesaprobacionClick"></ClientSideEvents>
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
</asp:Content>
