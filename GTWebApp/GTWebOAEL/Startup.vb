Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin
Imports Microsoft.Owin.Security.Cookies
Imports Owin

<Assembly: OwinStartup(GetType(GTWebOAEL.Startup))> 
Public Class Startup
    Public Sub Configuration(ByVal app As IAppBuilder)
        app.UseCookieAuthentication(New CookieAuthenticationOptions With {
            .AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
            .LoginPath = New PathString("/Login.aspx")
        })
        'app.Run(Function(context)
        '            Dim t As String = DateTime.Now.Millisecond.ToString()
        '            Return context.Response.WriteAsync(t & " Production OWIN App")
        '        End Function)
    End Sub
End Class
