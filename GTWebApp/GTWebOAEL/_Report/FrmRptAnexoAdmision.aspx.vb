Imports Newtonsoft
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Security.Application
Imports DevExpress.Web
Imports System.Drawing

Public Class FrmRptAnexoAdmision
    Inherits System.Web.UI.Page
    Public CRecord As New Anexoadmision    '::::: EDITAR
    Public CRecordD As New Anexoadmisiondetalle
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
        '    If Session("Login") Is Nothing Then
        '        Response.Redirect("~\Login.aspx")
        '    End If
        '    CargaCombos()
        'Else

        'End If

        'Inicia() ':::: NO MODIFICAR
        'MostrarDatos() ':::: NO MODIFICAR
        'MostrarDatosDetalle()


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
                If Session("Login") Is Nothing Then
                    'Response.Redirect("~\Login.aspx")
                    Response.Redirect("~/Login.aspx", False)
                    Context.ApplicationInstance.CompleteRequest()
                End If
                If HttpContext.Current.User.IsInRole("3") Then
                    CargaCombos()
                    Inicia()

                Else
                    ' No tiene acceso para ver esta vista
                    Response.Redirect("~/Default.aspx")
                End If

                

            End If


        End If


        MostrarDatos() ':::: NO MODIFICAR
        MostrarDatosDetalle()
    End Sub
    Sub Inicia()

        '::::: INI EDITAR MAIN :::::
        Me.PopupFormMain.Windows.Item(0).HeaderText = "Formulario RDP Anexo 5 - PGI"
        TablaRegistros.KeyFieldName = "iCodAnexoAdmision" '::::: EDITAR
        cFormMetadata.Set("pTable", "FrmRptAnexoAdmision")
        cFormMetadata.Set("pConfigForm", "MainDetalle")
        cFormMetadata.Set("iCodSubContrata", Decrypt(Session("iCodContrata")))
        cFormMetadata.Set("pTablaDetalle", "0")

        '::: SETTINGS DETALLE
        TablaRegistrosDetalle.KeyFieldName = "iCodAnexoAdmisionDetalle" '::::: EDITAR
        cFormMetadata.Set("pTableDetalle", "FrmRptAnexoAdmision")

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
        Dim dFechaIni As Date = Date.Now.AddDays(-80)
        Dim dFechaFin As Date = Date.Now

        'MsgBox(dFechaIni & vbNewLine & dFechaFin)

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                TablaRegistros.DataSource = CRecord.ListaSolicitudesSeguimiento(0, F_ObtenerFecha(dFechaIni), F_ObtenerFecha(dFechaFin), "TF", "")
                'CRecord.ListaSolicitudes(Decrypt(Session("iCodContrata")), "", "", "CT", "")
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
    Protected Sub MostrarDatosDetalle()
        '::::: INI EDITAR MAIN :::::
        If iCodRegistro.Text = "" Then
            CRecordD.iCodAnexoAdmision = 0
        Else
            CRecordD.iCodAnexoAdmision = iCodRegistro.Text ' CRecord.iCodAnexoAdmision
        End If

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                TablaRegistrosDetalle.DataSource = CRecordD.ListaItemsAnexo
                TablaRegistrosDetalle.CollapseAll()
                AjustarTablaRegistrosDetalle()


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

            .Columns(0).Visible = False

            .Columns(1).Caption = "-"
            .Columns(1).Width = 30

            .Columns(2).Caption = "Datos del Postulante"

            .Columns(3).Caption = "T.Doc."
            .Columns(3).Visible = False

            .Columns(4).Caption = "Nro Doc."
            .Columns(4).Width = 75

            .Columns(5).Caption = "ModIngr."
            .Columns(5).CellStyle.Font.Size = 10
            '.Columns(5).Visible = False

            .Columns(6).Caption = "G." 'SEXO
            .Columns(6).Visible = False

            .Columns(7).Caption = "Cargo"
            .Columns(7).CellStyle.Font.Size = 9
            '.Columns(7).Visible = False

            .Columns(8).Caption = "Sub Contrata"
            .Columns(8).Visible = False


            .Columns(9).Caption = "Categoria"
            .Columns(9).Width = 70

            .Columns(10).Caption = "Sustento"
            .Columns(10).Visible = False


            .Columns(11).Caption = "Cond."
            .Columns(11).Width = 75

            .Columns(12).Caption = "Motivo Rechazo"
            .Columns(12).Visible = False

            .Columns(13).Caption = "Obs."
            .Columns(13).Visible = False

            .Columns(14).Caption = "An."
            .Columns(14).Visible = False

            .Columns(15).Visible = False 'NUEVO
            .Columns(16).Visible = False 'ICODCANDIDATOINFORME


            .Columns(17).Caption = "Doc"
            .Columns(17).Width = 35

            .Columns(18).Visible = False 'iCodAnexoAdmision

            '.Columns.
            '.SettingsResizing.ColumnResizeMode = DevExpress.Web.ColumnResizeMode.Control
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
            .iCodAnexoAdmisionTipo = Me.iCodAnexoAdmisionTipo.Value
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





                .dFechaSolicitud = F_ObtenerFecha(Date.Now)
                .iCodUsuarioRegistra = Decrypt(Session("iCodUsuario"))
                .dFechaRegistro = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")

                .iCodUsuarioContrataEnvia = 0
                .dFechaUsuarioContrataEnvia = Format(Date.Now, "yyyy-MM-dd HH:mm:ss")

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
        TablaRegistros.DataBind() ':::: NO MODIFICAR
    End Sub
    ':::::::::::: INICIO NO MODIFICAR ::::::::::::




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
                CRecord.cEstado = "P"
                CRecord.CambiarEstado()


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
        Dim cTipoOpe As String
        cTipoOpe = e.Parameters.ToString
      

        If iCodRegistro.Text = "" Or CInt(iCodRegistro.Text) = 0 Then
            CRecordD.iCodAnexoAdmision = 0
            'TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnAgregarDetalle").Enabled = False
            'TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEditarDetalle").Enabled = False
            'TablaRegistrosDetalle.Toolbars(0).Items.FindByName("BtnEliminarDetalle").Enabled = False
        Else
            CRecordD.iCodAnexoAdmision = iCodRegistro.Text ' CRecord.iCodAnexoAdmision

        End If


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                TablaRegistrosDetalle.DataSource = CRecordD.ListaItemsAnexo

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



        '




       
        TablaRegistrosDetalle.DataBind()
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

        'MsgBox(pTipoReport)

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
                'WebReportViewer.
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
        iCodContratistaContrato.ValueField = "ValueMember"
        iCodContratistaContrato.TextField = "DisplayMember"
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


     

        CRecordTA = Nothing
    End Sub
   
    Sub CargaContratistas()
        Dim CRecordCTO As New Contrata
        'iCodSubContrata.DataSource = CRecordCTO.ListaContratistasAll
        'iCodSubContrata.ValueField = "ValueMember"
        'iCodSubContrata.TextField = "DisplayMember"
        'iCodSubContrata.DataBindItems()

        CRecordCTO = Nothing
    End Sub


    Private Sub FrmAnexoAdmision_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        CRecord = Nothing
        CRecordD = Nothing
    End Sub

    Protected Sub AnexoAdmisionGrupoContratoImg_Init(sender As Object, e As EventArgs)
     


        Dim label = TryCast(sender, ASPxLabel)
        Dim container = TryCast(label.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "cGrupoContrato")))


        If value = "SMI" Then

            label.BackColor = ColorTranslator.FromHtml("#7EA190")
            label.Border.BorderColor = Color.Green
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = " <span><strong>SMI</strong></span>"
            label.Font.Size = 9

        ElseIf value = "AAQ" Then

            label.BackColor = ColorTranslator.FromHtml("#2E6E9B")
            label.Border.BorderColor = ColorTranslator.FromHtml("#2E6E9B")
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = "<span><strong>AAQ</strong></span>"
            label.Font.Size = 9
            'label.Font.Size = FontSize.Smaller
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
End Class