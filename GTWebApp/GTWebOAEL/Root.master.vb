Imports System.Web.Services

Public Class RootMaster
    Inherits System.Web.UI.MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LblInfoManpower.Text = Date.Now.Year.ToString() + Server.HtmlDecode(" &copy; Copyright by Manpower Group se autoriza el uso para Antamina")
        LblInfoUsuario.Text = Session("cNomContrata") & "   ::   " & Session("cNomPersona")

        Dim CRecordU As New Usuario
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try

            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim tipoUsuario As String = CStr(Decrypt(Session("cTipoUsuario")))

                CRecordU.iCodUsuario = Decrypt(Session("iCodUsuario"))
                Dim dtPermisos As DataTable = CRecordU.GetPermisosWebPorUsuario()

                Dim permisosOtorgados As New List(Of String)

                For Each row As DataRow In dtPermisos.Rows
                    permisosOtorgados.Add(row("cNomFormulario").ToString())
                Next

                For Each tabe As DevExpress.Web.RibbonTab In ASPxRibbon1.Tabs
                    For Each group As DevExpress.Web.RibbonGroup In tabe.Groups
                        For Each linkItem As DevExpress.Web.RibbonItemBase In group.Items
                            Dim edit = TryCast(linkItem, DevExpress.Web.RibbonItemBase)

                            If edit IsNot Nothing Then
                                ' Deshabilitar por defecto
                                edit.ClientEnabled = False
                                ' Habilitar si está en los permisos otorgados
                                If permisosOtorgados.Contains(edit.Name) Then
                                    edit.ClientEnabled = True
                                End If
                            End If
                        Next
                    Next
                Next
            Else

                Throw New ApplicationException("Error en la conexión con la BBDD.")
            End If
        Catch ex As Exception
            Response.Redirect("~/Login.aspx", False)
            Return
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordU = Nothing

        End Try

    End Sub

    Protected Sub BtnCerrarLogin_Click(sender As Object, e As EventArgs)

        Dim context = HttpContext.Current.GetOwinContext()
        Dim auntenticacionManager = context.Authentication

        auntenticacionManager.SignOut()

        Session.Remove("Login")
        Session.RemoveAll()
        Session.Abandon()
        Session.Clear()
        Response.Redirect("~\Login.aspx")

    End Sub

    Private Sub CallBackMainPage_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackMainPage.Callback
        Dim cTipoOpe As String
        cTipoOpe = e.Parameter.ToString
        If cTipoOpe = "CambiarClave" Then
            e.Result = CambiarClave()
        ElseIf cTipoOpe = "AgregaSubContrata" Then
            e.Result = AgregarSubContrata()
        End If
    End Sub
    Function CambiarClave() As String
        CambiarClave = "FAIL"
        Dim CRecordU As New Usuario
        Dim pTipoError As Integer = 0


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try

            If (EscapeComilla(Trim(Me.cClaveNueva.Text)) <> EscapeComilla(Trim(Me.cClaveNueva2.Text))) Then
                pTipoError = 101
                Throw New ApplicationException("Claves no coinciden.")
            End If
            If Not EsValidaContrasenia(Me.cClaveNueva.Text.Trim()) Then
                pTipoError = 102
                Throw New ApplicationException("Clave no cumple los requisitos.")
            End If

            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                If CRecordU.UpdateClave(EscapeComilla(Trim(Me.cClave.Text)), EscapeComilla(Trim(Me.cClaveNueva2.Text)), Session("iCodUsuario")) Then
                    CambiarClave = "OK"
                Else
                    pTipoError = 103 ' clave antigua no valida
                    Throw New ApplicationException("Clave anterior no es la correcta.")
                End If


                Return CambiarClave
            Else
                pTipoError = 100
                Throw New ApplicationException("Error en la conexión con la BBDD.")
            End If
        Catch ex As Exception

            If pTipoError >= 100 Then
                Return "FAIL-" & ex.Message
            Else
                Return "FAIL-Error de Proceso "
            End If


        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordU = Nothing
            pTipoError = Nothing
        End Try

    End Function
    Function AgregarSubContrata() As String
        AgregarSubContrata = "FAIL"
        Dim CRecordC As New Contrata
        Dim pTipoError As Integer = 0

        Dim iResultadoQuery As Integer = 0
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            If Len(Me.cRUCSubContrataMain.Text.Trim()) <> 11 Then
                pTipoError = 101
                Throw New ApplicationException("Número de RUC inválido.")
            End If

            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                CRecordC.cRUC = Me.cRUCSubContrataMain.Text
                CRecordC.cNomContrata = Me.cNomSubContrataMain.Text
                CRecordC.iCodUsuario = Decrypt(Session("iCodUSuario"))
                iResultadoQuery = CRecordC.InsertarSubContrata

                If iResultadoQuery = 1 Then
                    AgregarSubContrata = "OK"
                ElseIf iResultadoQuery = 0 Then
                    pTipoError = 102
                    Throw New ApplicationException("La empresa ya esta registrada.")
                ElseIf iResultadoQuery = -1 Then
                    pTipoError = 103
                    Throw New ApplicationException("Error en el proceso de registro interno.")
                Else
                    pTipoError = 110 '  
                    Throw New ApplicationException("Error en el proceso de registro.")
                End If
                Return AgregarSubContrata
            Else
                pTipoError = 100
                Throw New ApplicationException("Error en la conexión con la BBDD.")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            If pTipoError >= 100 Then
                Return "FAIL-" & ex.Message
            Else
                Return "FAIL-Error de Proceso "
            End If

        Finally

            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordC = Nothing
            pTipoError = Nothing

        End Try

    End Function
End Class