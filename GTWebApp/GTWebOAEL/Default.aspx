<%@ Page Language="VB" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="Default.aspx.vb" Inherits="GTWebOAEL._Default" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="_GTJScript/_jquery-3.3.0.min.js" ></script>
     <script type="text/javascript" > 
         function OnBtnCerrarMensajeClick(s, e) {
             var popupWindow = PopupMensajeOAEL.GetWindow(0);
             PopupMensajeOAEL.HideWindow(popupWindow);
             e.processOnServer = false;

         }
         </script>
   

<dx:ASPxPopupControl ID="PopupMensajeOAEL" runat="server" Modal="True" CloseOnEscape="True" ClientInstanceName="PopupMensajeOAEL"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="640px">
          <Windows>
              <dx:PopupWindow ScrollBars="None" ShowFooter="False" ShowHeader="True" HeaderText="Aviso Importante - OAEL">
                  <ContentCollection>
                      <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                          <div>
                              <dx:ASPxFormLayout runat="server" ID="LayoutMensajeOAEL" CssClass="formLayout" ClientInstanceName="FormLayoutMensajeOAEL" >
                                  <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                  <Items>
                                      <dx:LayoutItem Caption="">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                 
                                                  <div style="font-size:0.9em;">
                                                   <%=MensajeOAEL%>
                                                  </div>
                                              </dx:LayoutItemNestedControlContainer>
                                          </LayoutItemNestedControlCollection>
                                      </dx:LayoutItem>
                                      <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                          <LayoutItemNestedControlCollection>
                                              <dx:LayoutItemNestedControlContainer>
                                                  <table style="margin-top:12px!important;">
                                                      <tr>
                                                          <td style="padding-right: 10px;">
                                                              
                                                          </td>
                                                           
                                                          <td>
                                                              <dx:ASPxButton ID="BtnCerrarMensaje" runat="server" Text="Cerrar" Width="100" ClientInstanceName="BtnCerrarMensaje" AutoPostBack="false" >
                                                                  <ClientSideEvents Click="OnBtnCerrarMensajeClick">
                                                                  </ClientSideEvents>
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