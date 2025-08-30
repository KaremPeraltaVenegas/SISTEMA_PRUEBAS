Imports System.Web.Services
Imports Newtonsoft

Public Class UcwCandidatoinforme
    Inherits System.Web.UI.UserControl
    Public UCRecord As New Candidatoinforme

#Region "FUNCIONES DE CARGADO DE PAGINA"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
            IniciaForm()
        Else

        End If
    End Sub
    Sub IniciaForm()

        cFormMetadataPostulante.Set("pTablePostulante", "UcwPostulante")
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

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

                CRecordCI = Nothing

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

#Region "BOTON GUARDAR  INSERSION Y UPDATE"
    Private Sub CallBackFunctionPostulante_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunctionPostulante.Callback

        Dim pResult As String = "FAIL"
        If e.Parameter = "GuardarRegistro" Then
            pResult = GuardarRegistro()
        ElseIf e.Parameter = "Otros" Then
            pResult = "FAIL"
        End If

        e.Result = pResult

    End Sub
    Function GuardarRegistro() As String
        GuardarRegistro = "FAIL"
        Controller()
        If Me.cTipoOpePostulante.Text = "A" Then

            If Me.iCodCandidatoInforme.Text <= 0 Then
                GuardarRegistro = GuardarRegistroCandidatoNuevo() + "-ADD_REG"
            Else
                GuardarRegistro = "EXISTE-ADD_REG"
            End If

        ElseIf Me.cTipoOpePostulante.Text = "M" Then
            GuardarRegistro = GuardarRegistroExistente() + "-UPD_REG"
        End If

        Return GuardarRegistro
    End Function
    Function GuardarRegistroCandidatoNuevo() As String
        Dim CRecordCD As New Convocatoriadetalle
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection

            If cResultCon = "OK" Then
                Controller()
                UCRecord.Insertar()
                Return "OK"
            Else
                Return "FAIL"
            End If

        Catch ex As Exception
            Return "FAIL" 'MsgBox(ex.Message)
        End Try
        CRecordCD = Nothing
    End Function
    Function GuardarRegistroExistente() As String

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                UCRecord.Modificar()
                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Ocurrió un error durante la transacción."
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
        End Try
    End Function
    Sub Controller()

        If Me.cTipoOpePostulante.Text = "M" Then
            UCRecord.iCodCandidatoInforme = iCodRegistroPostulante.Text

            Dim cResultCon As String = ""
            Dim miConexion As New ConnectSQL

            Try
                cResultCon = miConexion.OpenConnection
                If cResultCon = "OK" Then 'ok
                    UCRecord.getRecord()
                Else
                    Throw New ApplicationException("Error en la conexión con a BBDD.")
                End If
            Catch ex As Exception
                Throw New ApplicationException("Error de carga de elementos.")
            Finally
                miConexion.CloseConnection()
                miConexion = Nothing
            End Try

        End If

        If Me.cTipoOpePostulante.Text = "A" Then
            With UCRecord
                .iCodCandidatoInforme = Me.iCodCandidatoInforme.Text
                .cTipoDoc = Me.cTipoDoc.Text
                .cDNI = Me.cDNI.Text
                .cCUI = Me.cCUI.Text
                .cApellidos = Me.cApellidos.Text
                .cNombres = Me.cNombres.Text
                .cSexo = Me.cSexo.Value
                .dFechaNac = F_ObtenerFecha(Me.dFechaNac.Text)
                .cUbigeo = Me.cUbigeo.Value
                .cUbigeoResidencia = Me.cUbigeoResidencia.Value
                .cEstCivil = Me.cEstCivil.Value
                .cFono = Me.cTelefono.Text
                .cCorreo = Me.cCorreo.Text
                .cDireccion = Me.cDireccion.Text
                .bCargaBox = 0
                .bSustentoCV = CBool(Me.bSustentoCV.Checked)
                .bCumplePefil = CBool(Me.bCumplePefil.Checked)
                .cLicenciaConducir = Me.cLicenciaConducir.Text
                .cObservacion = Me.cObservacion.Text
                .bDiscapacitado = CBool(Me.bDiscapacitado.Checked)
                .bPrioritario = CBool(Me.bPrioritario.Checked)
                .iCodUsuario = Decrypt(Session("iCodUsuario"))
                .dFechaSis = GlobalDateNow()
                .cCondicion = 0
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
                .dFechaDisponible = F_ObtenerFecha(Date.Now)
                .cCapacitacion = ""
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
                .bDNIMoq = CBool(0)
                .bCasadoMoq = CBool(0)
                .bConviveMoq = CBool(0)
                .bHijosMoq = CBool(0)
                .bRucMoq = CBool(0)
                .bEstudioMoq = CBool(0)
                .bTrabajoMoq = CBool(0)
                .bContratado = CBool(0)
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
                .bDisponible = CBool(1)
                .dFechaEmisionDni = "1900-01-01"
                .cEmpresaTrabaja = ""
                .dFechaEvaluacionResultado = "1900-01-01"
                .iCodPersonaEvalua = 0
                .iResultadoVerificativa = 0

                .iCodUsuario = Decrypt(Session("iCodUsuario"))
                .dFechaSis = GlobalDateNow()

            End With
        ElseIf Me.cTipoOpePostulante.Text = "M" Then

            With UCRecord
                .iCodCandidatoInforme = Me.iCodCandidatoInforme.Text
                .cApellidos = Me.cApellidos.Text
                .cNombres = Me.cNombres.Text
                .cSexo = Me.cSexo.Value
                .dFechaNac = F_ObtenerFecha(Me.dFechaNac.Text)
                .cUbigeo = Me.cUbigeo.Value
                .cUbigeoResidencia = Me.cUbigeoResidencia.Value
                .cEstCivil = Me.cEstCivil.Value
                .cFono = Me.cTelefono.Text
                .cCorreo = Me.cCorreo.Text
                .cDireccion = Me.cDireccion.Text
                .bSustentoCV = CBool(Me.bSustentoCV.Checked)
                .bCumplePefil = CBool(Me.bCumplePefil.Checked)
                .cLicenciaConducir = Me.cLicenciaConducir.Text
                .cObservacion = Me.cObservacion.Text
                .bDiscapacitado = CBool(Me.bDiscapacitado.Checked)
                .bPrioritario = CBool(Me.bPrioritario.Checked)
                .iCodUsuario = Decrypt(Session("iCodUsuario"))
                .dFechaSis = GlobalDateNow()
            End With
        End If

    End Sub

#End Region

End Class