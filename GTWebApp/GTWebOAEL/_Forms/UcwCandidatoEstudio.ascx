<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcwCandidatoEstudio.ascx.vb" Inherits="GTWebOAEL.UcwCandidatoEstudios" %>
<script type="text/javascript" src="../_GTJScript/CandidatoEstudio.js"></script>

<div id="#region_FrmEstudio_AgregarEditar">

    <dx:ASPxTextBox ID="iCodRegistroEstudio" runat="server" Text="" Height="1px" Visible="True" ClientVisible="False" ClientInstanceName="iCodRegistroEstudio" CssClass="toUpper">
    </dx:ASPxTextBox>
    <dx:ASPxTextBox ID="cTipoOpeEstudio" runat="server" Text="" Height="1px" Visible="True" ClientVisible="False" ClientInstanceName="cTipoOpeEstudio" CssClass="toUpper">
    </dx:ASPxTextBox>
    <dx:ASPxHiddenField ID="cFormMetadataEstudio" runat="server" ClientInstanceName="cFormMetadataEstudio">
    </dx:ASPxHiddenField>

    <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True"
        ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
    </dx:ASPxTextBox>

    <%-- POPUP MAIN ESTUDIO --%>

    <dx:ASPxPopupControl ID="PopupFormMain_Estudio" runat="server" Modal="True" ClientInstanceName="PopupFormMain_Estudio"
        PopupElementID="PopupFormMain_Estudio" PopupHorizontalAlign="WindowCenter" Width="1000px" PopupVerticalAlign="WindowCenter"
        MaxWidth="1000px" MaxHeight="680px" MinWidth="460px" CloseAction="CloseButton" CloseAnimationType="Fade" Draggable="true">
        <Windows>
            <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario Lista de Estudios" ShowFooter="False">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControlEstudio" runat="server">
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupMain_Estudio" CssClass="formLayout" ClientInstanceName="FormLayoutPopupMain_Estudio">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Estudios">
                                        <Items>

                                            <dx:LayoutGroup ColCount="1" Width="34%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>
                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Nombres y Apellidos">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="txtNombresCompletos" ClientInstanceName="txtNombresCompletos">
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>
                                                </Items>
                                            </dx:LayoutGroup>

                                        </Items>
                                    </dx:LayoutGroup>


                                </Items>
                            </dx:ASPxFormLayout>

                            <dx:ASPxGridView ID="TablaRegistrosEstudio" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistrosEstudio">
                                <ClientSideEvents ToolbarItemClick="OnToolbarItemClickEstudio"></ClientSideEvents>
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

                                            <dx:GridViewToolbarItem Name="BtnAgregarEstudio" Text="Agregar" Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1">
                                                <Image Url="../_GTContent/icons/sign-add-icon.png"></Image>
                                            </dx:GridViewToolbarItem>

                                            <dx:GridViewToolbarItem Name="BtnEditarEstudio" Text="Editar" Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1">
                                                <Image IconID="edit_edit_16x16office2013"></Image>
                                            </dx:GridViewToolbarItem>

                                            <dx:GridViewToolbarItem ItemStyle-HorizontalAlign="Right">
                                                <Template>
                                                    <dx:ASPxButtonEdit ID="tbToolbarSearchEstudio" runat="server" NullText="Buscar..." Height="100%">
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
                                    <dx:GridViewDataTextColumn FieldName="iCodCandidatoEstudios" Visible="False" VisibleIndex="0" Caption="ID"></dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="cCentroEstudios" Visible="True" VisibleIndex="1" Caption="Centro Estudios"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="250">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="cCarrera" Visible="True" VisibleIndex="2" Caption="Carrera"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="200">
                                    </dx:GridViewDataTextColumn>

                                    <dx:GridViewDataTextColumn FieldName="cPeriodoFin" Visible="True" VisibleIndex="4" Caption="Egreso"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="70">
                                    </dx:GridViewDataTextColumn>

                                </Columns>

                            </dx:ASPxGridView>

                        </div>
                    </dx:PopupControlContentControl>
                </ContentCollection>
            </dx:PopupWindow>
        </Windows>
    </dx:ASPxPopupControl>

    <%-- FIN POPUP MAIN ESTUDIO --%>

    <dx:ASPxCallback ID="CallBackFunctionEstudio" runat="server" ClientInstanceName="CallBackFunctionEstudio">
        <ClientSideEvents CallbackComplete="OnCompleteCallBackFunctionEstudio" />
    </dx:ASPxCallback>

    <dx:ASPxPopupControl ID="PopupForm_Estudio" runat="server" Modal="True" ClientInstanceName="PopupForm_Estudio"
        PopupElementID="PopupForm_Estudio" PopupHorizontalAlign="WindowCenter" Width="1000px" PopupVerticalAlign="WindowCenter"
        MaxWidth="1000px" MaxHeight="680px" MinWidth="460px" CloseAction="CloseButton" CloseAnimationType="Fade" Draggable="true">
        <Windows>
            <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Estudios" ShowFooter="False">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                        <%--********* INI CONTENT FORM MAIN *********--%>
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup_Estudio" CssClass="formLayout" ClientInstanceName="FormLayoutPopup_Estudio">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Estudios">
                                        <Items>

                                            <dx:LayoutGroup ColCount="1" Width="34%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>

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
                                                </Items>
                                            </dx:LayoutGroup>

                                        </Items>
                                    </dx:LayoutGroup>

                                    <dx:LayoutGroup ColCount="4" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Informacion Complementaria del Postulante">
                                        <Items>

                                            <dx:LayoutGroup ColCount="1" Width="30%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>


                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bSustentoCV" Checked="False" ClientInstanceName="bSustentoCV" AutoPostBack="false"
                                                                    runat="server" Text="Presenta Sustento de Local ó CV Foraneo">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bCumplePefil" Checked="False" ClientInstanceName="bCumplePefil" AutoPostBack="false"
                                                                    runat="server" Text="Es Postulable">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                </Items>
                                            </dx:LayoutGroup>
                                            <dx:LayoutGroup ColCount="1" ColSpan="2" Width="40%" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                                <Items>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Observaciones">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxMemo runat="server" ID="cObservacion" ClientInstanceName="cObservacion" CssClass="toUpper" Width="400px" Height="120px" TextMode="MultiLine" NullText="Escriba sus comentarios aquí...">
                                                                </dx:ASPxMemo>
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
                                                                <dx:ASPxCheckBox ID="bDiscapacitado" Checked="False" ClientInstanceName="bDiscapacitado" runat="server" AutoPostBack="false"
                                                                    Text="Persona con Discapcidad">
                                                                </dx:ASPxCheckBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bPrioritario" Checked="False" ClientInstanceName="bPrioritario" AutoPostBack="false"
                                                                    runat="server" Text="Prioritario - Stakeholders">
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
                                                            <dx:ASPxButton ID="BtnGuardarEstudio" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarPostulante" AutoPostBack="false">
                                                                <ClientSideEvents Click="OnBtnGuardarClick_Postulante" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnCancelar" runat="server" Text="Cancelar" Width="100" ClientInstanceName="BtnCancelar" AutoPostBack="false">
                                                                <ClientSideEvents Click="CloseModal_Postulante"></ClientSideEvents>
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
        <ClientSideEvents Closing="function(s, e) { ClearControls_Postulante();}" Shown="function(s,e){}"></ClientSideEvents>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="PopupAlertMessagePostulante" runat="server" ClientInstanceName="PopupAlertMessagePostulante"
        Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below"
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>



</div>
