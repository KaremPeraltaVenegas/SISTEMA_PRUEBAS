<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Main.master" CodeBehind="FrmPostulante.aspx.vb" Inherits="GTWebOAEL.FrmPostulante" %>

<%@ Register Assembly="DevExpress.XtraReports.v17.2.Web, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Src="~/_Forms/UcwCandidatoinforme.ascx" TagName="FrmCandidatoinformeView" TagPrefix="gt" %>
<%@ Register Src="~/_Forms/UcwCandidatoestudio.ascx" TagName="FrmEstudioView" TagPrefix="gt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../_GTJScript/_jquery-3.3.0.min.js"></script>

    <script>
        function OnToolbarItemClickMain(s, e) {

            //if (IsCustomExportToolbarCommand(e.item.name)) {
            //    e.processOnServer = true;
            //    e.usePostBack = true;
            //}

            if (e.item.name == "BtnAgregar") {

                iCodRegistroPostulante.SetText("0");
                cTipoOpePostulante.SetText("A");
                ShowModal_Postulante();
                e.processOnServer = false;

            }
            else if (e.item.name == "BtnEditar") {

                iCodRegistro.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                iCodRegistroPostulante.SetText(TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex()));
                cTipoOpePostulante.SetText("M");
                ShowModal_Postulante();

                e.processOnServer = false;
            }
            else if (e.item.name == "BtnBuscar") {
                cTipoBusqueda.SetText("BusquedaPorDni");
                TablaRegistros.PerformCallback();
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnBuscarPorAnoMes") {
                cTipoBusqueda.SetText("");
                TablaRegistros.PerformCallback();
                e.processOnServer = false;
            }
            else if (e.item.name == "BtnAnular") {
            }
        }

        function OnTablaRegistrosContextMenu(s, e) {
            if (e.htmlEvent.button === 2) { 
                e.htmlEvent.preventDefault();
                s.SetFocusedRowIndex(e.index);
                popupMenuTablaRegistros.ShowAtPos(e.htmlEvent.clientX, e.htmlEvent.clientY);
            }
        }

        function popupMenuTablaRegistros_ItemClick(s, e) {
            var codigo = TablaRegistros.GetRowKey(TablaRegistros.GetFocusedRowIndex());

            switch (e.item.name) {
                case "pmEstudios":
                    cTipoOpeEstudio.SetText("A");
                    ShowModalMain_Estudio();
                    break;
                case "pmExperienciaLaboral":

                    break;
            }
        }
    </script>

    <%-- ************************ SECCION DATAGRIDVIEW PRINCIPAL ************************* --%>
    <div id="ContentTablaRegistros" style="padding: 0px 15px 0px 15px;">
        <div id="gtTitleTableMain">[ Postulantes ]</div>

        <dx:ASPxTextBox ID="iCodRegistro" runat="server" Width="170px" Visible="True"
            ClientVisible="False" ClientInstanceName="iCodRegistro">
        </dx:ASPxTextBox>

        <dx:ASPxHiddenField ID="cFormMetadata" runat="server" ClientInstanceName="cFormMetadata">
        </dx:ASPxHiddenField>
        <dx:ASPxTextBox ID="cTipoBusqueda" runat="server" Text="" Height="1px" Visible="True" ClientVisible="False" ClientInstanceName="cTipoBusqueda">
        </dx:ASPxTextBox>


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
                        <dx:GridViewToolbarItem Name="gvtbDniBusqueda">
                            <Template>
                                <dx:ASPxTextBox ID="txtDniBusqueda" runat="server" Width="100px" Name="txtDniBusqueda" ClientInstanceName="txtDniBusqueda">
                                </dx:ASPxTextBox>
                            </Template>
                        </dx:GridViewToolbarItem>
                        <dx:GridViewToolbarItem Name="BtnBuscar" Text="Por Dni" Image-IconID="find_find_16x16gray" ItemStyle-BackColor="SkyBlue">
                        </dx:GridViewToolbarItem>

                        <dx:GridViewToolbarItem Name="gvtbMesBusqueda">
                            <Template>
                                <dx:ASPxDateEdit ID="dFechaBusqueda" runat="server" ClientInstanceName="dFechaBusqueda" AutoPostBack="false" UseMaskBehavior="False">
                                    <CalendarProperties ShowWeekNumbers="False" ShowTodayButton="False" 
                                        ShowClearButton="False" ShowDayHeaders="false"  />
                                </dx:ASPxDateEdit>
                            </Template>
                        </dx:GridViewToolbarItem>

                        <dx:GridViewToolbarItem Name="BtnBuscarPorAnoMes" Text="Por Año-Mes" Image-IconID="find_find_16x16gray" ItemStyle-BackColor="SkyBlue">
                        </dx:GridViewToolbarItem>

                        <dx:GridViewToolbarItem Name="BtnAgregar" Text="Agregar" Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1">
                            <Image Url="../_GTContent/icons/sign-add-icon.png"></Image>
                        </dx:GridViewToolbarItem>

                        <dx:GridViewToolbarItem Name="BtnEditar" Text="Editar" Image-IconID="actions_download_16x16office2013" BeginGroup="true" AdaptivePriority="1">
                            <Image IconID="edit_edit_16x16office2013"></Image>
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
                <dx:GridViewDataTextColumn FieldName="iCodCandidatoInforme" Visible="False" VisibleIndex="0" Caption="ID"></dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="dFechaSis" Visible="True" VisibleIndex="1" Caption="Fecha Registro"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cDNI" Visible="True" VisibleIndex="2" Caption="Dni"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cNomCompleto" Visible="True" VisibleIndex="4" Caption="Apellidos y Nombres"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="200">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="cSexo" Visible="True" VisibleIndex="4" Caption="Sexo"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cCondicion" Visible="True" VisibleIndex="4" Caption="Condicion" CellStyle-Font-Size="Smaller"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="80">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cComunidad" Visible="True" VisibleIndex="4" Caption="Comunidad"
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="150">
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataTextColumn FieldName="cTipoAreaInfluencia" Visible="True" VisibleIndex="4" Caption="Tipo Area Infl."
                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-ForeColor="Black" HeaderStyle-Font-Bold="true" Width="100">
                </dx:GridViewDataTextColumn>
            </Columns>

            <ClientSideEvents ContextMenu="OnTablaRegistrosContextMenu" />

        </dx:ASPxGridView>
    </div>

    <!--#region POPUP AGREGAR Y EDITAR CANDIDATO -->
    <gt:FrmCandidatoinformeView ID="UcwCandidatoinforme" runat="server" />
    <!--#endregion POPUP AGREGAR Y EDITAR CANDIDATO -->

    <!--#region POPUP AGREGAR Y EDITAR ESTUDIO -->
    <gt:FrmEstudioView ID="UcwCandidatoestudio" runat="server" />
    <!--#endregion POPUP AGREGAR Y EDITAR ESTUDIO -->


     <!-- Menú contextual -->
        <dx:ASPxPopupMenu ID="popupMenuTablaRegistros" runat="server" ClientInstanceName="popupMenuTablaRegistros">
            <Items>
                <dx:MenuItem Name="pmEstudios" Text="Estudios" />
                <dx:MenuItem Name="pmExperienciaLaboral" Text="Experiencia Laboral" />
            </Items>
             <ClientSideEvents ItemClick="popupMenuTablaRegistros_ItemClick" />
        </dx:ASPxPopupMenu>


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
                                                                <%--   <ClientSideEvents Click="DeleteRecord" />--%>
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
