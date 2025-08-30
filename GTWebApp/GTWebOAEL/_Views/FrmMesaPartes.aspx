<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmMesaPartes.aspx.vb" Inherits="GTWebOAEL.FrmMesaPartes" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../_GTJScript/_jquery-3.3.0.min.js"></script>
    <script type="text/javascript" src="../_GTJScript/Mesapartes.js"></script>

    <script type="text/javascript">
        var iCommand = 0;
        var msg = "";
        function OnToolbarItemClickMain(s, e) {

            if (e.item.name == "BtnAgregar") {
                iCodRegistro.SetText("0");
                iCommand = 1;
                msg = "El registro se guard&oacute; con éxito";
                cFormMetadata.Set("cTipoOpe", "A");
                LimpiarControlesPopup();
                $("#mensajeRegistrado").html("Situaci&oacute;n : <b></b>");
                $("#mensajeEvaluado").html("Evaluado : <b></b>");
                $("#mensajeExpediente").html("Expediente : <b></b>");

                iNivelRiesgo.SetValue(0);
                cTipoDoc.SetValue("DNI");

                var popupWindow = PopupFormMain.GetWindow(0);
                PopupFormMain.ShowWindow(popupWindow);

                var fechaHoy = new Date();
                dFechaSolicitud.SetDate(fechaHoy);

                e.processOnServer = false;
            }
            else if (e.item.name == "BtnEliminar") {
                iCommandDetalle = 2;
                msgDetalle = "El registro se borró con éxito";
                iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                var popupWindow = PopupConfirmDelete.GetWindow(0);
                PopupConfirmDelete.ShowWindow(popupWindow);
                
                e.processOnServer = false;
            }
        }
        function OnEndCallBackFunctionCustom(s, e) {
            if (e.result == 'FRM_MP_CON_EXPE') {
                ShowAlertMessage('La persona ya cuenta con expediente. No procede el REGISTRO NUEVO');
            } else if (e.result == 'FRM_MP_SIN_EXPE') {
                ShowAlertMessage('La persona ya cuenta con un trámite existente. No procede el REGISTRO NUEVO');
            } else if (e.result == 'FRM_MP_POST') {
                ShowAlertMessage('Ha seleccionado el trámite POSTULACIÓN. Debe seleccionar un perfil vigente.');
            } else if (e.result == 'OK-OK')
            {
                
                var popupWindow = PopupAlertMessageConfirm.GetWindow(0);
                PopupAlertMessageConfirm.HideWindow(popupWindow);
                var popupWindow2 = PopupFormMain.GetWindow(0);
                PopupFormMain.HideWindow(popupWindow2);
                ShowAlertMessage('Se realizó con éxito la transacción.');
                TablaRegistros.PerformCallback();
            }
            else {
                ShowAlertMessage('Ocurrió un error durante la transacción.');
            }
        }
    </script>

    <%-- ************************ SECCION DATAGRIDVIEW PRINCIPAL ************************* --%>
    <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
        <div id="gtTitleTableMain">[ Mesa de Partes - Registros de Solicitudes de Admisión ]</div>
        <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
            <ClientSideEvents CallbackComplete="OnEndCallBackFunctionCustom" />
        </dx:ASPxCallback>
        <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
            ClientVisible="False" ClientInstanceName="iCodRegistro">
        </dx:ASPxTextBox>
        <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
        </dx:ASPxHiddenField>
        <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros">
            <ClientSideEvents ToolbarItemClick="OnToolbarItemClickMain"></ClientSideEvents>
            <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
            </SettingsPager>
            <Settings ShowVerticalScrollBar="True" GridLines="None" />
            <SettingsBehavior AllowFocusedRow="True" />
            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
             <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="342"></Settings>
            <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
            <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />

            <Toolbars>
                <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                    <Items>
                        <dx:GridViewToolbarItem Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1" Name="BtnAgregar" Text="Agregar Registro">
                            <Image IconID="people_publicfix_16x16office2013"></Image>
                        </dx:GridViewToolbarItem>
                        <dx:GridViewToolbarItem Name="BtnEliminar" Text="Eliminar" ToolTip="Eliminar Registro">
                            <Image IconID="edit_delete_16x16office2013">
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
                <dx:GridViewDataTextColumn FieldName="iCodCandidatoAdmision" Visible="False" VisibleIndex="0" Caption="ID"></dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="dFechaRegistro" Visible="True" VisibleIndex="1" Caption="Fecha Registro" 
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="dFechaSolicitud" Visible="True" VisibleIndex="2" Caption="Fecha Solicitud" 
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cCandidatoAdmisionTipo" Visible="True" VisibleIndex="4" Caption="Trámite" 
                     HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="100">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="cCandidatoAdmisionOrigenGrupo" Visible="True" VisibleIndex="4" Caption="Fuente" 
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="100">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cDNI" Visible="True" VisibleIndex="4" Caption="DNI" CellStyle-Font-Size="Smaller"
                   HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cNomCompleto" Visible="True" VisibleIndex="4" Caption="Apellidos y Nombres" 
                     HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="170">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cCondicion" Visible="True" VisibleIndex="4" Caption="Condicion" 
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="100">
                </dx:GridViewDataTextColumn>

            </Columns>
        </dx:ASPxGridView>
    </div>

    <%--**************************** POPUP NOTIFICATIONES ******************************** --%>
    <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server" ClientInstanceName="PopupAlertMessage"
        Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below"
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <%--******************* POPUP NOTIFICATIONES CON CONFIRMACION ************************ --%>
    <dx:ASPxPopupControl ID="PopupAlertMessageConfirm" runat="server" Width="400px"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter"
        HeaderText="Mensaje de Confirmación" CloseOnEscape="True"
        Modal="True" ClientInstanceName="PopupAlertMessageConfirm">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl4" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormConfirmLayoutPopupDetalle" CssClass="formLayout" ClientInstanceName="FormConfirmLayoutPopupDetalle">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel ID="lblMensajeConfirmacion" runat="server" ClientInstanceName="lblMensajeConfirmacion"></dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table style="margin-top: 12px!important;">
                                                    <tr>
                                                        <td style="padding-right: 10px;">
                                                            <dx:ASPxButton ID="btnAceptarMessageConfirm" runat="server" Text="Si" Width="60" ClientInstanceName="btnAceptarMessageConfirm" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnAceptarClickMessageConfirm" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="btnCancelarMessageConfirm" runat="server" Text="No" Width="60" ClientInstanceName="btnCancelarMessageConfirm" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnCancelarClickMessageConfirm"></ClientSideEvents>
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

    <%-- ***************************** SECCION POPUP PRINCIPAL   ************************* --%>
    <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMain"
        PopupElementID="PopupFormDetalle" PopupHorizontalAlign="WindowCenter" Width="1000px" PopupVerticalAlign="WindowCenter"
        MaxWidth="1000px" MaxHeight="680px" MinWidth="460px" CloseAction="CloseButton" CloseAnimationType="Fade" Draggable="true">
        <Windows>
            <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Mesa Partes" ShowFooter="False">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                        <%--********* INI CONTENT FORM MAIN *********--%>
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Datos del Registro">
                                        <Items>

                                            <dx:LayoutGroup ColCount="1" Width="34%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Tipo Doc. Id.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="cTipoDoc" runat="server" ValueType="System.String" ClientInstanceName="cTipoDoc">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
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
                                                    <dx:LayoutItem Caption="Nro. Doc. Id.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True"
                                                                    ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
                                                                </dx:ASPxTextBox>
                                                                <dx:ASPxCheckBox ID="bCargaBox" Checked="False" ClientInstanceName="bCargaBox" AutoPostBack="false"
                                                                    Visible="true" ClientVisible="False" runat="server">
                                                                </dx:ASPxCheckBox>
                                                                <dx:ASPxTextBox ID="cBloqueadoRegistroActualizacion"
                                                                    ClientInstanceName="cBloqueadoRegistroActualizacion" AutoPostBack="false"
                                                                    Visible="true" ClientVisible="False" runat="server">
                                                                </dx:ASPxTextBox>
                                                                <dx:ASPxTextBox ID="cFechaFinBloqueo"
                                                                    ClientInstanceName="cFechaFinBloqueo" AutoPostBack="false"
                                                                    Visible="true" ClientVisible="False" runat="server">
                                                                </dx:ASPxTextBox>

                                                                <dx:ASPxTextBox ID="cFechaFinObservado"
                                                                    ClientInstanceName="cFechaFinObservado" AutoPostBack="false"
                                                                    Visible="true" ClientVisible="False" runat="server">
                                                                </dx:ASPxTextBox>

                                                                <dx:ASPxComboBox ID="cCondicion" runat="server" ValueField="ValueMember"
                                                                    ValueType="System.String" TextFormatString="{0}" ClientInstanceName="cCondicion" ClientVisible="False">
                                                                </dx:ASPxComboBox>

                                                                <dx:ASPxButtonEdit ID="cDNI" runat="server" NullText="Buscar..."
                                                                    ClientInstanceName="cDNI" ClientSideEvents-ButtonClick="cDNI_OnButtonClick" AutoPostBack="false">

                                                                    <ClientSideEvents KeyPress="cDNI_KeyPress"
                                                                        LostFocus="function(s, e) {s.Validate();}"
                                                                        Validation="cDNI_Validation" />

                                                                    <ValidationSettings RequiredField-IsRequired="true" ErrorDisplayMode="ImageWithTooltip" ErrorText="Cantidad de caracteres inválido" Display="Dynamic" />
                                                                    <Buttons>
                                                                        <dx:SpinButtonExtended Image-IconID="find_find_16x16gray">
                                                                            <Image IconID="find_find_16x16gray"></Image>
                                                                        </dx:SpinButtonExtended>
                                                                    </Buttons>
                                                                </dx:ASPxButtonEdit>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Nombres">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cNombres" ClientInstanceName="cNombres" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Apellidos">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cApellidos" ClientInstanceName="cApellidos" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
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
                                                                <dx:ASPxComboBox ID="cSexo" runat="server" ClientInstanceName="cSexo" ValueType="System.String">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
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
                                                    <dx:LayoutItem Caption="Fecha Nacimiento">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dFechaNac" ClientInstanceName="dFechaNac" runat="server" AutoPostBack="false" UseMaskBehavior="False"
                                                                    CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                    <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
                                                                </dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>

                                            <dx:LayoutGroup ColCount="1" ColSpan="2" Width="40%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>


                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="CUI">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cCUI" ClientInstanceName="cCUI" CssClass="toUpper" Width="30%">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                     <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <table class="TablaMensajes" style="margin-top: 12px!important; float: left;">
                                                                    <tr>
                                                                        <td style="padding-right: 20px; padding-top: 2px;">
                                                                            <span id="mensajeRegistrado"></span>
                                                                            <span id="mensajeEvaluado"></span>
                                                                            <span id="mensajeExpediente"></span>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Ubigeo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="cUbigeo" runat="server" ValueType="System.String" ClientInstanceName="cUbigeo">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Ubigeo Residencia">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="cUbigeoResidencia" runat="server" ValueType="System.String" ClientInstanceName="cUbigeoResidencia">
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                      <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Estado Civil">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="cEstCivil" runat="server" ValueType="System.String" ClientInstanceName="cEstCivil">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Correo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cCorreo" ClientInstanceName="cCorreo" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup ColCount="1" Width="26%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                   
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Condicion">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="iCodTDCondicionSustento" runat="server" ValueField="iCodTDCondicionSustento" ValueType="System.String" TextFormatString="{0}" ClientInstanceName="iCodTDCondicionSustento">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="iCodTDCondicionSustento" FieldName="iCodTDCondicionSustento" Visible="false" Width="1%" />
                                                                        <dx:ListBoxColumn Caption="Condicion Sustento" FieldName="cCondicionSustento" Width="70px" />
                                                                        <dx:ListBoxColumn Caption="Sustento" FieldName="cSustento" Width="100%" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>


                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Teléfono">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cTelefono" ClientInstanceName="cTelefono" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                        </Items>
                                    </dx:LayoutGroup>

                                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Datos del Trámite">
                                        <Items>

                                            <dx:LayoutGroup ColCount="1" Width="30%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                    <%--***ITEM FORM ***--%>

                                                    <dx:LayoutItem Caption="Fecha Solicitud">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxDateEdit ID="dFechaSolicitud" ClientInstanceName="dFechaSolicitud" runat="server" AutoPostBack="false" UseMaskBehavior="False"
                                                                    CalendarProperties-ShowWeekNumbers="False" CalendarProperties-ShowTodayButton="False" CalendarProperties-ShowClearButton="False">
                                                                    <CalendarProperties ShowClearButton="False" ShowTodayButton="False" ShowWeekNumbers="False"></CalendarProperties>
                                                                </dx:ASPxDateEdit>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Tipo Registro">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="iCodCandidatoAdmisionTipo" runat="server" ValueType="System.String" ClientInstanceName="iCodCandidatoAdmisionTipo">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Fuente">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="iCodCandidatoAdmisionOrigen" runat="server" ValueType="System.String" ClientInstanceName="iCodCandidatoAdmisionOrigen">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup ColCount="1" ColSpan="2" Width="40%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Nivel Riesgo">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="iNivelRiesgo" runat="server" ValueType="System.String" ClientInstanceName="iNivelRiesgo">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxComboBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <%--                             <dx:LayoutItem Caption="Perfil">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxComboBox ID="iCodConvocatoria" runat="server"
                                                                    ValueField="iCodConvocatoria" ValueType="System.Int32" TextFormatString="{0}" ClientInstanceName="iCodConvocatoria">
                                                                    <Columns>
                                                                        <dx:ListBoxColumn Caption="iCodConvocatoria" FieldName="iCodConvocatoria" Visible="false" Width="1%" />
                                                                        <dx:ListBoxColumn Caption="Perfil" FieldName="cPerfil" Width="100%" />
                                                                    </Columns>
                                                                </dx:ASPxComboBox>
                                                                <dx:ASPxButton ID="BtnLimpiarPerfil" runat="server" Text="Limpiar" Width="100px" ClientInstanceName="BtnLimpiarPerfil" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnLimpiarPerfil" />
                                                            </dx:ASPxButton>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>--%>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Notas">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cObs" ClientInstanceName="cObs" CssClass="toUpper">
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>

                                            <dx:LayoutGroup ColCount="1" Width="20%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bImprocedente" Checked="False" ClientInstanceName="bImprocedente" AutoPostBack="false"
                                                                    runat="server" ClientSideEvents-CheckedChanged="bImprocedente_onCheckBoxChanged" Text="Procede el Trámite">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bDocumentoTramite" Checked="False" ClientInstanceName="bDocumentoTramite" runat="server" AutoPostBack="false"
                                                                    ClientSideEvents-CheckedChanged="bDocumentoTramite_onCheckBoxChanged" Text="Si Presenta Documentación">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bActualizaDatosContacto" Checked="False" ClientInstanceName="bActualizaDatosContacto" AutoPostBack="false"
                                                                    runat="server" ClientSideEvents-CheckedChanged="bActualizaDatosContacto_onCheckBoxChanged" Text="Sin Acciones">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>
                                        </Items>
                                    </dx:LayoutGroup>
                                    <%--*** COMMANDS BUTTON ***--%>
                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right">
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
                                                            <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false">
                                                                <ClientSideEvents Click="CloseFormPopupMain"></ClientSideEvents>
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
                        <%--********* END CONTENT FORM MAIN *********--%>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:PopupWindow>
        </Windows>
        <ClientSideEvents Closing="function(s, e) { LimpiarControlesPopup();}" Shown="function(s,e){}"></ClientSideEvents>
    </dx:ASPxPopupControl>


    <%-- ********************* POPUP DE CONFIRMACION DE BORRADO PRINCIPAL ****************** --%>
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

</asp:Content>
