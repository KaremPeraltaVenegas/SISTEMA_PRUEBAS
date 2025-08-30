Imports Newtonsoft
Imports System.Web
Imports System.Web.UI
Imports System.Web.Services
Imports System.Web.Script.Services
Imports Microsoft.Security.Application
Public Class FrmReporteCliente
    Inherits System.Web.UI.Page
    Public CRecord As New Reportecatalogo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
                    Response.Redirect("~\Login.aspx")
                End If
                CargaCombos()
                Inicia()
            End If
        End If
    End Sub
    Sub Inicia()
        'cFormMetadata.Set("pTable", "FrmReporteCliente")
        dFechaInicio.Date = DateTime.Today
        dFechaFin.Date = DateTime.Today
    End Sub

    Sub CargaCombos()
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordUR As New Usuarioreportecatalogo
                CRecordUR.iCodUsuarioSistema = Decrypt(Session("iCodUsuario"))
                Me.iCodReporteCatalogo.DataSource = CRecordUR.ListaReporteHabilitados
                iCodReporteCatalogo.TextField = "cNombreReporte"
                iCodReporteCatalogo.ValueField = "cQueryReporte"
                iCodReporteCatalogo.DataBindItems()
                CRecordUR = Nothing

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

    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        TablaRegistros.DataBind()
    End Sub

    Private Sub TablaRegistros_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistros.DataBinding
        MostrarDatos()
    End Sub

    Protected Sub MostrarDatos()
        '::::: INI EDITAR MAIN :::::
        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                CRecord.cQueryReporte = iCodReporteCatalogo.Value
                CRecord.dFechaIni = F_ObtenerFecha(dFechaInicio.Text)
                CRecord.dFechaFin = F_ObtenerFecha(dFechaFin.Text)

                TablaRegistros.DataSource = CRecord.EjecutaReporte
                TablaRegistros.CollapseAll()

            Else
                Throw New ApplicationException("Error en la conexión con a BBDD.")
            End If
        Catch ex As Exception

        Finally
            miConexion.CloseConnection()
            miConexion = Nothing
            cResultCon = Nothing
        End Try

        TablaRegistros.Selection.UnselectAll()
        TablaRegistros.FocusedRowIndex = -1
    End Sub
End Class