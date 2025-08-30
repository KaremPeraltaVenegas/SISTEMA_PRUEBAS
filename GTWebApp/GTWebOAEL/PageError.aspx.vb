 
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization

Public Class PageError
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.AddHeader("Refresh", Convert.ToString((Session.Timeout * 60) + 5))

        If Not User.Identity.IsAuthenticated Then
            FormsAuthentication.SignOut()
            Session.Abandon()
            Session.Clear()
            Response.Redirect("~/Login.aspx")
        End If
    End Sub

    
End Class