<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UcwCandidatoinforme.ascx.vb" Inherits="GTWebOAEL.UcwCandidatoinforme" %>

<script type="text/javascript" src="../_GTJScript/Candidatoinforme.js"></script>

<div id="#region_FrmPostulante_AgregarEditar">

    <dx:ASPxTextBox ID="iCodRegistroPostulante" runat="server" Text="" Height="1px" Visible="True" ClientVisible="False" ClientInstanceName="iCodRegistroPostulante" CssClass="toUpper">
    </dx:ASPxTextBox>
    <dx:ASPxTextBox ID="cTipoOpePostulante" runat="server" Text="" Height="1px" Visible="True" ClientVisible="False" ClientInstanceName="cTipoOpePostulante" CssClass="toUpper">
    </dx:ASPxTextBox>

    <dx:ASPxHiddenField ID="cFormMetadataPostulante" runat="server" ClientInstanceName="cFormMetadataPostulante">
    </dx:ASPxHiddenField>

    <dx:ASPxCallback ID="CallBackFunctionPostulante" runat="server" ClientInstanceName="CallBackFunctionPostulante">
        <ClientSideEvents CallbackComplete="OnCompleteCallBackFunctionPostulante" />
    </dx:ASPxCallback>

    <dx:ASPxPopupControl ID="PopupForm_Postulante" runat="server" Modal="True" ClientInstanceName="PopupForm_Postulante"
        PopupElementID="PopupForm_Postulante" PopupHorizontalAlign="WindowCenter" Width="1000px" PopupVerticalAlign="WindowCenter"
        MaxWidth="1000px" MaxHeight="680px" MinWidth="460px" CloseAction="CloseButton" CloseAnimationType="Fade" Draggable="true">
        <Windows>
            <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos :: Registro de Postulantes" ShowFooter="False">
                <ContentCollection>
                    <dx:PopupControlContentControl ID="PopupControlContentControl2" runat="server">
                        <%--********* INI CONTENT FORM MAIN *********--%>
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup_Postulante" CssClass="formLayout" ClientInstanceName="FormLayoutPopup_Postulante">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutGroup ColCount="6" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Caption="Información Principal del Postulante">
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
                                                    <dx:LayoutItem Caption="Nro. Doc. Id.">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="iCodCandidatoInforme" runat="server" Width="0px" Height="0px" Visible="True"
                                                                    ClientVisible="False" ClientInstanceName="iCodCandidatoInforme" AutoPostBack="false" Size="0">
                                                                </dx:ASPxTextBox>

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

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Dirección">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cDireccion" ClientInstanceName="cDireccion" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxCheckBox ID="bCargaBox" Checked="False" ClientInstanceName="bCargaBox" AutoPostBack="false" ForeColor="WhiteSmoke" BackColor="#cccccc"
                                                                    runat="server" Text="Expediente Cargado" ReadOnly="true">
                                                                </dx:ASPxCheckBox>
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
                                                    <dx:LayoutItem Caption="Condicion">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxTextBox ID="cCondicion" runat="server" ValueType="System.String" ClientInstanceName="cCondicion" ReadOnly="true" ForeColor="WhiteSmoke" BackColor="#cccccc">
                                                                </dx:ASPxTextBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

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

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Comunidad">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxTextBox ID="cComunidad" runat="server" ValueType="System.String" ClientInstanceName="cComunidad" ReadOnly="true" ForeColor="WhiteSmoke" BackColor="#cccccc">
                                                                </dx:ASPxTextBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Tipo MOCMONC">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>

                                                                <dx:ASPxTextBox ID="cMOCMONC" runat="server" ValueType="System.String" ClientInstanceName="cMOCMONC" ReadOnly="true" ForeColor="WhiteSmoke" BackColor="#cccccc">
                                                                </dx:ASPxTextBox>

                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Ocupacion">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="cOcupacion1" runat="server" ValueType="System.String" ClientInstanceName="cOcupacion1" Width="100%" ReadOnly="true" ForeColor="WhiteSmoke" BackColor="#cccccc">
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>

                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Ocupacion 2">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox ID="cOcupacion2" runat="server" ValueType="System.String" ClientInstanceName="cOcupacion2" Width="100%" ReadOnly="true" ForeColor="WhiteSmoke" BackColor="#cccccc">
                                                                </dx:ASPxTextBox>
                                                            </dx:LayoutItemNestedControlContainer>
                                                        </LayoutItemNestedControlCollection>
                                                    </dx:LayoutItem>


                                                    <%--***ITEM FORM ***--%>
                                                    <dx:LayoutItem Caption="Brevet">
                                                        <LayoutItemNestedControlCollection>
                                                            <dx:LayoutItemNestedControlContainer>
                                                                <dx:ASPxTextBox runat="server" ID="cLicenciaConducir" ClientInstanceName="cLicenciaConducir" CssClass="toUpper">
                                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                        <RequiredField IsRequired="True"></RequiredField>
                                                                    </ValidationSettings>
                                                                </dx:ASPxTextBox>
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
                                                            <dx:ASPxButton ID="BtnGuardarPostulante" runat="server" Text="Guardar" Width="100px" ClientInstanceName="BtnGuardarPostulante" AutoPostBack="false">
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
