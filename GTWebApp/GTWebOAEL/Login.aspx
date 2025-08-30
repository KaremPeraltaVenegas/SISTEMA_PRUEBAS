<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="GTWebOAEL.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, user-scalable=no, maximum-scale=1.0, minimum-scale=1.0" />
    <title>Manpower Group</title>
    <link rel="stylesheet" type="text/css" href="Content/Site.css" />
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <script src="https://www.google.com/recaptcha/api.js"></script>
    <style>
        /*.container {
  height: 200px;
  position: relative;
  border: 3px solid green;
}

.center {
  margin: 0;
  position: absolute;
  top: 50%;
  left: 50%;
  -ms-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
}*/
        .BoxLogin {
            box-shadow: 0 10px 25px 0 rgba(50,50,93,.1), 0 5px 15px 0 rgba(0,0,0,.1);
            /*padding:60px 12px!important;*/
            margin-top: 60px !important;
            background: #f4f6f7;
        }

        .divCenter {
            margin: 45px auto !important;
            display: block;
        }

        .blockCenter {
            margin: 0 auto !important;
        }

        .gtTitle {
            color: #4d87b9;
            font-size: 1.2em;
            font-weight: 500;
            padding-bottom: 12px !important;
        }

        .gtContainerLogin {
            width: 60% !important;
            margin: auto;
            /*background:#f4f6f7;*/
        }

        .gtContainerLoginFirst {
            background: #fff;
            height: 100% !important;
            padding: 95px 10px !important;
        }

        .gtContainerLoginSecond {
            /*background:#f4f6f7;*/
            padding: 45px 10px !important;
        }

        .errorMsg {
        }

        .errorLogin {
            color: #ff2d1a;
        }

        @media (max-width: 480px) {
            .gtContainerLogin {
                width: 40%;
            }
        }

        .toUpper {
        }
        /* Estilos para mostrar contraseña*/

        .password-container {
            display: flex;
            align-items: center;
        }

            .password-container .toggle-button {
                margin-left: 5px;
                cursor: pointer;
            }

        #loadingMessage {
            display: none;
            text-align: center;
            margin-top: 20px;
            color: #4d87b9;
            font-size: 1.2em;
            font-weight: bold;
            font-weight: 500;
        }
        .ImagenCentro {
         display: block;
  margin-left: auto;
  margin-right: auto;
        }
    </style>

    <script type="text/javascript">

        function OpenFormRecovery(e, s) {


            var popupWindow = PopupFormRecoveryClave.GetWindow(0);
            PopupFormRecoveryClave.ShowWindow(popupWindow);
            cUsuarioRecovery.SetText('');
            LblRecovery.SetText('');
            e.processOnServer = false;
        }
        function OnBtnRecoveryClaveClick(s, e) {

            if (ASPxClientEdit.ValidateEditorsInContainer(FormLayoutPopupRecoveryClave.GetMainElement(), 'GrupoRecoveryClave', false)) {


                e.processOnServer = true;
            }
            else {

                e.processOnServer = false;
            }

        }
        function OnBtnCerrarFormRecoveryClaveClick(e, s) {
            var popupWindow = PopupFormRecoveryClave.GetWindow(0);
            PopupFormRecoveryClave.HideWindow(popupWindow);
            e.processOnServer = false;
        }


        function cUsuarioRecovery_KeyPress(s, e) {

            if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122) || (e.htmlEvent.keyCode == 45) || (e.htmlEvent.keyCode == 46)) {

                return true;
            }
            else {

                ASPxClientUtils.PreventEvent(e.htmlEvent);
            }

        }
        function cUsuarioRecovery_Validation(s, e) {
            var eText = s.GetText();
            if ((eText.length < 4) || (eText.length > 20)) {

                e.isValid = false;
            }
            else {
                e.isValid = true;
            }


        }

        function cUsuario_KeyPress(s, e) {

            if ((e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) || (e.htmlEvent.keyCode >= 65 && e.htmlEvent.keyCode <= 90) || (e.htmlEvent.keyCode >= 97 && e.htmlEvent.keyCode <= 122) || (e.htmlEvent.keyCode == 45) || (e.htmlEvent.keyCode == 46)) {

                return true;
            }
            else {

                ASPxClientUtils.PreventEvent(e.htmlEvent);
            }

        }
        function cUsuario_Validation(s, e) {
            var eText = s.GetText();
            if ((eText.length < 4) || (eText.length > 20)) {

                e.isValid = false;
            }
            else {
                e.isValid = true;
            }


        }

        /*Para mostrar contraseña*/

        function togglePasswordVisibility() {
            var passwordField = cClave.GetInputElement();
            if (passwordField.type === "password") {
                passwordField.type = "text";
            } else {
                passwordField.type = "password";
            }
        }

        /* Para recapcha*/

        function onSubmit(token) {
            gRecaptchaResponse.SetText(token);
            document.getElementById('loadingMessage').style.display = 'block'; // Mostrar mensaje de espera
            BtnLogin.DoClick();

        }

    </script>
