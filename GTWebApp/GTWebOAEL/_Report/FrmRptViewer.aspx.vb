Public Class FrmRptViewer
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Remove("Login")
            Session.RemoveAll()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx")
        Else
            If Session("Login") Is Nothing Then
                Response.Redirect("~/Login.aspx")
            End If

            If HttpContext.Current.User.IsInRole("2") Or
                    HttpContext.Current.User.IsInRole("3") Then

            Else
                ' No tiene acceso para ver esta vista
                Response.Redirect("~/Default.aspx")
            End If


        End If
    End Sub

End Class