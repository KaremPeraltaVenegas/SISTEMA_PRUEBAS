Imports System.Web.Security
Imports System.Security.claims
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports Microsoft.Security.Application
Public Class Login
    Inherits System.Web.UI.Page
    Public Shared NroIntentos As Integer = 0
    Public Shared NickUnico As String = ""
    Public Shared IngresoAplicacion As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim pToken As String = TokenGenerator()
        Session("cToken") = pToken
        cToken.Value = pToken
        pToken = Nothing
    End Sub
    Protected Sub BtnLogin_Click(sender As Object, e As EventArgs)
        Dim pTipoError As Integer = 0
        Dim CRecordU As New Usuario
        Dim CRecordUC As New Usuariocontrata
        Dim DT As IDataReader
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        LblMessage.Text = ""

        Try
            ' Validar token
            If Me.cToken.Value <> Session("cToken") Then
                LblMessage.Text = "Error de inicio de sesión."
                Exit Sub
            End If

            ' Abrir conexión
            cResultCon = miConexion.OpenConnection()
            If cResultCon <> "OK" Then
                pTipoError = 100
                Throw New ApplicationException("Error en la conexión con la base de datos.")
            End If

            ' Validar CAPTCHA
            If Not IsReCaptchValid() Then
                pTipoError = 101
                Throw New ApplicationException("Error de validación.")
            End If

            ' Manejo de intentos de login
            Dim usuarioActual As String = Trim(Me.cUsuario.Text)
            If NroIntentos = 0 OrElse NickUnico <> usuarioActual Then
                NroIntentos = 1
                NickUnico = usuarioActual
            Else
                NroIntentos += 1
            End If

            ' Verificar existencia del usuario
            If CRecordU.VerificarUsuarioExiste(usuarioActual) <= 0 Then
                pTipoError = 102
                Throw New ApplicationException("Usuario no existe.")
            End If

            ' Verificar si está bloqueado
            If CRecordU.VerificarBloqueo(usuarioActual) = 1 Then
                pTipoError = 103
                Throw New ApplicationException("El Usuario se encuentra bloqueado, intente más tarde.")
            End If

            ' Verificar si tiene acceso
            If CRecordU.VerificarAcceso(usuarioActual) <= 0 Then
                pTipoError = 104
                Throw New ApplicationException("Acceso no autorizado. Verifique sus credenciales o contacte soporte.")
            End If

            ' Intentar login
            DT = CRecordU.GetLogin(EscapeComilla(usuarioActual), EscapeComilla(Me.cClave.Text))
            If DT.Read() Then
                RegenerateID()

                ' Asignar variables de sesión
                Session("Login") = Encrypt(usuarioActual)
                Session("iCodUsuario") = Encrypt(CStr(DT.GetValue(0)))
                Session("iCodPersona") = Encrypt(CStr(DT.GetValue(1)))
                Session("cNomPersona") = CStr(DT.GetValue(2))
                Session("cNick") = CStr(DT.GetValue(3))
                Session("cTipoUsuario") = Encrypt(CStr(DT.GetValue(4)))
                Session.Timeout = 15

                ' Claims y autenticación
                Dim claims As New List(Of Claim) From {
                    New Claim(ClaimTypes.Name, CStr(DT.GetValue(0))),
                    New Claim(ClaimTypes.NameIdentifier, CStr(DT.GetValue(2))),
                    New Claim(ClaimTypes.GivenName, CStr(DT.GetValue(0)))
                }

                Dim identity As New ClaimsIdentity(claims, "ApplicationCookie")
                Dim context = HttpContext.Current.GetOwinContext()
                context.Authentication.SignIn(identity)

                IngresoAplicacion = True
                RegistrarSeguridadUsuarioHistorial(False)
                Response.Redirect("Default.aspx")
            Else
                ' Si el login falla
                IngresoAplicacion = False
                RegistrarSeguridadUsuarioHistorial(False)

                If NroIntentos > 3 Then
                    Dim objUsuario As New Usuario
                    objUsuario.RegistrarBloqueo(usuarioActual)
                    LblMessage.Text = "Usuario tuvo más de 3 intentos fallidos. Se bloqueará por 1 hora."
                    objUsuario = Nothing
                Else
                    LblMessage.Text = $"Login Incorrecto. Intento Fallido {NroIntentos}"
                End If
            End If

            DT?.Close()

        Catch ex As ApplicationException
            If pTipoError >= 100 Then
                LblMessage.Text = ex.Message
            Else
                LblMessage.Text = "Error en la solicitud. Por favor, intente nuevamente."
            End If
        Finally
            ' Liberar recursos
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordUC = Nothing
            DT = Nothing
        End Try
    End Sub
    Sub RecuperarClave()

        Dim pTipoError As Integer = 0
        Dim CRecordMail As New cMailing
        Dim CRecordU As New Usuario
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim bRecuperar As Boolean = False

        Dim DTReader As IDataReader
        Try
            If Len(Trim(Me.cUsuarioRecovery.Text)) <= 0 Then
                pTipoError = 110
                Throw New ApplicationException("No ha consignado un nombre de usuario válido.")
            End If
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordUC As New Uconfig
                CRecordUC.iCodUConfig = 1
                CRecordUC.getRecord()
                CRecordMail.cMail = CRecordUC.cValue1
                CRecordMail.cMailKey = CRecordUC.cValue2
                'CRecordMail.cMailSMTP = CRecordUC.cValue3
                CRecordMail.cMailPort = CRecordUC.cValue4
                'CRecordMail.cMailDomain = CRecordUC.cValue5
                CRecordMail.cMailHostIP = CRecordUC.cValue3
                CRecordUC = Nothing

                CRecordMail.cNombres = ""
                CRecordMail.cCorreoDestino = ""

                CRecordMail.cClave = GeneradorPasswordDos(8, True)
                CRecordU.cClave = CRecordMail.cClave
                CRecordU.cNick = (Trim(Me.cUsuarioRecovery.Text))

                DTReader = CRecordU.GetRecordUCPersonaByNick


                If DTReader.Read() Then

                    CRecordU.iCodUsuario = CStr(DTReader.GetValue(2))
                    CRecordMail.cNombres = CStr(DTReader.GetValue(3))
                    CRecordMail.cCorreoDestino = CStr(DTReader.GetValue(4))
                    CRecordMail.cUsuario = (Trim(Me.cUsuarioRecovery.Text))
                    CRecordMail.cUrlDrive = Session("cUrlPGI")
                    CRecordMail.cNomContrata = Session("cNomContrata")
                    'SI TIENE PERMISO PARA ACCEDER BACCEDER=1 
                    If CBool(DTReader.GetValue(5)) = True Then
                        bRecuperar = True
                    Else
                        pTipoError = 101
                        Throw New ApplicationException("Su cuenta se encuentra inhabilitada.")
                    End If
                Else

                    pTipoError = 102
                    Throw New ApplicationException("El nombre de usuario no existe.")
                End If


                If bRecuperar = True Then
                    If Not IsValidEmail(CRecordMail.cCorreoDestino) Then
                        pTipoError = 103
                        Throw New ApplicationException("El correo consignado es inválido, contacte en el grupo de soporte de Telegram.")
                    End If

                    If CRecordU.UpdateClaveRecovery Then
                        'ENVIAMOS CORREO

                        If CRecordMail.GestionarEnvio("RecuperarClave", "", "") = True Then
                            LblRecovery.Text = String.Format("Se envió su nueva contraseña al correo {0} .", GenerateCorreoAcortado(CRecordMail.cCorreoDestino))
                        Else
                            pTipoError = 104
                            Throw New ApplicationException("Error de recuperación de contraseña. Intente de nuevo. Si el problema persiste consulte en el grupo de soporte.")
                        End If
                    Else
                        pTipoError = 105
                        Throw New ApplicationException("Error de Proceso.")
                    End If
                End If
            Else
                    pTipoError = 100
                    Throw New ApplicationException("Error en la conexión con a BBDD.")
                End If
        Catch ex As Exception

            If pTipoError >= 100 Then
                LblRecovery.Text = ex.Message
            Else
                LblRecovery.Text = "Error en la petición al servidor."
            End If
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordMail = Nothing
            CRecordU = Nothing
            DTReader = Nothing
            pTipoError = Nothing
            bRecuperar = Nothing
        End Try
    End Sub

    Sub RegenerateID()
        Dim oHTTPContext As HttpContext = HttpContext.Current

        Dim oSessionIdManager As New SessionIDManager
        Dim sOldId As String = oSessionIdManager.GetSessionID(oHTTPContext)
        Dim sNewId As String = oSessionIdManager.CreateSessionID(oHTTPContext)

        Dim bIsRedir As Boolean = False
        Dim bIsAdd As Boolean = False
        oSessionIdManager.SaveSessionID(oHTTPContext, sNewId, bIsRedir, bIsAdd)

        Dim oAppContext As HttpApplication = HttpContext.Current.ApplicationInstance

        Dim oModules As HttpModuleCollection = oAppContext.Modules

        Dim oSessionStateModule As SessionStateModule = _
          DirectCast(oModules.Get("Session"), SessionStateModule)

        Dim oFields() As System.Reflection.FieldInfo = _
          oSessionStateModule.GetType.GetFields(System.Reflection.BindingFlags.NonPublic Or _
                                                System.Reflection.BindingFlags.Instance)

        Dim oStore As SessionStateStoreProviderBase = Nothing
        Dim oRqIdField As System.Reflection.FieldInfo = Nothing
        Dim oRqItem As SessionStateStoreData = Nothing
        Dim oRqLockIdField As System.Reflection.FieldInfo = Nothing
        Dim oRqStateNotFoundField As System.Reflection.FieldInfo = Nothing

        For Each oField As System.Reflection.FieldInfo In oFields
            If (oField.Name.Equals("_store")) Then
                oStore = DirectCast(oField.GetValue(oSessionStateModule),  _
                                    SessionStateStoreProviderBase)
            End If
            If (oField.Name.Equals("_rqId")) Then
                oRqIdField = oField
            End If
            If (oField.Name.Equals("_rqLockId")) Then
                oRqLockIdField = oField
            End If
            If (oField.Name.Equals("_rqSessionStateNotFound")) Then
                oRqStateNotFoundField = oField
            End If
            If (oField.Name.Equals("_rqItem")) Then
                oRqItem = DirectCast(oField.GetValue(oSessionStateModule),  _
                                     SessionStateStoreData)
            End If
        Next

        If oStore IsNot Nothing Then

            Dim oLockId As Object = Nothing

            If oRqLockIdField IsNot Nothing Then
                oLockId = oRqLockIdField.GetValue(oSessionStateModule)
            End If

            If (oLockId IsNot Nothing) And (Not String.IsNullOrEmpty(sOldId)) Then
                oStore.ReleaseItemExclusive(oHTTPContext, sOldId, oLockId)
                oStore.RemoveItem(oHTTPContext, sOldId, oLockId, oRqItem)
            End If

            oRqStateNotFoundField.SetValue(oSessionStateModule, True)
            oRqIdField.SetValue(oSessionStateModule, sNewId)

        End If
    End Sub

    Public Function IsReCaptchValid() As Boolean

        Dim secretKey As String = "6LdQcncaAAAAAGGkaMRkgW34I4BZoOX8tiQ5vfLD"
        Dim recaptcha_response = gRecaptchaResponse.Value
        Dim Myrequest As WebRequest = WebRequest.Create("https://www.google.com/recaptcha/api/siteverify")
        Myrequest.Method = "POST"

        Dim postData As String = "secret=" & secretKey & "&response=" & recaptcha_response
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        Myrequest.ContentType = "application/x-www-form-urlencoded"
        Myrequest.ContentLength = byteArray.Length


        Dim dataStream As Stream = Myrequest.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = Myrequest.GetResponse()
        Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)

        Using dataStream1 As Stream = response.GetResponseStream()

            Dim reader As New StreamReader(dataStream1)

            Dim responseFromServer As String = reader.ReadToEnd()

            Dim jsonData As String = responseFromServer
            Dim JsonResults As Object = New JavaScriptSerializer().Deserialize(Of Object)(jsonData)

            If JsonResults("success") = True Then
                Return True
            Else
                Return False
            End If

        End Using
        response.Close()
    End Function

    Function RegistrarSeguridadUsuarioHistorial(ByVal _bEsBloqueado As Boolean) As String

        Dim CRecordP As New Seguridadusuariohistorial
        Dim cResultadoOperacion As String = "FAIL"
        Dim cRespuesta As Integer = 0
        Try

            CRecordP.bEsBloqueado = _bEsBloqueado
                With CRecordP
                    .cNick = Me.cUsuario.Text
                    .iCodUsuario = 0
                    .cTipoLogOnOff = "LOGON"
                    .iNroIntentosLogOn = NroIntentos.ToString()
                    .bIngresoAplicacion = IngresoAplicacion.ToString()
                    .dFechaLogOnOff = GlobalDateNow()
                    .cHostName = Request.ServerVariables("REMOTE_HOST")
                    .cIP = IIf(String.IsNullOrEmpty(Request.ServerVariables("HTTP_X_FORWARDED_FOR")), Request.ServerVariables("REMOTE_ADDR"), Request.ServerVariables("HTTP_X_FORWARDED_FOR")) 'Convert.ToString(ipEntry.AddressList(ipEntry.AddressList.Length - 1)) 'Request.ServerVariables("REMOTE_ADDR")
                    If .bEsBloqueado Then
                        .bBloqueado = "True"
                        .dFechaBloqueo = GlobalDateNow()
                    Else
                        .bBloqueado = "NULL"
                        .dFechaBloqueo = "NULL"
                    End If
                End With

                cRespuesta = CRecordP.AgregarSeguridadUsuarioHistorial()

                If cRespuesta > 0 Then
                    cResultadoOperacion = "OK"
                Else
                    cResultadoOperacion = "Error en la transacción"
                End If
           

        Catch ex As Exception
            Return "Ocurrió un error durante la transacción."
        Finally

            CRecordP = Nothing
        End Try
        Return cResultadoOperacion
    End Function

    Protected Sub BtnRecoveryClave_Click(sender As Object, e As EventArgs)
        RecuperarClave()
    End Sub
End Class