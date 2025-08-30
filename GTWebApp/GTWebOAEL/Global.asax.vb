Imports System.Web.SessionState
Imports DevExpress.Web

Public Class Global_asax
    Inherits System.Web.HttpApplication
        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
        ''Sis_iCodContrata = 27 '27 MANPOWER
        'Sis_bBBDDCustom = False 'TRUE=CUSTOM  FALSE=APP
        'EstablecerParametrosGlobales()
        DevExpress.XtraReports.Web.ASPxWebDocumentViewer.StaticInitialize()
End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub


    'Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
    '    routes.MapPageRoute("Index", "Index", "~/Index.aspx")
    'End Sub

End Class