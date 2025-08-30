Imports System.Drawing
Imports System.Web.Services
Imports DevExpress.Web
Imports Newtonsoft
Public Class FrmMesaPartes
    Inherits System.Web.UI.Page
    Public CRecord As New Candidatoadmision
    Private CRecordCI As New Candidatoinforme

#Region "FUNCIONES DE CARGADO DE PAGINA"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx", False)
        Else
            If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
                Dim p_paginaNombre As String = "FrmMesaPartesWebMain"
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
                            Inicia()
                            MostrarDatos()
                        End If
                    Else
                        Throw New ApplicationException("Error en la conexión con la BBDD.")
                    End If
                Catch ex As Exception
                    Response.Redirect("~/Login.aspx")
                Finally
                    miConexion.CloseConnection()
                    miConexion = Nothing
                    cResultCon = Nothing

                End Try
            End If
        End If
    End Sub
    Sub Inicia()
        TablaRegistros.KeyFieldName = "iCodCandidatoAdmision"
        cFormMetadata.Set("pTable", "FrmMesaPartes")

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                'Dim CRecordCV As New Convocatoria
                'iCodConvocatoria.DataSource = CRecordCV.ListaConvocatoriasVigentes()
                'iCodConvocatoria.ValueField = "iCodConvocatoria"
                'iCodConvocatoria.TextField = "cPerfil"
                'iCodConvocatoria.DataBindItems()

                'CRecordCV = Nothing

                Dim CRecordCI As New Candidatoinforme

                cUbigeo.DataSource = CRecordCI.ListaTDUbigeos
                cUbigeo.ValueField = "ValueMember"
                cUbigeo.TextField = "DisplayMember"
                cUbigeo.DataBindItems()

                cUbigeoResidencia.DataSource = CRecordCI.ListaTDUbigeos
                cUbigeoResidencia.ValueField = "ValueMember"
                cUbigeoResidencia.TextField = "DisplayMember"
                cUbigeoResidencia.DataBindItems()

                cEstCivil.DataSource = CRecordCI.ListaEstadoCivil
                cEstCivil.ValueField = "ValueMember"
                cEstCivil.TextField = "DisplayMember"
                cEstCivil.DataBindItems()

                cCondicion.DataSource = CRecordCI.ListaCondicion
                cCondicion.ValueField = "ValueMember"
                cCondicion.TextField = "DisplayMember"
                cCondicion.DataBindItems()

                CRecordCI = Nothing

                Dim CRecordTCS As New Tdcondicionsustento

                CRecordTCS.iCodCliente = 1
                iCodTDCondicionSustento.DataSource = CRecordTCS.ListaCondicionSustento
                iCodTDCondicionSustento.ValueField = "iCodTDCondicionSustento"
                iCodTDCondicionSustento.TextField = "cCondicionSustento"
                iCodTDCondicionSustento.DataBindItems()

                CRecordTCS = Nothing

                Dim CRecordCAT As New Candidatoadmisioncatalogo
                CRecordCAT.cTipo = "T"
                iCodCandidatoAdmisionTipo.DataSource = CRecordCAT.ListaCatalogoTipoAdmisionPorTipo
                iCodCandidatoAdmisionTipo.ValueField = "ValueMember"
                iCodCandidatoAdmisionTipo.TextField = "DisplayMember"
                iCodCandidatoAdmisionTipo.DataBindItems()


                CRecordCAT.cTipo = "O"
                iCodCandidatoAdmisionOrigen.DataSource = CRecordCAT.ListaCatalogoTipoAdmisionPorTipo
                iCodCandidatoAdmisionOrigen.ValueField = "ValueMember"
                iCodCandidatoAdmisionOrigen.TextField = "DisplayMember"
                iCodCandidatoAdmisionOrigen.DataBindItems()

                CRecordCAT = Nothing

                iNivelRiesgo.DataSource = CRecord.ListaNivelRiesgo
                iNivelRiesgo.ValueField = "ValueMember"
                iNivelRiesgo.TextField = "DisplayMember"
                iNivelRiesgo.DataBindItems()

                iNivelRiesgo.Value = 0
                dFechaSolicitud.Value = DateTime.Now



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
#End Region

