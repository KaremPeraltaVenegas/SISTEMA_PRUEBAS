Imports System.Drawing
Imports System.Web.Services
Imports DevExpress.Web
Imports Microsoft.Security.Application
Imports Newtonsoft
Public Class FrmContrato
    Inherits System.Web.UI.Page
    Public CRecord As New Contratistacontrato
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 9))

        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx")
        Else
            'If Session("Login") Is Nothing Then
            '    Response.Redirect("~\Login.aspx", False)
            '    Context.ApplicationInstance.CompleteRequest()
            'Else

            '    If Not IsPostBack Then 'SI ES LA PRIMERA CARGA
            '        Inicia()
            '    End If

            '    'MostrarDatos()

            'End If

            If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
                If Session("Login") Is Nothing Or Session("iCodContrata") Is Nothing Then
                    Response.Redirect("~\Login.aspx")
                    Context.ApplicationInstance.CompleteRequest()
                End If

                Inicia()
                TablaRegistros.DataBind()
            Else

            End If
        End If
    End Sub

    Sub Inicia()

        'Me.PopupFormMain.Windows.Item(0).HeaderText = "Formulario :: Gestión del Requerimiento"
        TablaRegistros.KeyFieldName = "iCodContratistaContrato"
        cFormMetadata.Set("pTable", "FrmContrato")

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim objContrata As New Contrata
        Dim objContratistaContrato As New Contratistacontrato
        Dim objOcupacion As New Tdocupacion
        Dim objCatalogo As New Tdcatalogo


        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then
                 
                objCatalogo.cTabla = "ContratistaContrato"
                objCatalogo.cNombreGrupo = "Zona"
                cZona.DataSource = objCatalogo.ListaDatosComboSimplePorTabla()
                cZona.ValueField = "Zona"
                cZona.TextField = "cDisplayMember"
                cZona.DataBindItems()
                 
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Throw New ApplicationException("Error de carga de elementos.")
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
        End Try
    End Sub

    Protected Sub MostrarDatos()
        'MsgBox("Carga DAtos")
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        CRecord.iCodContrata = Decrypt(Session("iCodContrata"))

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                TablaRegistros.DataSource = CRecord.ListaContratosCompletoPorContrata
                'TablaRegistros.CollapseAll()

            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Throw New ApplicationException("Error de carga de elementos.")
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
        End Try
    End Sub
    Private Sub CallBackFunction_Callback(source As Object, e As DevExpress.Web.CallbackEventArgs) Handles CallBackFunction.Callback

        Dim pResult As String
        pResult = GuardarRegistro()
        e.Result = CRecord.iCodContratistaContrato + "-" + pResult
    End Sub
    Function GuardarRegistro() As String

        GuardarRegistro = "FAIL"
        If GuardarRegistro = "FAIL" Then
            Controller()
            If cFormMetadata("cTipoOpe") = "A" Then
                GuardarRegistro = MainInsertar() + "-CR_CONT"
            ElseIf cFormMetadata("cTipoOpe") = "M" Then
                GuardarRegistro = MainUpdate() + "-ED_CONT"
                'ElseIf cFormMetadata("cTipoOpe") = "E" Then
                '    GuardarRegistro = EnviarCED() + "-EN_CED"
            End If
        End If

        Return GuardarRegistro
    End Function

    Sub Controller()
        'If cFormMetadata("cTipoOpe") = "M" Or cFormMetadata("cTipoOpe") = "E" Then
        '    CRecord.iCodContratistaContrato = Encoder.HtmlEncode(iCodRegistro.Text)

        '    Dim cResultCon As String = ""
        '    Dim miConexion As New ConnectSQL

        '    Try
        '        cResultCon = miConexion.OpenConnection
        '        If cResultCon = "OK" Then 'ok

        '            CRecord.getRecord()
        '        Else
        '            Throw New ApplicationException("Error en la conexión con a BBDD.")
        '        End If
        '    Catch ex As Exception
        '        Throw New ApplicationException("Error de carga de elementos.")
        '    Finally
        '        miConexion.CloseConnection()
        '        miConexion = Nothing
        '    End Try

        'End If


        With CRecord
            

            .iCodContratistaContrato = Encoder.HtmlEncode(iCodRegistro.Text)
            .iCodContrata = Decrypt(Session("iCodContrata"))
            .cNroContrato = Encoder.HtmlEncode(cNroContrato.Text)
            .cNomContrato = Encoder.HtmlEncode(cNomContrato.Text)
            .cZona = Encoder.HtmlEncode(cZona.Value)
            .iHeadCount = Encoder.HtmlEncode(iHeadCount.Text)
             
            .dFechaTermino = Encoder.HtmlEncode(dFechaTermino.Value) 'Format(CDate(Me.dFechaTermino.EditValue), "yyyy-MM-dd")
             
            .cAreaUsuaria = Encoder.HtmlEncode(cAreaUsuaria.Text)
            .cAreaUsuariaSupervisor = Encoder.HtmlEncode(cAreaUsuariaSupervisor.Text)
            .cDatosContacto = Encoder.HtmlEncode(cDatosContacto.Text)

            If cFormMetadata("cTipoOpe") = "A" Then
                .dFechaInicio = GlobalDateNow()
                .cTipoFFLL = ""
                .cTipoContrato = ""
                .cGrupoContrato = ""
                .cFase = "OP"
                .iCodClienteArea = -1
                .bCerrado = CBool(0)
                .iCodRubroIntervencion = 0
                .iCodLineaInversion = 0
                .iCodCliente = 1
                .iCodClienteContrato = 1
                .cProvinciaEjecucion = "REGIONAL"
                .iCodGrupoIntervencion = 0
                .cAreaOperacional = ""
                .cTipoValoracionPGS = "P"
                .iMOCForaneo = 0
                .iMOCLocal = 0
                .iMOSCForaneo = 0
                .iMOSCLocal = 0
                .iMONCForaneo = 0
                .iMONCLocal = 0
                .nTasaMOCLocal = 0
                .nTasaMOSCLocal = 0
                .nTasaMONCLocal = 0
                .cAnotaciones = ""


                .iEstado = 5
                .cEstado = "APROBADO"

                '.iEstado = 2
                '.cEstado = "REVISIÓN"

                .iCodUsuarioEstado = Decrypt(Session("iCodUsuario"))
                .dFechaEstado = GlobalDateNow()

                .iCodUsuarioEnvio = Decrypt(Session("iCodUsuario"))
                .dFechaUsuarioEnvio = GlobalDateNow()
                .iCodUsuarioAprueba = 0
                .dFechaUsuarioAprueba = "1900-01-01"
                .iCodUsuarioCreacion = Decrypt(Session("iCodUsuario"))
                .dFechaCreacion = GlobalDateNow()
                .cObs = ""
                .bReporteFFLL = CBool(0)
            ElseIf cFormMetadata("cTipoOpe") = "M" Then

            End If


            .iCodUsuario = Decrypt(Session("iCodUsuario"))
            .dFechaSis = GlobalDateNow()


        End With

    End Sub

    Function MainInsertar() As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                CRecord.Insertar()
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

    Function MainUpdate() As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok
                CRecord.UpdateContrato()
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

    <WebMethod()>
    Public Shared Function GetRecord(ByVal pID As String) As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim JSONString As String
        Dim CRecordW As New Contratistacontrato
        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                JSONString = Newtonsoft.Json.JsonConvert.SerializeObject(CRecordW.GetContratistaContratoPorCodigo(Trim(pID)), Json.Formatting.None)
                Return JSONString
            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Ocurrió un error durante la transacción."
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            CRecordW = Nothing
        End Try
    End Function

    <WebMethod()>
    Public Shared Function AnularRecord(ByVal pID As String) As String
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL
        Dim CRecord As New Contratistacontrato
        Dim cRespuesta As Integer = 0
        Dim cResultadoOperacion As String = ""

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then

                If pID = "" Then
                    Return "FAIL"
                End If
                CRecord.iCodContratistaContrato = CInt(Encoder.HtmlEncode(pID))
                CRecord.dFechaEstado = GlobalDateNow()
                CRecord.iCodUsuarioEstado = Decrypt(HttpContext.Current.Session("iCodUsuario"))
                cRespuesta = CRecord.AnulacionContratistaContrato()

                If cRespuesta = 1 Then
                    cResultadoOperacion = "OK"
                ElseIf cRespuesta = 2 Then
                    cResultadoOperacion = "Ya se encuentra ANULADO el contrato."
                ElseIf cRespuesta = 3 Then
                    cResultadoOperacion = "No se puede anular un contrato APROBADO."
                ElseIf cRespuesta = 0 Then
                    cResultadoOperacion = "No se pudo ANULAR el contrato."
                Else
                    cResultadoOperacion = "FAIL"
                End If

            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            Return "Ocurrió un error durante la transacción."
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            CRecord = Nothing
        End Try
        Return cResultadoOperacion
    End Function

    Protected Sub EstadoCerradoContrato_Init(sender As Object, e As EventArgs)
        Dim image = TryCast(sender, ASPxImage)
        Dim container = TryCast(image.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "bCerrado")))
        Dim url = "~/_GTContent/icons/"

        If value = "True" Then
            url &= "Remove-event-icon24.png"
        Else
            'url &= "Calendar-selection-day-icon24.png"
            url &= "Calendar-blue24.png"
        End If

        image.ImageUrl = url
    End Sub

    Protected Sub EstadoGestionContrato_Init(sender As Object, e As EventArgs)
        Dim image = TryCast(sender, ASPxImage)
        Dim container = TryCast(image.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "iEstado")))
        Dim url = "~/_GTContent/icons/"

        If value = "1" Then
            url &= "16-edit-icon.png"
        ElseIf value = "2" Or value = "6" Then
            url &= "16-five-o-clock-icon.png"
        ElseIf value = "3" Then
            url &= "alert-icon-16.png"
        ElseIf value = "4" Then
            url &= "delete-icon-16.png"
        ElseIf value = "5" Then
            url &= "accept-icon-16.png"
        End If

        image.ImageUrl = url
    End Sub


    Protected Sub EstadoReportarFFLL_Init(sender As Object, e As EventArgs)



        Dim label = TryCast(sender, ASPxLabel)
        Dim container = TryCast(label.NamingContainer, GridViewDataItemTemplateContainer)
        Dim index = container.VisibleIndex
        Dim value = Trim(CStr(container.Grid.GetRowValues(index, "cReporteFFLL")))


        If value = "SI" Then

            label.BackColor = ColorTranslator.FromHtml("#7EA190")
            label.Border.BorderColor = Color.Green
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = " <span><strong>SI</strong></span>"
            label.Font.Size = 9

        ElseIf value = "NO" Then

            label.BackColor = ColorTranslator.FromHtml("#2E6E9B")
            label.Border.BorderColor = ColorTranslator.FromHtml("#2E6E9B")
            label.ForeColor = ColorTranslator.FromHtml("#FFFFFF")
            label.Text = "<span><strong>NO</strong></span>"
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

    Private Sub TablaRegistros_CustomCallback(sender As Object, e As ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        TablaRegistros.DataBind()
    End Sub

    Private Sub TablaRegistros_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistros.DataBinding
        MostrarDatos()
    End Sub
End Class