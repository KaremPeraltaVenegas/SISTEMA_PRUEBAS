Imports System.Web.Services

Public Class _Default
    Inherits System.Web.UI.Page
    Public MensajeOAEL As String = ""
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

            End If
        End If





        Dim bMostrarMensaje As Boolean = False


        Dim cResultCon As String = ""
        Dim miConexion As New ConnectSQL

        Try
            cResultCon = miConexion.OpenConnection
            If cResultCon = "OK" Then 'ok

                Dim CRecordUC As New Uconfig2

                CRecordUC.iCodUConfig2 = 9
                CRecordUC.getRecord()

                MensajeOAEL = Trim(CRecordUC.cValue1)
                'If MensajeOAEL <> "" Then
                bMostrarMensaje = False
                'End If

                CRecordUC = Nothing


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



        PopupMensajeOAEL.Windows(0).ShowOnPageLoad = bMostrarMensaje
    End Sub

    <WebMethod()> _
    Public Shared Function GetEmpresaCloud(ByVal pDoc As String) As String ':::: NO MODIFICAR


        'HttpContext.Current.Session["USERID"] == null
        If HttpContext.Current.Session("iCodUsuario") Is Nothing Then
            Return System.Net.WebUtility.HtmlDecode("{""success"":false,""ruc"":"""",""razonsocial"":""""}")
            'Exit Function
        End If
        'CRecordW.iCodUsuario = Decrypt(HttpContext.Current.Session("iCodUsuario"))

        Return System.Net.WebUtility.HtmlDecode(WebRUC((pDoc.ToString.Trim)))


    End Function
    Private Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        MensajeOAEL = Nothing
    End Sub
End Class