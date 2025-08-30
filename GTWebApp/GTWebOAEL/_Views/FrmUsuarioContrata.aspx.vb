Imports Newtonsoft
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services
Imports System.Web.Script.Services

Public Class FrmUsuarioContrata
    Inherits System.Web.UI.Page
    Public CRecord As New Usuariocontrata
    '::::: EDITAR
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx", False)
            Return
        Else
            If Session("Login") Is Nothing Or Session("iCodContrata") Is Nothing Then
                Response.Redirect("~/Login.aspx", False)
                Return
            Else
                If Not IsPostBack Then

                    Dim p_paginaNombre As String = "FrmUsuarioContrataWebMain"
                    Dim p_iCodUsuario As String = Decrypt(Session("iCodUsuario"))

                    ' Verifica que la sesión no sea nula
                    If String.IsNullOrEmpty(p_iCodUsuario) Then
                        Response.Redirect("~/Login.aspx", False)
                        Return
                    End If

                    Dim cResultCon As String = ""
                    Dim miConexion As New ConnectSQL

                    Try

                        cResultCon = miConexion.OpenConnection
                        If cResultCon = "OK" Then 'ok

                            Dim objUsuarioPermiso As New Usuariopermiso
                            If Not objUsuarioPermiso.VerificarTienePermisoPorNombrePagina(p_paginaNombre, p_iCodUsuario) Then
                                Response.Redirect("~/Default.aspx", False)
                                Return
                            Else
                                If HttpContext.Current.User.IsInRole("3") Then
                                    CargaContratistas()
                                Else
                                    Response.Redirect("~/Default.aspx", False)
                                    Return
                                End If
                            End If
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

                    End Try
                End If
                Inicia()
                MostrarDatos()
            End If
        End If
    End Sub
    Sub Inicia()
        Me.PopupFormMain.Windows.Item(0).HeaderText = "Formulario :: Usuarios del Sistema"
        TablaRegistros.KeyFieldName = "iCodUsuarioContrata" '::::: EDITAR
        cFormMetadata.Set("pTable", "FrmUsuarioContrata")
    End Sub
    Protected Sub MostrarDatos()
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                TablaRegistros.DataSource = CRecord.ListaUsuarios
                TablaRegistros.CollapseAll()
                AjustarTablaRegistros()
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception

        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Sub
    Sub AjustarTablaRegistros()
        With TablaRegistros
            .Columns(0).Visible = False
            .Columns(1).Caption = "Empresa"
            .Columns(2).Caption = "Empleado"
            .Columns(3).Caption = "Habilitado"
            .Columns(3).Width = 80

        End With
    End Sub
    Function GuardarRegistro() As String

        GuardarRegistro = "FAIL"

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                If cFormMetadata("cTipoOpe") = "A" Then
                    GuardarRegistro = HandleInsertar()
                ElseIf cFormMetadata("cTipoOpe") = "M" Then
                    GuardarRegistro = HandleUpdate()
                End If

                Return GuardarRegistro
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            GuardarRegistro = "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function
    Function HandleInsertar() As String
        Dim CRecordP As New Persona
        Dim CRecordPN As New Personanatural
        Dim CRecordU As New Usuario
        Dim CRecordUP As New Usuariopermiso

        With CRecordP
            .iCodPersona = Me.iCodPersona.Text
            .cTipoPer = "R"
            .iCodTipoDocumentoIdentidad = 2
            .cNroDoc = Me.cNroDoc.Text
            .cDireccion = ""
            .bAnulado = CBool(0)
            .iCodUsuario = Decrypt(Session("iCodUSuario"))
            .dFechaSis = GlobalDateNow()
        End With

        With CRecordPN
            .iCodPersonaNatural = 0
            .iCodPersona = 0
            .cApelP = Me.cApelP.Text
            .cApelM = ""
            .cNombres = Me.cNombres.Text
            .cSexo = Me.cSexo.Value
            .cFuncion = "UC"
            .iCodTipoEstadoCivil = 1
            .dFechaNac = "1900-01-01"
            .cLugarNac = ""
            .cFono = Me.cFono.Text
            .cCorreo = Me.cCorreo.Text
            .cCusp = ""
            .cLicenciaConducir = ""
            .cCargo = ""
            .cGrupoSanguineo = ""
            .iCodTipoGradoInstruccion = 7
            .iCodDepartamentoRes = 0
            .iCodProvinciaRes = 0
            .iCodDistritoRes = 0
            .iCodDepartamentoNac = 0
            .iNroDependientes = 0
            .iSituacion = 0
            .cCodigoPlanilla = ""
            .iCodPersonaCargo = 0
        End With

        With CRecordU
            .iCodUsuario = 0
            .iCodPersona = 0
            .cNick = CRecordP.cNroDoc
            .cClave = CRecordP.cNroDoc
            .cTipo = Me.cTipo.Value
            .bEliminado = CBool(0)

            .bBloqueado = CBool(0)
            .dFechaUltimoBloqueo = "NULL"
            .dFechaSis = GlobalDateNow()
            .iCodUsuarioSis = Decrypt(Session("iCodUSuario"))
        End With

        With CRecord
            .iCodUsuarioContrata = 0
            .iCodPersona = 0
            .iCodUsuario = 0
            .iCodContrata = Me.iCodContrata.Value
            .bAcceder = CBool(Me.bAcceder.Checked)
        End With
        Try
            CRecord.mc.miTransact = ConnectSQL.linkSQL.BeginTransaction

            CRecordP.mc.miTransact = CRecord.mc.miTransact
            CRecordPN.mc.miTransact = CRecord.mc.miTransact
            CRecordU.mc.miTransact = CRecord.mc.miTransact
            CRecordUP.mc.miTransact = CRecord.mc.miTransact

            If Me.iCodPersona.Text = "" OrElse CInt(Me.iCodPersona.Text) <= 0 Then
                CRecordP.InsertarTransact()
                CRecordPN.iCodPersona = CRecordP.iCodPersona
                CRecordU.iCodPersona = CRecordP.iCodPersona
                CRecord.iCodPersona = CRecordP.iCodPersona
                CRecordPN.InsertarTransact()
            Else
                CRecord.iCodPersona = Me.iCodPersona.Text
            End If

            If Me.iCodUsuario.Text = "" OrElse CInt(Me.iCodUsuario.Text) <= 0 Then
                CRecordU.InsertarTransact()
                CRecord.iCodUsuario = CRecordU.iCodUsuario
            Else
                CRecord.iCodUsuario = Me.iCodUsuario.Text
            End If

            CRecord.InsertarTransact()

            CRecordUP.iCodUsuarioSistema = CRecord.iCodUsuario
            CRecordUP.cTipoUsuario = CRecordU.cTipo
            CRecordUP.iCodUsuario = Decrypt(Session("iCodUSuario"))
            CRecordUP.GenerarPermisosTransact()

            CRecord.mc.miTransact.Commit()
            Return "OK"
        Catch ex As Exception
            CRecord.mc.miTransact.Rollback()
            Return "FAIL"
        Finally
            CRecordU = Nothing
            CRecordP = Nothing
            CRecordPN = Nothing
        End Try
    End Function
    Function HandleUpdate() As String
        'MsgBox("usuario a : " & Me.iCodUsuario.Text)
        Dim CRecordPN As New Personanatural
        Dim CRecordU As New Usuario


        With CRecordPN
            .iCodPersona = Me.iCodPersona.Text
            .cFono = Me.cFono.Text
            .cCorreo = Me.cCorreo.Text
        End With

       

        With CRecord
            .iCodUsuarioContrata = Me.iCodRegistro.Text
            .iCodPersona = Me.iCodPersona.Text
            .iCodUsuario = Me.iCodUsuario.Text
            .iCodContrata = Me.iCodContrata.Value
            .bAcceder = CBool(Me.bAcceder.Checked)



        End With

        CRecordU.iCodUsuario = CRecord.iCodUsuario
        CRecordU.cTipo = Me.cTipo.Value
        Try
            CRecord.mc.miTransact = ConnectSQL.linkSQL.BeginTransaction
            CRecordPN.mc.miTransact = CRecord.mc.miTransact
            CRecordU.mc.miTransact = CRecord.mc.miTransact

            CRecordPN.UpdateDataWeb()
            CRecord.ModificarTransact()

            CRecordU.UpdateTipoUsuarioTransact()


            CRecord.mc.miTransact.Commit()


            Return "OK"
        Catch ex As Exception
            CRecord.mc.miTransact.Rollback()

            Return "FAIL"
        Finally
            CRecordPN = Nothing
            CRecordU = Nothing
        End Try
    End Function
    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        TablaRegistros.DataBind() ':::: NO MODIFICAR
    End Sub
    Private Sub CallBackFunction_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunction.Callback
        e.Result = GuardarRegistro() ':::: NO MODIFICAR
    End Sub
    '*********************** INI SECCION DE CONTROLADOR ***********************
    <WebMethod()> _
    Public Shared Function GetRecord(ByVal pID As String) As String ':::: NO MODIFICAR
        
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Usuariocontrata '::::: EDITAR
                CRecordW.iCodUsuarioContrata = pID
                Dim strJSON As String
                strJSON = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetRecordUCPersona, Json.Formatting.None)
                CRecordW = Nothing



                Return strJSON
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Error de Proceso"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try

    End Function
    <WebMethod()> _
    Public Shared Function DeleteRecord(ByVal pID As String) As String ':::: NO MODIFICAR
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Usuariocontrata  '::::: EDITAR
                If pID = "" Then
                    Return "FAIL"
                End If
                CRecordW.iCodUsuarioContrata = pID
                CRecordW.Eliminar()
                CRecordW = Nothing


                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Error de Proceso"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing

            'miConexion = Nothing
            'ConnectSQL.linkSQL.Dispose()
            'cResultCon = Nothing
        End Try

    End Function
    '+++++++++++++++++++++++ INI METODOS WEB CUSTOM +++++++++++++++++++++++
    ' Aqui puede añadir las Web Methods personalizadas


    '+++++++++++++++++++++++ INI METODOS WEB CUSTOM +++++++++++++++++++++++
    <WebMethod()> _
    Public Shared Function GetRecordPersona(ByVal pDoc As String, ByVal pTipo As String) As String ':::: NO MODIFICAR
       


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Personanatural '::::: EDITAR
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetPersonaByDNI(pDoc, pTipo), Json.Formatting.None)
                CRecordW = Nothing
             


                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Error de Proceso"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try

    End Function
    <WebMethod()> _
    Public Shared Function GetRecordPersonaCloud2020(ByVal pDoc As String) As String ':::: NO MODIFICAR

        Return System.Net.WebUtility.HtmlDecode(WebDNICloud(pDoc, ""))


    End Function
    '*********************** FIN SECCION DE CONTROLADOR ***********************
    Sub CargaContratistas()


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordCTO As New Contrata

                iCodContrata.DataSource = CRecordCTO.ListaContratistasPrincipales
                iCodContrata.ValueField = "ValueMember"
                iCodContrata.TextField = "DisplayMember"
                iCodContrata.DataBindItems()

                CRecordCTO = Nothing


            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            'ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try

      
    End Sub
     
    Private Sub FrmUsuarioContrata_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        CRecord = Nothing
    End Sub
End Class