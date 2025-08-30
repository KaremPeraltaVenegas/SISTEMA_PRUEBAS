Imports System.Web.Security
Imports Microsoft.AspNet.Identity
Public Class CustomRoleProvider
    Inherits RoleProvider

    Public Overrides Property ApplicationName As String
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Overrides Sub CreateRole(roleName As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub AddUsersToRoles(usernames() As String, roleNames() As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Sub RemoveUsersFromRoles(usernames() As String, roleNames() As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function IsUserInRole(username As String, roleName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetRolesForUser(username As String) As String()
        'Dim cResultCon As String = ""
        'Dim miConexion As New ConnectSQL
        'Dim cUsuarioCliente As New Usuariocontrata
        Dim listaAccesos As IList(Of String) = New List(Of String)

        'If Not HttpContext.Current.Session("Login").ToString() Is Nothing Then
        '    Try
        '        cResultCon = miConexion.OpenConnection
        '        If cResultCon = "OK" Then 'ok
        '            Dim dtUsuario As DataTable
        '            cUsuarioCliente.iCodUsuario = username
        '            'cUsuarioCliente.iCodClienteCuenta = HttpContext.Current.Session("ClienteCuenta").ToString()
        '            'dtUsuario = cUsuarioCliente.GetRolesPorUsuarioYClienteCuenta()

        '            If dtUsuario.Rows.Count > 0 Then
        '                For Each dr As DataRow In dtUsuario.Rows
        '                    listaAccesos.Add(CType(dr(0), String))
        '                Next
        '            End If
        '        Else
        '            Throw New ApplicationException("No se puede establecer Conexion a BD")
        '        End If
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        miConexion.CloseConnection()
        '        miConexion = Nothing
        '    End Try
        'End If
        listaAccesos.Add(CType(Decrypt(HttpContext.Current.Session("cTipoUsuario")), String))
        Return listaAccesos.ToArray()
    End Function

    Public Overrides Function DeleteRole(roleName As String, throwOnPopulatedRole As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function RoleExists(roleName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetUsersInRole(roleName As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function GetAllRoles() As String()
        Throw New NotImplementedException()
    End Function

    Public Overrides Function FindUsersInRole(roleName As String, usernameToMatch As String) As String()
        Throw New NotImplementedException()
    End Function
End Class
