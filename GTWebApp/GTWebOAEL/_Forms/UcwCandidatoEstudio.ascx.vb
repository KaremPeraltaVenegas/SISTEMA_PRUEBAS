Public Class UcwCandidatoEstudios
    Inherits System.Web.UI.UserControl
    Public CRecord As New Candidatoestudios
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistrosEstudio.CustomCallback
        TablaRegistrosEstudio.DataBind()
    End Sub
    Private Sub TablaRegistrosEstudio_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistrosEstudio.DataBinding
        MostrarDatos()
    End Sub

    Protected Sub MostrarDatos()

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then
                CRecord.iCodCandidatoInforme = Me.iCodCandidatoInforme.Text
                TablaRegistrosEstudio.DataSource = CRecord.ListaEstudiosPorPersona()
                TablaRegistrosEstudio.Selection.UnselectAll()
                TablaRegistrosEstudio.CollapseAll()
                TablaRegistrosEstudio.FocusedRowIndex = -1
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