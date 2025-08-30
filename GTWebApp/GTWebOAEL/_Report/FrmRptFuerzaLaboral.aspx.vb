Imports System.IO
Imports DevExpress.XtraPrinting
'Imports DevExpress.XtraReports
Public Class FrmRptFuerzaLaboral
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        'If Not User.Identity.IsAuthenticated Then
        '    FormsAuthentication.SignOut()
        '    Session.Abandon()
        '    Session.Clear()
        '    Response.Redirect("~\Login.aspx")
        'Else
        '    If Session("Login") Is Nothing Then
        '        Response.Redirect("~\Login.aspx")
        '    Else

        '        If HttpContext.Current.User.IsInRole("ADM") Or
        '            HttpContext.Current.User.IsInRole("AUX") Then


        '        Else
        '            ' No tiene acceso para ver esta vista
        '            Response.Redirect("~/Default.aspx")
        '        End If

        '        CargaContratas()
        '    End If
        'End If




        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx")
        Else
            If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
                If Session("Login") Is Nothing Then
                    Response.Redirect("~/Login.aspx")
                End If

                CargaContratas()
            End If
          

            If HttpContext.Current.User.IsInRole("US") Or
                    HttpContext.Current.User.IsInRole("3") Then

            Else
                ' No tiene acceso para ver esta vista
                Response.Redirect("~/Default.aspx")
            End If


        End If


        'If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
        '    If Session("Login") Is Nothing Then
        '        Response.Redirect("~\Login.aspx")
        '    End If
        '    CargaContratas()
        'Else

        'End If
        'DevExpress.XtraReports .UI.

    End Sub

   
    Sub ExportDocument()
        Using ms As New MemoryStream()

            'Dim r As New XtraReport1()
            Dim r As New RptFormatoPGI
            r.Parameters("iCodAnexoAdmision").Value = 500
            r.RequestParameters = False

            r.CreateDocument()

            'Dim opts As New TextExportOptions
            'opts.TextExportMode = TextExportMode.Text

            'Dim opts As New PdfExportOptions()
            'opts.ShowPrintDialogOnOpen = True

            'Dim opts As New CsvExportOptions

            Dim opts As New HtmlExportOptions
            r.ExportToHtml(ms, opts)

            'Dim opts As New RtfExportOptions
            'r.ExportToRtf(ms, opts)

            'r.ExportToText(ms, opts)
            'r.ExportToPdf(ms, opts)





            'Dim strPath As String = ""
            'r.ExportToCsv(strPath, opts)

            ms.Seek(0, SeekOrigin.Begin)


            Dim report() As Byte = ms.ToArray()

            'Dim report As Byte() = ms.ToArray

            'Dim report2 As Char() = ms.ToString.ToString

            Dim value As String = System.Text.ASCIIEncoding.ASCII.GetString(report)

            'Dim oEmail As New cMail(value, "dan@drmnet.com", "Drm Access Request")
            'oEmail.send()
            'oEmail.dispose()




            Page.Response.ContentType = "application/octet-stream"
            Page.Response.ContentType = "application/pdf"

            Page.Response.Clear()
            Page.Response.OutputStream.Write(report, 0, report.Length)
            Page.Response.End()
        End Using
    End Sub
    Sub CargaContratas()


        Dim CRecordCTO As New Fuerzalaboral

        Dim dtContrata As DataTable






        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                dtContrata = CRecordCTO.ListaContratistasFFLL
                Dim newRow As DataRow = dtContrata.NewRow()
                newRow(0) = "0"
                newRow(1) = "TODAS LAS EECC"
                dtContrata.Rows.InsertAt(newRow, 0)

                iCodContrata.DataSource = dtContrata
                iCodContrata.ValueField = "ValueMember"
                iCodContrata.TextField = "DisplayMember"
                iCodContrata.DataBindItems()





            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception
            'Return ex.Message
        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
            CRecordCTO = Nothing
            dtContrata = Nothing
        End Try
        
    End Sub
    Protected Sub CallBackPanelReport_Callback(sender As Object, e As DevExpress.Web.CallbackEventArgsBase)
        Dim pTipoReport As String = ""
        pTipoReport = e.Parameter.ToString


        Select Case pTipoReport
            Case "HHCC"
                Dim report As New RptFuerzaLaboralHHCCSetting
                ' PARA CONECTAR
                report.SqlDataSource1.ConnectionParameters = getParametrosReporte()
                'SETEO DE PARAMETROS
                'report.Parameters("cTipo").Value = "ACC"
                report.Parameters("iCodContrata").Value = Me.iCodContrata.Value
                report.Parameters("iPeriodo").Value = Me.iPeriodo.Value
                report.Parameters("iMes").Value = Me.iMes.Value

                If CInt(Me.iCodContrata.Value) = 0 Then

                    report.Parameters("cTipo").Value = "AP"
                Else
                    report.Parameters("cTipo").Value = "ACC"
                End If

                '===========================================
                report.RequestParameters = False
                Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer

                WebReportViewer.OpenReport(report)
                report = Nothing
                pt = Nothing
            Case "FFLL"
                Dim report As New RptFuerzaLaboralFFLL
                ' PARA CONECTAR
                report.SqlDataSource1.ConnectionParameters = getParametrosReporte()
                'SETEO DE PARAMETROS
                'MsgBox("solo activos")
                'report.TablaInfo.Visible = False
                report.Parameters("iCodFuerzaLaboral").Value = 0
                report.Parameters("dFechaCeseIni").Value = "1900-01-01"
                report.Parameters("dFechaCeseFin").Value = "1900-01-01"
                report.Parameters("iPeriodo").Value = Me.iPeriodo.Value
                report.Parameters("iMes").Value = Me.iMes.Value
                report.Parameters("iCodContrata").Value = Me.iCodContrata.Value
                report.Parameters("iCodContratistaContrato").Value = 0

                If CInt(Me.iCodContrata.Value) = 0 Then
                    report.TablaInfo.Visible = False
                    report.Parameters("cTipo").Value = "AP"
                Else
                    report.Parameters("cTipo").Value = "AAC"
                End If


                '===========================================
                report.RequestParameters = False
                Dim pt As New DevExpress.XtraReports.Web.ASPxWebDocumentViewer

                WebReportViewer.OpenReport(report)
                report = Nothing
                pt = Nothing
            Case Else
                'WebReportViewer.
        End Select
    End Sub
End Class