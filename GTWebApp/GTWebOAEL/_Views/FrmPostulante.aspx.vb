Imports System.Drawing
Imports System.Web.Services
Imports DevExpress.Web
Imports Newtonsoft
Public Class FrmPostulante
    Inherits System.Web.UI.Page
    Public CRecord As New Candidatoinforme
    Public dFechaBusqueda As Date
    Public cDniBusqueda As String


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
                    If cResultCon = "OK" Then

                        Dim objUsuarioPermiso As New Usuariopermiso
                        If Not objUsuarioPermiso.VerificarTienePermisoPorNombrePagina(p_paginaNombre, p_iCodUsuario) Then
                            Response.Redirect("~/Default.aspx", False)
                            Return
                        Else
                            Inicia()

                            ManipulacionToolBarGrid()
                            If Not IsPostBack Then
                                MostrarDatos()
                            End If

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
        TablaRegistros.KeyFieldName = "iCodCandidatoInforme"
        cFormMetadata.Set("pTable", "FrmPostulante")
        cTipoBusqueda.Text = ""
    End Sub
    Sub ManipulacionToolBarGrid()
        Dim toolbar As GridViewToolbar = TablaRegistros.Toolbars(0)
        For Each item As GridViewToolbarItem In toolbar.Items

            If item.Name = "gvtbMesBusqueda" Then

                Dim dateBox As ASPxDateEdit = CType(item.FindControl("dFechaBusqueda"), ASPxDateEdit)

                If Not IsPostBack Then
                    Dim today As DateTime = DateTime.Now
                    dateBox.Value = today
                    dFechaBusqueda = dateBox.Value
                Else
                    dFechaBusqueda = dateBox.Value
                End If

            ElseIf item.Name = "gvtbDniBusqueda" Then
                Dim textBox As ASPxTextBox = CType(item.FindControl("txtDniBusqueda"), ASPxTextBox)
                cDniBusqueda = If(textBox.Text IsNot Nothing, textBox.Text.Trim(), String.Empty)
            End If
        Next
    End Sub

#End Region

#Region "FUNCIONES DE GRIDVIEW"
    Private Sub TablaRegistros_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridViewCustomCallbackEventArgs) Handles TablaRegistros.CustomCallback
        TablaRegistros.DataBind()
    End Sub
    Private Sub TablaRegistros_DataBinding(sender As Object, e As EventArgs) Handles TablaRegistros.DataBinding

        If Me.cTipoBusqueda.Text = "BusquedaPorDni" Then
            MostrarDatosPorDni()
        Else
            MostrarDatos()
        End If

    End Sub
    Protected Sub MostrarDatos()

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        ManipulacionToolBarGrid()

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then
                CRecord.dFechaBusqueda = dFechaBusqueda
                TablaRegistros.DataSource = CRecord.ListaPostulantesPorMesRegistrado()
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
    Protected Sub MostrarDatosPorDni()

        ManipulacionToolBarGrid()

        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then
                CRecord.cDNI = cDniBusqueda
                TablaRegistros.DataSource = CRecord.ListaPostulantesPorDni()
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

End Class