Imports Newtonsoft
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Security.Application
Imports DevExpress.Web
Imports System.Drawing

Public Class FrmAnexoAdmision
    Inherits System.Web.UI.Page
    Public CRecord As New Anexoadmision    '::::: EDITAR
    Public CRecordD As New Anexoadmisiondetalle
    Dim bPrimeraCarga As Boolean = False
    Dim bPrimeraCargaDetalle As Boolean = False
    Dim bCargarDetalleBind As Boolean = False
    Dim bCargaDetalleCB As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx", False)
            Context.ApplicationInstance.CompleteRequest()

        Else
            If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA

                Dim p_paginaNombre As String = "FrmAdmisionWebMain"
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
                            bPrimeraCarga = True
                            CargaCombos()
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

            Else
                bPrimeraCarga = False
            End If

        End If
    End Sub
    Sub Inicia()

        '::::: INI EDITAR MAIN :::::
        Me.PopupFormMain.Windows.Item(0).HeaderText = "Formulario RDP Anexo 5 - PGI"
        TablaRegistros.KeyFieldName = "iCodAnexoAdmision" '::::: EDITAR
        cFormMetadata.Set("pTable", "FrmAnexoAdmision")
        cFormMetadata.Set("pConfigForm", "MainDetalle")
        cFormMetadata.Set("iCodSubContrata", Decrypt(Session("iCodContrata")))
        cFormMetadata.Set("pTablaDetalle", "0")

        '::: SETTINGS DETALLE
        TablaRegistrosDetalle.KeyFieldName = "iCodAnexoAdmisionDetalle" '::::: EDITAR
        cFormMetadata.Set("pTableDetalle", "FrmAnexoAdmision")
        cFormMetadata.Set("pEstado", "000")
        'cFormMetadata.SyncWithServer = True
        'cFormMetadata .
        '::::: FIN EDITAR MAIN :::::

    End Sub
    Sub CargaCombos()

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                CargaContratos()
                'CargaConvocatorias()
                CargaGrupoAnexo()
                CargaTipoAnexoAdmision()
                CargaOcupaciones()
                CargaUbigeos()
                CargaTipoDoc()
                CargaCondicion()
                CargaContratistas()


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
    Protected Sub MostrarDatos()
        '::::: INI EDITAR MAIN :::::
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                'MsgBox("carga main mostrar")
                TablaRegistros.DataSource = CRecord.ListaSolicitudes(Decrypt(Session("iCodContrata")), "", "", "CT", "")
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


        '::::: FIN EDITAR MAIN :::::
    End Sub
    Protected Sub MostrarDatosDetalle(ByVal cTipoOpe As String)
        TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = True
        TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = True
        TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = True

        If iCodRegistro.Text = "" OrElse CInt(iCodRegistro.Text) = 0 Then
            CRecordD.iCodAnexoAdmision = 0
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = False
            Exit Sub
        Else
            CRecordD.iCodAnexoAdmision = iCodRegistro.Text ' CRecord.iCodAnexoAdmision

        End If


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim DTablaDetalle As DataTable
        Dim iCantRegistros As Integer = 0
        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                DTablaDetalle = CRecordD.ListaItemsAnexo
                TablaRegistrosDetalle.DataSource = DTablaDetalle
                iCantRegistros = DTablaDetalle.Rows.Count
                'MsgBox("carga dato anexo")
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            'ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            DTablaDetalle = Nothing
        End Try



        'iCantRegistros = TablaRegistrosDetalle.VisibleRowCount()

        'MsgBox(cFormMetadata("pEstado"))
        'MsgBox("1: " & Me.cEstado.Text & vbCrLf & "2:" & cTipoOpe)

        If cEstado.Text = "C" Or cTipoOpe = "LoadAfterInsert" Then


            If iCantRegistros <= 0 Then

                TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = False
                TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = False
            End If


            If iCantRegistros >= 20 Then

                TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = False
            End If

            If iCantRegistros > 0 And iCantRegistros <= 20 Then

                TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = True
                TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = True
            End If
        Else
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = False
        End If


        If cTipoOpe = "EnvioOAEL" Then
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = False
            TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = False
        End If
        TablaRegistrosDetalle.CollapseAll()
        TablaRegistrosDetalle.Selection.UnselectAll()
        TablaRegistrosDetalle.FocusedRowIndex = -1
        iCantRegistros = Nothing
        'TablaRegistrosDetalle.DataBind()
        'AjustarTablaRegistrosDetalle()
    End Sub


    Sub AjustarTablaRegistros()
        '::::: INI EDITAR MAIN :::::
        With TablaRegistros
            '.Columns(0).Visible = False
            '.Columns(1).Visible = False
            '.Columns(2).Caption = "Nro. Contrato"
            '.Columns(3).Visible = False 'nro anexo
            '.Columns(4).Caption = "Correlativo"
            '.Columns(5).Caption = "Tipo"
            '.Columns(6).Caption = "Motivo"
            '.Columns(7).Caption = "F.Solic."
            '.Columns(8).Visible = False '"F.Reg."
            '.Columns(9).Caption = "F.Etapa"
            '.Columns(10).Caption = "Estado"
            '.Columns(11).Visible = False 'ctipo
        End With
        '::::: FIN EDITAR MAIN :::::

    End Sub
    Sub AjustarTablaRegistrosDetalle()
        '::::: INI EDITAR MAIN :::::
        With TablaRegistrosDetalle

            '.Columns(0).Visible = False

            '.Columns(1).Caption = "-"
            '.Columns(1).Width = 30

            '.Columns(2).Caption = "Datos del Postulante"

            '.Columns(3).Caption = "T.Doc."
            '.Columns(3).Visible = False

            '.Columns(4).Caption = "Nro Doc."
            '.Columns(4).Width = 75

            '.Columns(5).Caption = "ModIngr."
            '.Columns(5).CellStyle.Font.Size = 10
            ''.Columns(5).Visible = False

            '.Columns(6).Caption = "G." 'SEXO
            '.Columns(6).Visible = False

            '.Columns(7).Caption = "Cargo"
            '.Columns(7).CellStyle.Font.Size = 9
            ''.Columns(7).Visible = False

            '.Columns(8).Caption = "Sub Contrata"
            '.Columns(8).Visible = False


            '.Columns(9).Caption = "Categoria"
            '.Columns(9).Width = 70

            '.Columns(10).Caption = "Sustento"
            '.Columns(10).Visible = False


            '.Columns(11).Caption = "Cond."
            '.Columns(11).Width = 75

            '.Columns(12).Caption = "Motivo Rechazo"
            '.Columns(12).Visible = False

            '.Columns(13).Caption = "Obs."
            '.Columns(13).Visible = False

            '.Columns(14).Caption = "An."
            '.Columns(14).Visible = False

            '.Columns(15).Visible = False 'NUEVO
            '.Columns(16).Visible = False 'ICODCANDIDATOINFORME


            '.Columns(17).Caption = "Doc"
            '.Columns(17).Width = 35

            '.Columns(18).Visible = False 'iCodAnexoAdmision

            ''.Columns.
            ''.SettingsResizing.ColumnResizeMode = DevExpress.Web.ColumnResizeMode.Control
        End With
        '::::: FIN EDITAR MAIN :::::

    End Sub
    Sub Controller()
        '::::: INI EDITAR MAIN :::::
        If cFormMetadata("cTipoOpe") = "M" Then
            CRecord.iCodAnexoAdmision = iCodRegistro.Text
            CRecord.getRecord()
        End If

        With CRecord
            .iCodAnexoAdmision = iCodRegistro.Text
            .iCodContrata = Decrypt(Session("iCodContrata"))
            .iCodContratistaContrato = Me.iCodContratistaContrato.Value
            .iCodAnexoAdmisionTipo = 15
            .iCodConvocatoriaMain = 0 ' Me.iCodConvocatoriaMain.Value



            .cNroAnexo = "" '(Me.cNroAnexo.Text)
            .cPersonaSolicita = (Me.cPersonaSolicita.Text)
            .cPersonaSolicitaCargo = (Me.cPersonaSolicitaCargo.Text)
            .cAreaUsuaria = (Me.cAreaUsuaria.Text)


            .iCodSubContrata = 0 'COD DE SUB CONTRATA
            .iCodCliente = 1 'AAQ
            .iCodClienteArea = 0 ' SE CALCULA AUTOMATICO A PARTIR DEL CONTRATO



            .cNotas = (Me.cNotas.Text)

            'If Me.iCodContratistaContrato.Text.ToString.Trim.Substring(0, 3) = "AAQ" Then
            '    .cTipo = "A"
            'Else
            '    .cTipo = "P"
            'End If
            .cTipo = "A" 'TODO SERA ANEXO 05

            .cGrupo = Me.cGrupo.Value
            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .dFechaSis = GlobalDateNow()

            If cFormMetadata("cTipoOpe") = "A" Then ' CAMPOS DE INICIO AL MOMENTO DE INSERTAR

                .cEstado = "C" 'CONTRATISTA PROCESANDO REVISION OBSERVADO APROBADO

                .iCorrelativo = 0 'POR TRIGGER SERA UN CORRELATIVO INTERNO


                .iPeriodo = CInt(Format(CDate(Date.Now), "yyyy"))
                .iCodPersonaGestor = 0





                .dFechaSolicitud = "1900-01-01" 'fecha de solicitud de firma
                .iCodUsuarioRegistra = Decrypt(Session("iCodUsuario"))
                .dFechaRegistro = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")

                .iCodUsuarioContrataEnvia = 0
                .dFechaUsuarioContrataEnvia = "1900-01-01"

                .iCodUsuarioValidaDoc = 0
                .dFechaValidaDoc = "1900-01-01"
                .iCodUsuarioAprueba = 0
                .dFechaAprobacion = "1900-01-01"
                .bAprobadoAAQ = CBool(0)
                .dFechaAprobadoAAQ = "1900-01-01"
                .cNotasAprobadoAAQ = ""

                .iCodUsuarioAprobadoAAQ = 0
                .dFechaUsuarioAprobadoAAQ = "1900-01-01"

                .bNotificado = CBool(0)
                .iCodUsuarioNotifica = 0
                .dFechaNotifica = "1900-01-01"
                .cCorreoNotifica = ""
                .cNotasNotifica = ""

                .bApruebaAreaAAQ = CBool(0)
                .dFechaApruebaAreaAAQ = "1900-01-01"
                .cNotasApruebaAreaAAQ = ""

                .iCodUsuarioApruebaAreaAAQ = 0
                .dFechaUsuarioApruebaAreaAAQ = "1900-01-01"

                .cObsDocumento = ""

                .cTipoObs = ""
                .dFechaObs = "1900-01-01"
                .iCodUsuarioObserva = 0
            Else 'LO QUE NO QUIERO QUE SE MODIFIQUE CUANDO MODIFICO

                .dFechaSolicitud = F_ObtenerFecha(.dFechaSolicitud)
                '.iCodUsuarioRegistra = Decrypt(Session("iCodUsuario"))
                .dFechaRegistro = Format(CDate(.dFechaRegistro), "yyyy-MM-dd HH:mm:ss")
                '.iCodUsuarioValidaDoc = 0

                .dFechaUsuarioContrataEnvia = Format(CDate(.dFechaUsuarioContrataEnvia), "yyyy-MM-dd HH:mm:ss")

                .dFechaValidaDoc = Format(CDate(.dFechaValidaDoc), "yyyy-MM-dd HH:mm:ss")
                '.iCodUsuarioAprueba = 0
                .dFechaAprobacion = Format(CDate(.dFechaAprobacion), "yyyy-MM-dd HH:mm:ss")
                .bAprobadoAAQ = CBool(.bAprobadoAAQ)
                .dFechaAprobadoAAQ = Format(CDate(.dFechaAprobadoAAQ), "yyyy-MM-dd HH:mm:ss")
                '.cNotasAprobadoAAQ = ""
                .bNotificado = CBool(.bNotificado)
                '.iCodUsuarioNotifica = 0
                .dFechaNotifica = Format(CDate(.dFechaNotifica), "yyyy-MM-dd HH:mm:ss")
                '.cCorreoNotifica = ""
                .bApruebaAreaAAQ = CBool(.bApruebaAreaAAQ)
                .dFechaApruebaAreaAAQ = Format(CDate(.dFechaApruebaAreaAAQ), "yyyy-MM-dd HH:mm:ss")


                .dFechaUsuarioAprobadoAAQ = Format(CDate(.dFechaUsuarioAprobadoAAQ), "yyyy-MM-dd HH:mm:ss")

                .dFechaUsuarioApruebaAreaAAQ = Format(CDate(.dFechaUsuarioApruebaAreaAAQ), "yyyy-MM-dd HH:mm:ss")

                .dFechaObs = Format(CDate(.dFechaObs), "yyyy-MM-dd HH:mm:ss")

            End If
        End With
        '::::: FIN EDITAR MAIN :::::
    End Sub
    ':::::::::::: INICIO NO MODIFICAR ::::::::::::
    Function GuardarRegistro() As String ':::: NO MODIFICAR
         
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Controller()

                If cFormMetadata("cTipoOpe") = "A" Then

                    CRecord.Insertar()
                ElseIf cFormMetadata("cTipoOpe") = "M" Then

                    CRecord.Modificar()
                End If


                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try



    End Function
    Private Sub CallBackFunction_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunction.Callback
        Dim pResult As String
        pResult = GuardarRegistro() ':::: NO MODIFICAR

        e.Result = CRecord.iCodAnexoAdmision
    End Sub
    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        'TablaRegistros.DataBind() ':::: NO MODIFICAR
        MostrarDatos()
    End Sub
    ':::::::::::: INICIO NO MODIFICAR ::::::::::::
    Function GuardarRegistroDetalle() As String ':::: NO MODIFICAR

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                If cFormMetadata("cTipoOpeDetalle") = "A" Then
                    HandleGuardarDetalle()
                ElseIf cFormMetadata("cTipoOpeDetalle") = "M" Then
                    ControllerDetalle(Me.iCodCandidatoInforme.Text)
                    CRecordD.Modificar()
                    TablaRegistrosDetalle.JSProperties("cpResultado") = "OK"
                End If


                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try


    End Function
    Sub ControllerDetalle(pCodCandidatoInforme)
        If cFormMetadata("cTipoOpeDetalle") = "M" Then
            CRecordD.iCodAnexoAdmisionDetalle = iCodRegistroDetalle.Text
            CRecordD.getRecord()
        End If

        With CRecordD
            .iCodAnexoAdmisionDetalle = iCodRegistroDetalle.Text
            .iCodAnexoAdmision = iCodRegistro.Text
            .iCodCandidatoInforme = pCodCandidatoInforme
            .iCodAnexoAdmisionTipo = iCodAnexoAdmisionTipoDet.Value
            .cCargo = (Me.cOcupacion.Text)
            .cMOCMONC = (Me.cMOCMONC.Text)
            .iCodSubContrata = Me.iCodSubContrata.Value
            .cNota = (Me.cNota.Text)
            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .dFechaSis = GlobalDateNow()

            .iCodOcupacion = Me.cOcupacion.Value
            .iCodPuesto = 0
             
            'MsgBox(Session("iCodUsuario") & vbNewLine & Decrypt(Session("iCodUsuario")))
            If cFormMetadata("cTipoOpeDetalle") = "A" Then 'LO QUE NO QUIERO QUE SE MODIFIQUE
                .cProcesoEtapa = "P"


                .cObs = ""
                .bAnulado = CBool(0)
                .bNuevo = CBool(0)
                .bPerfilValidar = CBool(0)
                .bPerfilAprobado = CBool(0)
            Else 'LO QUE QUIERO QUE SE MODIFIQUE CUANDO MODIFICO  --- VALORES QUE NO DEBEN CAMBIAR DESDE LA WEB
                .bAnulado = CBool(.bAnulado)
                .bNuevo = CBool(.bNuevo)
                .bPerfilValidar = CBool(.bPerfilValidar)
                .bPerfilAprobado = CBool(.bPerfilAprobado)
            End If

        End With
    End Sub
    Sub ControllerCandidatoInforme(ByVal CRecordCI As Candidatoinforme)
        With CRecordCI
            .iCodCandidatoInforme = 0
            .cTipoDoc = (Me.cTipoDoc.Value)
            .cDNI = (Trim(Me.cDNI.Text))
            .cUbigeo = (Me.cUbigeo.Value)
            .cApellidos = (Me.cApellidos.Text)
            .cNombres = (Me.cNombres.Text)
            .cMOCMONC = (Me.cMOCMONC.Text)
            .cCondicion = (Me.cCondicion.Text)
            .cOcupacion = (Me.cOcupacion.Text)
            .cSexo = ""
            .cEstCivil = ""
            .cFono = ""
            .cCorreo = ""
            .dFechaNac = "1900-01-01"
            .cCUI = ""
            .cDireccion = ""

            .cPuestoEspecialidad = ""

            .cOcupacion2 = ""
            .cEducaSecundaria = ""
            .cEducaTecnica = ""
            .cEducaSuperior = ""
            .cExpLaboral = "NO"
            .cEmprEx1 = ""
            .cCargoEx1 = ""
            .dFechaIniEx1 = "1900-01-01"
            .dFechaFinEx1 = "1900-01-01"
            .cEmprEx2 = ""
            .cCargoEx2 = ""
            .dFechaIniEx2 = "1900-01-01"
            .dFechaFinEx2 = "1900-01-01"
            .cComunidad = ""


            .cUbigeoResidencia = ""

            .cLicenciaConducir = ""
            .cCertificacion = ""

            .dFechaEmisionDni = "1900-01-01"


            .cAptitud = "SIN DATOS" 'SIGNIFICA QUE AUN NO TIENE EVALUACION
            .cCapacitacion = ""
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
            .bVerificativa = CBool(0) '0=SIN RIESGO 1=CON RIESGO
            .iEstadoVerificativa = 0 '1=STAND BY  2=ENVIADO  3=RESPONDIDO
            .dFechaCargaBox = "1900-01-01"
            .bCargaBox = CBool(0)
            .iTipoIngreso = 3 'ADMISION ANEXO 05
            .bContratado = CBool(0)
            '.dFechaContrato = "1900-01-01"
            .dFechaDisponible = F_ObtenerFecha(Date.Now)
            .cObservacion = ""
            .cPaisNacimiento = "PERÚ"

            .bCip = CBool(0)
            .bCumplePefil = CBool(0)
            .bDisponible = CBool(1)
            .cEmpresaTrabaja = ""
            .dFechaEvaluacionResultado = "1900-01-01"
            .iCodPersonaEvalua = 0
            .iResultadoVerificativa = 0



            .bDNIMoq = CBool(0)
            .bCasadoMoq = CBool(0)
            .bConviveMoq = CBool(0)
            .bHijosMoq = CBool(0)
            .bRucMoq = CBool(0)
            .bEstudioMoq = CBool(0)
            .bTrabajoMoq = CBool(0)

            .bSustentoCV = CBool(0)
            '.cTipoDoc =""
            '.dFechaSis = Me.dFechaSis.EditValue

            .cObservacion = ""
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

            .bDiscapacitado = CBool(0)
            .bPrioritario = CBool(0)

            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .iCodUsuarioRegistra = Decrypt(Session("iCodUsuario"))
            .dFechaSis = GlobalDateNow()
        End With
    End Sub
    Public Function HandleGuardarDetalle() As String ':::: NO MODIFICAR
        HandleGuardarDetalle = "FAIL"
        Dim CRecordCI As New Candidatoinforme

        Dim pCodCandidaInforme As String

        ControllerCandidatoInforme(CRecordCI)

        CRecordD.mc.miTransact = ConnectSQL.linkSQL.BeginTransaction
        Try
            CRecordCI.mc.miTransact = CRecordD.mc.miTransact

            If Me.iCodCandidatoInforme.Text = "" OrElse CInt(Me.iCodCandidatoInforme.Text) <= 0 Then

                CRecordCI.InsertarTransact()
                pCodCandidaInforme = CRecordCI.iCodCandidatoInforme


            Else

                pCodCandidaInforme = Me.iCodCandidatoInforme.Text
                CRecordCI.cUbigeo = (Me.cUbigeo.Value)
                CRecordCI.iCodCandidatoInforme = pCodCandidaInforme
                CRecordCI.UpdateUbigeoTransact()

            End If

            ControllerDetalle(pCodCandidaInforme)

            CRecordD.InsertarTransact()

            CRecordD.mc.miTransact.Commit()
            TablaRegistrosDetalle.JSProperties("cpResultado") = "OK"
            HandleGuardarDetalle = "OK"
        Catch ex As Exception
            'MsgBox(ex.Message)
            CRecordD.mc.miTransact.Rollback()
            TablaRegistrosDetalle.JSProperties("cpResultado") = "FAIL"
            HandleGuardarDetalle = "FAIL"
        End Try

        CRecordCI = Nothing
        Return HandleGuardarDetalle
    End Function

    Private Sub CallBackFunctionDetalle_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunctionDetalle.Callback

        e.Result = GuardarRegistroDetalle()

    End Sub

    Private Sub CallBackFunctionEnvio_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunctionEnvio.Callback
        'Try

        '    CRecord.iCodAnexoAdmision = iCodRegistro.Text
        '    CRecord.cEstado = "P"
        '    CRecord.CambiarEstado()
        '    e.Result = "OK"

        'Catch ex As Exception
        '    e.Result = "FAIL"

        'End Try

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                CRecord.iCodAnexoAdmision = iCodRegistro.Text
                CRecord.iCodUsuarioContrataEnvia = Decrypt(Session("iCodUsuario"))
                CRecord.dFechaUsuarioContrataEnvia = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")
                CRecord.cEstado = "P"
                CRecord.EnviarOAEL()


                e.Result = "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            e.Result = "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try



    End Sub
    Private Sub TablaRegistrosDetalle_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistrosDetalle.CustomCallback
        'If bPrimeraCargaDetalle = True Then
        '    bPrimeraCargaDetalle = False
        'End If

        Dim cTipoOpe As String
        cTipoOpe = e.Parameters.ToString
        If cTipoOpe = "LoadPrimera" Then
            bPrimeraCargaDetalle = True
        Else
            bPrimeraCargaDetalle = False
        End If
        bCargaDetalleCB = True
        'MsgBox("carga detalle Callback")
        MostrarDatosDetalle(cTipoOpe)

        'TablaRegistrosDetalle.DataBind()
    End Sub
    'Protected Sub BtnImprimirFormatoPGI_Click(sender As Object, e As EventArgs)
    '    'MsgBox("abc")
    '    Dim report As New RptFormatoPGI
    '    ' PARA CONECTAR
    '    report.SqlDataSource1.ConnectionParameters = getParametrosReporte()
    '    'SETEO DE PARAMETROS

    '    report.Parameters("iCodAnexoAdmision").Value = Me.iCodRegistro.Text

    '    '===========================================
    '    report.RequestParameters = False
    '    Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer
    '    'DESHABILITAR PANEL DE PARAMETROS
    '    'pt.AutoShowParametersPanel = False
    '    ''MOSTRAR REPORTE
    '    'pt.ShowPreviewDialog()
    '    'WebReportViewer .
    '    'WebReportViewer.
    '    'WebReportViewer.SettingsClientSideModel.
    '    WebReportViewer.OpenReport(report)
    'End Sub
    Protected Sub CallBackPanelReport_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase)
        Dim pTipoReport As String = ""
        Dim pFirma As String = ""
        pTipoReport = e.Parameter.ToString
         pTipoReport = Me.iCodContratistaContrato.Text.Substring(0, 3)

 
        Select Case pTipoReport
            Case "SMI" 'PGI
                pFirma = "FIRMA SMI - FLUOR"
                'Dim report As New RptFormatoPGI

                'report.SqlDataSource1.ConnectionParameters = getParametrosReporte()

                'report.Parameters("iCodAnexoAdmision").Value = Me.iCodRegistro.Text
                ''===========================================
                'report.RequestParameters = False
                'Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer
                'WebReportViewer.OpenReport(report)

                'pt = Nothing
                'report = Nothing
            Case "AAQ" ' A05
                pFirma = "FIRMA ÁREA USUARIA AAQ"
                'Dim report As New RptFormatoA5

                'report.SqlDataSource1.ConnectionParameters = getParametrosReporte()

                'report.Parameters("iCodAnexoAdmision").Value = Me.iCodRegistro.Text
                ''===========================================
                'report.RequestParameters = False
                'Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer
                'WebReportViewer.OpenReport(report)

                'pt = Nothing
                'report = Nothing

            Case Else
                pFirma = "FIRMA ÁREA USUARIA AAQ"
        End Select




        Dim report As New RptFormatoA5

        report.SqlDataSource1.ConnectionParameters = getParametrosReporte()

        report.Parameters("iCodAnexoAdmision").Value = Me.iCodRegistro.Text
        report.LblFirmaUsuario.Text = pFirma

 
        'report.DisplayName =
        '===========================================
        report.RequestParameters = False
        Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer
        WebReportViewer.OpenReport(report)

        pt = Nothing
        report = Nothing

        pTipoReport = Nothing
        pFirma = Nothing
    End Sub
    '*********************** INI SECCION DE CONTROLADOR ***********************
    <WebMethod()> _
    Public Shared Function GetRecord(ByVal pID As String) As String ':::: NO MODIFICAR
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Anexoadmision '::::: EDITAR
                CRecordW.iCodAnexoAdmision = pID
                CRecordW.getRecord()
                'cFormMetadata.Set("pEstado", CRecordW.cEstado)
                Dim strJSON As String
                strJSON = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW)
                CRecordW = Nothing



                Return strJSON

            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try




    End Function
    <WebMethod()> _
    Public Shared Function DeleteRecord(ByVal pID As String) As String ':::: NO MODIFICAR
        'Try
        '    Dim CRecordW As New Anexoadmision '::::: EDITAR
        '    If pID = "" Then
        '        Return "FAIL"
        '    End If

        '    CRecordW.iCodAnexoAdmision = pID
        '    CRecordW.Eliminar()
        '    CRecordW = Nothing



        '    Return "OK"
        'Catch ex As Exception
        '    Return "FAIL"
        'End Try
        Dim CRecordW As New Anexoadmision '::::: EDITAR
        Dim CRecordAD As New Anexoadmisiondetalle

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok


                If pID = "" Then
                    Return "FAIL"
                End If

                CRecordW.iCodAnexoAdmision = pID
                CRecordW.iCodUsuario = Decrypt(HttpContext.Current.Session("iCodUsuario"))
                CRecordW.Anular()



                CRecordAD.iCodAnexoAdmision = pID
                CRecordAD.iCodUsuario = CRecordW.iCodUsuario
                CRecordAD.AnularLista()



                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordW = Nothing
            CRecordW = Nothing
        End Try



    End Function
    '+++++++++++++++++++++++ INI METODOS WEB CUSTOM +++++++++++++++++++++++
    ' Aqui puede añadir las Web Methods personalizadas

    <WebMethod()> _
    Public Shared Function GetRecordDetalle(ByVal pID As String) As String ':::: NO MODIFICAR



        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Anexoadmisiondetalle '::::: EDITAR
                Dim JSONString As String = String.Empty
                CRecordW.iCodAnexoAdmisionDetalle = pID
                'CRecordW.GetRecordDetalleCI()
                'CRecordW.
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetRecordDetalleCI, Json.Formatting.None)
                CRecordW = Nothing



                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try


    End Function
    <WebMethod()> _
    Public Shared Function DeleteRecordDetalle(ByVal pID As String) As String ':::: NO MODIFICAR



        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Anexoadmisiondetalle '::::: EDITAR
                If pID = "" Then
                    Return "FAIL"
                End If

                CRecordW.iCodAnexoAdmisionDetalle = pID
                CRecordW.Eliminar()
                CRecordW = Nothing


                Return "OK"
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try





    End Function
    '+++++++++++++++++++++++ INI METODOS WEB CUSTOM +++++++++++++++++++++++
    <WebMethod()> _
    Public Shared Function GetRecordPersona(ByVal pDoc As String, ByVal pTipo As String) As String ':::: NO MODIFICAR
        'Dim CRecordW As New Candidatoinforme '::::: EDITAR
        'Dim JSONString As String = String.Empty
        'JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoByDNIStat(pDoc, pTipo), Json.Formatting.None)
        'CRecordW = Nothing
        'Return JSONString
        'GetCandidatoByDNIStatFL()



        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Candidatoinforme '::::: EDITAR
                Dim JSONString As String = String.Empty
                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetCandidatoByDNIStatFL(pDoc, pTipo), Json.Formatting.None)
                CRecordW = Nothing




                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "FAIL"
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

    Sub CargaGrupoAnexo()

        'cGrupo.DataSource = CRecord.ListaGrupoAnexo

        cGrupo.DataSource = CRecord.ListaGrupoAnexo
        cGrupo.ValueField = "ValueMember"
        cGrupo.TextField = "DisplayMember"
        cGrupo.DataBindItems()
    End Sub
    Sub CargaContratos()
        Dim CRecordCTO As New Contratistacontrato
        CRecordCTO.iCodContrata = Decrypt(Session("iCodContrata"))
        iCodContratistaContrato.DataSource = CRecordCTO.ListaContratos
        iCodContratistaContrato.ValueField = "iCodContratistaContrato"
        iCodContratistaContrato.TextField = "cContrato"
        iCodContratistaContrato.DataBindItems()

        CRecordCTO = Nothing
    End Sub
    Sub CargaConvocatorias()
        'Dim CRecordCONV As New Convocatoriamain
        'CRecordCONV.iCodContratistaContrato = Me.iCodContratistaContrato.Value
        'iCodConvocatoriaMain.DataSource = CRecordCONV.ListaConvocatorias
        'iCodConvocatoriaMain.ValueField = "ValueMember"
        'iCodConvocatoriaMain.TextField = "DisplayMember"
        'iCodConvocatoriaMain.DataBindItems()


        'CRecordCONV = Nothing
    End Sub

    Sub CargaTipoAnexoAdmision()
        Dim CRecordTA As New Anexoadmisiontipo

        iCodAnexoAdmisionTipo.DataSource = CRecordTA.ListaItems
        iCodAnexoAdmisionTipo.ValueField = "ValueMember"
        iCodAnexoAdmisionTipo.TextField = "DisplayMember"
        iCodAnexoAdmisionTipo.DataBindItems()


        iCodAnexoAdmisionTipoDet.DataSource = iCodAnexoAdmisionTipo.DataSource
        iCodAnexoAdmisionTipoDet.ValueField = "ValueMember"
        iCodAnexoAdmisionTipoDet.TextField = "DisplayMember"
        iCodAnexoAdmisionTipoDet.DataBindItems()

        CRecordTA = Nothing
    End Sub

    Sub CargaOcupaciones()
        Dim CRecordTO As New Tdocupacion

        cOcupacion.DataSource = CRecordTO.ListaOcupacionesAllField
        cOcupacion.ValueField = "iCodOcupacion"
        cOcupacion.TextField = "cNomOcupacion"
        cOcupacion.DataBindItems()

        CRecordTO = Nothing
    End Sub

    Sub CargaUbigeos()
        Dim CRecordCI As New Candidatoinforme

        cUbigeo.DataSource = CRecordCI.ListaTDUbigeos
        cUbigeo.ValueField = "ValueMember"
        cUbigeo.TextField = "DisplayMember"
        cUbigeo.DataBindItems()
        CRecordCI = Nothing
    End Sub
    Sub CargaTipoDoc()
        Dim CRecordCI As New Candidatoinforme

        cTipoDoc.DataSource = CRecordCI.TDTipoDocumento
        cTipoDoc.ValueField = "ValueMember"
        cTipoDoc.TextField = "DisplayMember"
        cTipoDoc.DataBindItems()
        cTipoDoc.SelectedIndex = 0
        CRecordCI = Nothing
    End Sub
    Sub CargaCondicion()
        Dim CRecordCI As New Candidatoinforme

        cCondicion.DataSource = CRecordCI.ListaCondicionWeb
        cCondicion.ValueField = "ValueMember"
        cCondicion.TextField = "DisplayMember"
        cCondicion.DataBindItems()

        CRecordCI = Nothing
    End Sub
    Sub CargaContratistas()
        Dim CRecordCTO As New Contrata
        iCodSubContrata.DataSource = CRecordCTO.ListaContratistasAll
        iCodSubContrata.ValueField = "ValueMember"
        iCodSubContrata.TextField = "DisplayMember"
        iCodSubContrata.DataBindItems()

        CRecordCTO = Nothing
    End Sub


    Private Sub FrmAnexoAdmision_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        CRecord = Nothing
        CRecordD = Nothing
        bCargaDetalleCB = Nothing
        bCargarDetalleBind = Nothing
        bPrimeraCarga = Nothing
        bPrimeraCargaDetalle = Nothing
    End Sub

    Protected Sub AnexoAdmisionGrupoContratoImg_Init(sender As Object, e As EventArgs)
        'Dim image = TryCast(sender, ASPxImage)
        'Dim container = TryCast(image.NamingContainer, GridViewDataItemTemplateContainer)
        'Dim index = container.VisibleIndex
        'Dim value = CStr(Math.Truncate(container.Grid.GetRowValues(index, "cTipo")))
        'Dim url = "~/_GTContent/icons/"

        'If value = "A" Then

        '    url &= "sign-warning-icon.png"

        'Else

        '    url &= "sign-check-icon.png"

        'End If

        'image.ImageUrl = url


        Dim label = TryCast(sender, ASPxLabel)
        Dim container = TryCast(label.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "cGrupoContrato")))


        If value = "SMI" Then

            label.BackColor = ColorTranslator.FromHtml("#7EA190")
            label.Border.BorderColor = Color.Green
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = " <span><strong>SMI</strong></span>"

        ElseIf value = "AAQ" Then

            label.BackColor = ColorTranslator.FromHtml("#2E6E9B")
            label.Border.BorderColor = ColorTranslator.FromHtml("#2E6E9B")
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = "<span><strong>AAQ</strong></span>"

        End If


        'If value = "1" Then 'PROCESO
        '    label.BackColor = ColorTranslator.FromHtml("#7EA190")
        '    label.Border.BorderColor = Color.Green
        '    label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        '    label.Text = " <span><strong>EP</strong></span>"

        'ElseIf value = "2" Then 'STAND BY
        '    label.BackColor = ColorTranslator.FromHtml("#E77C22")
        '    label.Border.BorderColor = ColorTranslator.FromHtml("#E77C22")
        '    label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        '    label.Text = "<span><strong>ST</strong></span>"

        'ElseIf value = "3" Then 'CANCELADO
        '    label.BackColor = ColorTranslator.FromHtml("#C8504F")
        '    label.Border.BorderColor = ColorTranslator.FromHtml("#C8504F")
        '    label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        '    label.Text = "<span><strong>CA</strong></span>"

        'ElseIf value = "4" Then 'CERRADO
        '    label.BackColor = ColorTranslator.FromHtml("#2E6E9B")
        '    label.Border.BorderColor = ColorTranslator.FromHtml("#2E6E9B")
        '    label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
        '    label.Text = " <span><strong>CE</strong></span>"
        'End If

    End Sub

    Protected Sub PGIStatus_Init(sender As Object, e As EventArgs)
        Dim image = TryCast(sender, ASPxImage)
        Dim container = TryCast(image.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "cEstado")))
        Dim url = "~/_GTContent/icons/"

        If value = "C" Then
            url &= "16-edit-icon.png"
        ElseIf value = "P" Then
            url &= "16-five-o-clock-icon.png"
        ElseIf value = "R" Then
            url &= "16-five-o-clock-icon.png"
        ElseIf value = "F" Then
            url &= "accept-icon-16.png"
        ElseIf value = "O" Then
            url &= "alert-icon-16.png"
        ElseIf value = "A" Then
            url &= "delete-icon-16.png"
        End If

        image.ImageUrl = url
    End Sub

    Private Sub TablaRegistrosDetalle_CustomColumnDisplayText(sender As Object, e As ASPxGridViewColumnDisplayTextEventArgs) Handles TablaRegistrosDetalle.CustomColumnDisplayText
        'Dim miGrid=DirectCast(sender as aspxgridview) 
        'asdasd()

        'If e.Column.FieldName = "CLI" Then
        '    If e.VisibleIndex > 3 Then

        '    End If
        'End If

        If (e.Column.FieldName = "cProcesoEtapa") Then
            Dim miProcesoActual As String = e.Value
            'Dim anotherColumnValue As String = e.GetFieldValue("property2")
            'e.DisplayText = currentColumnValue & " " & anotherColumnValue
            If miProcesoActual = "O" Then
                e.DisplayText = "<a href='#' onclick='OnMoreInfoClick(this, " & e.GetFieldValue("iCodAnexoAdmisionDetalle") & ")'><b>O</b></a>"
            End If
            'e.DisplayText = "<a href='javascript:void(0);' onclick='OnMoreInfoClick(this, '" & e.GetFieldValue("iCodAnexoAdmisionDetalle") & "')'>O</a>"

        End If
    End Sub

    Protected Sub CallbackPanelObs_Callback(sender As Object, e As CallbackEventArgsBase)
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordW As New Anexoadmisiondetalle '::::: EDITAR
                Dim JSONString As String = String.Empty
                CRecordW.iCodAnexoAdmisionDetalle = e.Parameter.ToString
                CRecordW.getRecordObs()
                litText.Text = CRecordW.cObs
                CRecordW = Nothing




            Else
                 litText.Text = "Error de Carga, intente de nuevo. Verifique su conexión a internet"
            End If
        Catch ex As Exception
            litText.Text = "Error de Carga, intente de nuevo."
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try
    End Sub

    Private Sub TablaRegistrosDetalle_CustomUnboundColumnData(sender As Object, e As ASPxGridViewColumnDataEventArgs) Handles TablaRegistrosDetalle.CustomUnboundColumnData

    End Sub

    Private Sub TablaRegistrosDetalle_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistrosDetalle.DataBinding

        'If bPrimeraCarga = True Then
        '    Exit Sub
        'End If
        'Dim cResultCon As String = ""
        'Dim miConexion As New ConnectSQL

        'Try
        '    cResultCon = miConexion.OpenConnection
        '    If cResultCon = "OK" Then 'ok
        '        MsgBox("carga detalle bind")
        '        TablaRegistrosDetalle.DataSource = CRecordD.ListaItemsAnexo
        '        'TablaRegistrosDetalle.CollapseAll()
        '        'AjustarTablaRegistrosDetalle()
        '    Else
        '        Throw New ApplicationException("Error en la conexión con a BBDD.")
        '    End If
        'Catch ex As Exception
        '    'ex.Message
        'Finally
        '    miConexion.CloseConnection()
        '    miConexion = Nothing
        '    cResultCon = Nothing
        'End Try
        If bPrimeraCargaDetalle = True Then
            Exit Sub
        End If

        If bCargaDetalleCB = True Then
            Exit Sub
        End If

        MostrarDatosDetalle("CargaBind")
    End Sub

    Private Sub TablaRegistros_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistros.DataBinding
        If bPrimeraCarga = True Then
            Exit Sub
        End If
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                'MsgBox("carga main bind")
                TablaRegistros.DataSource = CRecord.ListaSolicitudes(Decrypt(Session("iCodContrata")), "", "", "CT", "")
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
End Class