#Region "FUNCIONES DE GRIDVIEW"
    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        TablaRegistros.DataBind()
    End Sub
    Private Sub TablaRegistros_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistros.DataBinding
        MostrarDatos()
    End Sub
    Protected Sub MostrarDatos()

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then
                Dim dFechaInicio, dFechaFin As Date
                dFechaInicio = F_ObtenerFecha(Date.Now.AddDays(-2))
                dFechaFin = F_ObtenerFecha(Date.Now)
                TablaRegistros.DataSource = CRecord.ListaSolicitudes(dFechaInicio, dFechaFin)
                TablaRegistros.Selection.UnselectAll()
                TablaRegistros.CollapseAll()
                TablaRegistros.FocusedRowIndex = -1
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

#End Region

#Region "FUNCIONES DEL POPUP PRINCIPAL"

#Region "BOTON BUSCAR DNI"
    <WebMethod()>
    Public Shared Function GetRecordPersonaCI(ByVal pNroDoc As String, ByVal pTipoDoc As String) As String

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                Dim CRecordW As New Candidatoinforme
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoInformePorDniYTipoDoc((pNroDoc), (pTipoDoc)), Json.Formatting.None)
                CRecordW = Nothing
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function

    <WebMethod()>
    Public Shared Function GetHabilitadoActualizacion(ByVal pICodCandidatoInforme As String) As String

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                Dim cRecord As New Candidatoadmision
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(cRecord.HabilitadoRegistroActualizacion(pICodCandidatoInforme), Json.Formatting.None)
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function
    <WebMethod()>
    Public Shared Function GetRecordPersonaReniec(ByVal pDoc As String) As String

        Return System.Net.WebUtility.HtmlDecode(WebDNICloud((pDoc), ""))

    End Function

    <WebMethod()>
    Public Shared Function GetRecordAdmision(ByVal pID As String) As String

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                Dim CRecordW As New Candidatoadmision
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoAdmisionPorCodigo(pID), Json.Formatting.None)
                CRecordW = Nothing
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Function
#End Region