</head>
<body class="Login">

    <form id="form1" runat="server">

       <%-- <div id="loadingMessage" runat="server">
            <asp:Image ImageUrl="~/Content/images/loading.gif" runat="server" alt="Cargando..." />
            <br />
            <span>Verificando acceso, por favor espere...</span>
        </div>--%>

        <div class="divCenter">
            <dx:ASPxFormLayout runat="server" ID="FormLayoutLogin" CssClass="gtContainerLogin" ClientInstanceName="FormLayoutLogin">
                <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="480" />
                <Items>
                    <dx:LayoutGroup ColCount="2" Width="100%" GroupBoxDecoration="None" CssClass="BoxLogin" UseDefaultPaddings="false" Caption="" SettingsItemCaptions-Location="Top">
                        <Items>

                            <dx:LayoutGroup ColCount="1" CssClass="gtContainerLoginFirst" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="" SettingsItemCaptions-Location="Top">
                                <Items>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <img class="blockCenter" src="_GTContent/images/logo-mpg.png" />
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                </Items>

                                <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
                            </dx:LayoutGroup>

                            <dx:LayoutGroup ColCount="1" CssClass="gtContainerLoginSecond" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="Login de Usuario" SettingsItemCaptions-Location="Top">
                                <Items>


                                    <%--***ITEM FORM ***--%>
                                    <dx:LayoutItem Caption="">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <div class="gtTitle">Login de Usuario</div>
                                                <dx:ASPxTextBox runat="server" ID="cToken" ClientInstanceName="cToken" Visible="true" ClientVisible="false">
                                                </dx:ASPxTextBox>
                                                <dx:ASPxTextBox ID="gRecaptchaResponse" runat="server" Width="170px" Visible="True" ClientVisible="False" ClientInstanceName="gRecaptchaResponse">
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                    <%--***ITEM FORM ***--%>
                                    <dx:LayoutItem Caption="Usuario">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxTextBox runat="server" ID="cUsuario" ClientInstanceName="cUsuario">
                                                    <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic" ErrorDisplayMode="ImageWithTooltip" ErrorText="Dato inválido">
                                                    </ValidationSettings>

                                                    <ClientSideEvents KeyPress="cUsuario_KeyPress"
                                                        Validation="cUsuario_Validation" />
                                                </dx:ASPxTextBox>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <%--***ITEM FORM ***--%>
                                    <dx:LayoutItem Caption="Clave">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <div class="password-container">
                                                    <dx:ASPxTextBox runat="server" ID="cClave" ClientInstanceName="cClave" Width="100%" Password="True">
                                                        <ValidationSettings RequiredField-IsRequired="true" Display="Dynamic">
                                                        </ValidationSettings>
                                                    </dx:ASPxTextBox>
                                                    <!-- Botón para mostrar/ocultar la contraseña -->
                                                    <dx:ASPxButton runat="server" ID="btnTogglePassword" ClientInstanceName="btnTogglePassword" CssClass="toggle-button" Text="👁" Width="45px" AutoPostBack="False">
                                                        <ClientSideEvents Click="function(s, e) { togglePasswordVisibility(); }" />
                                                    </dx:ASPxButton>
                                                </div>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>



                                    <%--*** COMMANDS BUTTON ***--%>
                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <table style="margin-top: 12px!important;">
                                                    <tr>
                                                         <td style="padding-right: 10px;">
                                                            <button style="color: white; background-color: #F87C1D; border-radius: 2px; padding: 8px 16px 8px; font: 14px 'Segoe UI', Helvetica, 'Droid Sans', Tahoma, Geneva, sans-serif; border: 1px dotted transparent; display: table-cell; vertical-align: middle; line-height: 100%; text-decoration: inherit;  letter-spacing: 0.01em; border-spacing: 0; border-collapse: separate; cursor: pointer; font-weight: normal;"
                                                                class="g-recaptcha" data-sitekey="6LdQcncaAAAAACuyE5c30mB7GANmkfrPCvNP-wVI" data-callback='onSubmit' data-action='submit'>
                                                                Ingresar</button>
                                                        </td>

                                                        <td style="padding-right: 10px;">
                                                            <dx:ASPxButton ID="BtnLogin" runat="server" Text="Ingresar" OnClick="BtnLogin_Click" Width="20px" ClientInstanceName="BtnLogin" AutoPostBack="false" ClientVisible="False">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td>
                                                            <dx:ASPxButton ID="BtnRecuperarClave" runat="server"
                                                                Text="Olvide mi clave." Width="100" ClientInstanceName="BtnRecuperarClave" AutoPostBack="false" RenderMode="Link">
                                                                <ClientSideEvents Click="OpenFormRecovery"></ClientSideEvents>
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <div id="loadingMessage"  >
                                                                <span style='display:block;text-align:center;padding:0px 0px 4px 0px;font-size:10px;'>
                                                                Validando acceso, espere por favor.</span>
                                                                <img class='ImagenCentro' src='Content/images/ajax-loader.gif' />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>
                                    <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                        <LayoutItemNestedControlCollection>
                                            <dx:LayoutItemNestedControlContainer>
                                                <dx:ASPxLabel CssClass="errorLogin" ID="LblMessage" runat="server" Text=""></dx:ASPxLabel>
                                            </dx:LayoutItemNestedControlContainer>
                                        </LayoutItemNestedControlCollection>
                                    </dx:LayoutItem>

                                </Items>

                                <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
                            </dx:LayoutGroup>
                        </Items>

                        <SettingsItemCaptions Location="Top"></SettingsItemCaptions>
                    </dx:LayoutGroup>

                </Items>
            </dx:ASPxFormLayout>
        </div>




        <%-- ***************************** SECCION POPUPS  ***************************** --%>
        <dx:ASPxPopupControl ID="PopupFormRecoveryClave" runat="server" Modal="True" ClientInstanceName="PopupFormRecoveryClave"
            PopupElementID="PopupFormRecoveryClave" PopupHorizontalAlign="WindowCenter" Width="500" PopupVerticalAlign="WindowCenter"
            MaxWidth="500" MinWidth="360px" CloseAction="CloseButton" CloseAnimationType="Fade">
            <Windows>
                <dx:PopupWindow CloseAction="CloseButton" CloseOnEscape="False" Modal="True"
                    ScrollBars="None" AutoUpdatePosition="True" HeaderText="Recuperar Contraseña" ShowFooter="False">
                    <ContentCollection>
                        <dx:PopupControlContentControl ID="PopupControlContentControl5" runat="server">
                            <%--********* INI CONTENT FORM MAIN *********--%>
                            <div>
                                <dx:ASPxFormLayout runat="server" ID="FormLayoutPopupRecoveryClave" CssClass="formLayout" ClientInstanceName="FormLayoutPopupRecoveryClave">
                                    <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="500" />
                                    <Items>


                                        <dx:LayoutGroup ColCount="1" GroupBoxDecoration="None" UseDefaultPaddings="false" Caption="">
                                            <Items>

                                                <%--***ITEM FORM ***--%>
                                                <dx:LayoutItem Caption="Usuario">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxTextBox runat="server" ID="cUsuarioRecovery" ClientInstanceName="cUsuarioRecovery" CssClass="">
                                                                <ClientSideEvents KeyPress="cUsuarioRecovery_KeyPress"
                                                                    Validation="cUsuarioRecovery_Validation" />
                                                                <ValidationSettings ErrorDisplayMode="ImageWithTooltip" ErrorText="Dato inválido" Display="Dynamic" />
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>


                                                <%--*** COMMANDS BUTTON ***--%>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Right" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>

                                                            <table style="margin-top: 12px!important;">
                                                                <tr>

                                                                    <td style="padding-right: 10px;">
                                                                        <dx:ASPxButton ID="BtnRecoveryClave" runat="server" Text="Enviar" Width="100px" ClientInstanceName="BtnRecoveryClave" AutoPostBack="false" OnClick="BtnRecoveryClave_Click">
                                                                            <ClientSideEvents Click="OnBtnRecoveryClaveClick" />
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                    <td>
                                                                        <dx:ASPxButton ID="BtnCerrarFormRecoveryClave" runat="server" Text="Cerrar" Width="100" ClientInstanceName="BtnCerrarFormRecoveryClave" AutoPostBack="false">
                                                                            <ClientSideEvents Click="OnBtnCerrarFormRecoveryClaveClick"></ClientSideEvents>
                                                                        </dx:ASPxButton>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem ShowCaption="False" HorizontalAlign="Left" Width="100%">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxLabel CssClass="errorLogin" ClientInstanceName="LblRecovery" ID="LblRecovery" runat="server" Text=""></dx:ASPxLabel>
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
            <ClientSideEvents Closing="function(s, e) {
	  ASPxClientEdit.ClearEditorsInContainer(FormLayoutLogin.GetMainElement());
             cUsuario.SetText('');
                cClave.SetText('');
           cUsuario.Focus('');
              
}"
                Shown="function(s,e){
          
                 cUsuario.SetText('------');
                cClave.SetText('-');
          
              }"></ClientSideEvents>
        </dx:ASPxPopupControl>


    </form>
</body>
</html>
