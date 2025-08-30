<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmCorreoEnvio.aspx.vb" Inherits="GTWebOAEL.FrmCorreoEnvio" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script type="text/javascript" src="../_GTJScript/_jquery-3.3.0.min.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTHandleMain.js"></script>
    <script type="text/javascript" src="../_GTJScript/_GTMainCore.js"></script>

    <script type="text/javascript"> 
        //************* FUNCTIONS CUSTOM
        function OnToolbarItemClick(s, e) {

            if (IsCustomExportToolbarCommand(e.item.name)) {
                e.processOnServer = true;
                e.usePostBack = true;
            }

            if (e.item.name == "BtnEnviarCorreosSeleccionados") {
                iCodRegistro.SetText("0");
                CallBackFunction.PerformCallback('EnviarCorreosSeleccionados');
                e.processOnServer = false;
            }
        }

        function OnBeginCallBackFunction(s, e) {
             ShowAlertMessage('Proceso de envio iniciado. No cierre ni recargue la página.');             
        }
        function OnEndCallBackFunction(s, e) {
             
            if (e.result == 'OK') {
                
                TablaRegistros.PerformCallback('load');

                ShowAlertMessage('Se proceso los mensajes que cumplen los requisitos.');

            }
            else {
                ShowAlertMessage('Ocurrió un error durante la transacción.');
            }



        }

    </script>
    <%-- ***************************** INI SECCION DATATABLE ***************************** --%>
    <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
        <dx:ASPxCallback ID="CallBackFunction" runat="server" ClientInstanceName="CallBackFunction">
            <ClientSideEvents CallbackComplete="OnEndCallBackFunction" BeginCallback="OnBeginCallBackFunction" />
        </dx:ASPxCallback>
        <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
            ClientVisible="False" ClientInstanceName="iCodRegistro">
        </dx:ASPxTextBox>
        <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
        </dx:ASPxHiddenField>
        <dx:ASPxGridView ID="TablaRegistros" runat="server" Style="width: 100%;" ClientInstanceName="TablaRegistros" AutoGenerateColumns="False">
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
                                      CORREOS POR ENVIAR
                                </div>

                            </Template>

                        </dx:GridViewToolbarItem>
                        <dx:GridViewToolbarItem ItemStyle-Width="100%" Visible="true">
                            <Template>
                                <div id="div100Percent"></div>
                            </Template>
                        </dx:GridViewToolbarItem>
                        <dx:GridViewToolbarItem Text="Enviar" Name="BtnEnviarCorreosSeleccionados">
                            <Image IconID="mail_send_16x16office2013">
                            </Image>
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

<%--                <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Caption="Seleccionar" />--%>
                <dx:GridViewDataTextColumn FieldName="iCodCorreoEnvio" Caption="Id" Visible="false"  VisibleIndex="0" />
                <dx:GridViewDataTextColumn FieldName="bEnviado" Caption="Enviado" VisibleIndex="1" Width="120"  >
                    <DataItemTemplate>
                         <dx:ASPxImage runat="server" ID="bEnviado" OnInit="EstadoEnvioCorreo_Init"></dx:ASPxImage>
                    </DataItemTemplate>
                </dx:GridViewDataTextColumn>
                 <dx:GridViewDataTextColumn FieldName="cNickCreacion" Caption="Usuario"  VisibleIndex="1" Width="100" CellStyle-Font-Size="Smaller"  />
                 <dx:GridViewDataTextColumn FieldName="dFechaCreacion" Caption="Creado"  VisibleIndex="1" Width="130" CellStyle-Font-Size="Smaller"  />
                <dx:GridViewDataTextColumn FieldName="cPlantilla" Caption="Plantilla"  VisibleIndex="2"  CellStyle-Font-Size="Smaller"  />
                 <dx:GridViewDataTextColumn FieldName="cNombres" Caption="Destinatario"  VisibleIndex="3" />
                <dx:GridViewDataTextColumn FieldName="cCorreoDestino" Caption="Correo Destino"  VisibleIndex="4"  />
                <%--<dx:GridViewDataTextColumn FieldName="cUsuario" Caption="Usuario" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="cClave" Caption="Clave" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="cFechaFinBloqueo" Caption="FechaFinBloqueo" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="cFechaFinObservado" Caption="FechaFinObservado" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="cNomContrata" Caption="Contrata" Visible="false" />
                <dx:GridViewDataTextColumn FieldName="cUrlDrive" Caption="Url" Visible="false" />--%>
            </Columns>

        </dx:ASPxGridView>
    </div>
    <%-- ***************************** FIN SECCION DATATABLE ***************************** --%>

    <%-- ***************************** SECCION POPUPS ***************************** --%>
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
