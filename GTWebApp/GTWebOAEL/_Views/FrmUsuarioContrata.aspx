<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmUsuarioContrata.aspx.vb" Inherits="GTWebOAEL.FrmUsuarioContrata" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>
    <script type="text/javascript" src="../_GTJScript/Usuariocontrata.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCore.js"></script>
    <script type="text/javascript"> 
         // ************* FUNCTIONS CUSTOM 



    </script>
    <%-- ***************************** INI SECCION DATATABLE ***************************** --%>
    <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
        <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
            <ClientSideEvents CallbackComplete="OnEndCallBackFunction" />
        </dx:ASPxCallback>
        <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
            ClientVisible="False" ClientInstanceName="iCodRegistro">
        </dx:ASPxTextBox>
        <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
        </dx:ASPxHiddenField>
        <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros">
            <ClientSideEvents ToolbarItemClick="OnToolbarItemClick" FocusedRowChanged="OnGridFocusedRowChanged"
                Init="grid_Init" BeginCallback="grid_BeginCallback" EndCallback="grid_EndCallback"></ClientSideEvents>
            <SettingsPager EnableAdaptivity="True" PageSize="10" AlwaysShowPager="True">
            </SettingsPager>
            <Settings ShowVerticalScrollBar="True" VerticalScrollableHeight="270"></Settings>

            <SettingsBehavior AllowFocusedRow="True" />
            <SettingsDataSecurity AllowDelete="False"></SettingsDataSecurity>
            <Settings ShowVerticalScrollBar="True" />
            <SettingsSearchPanel CustomEditorID="tbToolbarSearch" />
            <SettingsExport EnableClientSideExportAPI="true" ExcelExportMode="DataAware" />
            <Toolbars>
                <dx:GridViewToolbar EnableAdaptivity="True" Position="Top" ItemAlign="Right">
                    <Items>
                        <dx:GridViewToolbarItem DisplayMode="Text" GroupName="titulo">
                            <ItemStyle HorizontalAlign="Right" Width="200px"></ItemStyle>
                            <Template>
                                <div id="gtHeadTitle" style="">
                                    <%--***  MODIFICAR ***--%>
                                      USUARIOS
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
        </dx:ASPxGridView>
    </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>

    <%-- ***************************** SECCION POPUPS ***************************** --%>
    <dx:ASPxPopupControl ID="PopupFormMain" runat="server" Modal="True" ClientInstanceName="PopupFormMainCli"
        PopupElementID="PopupForm" PopupHorizontalAlign="WindowCenter" Width="960px" PopupVerticalAlign="WindowCenter"
        MaxWidth="960px" MaxHeight="640px" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade">
        <Windows>
            <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                ScrollBars="None" AutoUpdatePosition="True" HeaderText="Formulario de Datos" ShowFooter="False">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
                        <%--********* INI CONTENT FORM MAIN *********--%>
                        <div>
                            <dx:ASPxFormLayout runat="server" ID="FormLayoutPopup" CssClass="formLayout" ClientInstanceName="FormLayoutPopup">
                                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                <Items>
                                    <dx:LayoutGroup ColCount="2" GroupBoxDecoration="Box" UseDefaultPaddings="false" Caption="">
                                        <Items>
                                            <%--***  INI FORMULARIO ***--%>
                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Nro. Doc. Id.">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox ID="iCodPersona" runat="server" Width="0px" Height="0px" Visible="True"
                                                            ClientVisible="False" ClientInstanceName="iCodPersona" AutoPostBack="false" Size="0">
                                                        </dx:ASPxTextBox>
                                                        <dx:ASPxTextBox ID="iCodUsuario" runat="server" Width="0px" Height="0px" Visible="True"
                                                            ClientVisible="False" ClientInstanceName="iCodUsuario" AutoPostBack="false" Size="0">
                                                        </dx:ASPxTextBox>
                                                        <dx:ASPxButtonEdit ID="cNroDoc" runat="server" NullText="Buscar..." ClientInstanceName="cNroDoc" ClientSideEvents-ButtonClick="viewRecordPersona" AutoPostBack="false">
                                                            <Buttons>
                                                                <dx:SpinButtonExtended Image-IconID="find_find_16x16gray" />
                                                            </Buttons>
                                                        </dx:ASPxButtonEdit>

                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Sexo:">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="cSexo" runat="server" ClientInstanceName="cSexo" ValueType="System.String">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                            <Items>
                                                                <dx:ListEditItem Text="MASCULINO" Value="M" />
                                                                <dx:ListEditItem Text="FEMENINO" Value="F" />
                                                            </Items>
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Apellidos">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="cApelP" ClientInstanceName="cApelP" CssClass="toUpper">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Nombres">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="cNombres" ClientInstanceName="cNombres" CssClass="toUpper">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>


                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Fono">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="cFono" ClientInstanceName="cFono" CssClass="toUpper">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Correo">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxTextBox runat="server" ID="cCorreo" ClientInstanceName="cCorreo">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                        </dx:ASPxTextBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Empresa">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxComboBox ID="iCodContrata" runat="server" ValueType="System.String" ClientInstanceName="iCodContrata">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" />
                                                        </dx:ASPxComboBox>
                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>
                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Tipo Usuario">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>

                                                        <dx:ASPxComboBox ID="cTipo" runat="server" ValueType="System.String" ClientInstanceName="cTipo">
                                                            <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                                <RequiredField IsRequired="True"></RequiredField>
                                                            </ValidationSettings>
                                                            <Items>
                                                                <dx:ListEditItem Text="USUARIO OPERADOR" Value="UC" />
                                                                <dx:ListEditItem Text="USUARIO SUPERVISOR" Value="US" />

                                                                <dx:ListEditItem Text="SISTEMA ADMINISTRADOR" Value="3" />
                                                                <dx:ListEditItem Text="SISTEMA SUPERVISOR" Value="2" />
                                                            </Items>
                                                        </dx:ASPxComboBox>

                                                    </dx:LayoutItemNestedControlContainer>
                                                </LayoutItemNestedControlCollection>
                                            </dx:LayoutItem>

                                            <%--***ITEM FORM ***--%>
                                            <dx:LayoutItem Caption="Habilitar">
                                                <LayoutItemNestedControlCollection>
                                                    <dx:LayoutItemNestedControlContainer>
                                                        <dx:ASPxCheckBox ID="bAcceder" Checked="true" ClientInstanceName="bAcceder" runat="server"></dx:ASPxCheckBox>
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
                                                                        <ClientSideEvents Click="OnBtnGuardarClick" />
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
}"></ClientSideEvents>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="PopupConfirmDelete" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupConfirmDelete"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="460px">
        <Windows>
            <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Confirmación">
                <ContentCollection>
                    <dx:PopupControlContentControl runat="server">
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
    <%--******** POPUP NOTIFICATIONS **********************************************************--%>
    <dx:ASPxPopupControl ID="PopupAlertMessage" runat="server" ClientInstanceName="PopupAlertMessage"
        Width="260px" PopupHorizontalAlign="LeftSides" PopupVerticalAlign="Below"
        HeaderStyle-CssClass="AlertSuccess-Header" HeaderText="Mensaje">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentAlert" runat="server" CssClass="AlertSuccess-Content">
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

</asp:Content>