#Region "BOTON GUARDAR"
    Private Sub CallBackFunction_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunction.Callback
        Dim cTipoOpe, cRespuesta As String
        cTipoOpe = e.Parameter.ToString
        cRespuesta = ""

        If cTipoOpe = "SIN_EXPE" Then

            CRecord.cEstado = "E"
            CRecord.iResultadoTramite = 0
            CRecord.iCodUsuarioResultado = 0
            CRecord.bImprocedente = CBool(Me.bImprocedente.Checked)
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & cObs.Text & vbCrLf
        End If

        If Me.iCodCandidatoInforme.Text <= 0 Then
            cRespuesta = GuardarRegistroCandidatoNuevo()
            e.Result = cRespuesta + "-" + EnviarCorreo()
        Else
            cRespuesta = GuardarRegistro()
            e.Result = cRespuesta + "-" + EnviarCorreo()
        End If
        cTipoOpe = Nothing

    End Sub
    Function GuardarRegistroCandidatoNuevo() As String
        Dim CRecordCD As New Convocatoriadetalle
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection

            If cResultCon = "OK" Then

                CRecord.mc.miTransact = ConnectSQL.linkSQL.BeginTransaction
                CRecordCI.mc.miTransact = CRecord.mc.miTransact
                ControllerCI()
                CRecordCI.InsertarTransact()
                ControllerSolicitud()

                With CRecord
                    .iCodCandidatoInforme = CRecordCI.iCodCandidatoInforme
                    .bNuevo = CBool(1)
                    .cGuid = "0000"
                    .InsertarTransact()
                End With

                'PARTE DE POSTULACION
                'If CBool(CRecord.bRequierePostulacion) Then
                '    CRecordCD.mc.miTransact = CRecord.mc.miTransact
                '    With CRecordCD
                '        '.iCodConvocatoriaDetalle = Me.iCodConvocatoriaDetalle.EditValue
                '        .iCodConvocatoria = 0 'Me.iCodConvocatoria.Value
                '        .iCodCandidatoInforme = CRecordCI.iCodCandidatoInforme
                '        .iTipoPostulacion = 1 'PREFERENCIAL
                '        .dFechaMintra = F_ObtenerFecha(Me.dFechaSolicitud.Text)
                '        .dFechaLiberadoExceptuado = "1900-01-01"
                '        .iRanking = 10
                '        .dFechaPropuesta = "1900-01-01"
                '        .cObsConsultor = ""
                '        .dFechaCargaCV = "1900-01-01"
                '        .dFechaContactoContrata1 = "1900-01-01"
                '        .dFechaRptaConformidad = "1900-01-01"
                '        .cSeleccionado = ""
                '        .cRptaContrata = ""
                '        .cRptaConformidad = "-"
                '        .dFechaVerificaFeedback = "1900-01-01"
                '        .cFeedbackCorrecto = "-"
                '        .SetEstadoProceso()
                '        .cObs = ""
                '        .bCumplePerfil = 0 'CUMPLEPERFIL
                '        .iCodUsuarioFeedback = 0
                '        .cTipoValidaFeedback = ""
                '        .iCodUsuarioRptaContrata = 0
                '        .dFechaRptaContrata = "1900-01-01"
                '        .iCodUsuario = Decrypt(Session("iCodUsuario"))
                '    End With

                '    CRecordCD.InsertarTransact()
                'End If
                CRecord.mc.miTransact.Commit()
                Return "OK"
            Else
                CRecord.mc.miTransact.Rollback()
                Return "FAIL"
            End If

        Catch ex As Exception
            CRecord.mc.miTransact.Rollback()
            Return "FAIL" 'MsgBox(ex.Message)
        End Try
        CRecordCD = Nothing
    End Function
    Function GuardarRegistro() As String
        Dim CRecordCD As New Convocatoriadetalle

        Try
            CRecord.mc.miTransact = ConnectSQL.linkSQL.BeginTransaction
            CRecordCI.mc.miTransact = CRecord.mc.miTransact
            With CRecordCI
                .iCodCandidatoInforme = Me.iCodCandidatoInforme.Text
                .cFono = Me.cTelefono.Text
                .cCorreo = Me.cCorreo.Text
                .cCUI = Me.cCUI.Text
                .cSexo = Me.cSexo.Value
                .cEstCivil = Me.cEstCivil.Value
                .cUbigeo = Me.cUbigeo.Value
                .cUbigeoResidencia = Me.cUbigeoResidencia.Value

                .UpdateDatosContactoTransact()

            End With
            ControllerSolicitud()
            If iCodCandidatoInforme.Text <= 0 And bCargaBox.Checked = False Then
                CRecord.cEstado = "E"
                CRecord.iResultadoTramite = 0
                CRecord.iCodUsuarioResultado = 0
                CRecord.bImprocedente = CBool(Me.bImprocedente.Checked)
                CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & cObs.Text & vbCrLf
            End If

            With CRecord
                .bNuevo = CBool(0)
                .iCodCandidatoInforme = CRecordCI.iCodCandidatoInforme
                .cGuid = System.Guid.NewGuid.ToString()
                .InsertarTransact()
            End With

            'PARTE DE POSTULACION
            'If CBool(CRecord.bRequierePostulacion) Then
            '    CRecordCD.mc.miTransact = CRecord.mc.miTransact
            '    With CRecordCD
            '        '.iCodConvocatoriaDetalle = Me.iCodConvocatoriaDetalle.EditValue
            '        .iCodConvocatoria = 0 'Me.iCodConvocatoria.Value
            '        .iCodCandidatoInforme = CRecordCI.iCodCandidatoInforme
            '        .iTipoPostulacion = 1 'PREFERENCIAL
            '        .dFechaMintra = F_ObtenerFecha(Me.dFechaSolicitud.Text)
            '        .dFechaLiberadoExceptuado = "1900-01-01"
            '        .iRanking = 10
            '        .dFechaPropuesta = "1900-01-01"
            '        .cObsConsultor = ""
            '        .dFechaCargaCV = "1900-01-01"
            '        .dFechaContactoContrata1 = "1900-01-01"
            '        .dFechaRptaConformidad = "1900-01-01"
            '        .cSeleccionado = ""
            '        .cRptaContrata = ""
            '        .cRptaConformidad = "-"
            '        .dFechaVerificaFeedback = "1900-01-01"
            '        .cFeedbackCorrecto = "-"
            '        .SetEstadoProceso()
            '        .cObs = ""
            '        .bCumplePerfil = 0 'CUMPLEPERFIL

            '        .iCodUsuarioFeedback = 0
            '        .cTipoValidaFeedback = ""

            '        .iCodUsuarioRptaContrata = 0
            '        .dFechaRptaContrata = "1900-01-01"

            '        .iCodUsuario = Decrypt(Session("iCodUsuario"))
            '        '.dFechaSis = Me.dFechaSis.EditValue
            '    End With

            '    CRecordCD.InsertarTransact()
            'End If

            CRecord.mc.miTransact.Commit()
            Return "OK"
        Catch ex As Exception
            CRecord.mc.miTransact.Rollback()
            Return "FAIL" 'MsgBox(ex.Message)
        End Try
        CRecordCD = Nothing
    End Function

    Sub ControllerCI()
        With CRecordCI
            .iCodCandidatoInforme = Me.iCodCandidatoInforme.Text
            .cDNI = Me.cDNI.Text
            .cUbigeo = Me.cUbigeo.Value
            .cApellidos = Me.cApellidos.Text
            .cNombres = Me.cNombres.Text
            .cSexo = Me.cSexo.Value
            .cEstCivil = Me.cEstCivil.Value
            .cFono = Me.cTelefono.Text
            .cCorreo = Me.cCorreo.Text
            .dFechaNac = F_ObtenerFecha(Me.dFechaNac.Text)
            .cCUI = Me.cCUI.Text
            .cDireccion = ""
            .cCondicion = Me.iCodTDCondicionSustento.Text
            .cPuestoEspecialidad = ""
            .cOcupacion = ""
            .cOcupacion2 = ""
            .cEducaSecundaria = ""
            .cEducaTecnica = ""
            .cEducaSuperior = ""
            .cExpLaboral = ""
            .cEmprEx1 = ""
            .cCargoEx1 = ""
            .dFechaIniEx1 = "1900-01-01"
            .dFechaFinEx1 = "1900-01-01"
            .cEmprEx2 = ""
            .cCargoEx2 = ""
            .dFechaIniEx2 = "1900-01-01"
            .dFechaFinEx2 = "1900-01-01"
            .cComunidad = ""
            .cMOCMONC = ""
            .cObservacion = ""
            .cAptitud = "SIN DATOS" 'SIGNIFICA QUE AUN NO TIENE EVALUACION
            .cUbigeoResidencia = Me.cUbigeoResidencia.Value
            .dFechaDisponible = F_ObtenerFecha(Date.Now)
            .cCapacitacion = ""
            .cLicenciaConducir = ""

            .cCertificacion = ""

            .iPAsertividad = 0
            .iPTrabajoEquipo = 0
            .iPComEfectiva = 0
            .iPAdaptabilidad = 0
            .iEEstable = 0
            .iEInestable = 0
            .iCCompromiso = 0
            .iSRptoNorma = 0
            .iSIperC = 0
            .iSActitud = 0
            .dFechaRegistro = F_ObtenerFecha(Date.Now)
            .iCodUsuarioRegistra = Decrypt(Session("iCodUsuario"))
            .dFechaEvaluacion = "1900-01-01"
            .bEvaluado = CBool(0)
            .dFechaVerificativa = "1900-01-01"
            .bVerificativa = CBool(0)
            .iEstadoVerificativa = 1 '1=SANTD BY  2=ENVIADO  3=RESPONDIDO
            .dFechaCargaBox = "1900-01-01"
            .bCargaBox = CBool(0)
            .bDNIMoq = CBool(0)
            .bCasadoMoq = CBool(0)
            .bConviveMoq = CBool(0)
            .bHijosMoq = CBool(0)
            .bRucMoq = CBool(0)
            .bEstudioMoq = CBool(0)
            .bTrabajoMoq = CBool(0)
            .bContratado = CBool(0)
            .bSustentoCV = CBool(0)
            .cTipoDoc = Me.cTipoDoc.Text
            .iTipoIngreso = 1 ' REGULAR MESA DE PARTES
            .cPaisNacimiento = "PERU"


            .iTiempoExperiencia = 0
            .cDNIConyuge = ""
            .cUbigeoConyuge = ""
            .cApellidosConyuge = ""
            .cNombresConyuge = ""
            .cDNIHijo = ""
            .cUbigeoHijo = ""
            .cApellidosHijo = ""
            .cNombresHijo = ""
            .bComunidadConstancia = CBool(0)
            .bComunidadPadron = CBool(0)

            .bCip = CBool(0)
            .bCumplePefil = CBool(1)
            .bDisponible = CBool(1)
            .dFechaEmisionDni = "1900-01-01"
            .cEmpresaTrabaja = ""
            .dFechaEvaluacionResultado = "1900-01-01"
            .iCodPersonaEvalua = 0
            .iResultadoVerificativa = 0

            .bDiscapacitado = CBool(0)
            .bPrioritario = CBool(0)

            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .dFechaSis = GlobalDateNow()

        End With
    End Sub
    Sub ControllerSolicitud()
        With CRecord

            .iCodCandidatoAdmisionTipo = Me.iCodCandidatoAdmisionTipo.Value
            .iCodCandidatoInforme = CRecordCI.iCodCandidatoInforme
            .iCodConvocatoria = 0
            .iCodCandidatoAdmisionOrigen = Me.iCodCandidatoAdmisionOrigen.Value
            .bDocumentoTramite = CBool(Me.bDocumentoTramite.Checked)
            .dFechaSolicitud = F_ObtenerFecha(CDate(Me.dFechaSolicitud.Text))
            .dFechaRegistro = Format(Date.Now, "yyyy-MM-dd")
            .iCodUsuarioRegistro = Decrypt(Session("iCodUsuario"))
            .dFechaEvaluacion = "1900-01-01"
            .bEvaluacion = CBool(0)
            .iCodUsuarioEvaluacion = 0
            .dFechaConsentimiento = "1900-01-01"
            .bConsentimiento = CBool(0)
            .iCodUsuarioConsentimiento = 0
            .dFechaAptitud = "1900-01-01"
            .bAptitud = CBool(0)
            .iCodUsuarioAptitud = 0
            .dFechaCheckList = "1900-01-01"
            .bCheckList = CBool(0)
            .iCodUsuarioCheckList = 0
            .dFechaExpediente = "1900-01-01"
            .bExpediente = CBool(0)
            .iCodUsuarioExpediente = 0
            .cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & cObs.Text & vbCrLf
            .bImprocedente = CBool(Me.bImprocedente.Checked)
            .bRespuesta = CBool(0)
            .iCodUsuarioRespuesta = 0
            .dFechaRespuesta = "1900-01-01"
            .iNivelRiesgo = Me.iNivelRiesgo.Value
            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .dFechaSis = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")

        End With


        CRecord.cEstado = "E"
        CRecord.iResultadoTramite = 0
        CRecord.iCodUsuarioResultado = 0


        If Me.iCodCandidatoAdmisionTipo.Value = 1 Then
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : REGISTRO NUEVO" & vbCrLf & cObs.Text & vbCrLf
        Else
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & cObs.Text & vbCrLf
        End If


        If Me.iCodCandidatoAdmisionTipo.Value = 2 Then
            CRecord.bRequierePostulacion = CBool(1)
        Else
            CRecord.bRequierePostulacion = CBool(0)
        End If

        ' ACTUALIZACION (3) - LOCAL CON EXPEDIENTE
        If Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.Value) = True And
            Me.cBloqueadoRegistroActualizacion.Text <> "SI" And
             iCodTDCondicionSustento.Value <> "FORANEO" Then

            CRecord.bImprocedente = CBool(Me.bImprocedente.Checked)
        End If

        'ANULA COLOCA COMO IMPROCEDENTE UN REGISTRO DE ACTUALIZACION QUE ESTA DENTRO DE FECHA 
        If Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.ValueChecked) = True And
           Me.cBloqueadoRegistroActualizacion.Text = "SI" And
            iCodTDCondicionSustento.Value <> "FORANEO" Then

            CRecord.bImprocedente = CBool(1)
            CRecord.cEstado = "R"
            CRecord.iResultadoTramite = 102 ' no procede DENTRO DE FECHA
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & "SOLICITUD DE ACTUALIZACÓN RECHAZADA - CUENTA CON UNA SOLICITUD EN TRÁMITE." & vbCrLf & cObs.Text & vbCrLf
            CRecord.iCodUsuarioResultado = Decrypt(Session("iCodUsuario"))


        End If
        'ACTUALIZACION (3) - LOCAL SIN EXPEDIENTE
        If Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.Checked) = False And
            iCodTDCondicionSustento.Value <> "FORANEO" Then
            CRecord.bImprocedente = CBool(1)
            CRecord.cEstado = "R"
            CRecord.iResultadoTramite = 103 ' LOCAL SIN EXPEDIENTE
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & "SOLICITUD DE ACTUALIZACÓN RECHAZADA - NO CUENTA CON EXPEDIENTE PARA ACTUALIZAR." & vbCrLf & cObs.Text & vbCrLf
            CRecord.iCodUsuarioResultado = Decrypt(Session("iCodUsuario"))
        End If
        ' ACTUALIZACION (3) - FORANEO NO REGISTRADO
        If Me.iCodCandidatoAdmisionTipo.Value = 3 And
            iCodTDCondicionSustento.Value = "FORANEO" Then
            CRecord.bImprocedente = CBool(1)
            CRecord.cEstado = "R"
            CRecord.iResultadoTramite = 101 ' no procede FORANEO NO LOCAL
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & "SOLICITUD DE ACTUALIZACÓN RECHAZADA - EL SOLICITANTE ESTA REGISTRADO COMO FORANEO." & vbCrLf & cObs.Text & vbCrLf
            CRecord.iCodUsuarioResultado = Decrypt(Session("iCodUsuario"))
        End If

        If CRecord.bBloqueoObservado Then
            CRecord.bImprocedente = CBool(1)
            CRecord.cEstado = "R"
            CRecord.iResultadoTramite = 105 ' no procede PERSONA OBSERVADA
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & "SOLICITUD DE ACTUALIZACÓN RECHAZADA - PERSONA OBSERVADA POR DOCUMENTOS." & vbCrLf & cObs.Text & vbCrLf
            CRecord.iCodUsuarioResultado = Decrypt(Session("iCodUsuario"))
        End If


        If Me.bActualizaDatosContacto.Checked Then
            ' sin acciones
        Else
            ' actualizar datos de contacto
            CRecord.cEstado = "R"
            CRecord.iResultadoTramite = 6 ' actualizar datos de contacto
            CRecord.cObs = Session("cNick") & " [ " & Format(Date.Now, "dd/MM/yyyy HH:mm") & " ] " & " : " & vbCrLf & "SE HA ACTUALIZADO LOS DATOS DE CONTACTO." & vbCrLf
            CRecord.iCodUsuarioResultado = Decrypt(Session("iCodUsuario"))
        End If

    End Sub

    Function EnviarCorreo()
        Dim pTipoEnvio As String = ""
        Dim pHeaderNotificacion As String = ""

        ' REGISTRO NUEVO
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 1 And
            Me.iCodTDCondicionSustento.Value <> "FORANEO" Then
            pTipoEnvio = "MailActividadesRegistro"
            pHeaderNotificacion = "Envío Correo Actividades"

        End If
        ' ACTUALIZACION (3) - LOCAL CON EXPEDIENTE  esta libre
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.Checked) = True And
             Me.cBloqueadoRegistroActualizacion.Text <> "SI" And
           CBool(Me.bActualizaDatosContacto.Checked) = True And
             Me.iCodTDCondicionSustento.Value <> "FORANEO" Then
            pTipoEnvio = "MailActualizacionRegistroLocalConExp"
            pHeaderNotificacion = "Envío Correo Actualización"
        End If

        ' ACTUALIZACION EN TRAMITE 
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.Checked) = True And
           Me.cBloqueadoRegistroActualizacion.Text = "SI" And
           CBool(Me.bActualizaDatosContacto.Checked) = True And
            Me.iCodTDCondicionSustento.Value <> "FORANEO" Then

            pTipoEnvio = "MailActualizacionRegistroEnTramite"
            pHeaderNotificacion = "Correo Actualización en Trámite"
        End If
        'ACTUALIZACION (3) - LOCAL SIN EXPEDIENTE
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 3 And CBool(Me.bCargaBox.Checked) = False And
             Me.iCodTDCondicionSustento.Value <> "FORANEO" Then
            pTipoEnvio = "MailActualizacionRegistroLocalSinExp"
            pHeaderNotificacion = "Correo Actualización Local Sin Exp"
        End If
        ' ACTUALIZACION (3) - FORANEO NO REGISTRADO
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 3 And
             Me.iCodTDCondicionSustento.Value = "FORANEO" Then
            pTipoEnvio = "MailActualizacionRegistroForaneo"
            pHeaderNotificacion = "Correo Actualización Foráneo"
        End If

        ' ACTUALIZACION (4) - ACTUALIZA DATOS 
        If CRecord.iCodCandidatoAdmision > 0 And Me.iCodCandidatoAdmisionTipo.Value = 3 And
            CBool(Me.bActualizaDatosContacto.Checked) = False And
             Me.iCodTDCondicionSustento.Value <> "FORANEO" Then
            pTipoEnvio = "MailActualizacionRegistroDatosContacto"
            pHeaderNotificacion = "Correo Actualización Datos Contacto"
        End If

        If CRecord.bBloqueoObservado Then

            pTipoEnvio = "MailActualizacionRegistroBloqueoObservado"
            pHeaderNotificacion = "Correo Actualización Persona Observada"

        End If


        ''WORKER DE ENVIO    MailActualizacionRegistroLocalConExp
        ''ENVIO DE CORREO
        'If pTipoEnvio <> "" Then
        '    If Not WorkerCorreo.IsBusy Then
        '        WorkerCorreo.RunWorkerAsync()
        '    End If
        'End If

        Return "OK"
    End Function
#End Region


    <WebMethod()>
    Public Shared Function DeleteRecord(ByVal pID As String) As String
        Dim miConexion As New ConnectSQL
        Dim cResultCon As String = ""
        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecord As New Candidatoadmision
                If pID = "" Then
                    Return "FAIL"
                End If
                CRecord.iCodCandidatoAdmision = pID
                CRecord.Eliminar()
                CRecord = Nothing
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

        End Try

    End Function
#End Region

End Class