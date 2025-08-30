Imports DevExpress.DashboardCommon
'Imports GTManpowerWeb.Win_Dashboards
Imports GTWebOAEL.Win_Dashboards
Imports DevExpress.DashboardWeb
Public Class FrmRptDashboardViewer
    Inherits System.Web.UI.Page
    Dim cTipoReporte As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then 'SI NO ES POST BACK QUIERE DECIR ES LA PRIMERA CARGA
        '    If Session("Login") Is Nothing Then
        '        Response.Redirect("~\Login.aspx")
        '    End If
        'Else

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
                    Response.Redirect("~\Login.aspx")
                End If

            End If

            If HttpContext.Current.User.IsInRole("2") Or
                    HttpContext.Current.User.IsInRole("3") Then

            Else
                ' No tiene acceso para ver esta vista
                Response.Redirect("~/Default.aspx")
            End If


        End If

        'ASPxDashboard1.DashboardType.
        cTipoReporte = Request.QueryString("cTipoReporte")
        Select Case cTipoReporte
            Case "FFLLResumen"

                Dim dDashboard As New DashboardFFLL
                ASPxDashboard1.OpenDashboard(dDashboard.SaveToXDocument)

                dDashboard = Nothing
            Case "PGIResumen"

                Dim dDashboard As New DashboardPGIAnexoAdmisionResumen
                ASPxDashboard1.OpenDashboard(dDashboard.SaveToXDocument)

                dDashboard = Nothing

            Case Else


        End Select
    End Sub
    'Private Sub ASPxDashboard1_ConfigureDataConnection(sender As Object, e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs) Handles ASPxDashboard1.ConfigureDataConnection
    '    MsgBox("aqui")
    '    e.ConnectionParameters = getParametrosReporte()
    'End Sub

    Private Sub ASPxDashboard1_ConfigureDataConnection(sender As Object, e As ConfigureDataConnectionWebEventArgs) Handles ASPxDashboard1.ConfigureDataConnection

        e.ConnectionParameters = getParametrosReporte()
    End Sub
End Class