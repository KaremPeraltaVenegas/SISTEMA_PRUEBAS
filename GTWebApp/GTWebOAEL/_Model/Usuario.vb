Imports System.Data.SqlClient
Public Class Usuario
    Public iCodUsuario As String
    Public iCodPersona As String
    Public cNick As String
    Public cClave As String
    Public cTipo As String
    Public bEliminado As String
    Public bBloqueado As String
    Public dFechaUltimoBloqueo As String
    Public dFechaSis As String
    Public iCodUsuarioSis As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.Usuario"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.Usuario (iCodPersona,cNick,cClave,cTipo,bEliminado,bBloqueado,dFechaUltimoBloqueo,dFechaSis,iCodUsuarioSis ) VALUES(@iCodPersona,@cNick,dbo.fnColocaClave(@cClave),@cTipo,@bEliminado,@bBloqueado,@dFechaUltimoBloqueo,@dFechaSis,@iCodUsuarioSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 40).Value = Me.cNick
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = Me.cClave
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 4).Value = Me.cTipo
        cmdSQL.Parameters.Add("@bEliminado", SqlDbType.Bit).Value = Me.bEliminado
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Datetime).Value = Me.dFechaUltimoBloqueo
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCodUsuarioSis", SqlDbType.Int).Value = Me.iCodUsuarioSis

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodUsuario = pCodInsert
        Else
            Me.iCodUsuario = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.Usuario (iCodPersona,cNick,cClave,cTipo,bEliminado,bBloqueado,dFechaUltimoBloqueo,dFechaSis,iCodUsuarioSis ) VALUES(@iCodPersona,@cNick,dbo.fnColocaClave(@cClave),@cTipo,@bEliminado,@bBloqueado,@dFechaUltimoBloqueo,@dFechaSis,@iCodUsuarioSis); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 40).Value = Me.cNick
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = Me.cClave
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 4).Value = Me.cTipo
        cmdSQL.Parameters.Add("@bEliminado", SqlDbType.Bit).Value = Me.bEliminado
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        'cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Datetime).Value = Me.dFechaUltimoBloqueo
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCodUsuarioSis", SqlDbType.Int).Value = Me.iCodUsuarioSis


        If Me.dFechaUltimoBloqueo = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = CDate(Me.dFechaUltimoBloqueo)
        End If

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodUsuario = pCodInsert
        Else
            Me.iCodUsuario = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.Usuario SET iCodPersona=@iCodPersona,cNick=@cNick,cClave=dbo.fnColocaClave(@cClave),cTipo=@cTipo,bEliminado=@bEliminado,bBloqueado=@bBloqueado,dFechaUltimoBloqueo=@dFechaUltimoBloqueo,dFechaSis=@dFechaSis,iCodUsuarioSis=@iCodUsuarioSis WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 40).Value = Me.cNick
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = Me.cClave
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 4).Value = Me.cTipo
        cmdSQL.Parameters.Add("@bEliminado", SqlDbType.Bit).Value = Me.bEliminado
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        'cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Datetime).Value = Me.dFechaUltimoBloqueo
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCodUsuarioSis", SqlDbType.Int).Value = Me.iCodUsuarioSis

        If Me.dFechaUltimoBloqueo = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = CDate(Me.dFechaUltimoBloqueo)
        End If

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.Usuario SET iCodPersona=@iCodPersona,cNick=@cNick,cClave=dbo.fnColocaClave(@cClave),cTipo=@cTipo,bEliminado=@bEliminado,bBloqueado=@bBloqueado,dFechaUltimoBloqueo=@dFechaUltimoBloqueo,dFechaSis=@dFechaSis,iCodUsuarioSis=@iCodUsuarioSis WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cNick", SqlDbType.Varchar, 40).Value = Me.cNick
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = Me.cClave
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 4).Value = Me.cTipo
        cmdSQL.Parameters.Add("@bEliminado", SqlDbType.Bit).Value = Me.bEliminado
        cmdSQL.Parameters.Add("@bBloqueado", SqlDbType.Bit).Value = Me.bBloqueado
        'cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Datetime).Value = Me.dFechaUltimoBloqueo
        cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis
        cmdSQL.Parameters.Add("@iCodUsuarioSis", SqlDbType.Int).Value = Me.iCodUsuarioSis


        If Me.dFechaUltimoBloqueo = "NULL" Then
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = DBNull.Value
        Else
            cmdSQL.Parameters.Add("@dFechaUltimoBloqueo", SqlDbType.Date).Value = CDate(Me.dFechaUltimoBloqueo)
        End If

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar2()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.Usuario  WHERE iCodUsuario=@iCodUsuario"
        'cmdSQL.CommandText = "UPDATE dbo.Usuario  SET bAnulado=1 WHERE  iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.Usuario  WHERE iCodUsuario=@iCodUsuario"
        'cmdSQL.CommandText = "UPDATE dbo.Usuario  SET bAnulado=1 WHERE  iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord2()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.Usuario WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodUsuario = CStr(readers.GetValue(0))
            Me.iCodPersona = CStr(readers.GetValue(1))
            Me.cNick = CStr(readers.GetValue(2))
            Me.cClave = CStr(readers.GetValue(3))
            Me.cTipo = CStr(readers.GetValue(4))
            Me.bEliminado = CStr(readers.GetValue(5))
            Me.bBloqueado = CStr(readers.GetValue(6))
            Me.dFechaUltimoBloqueo = CStr(readers.GetValue(7))
            Me.dFechaSis = CStr(readers.GetValue(8))
            Me.iCodUsuarioSis = CStr(readers.GetValue(9))
        End If
        readers.Close()
    End Sub
    Public Function ListaDatosCombo() As DataTable
        Dim miDataTable As New DataTable
        Dim readers As IDataReader
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT * FROM dbo.Usuario"
        readers = cmdSQL.ExecuteReader
        While readers.Read()
            miDataTable.Rows.Add(CStr(readers.GetValue(0)), CStr(readers.GetValue(1)))
        End While
        readers.Close()
        Return miDataTable
    End Function
    Public Function LastID() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalar(query)
    End Function
    Public Function LastIDT() As Integer
        Const query As String = "SELECT SCOPE_IDENTITY()"
        Return mc.ExecuteScalarTransact(query)
    End Function
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE Usuario SET bEliminado=1  WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()

        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else

        cmdSQL.CommandText = "SELECT icodusuario,icodpersona,cnick,dbo.fnLeeClave(cclave),ctipo,beliminado FROM Usuario WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodUsuario = CStr(readers.GetValue(0))
            Me.iCodPersona = CStr(readers.GetValue(1))
            Me.cNick = CStr(readers.GetValue(2))
            Me.cClave = CStr(readers.GetValue(3))
            Me.cTipo = CStr(readers.GetValue(4))
            Me.bEliminado = CStr(readers.GetValue(5))
        End If
        readers.Close()
    End Sub
    Public Function Login() As Boolean

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "SELECT COUNT(*) FROM v_UserLogin WHERE cNick=@cNick and dbo.fnLeeClave(cClave)=@cClave"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = Me.cClave
        If CInt(cmdSQL.ExecuteScalar()) <= 0 Then
            Return False
        Else
            Return True
        End If

    End Function

    Public Function ListaTipo() As DataTable
        Dim miDataTable As New DataTable
        miDataTable.Columns.Add("ValueMember")
        miDataTable.Columns.Add("DisplayMember")
        With miDataTable
            .Rows.Add("1", "Operador")
            .Rows.Add("2", "Supervisor")
            .Rows.Add("3", "Administrador")
            .Rows.Add("4", "Visitante")
        End With
        Return miDataTable
    End Function


    Public Function UpdateClave(ByVal pClaveAntigua As String, ByVal pClaveNueva As String, ByVal pCodUsuario As String) As Boolean

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  Usuario SET cClave=dbo.fnColocaClave(@cClaveNueva) WHERE iCodUsuario=@iCodUsuario and dbo.fnLeeClave(cClave)=@cClaveAntigua"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = pCodUsuario
        cmdSQL.Parameters.Add("@cClaveNueva", SqlDbType.VarChar, 30).Value = pClaveNueva
        cmdSQL.Parameters.Add("@cClaveAntigua", SqlDbType.VarChar, 30).Value = pClaveAntigua

        If CInt(cmdSQL.ExecuteNonQuery()) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function UpdateClaveRecovery() As Boolean

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  Usuario SET cClave=dbo.fnColocaClave(@cClave) WHERE iCodUsuario=@iCodUsuario "
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 30).Value = Me.cClave

        If CInt(cmdSQL.ExecuteNonQuery()) > 0 Then
            Return True
        Else
            Return False
        End If

    End Function
    Public Sub UpdateTipoUsuarioTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  Usuario SET cTipo=@cTipo WHERE iCodUsuario=@iCodUsuario"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.VarChar, 4).Value = Me.cTipo
        cmdSQL.ExecuteNonQuery()
    End Sub

    Public Function GetRecordUCPersonaByNick() As IDataReader

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_ROW_PersonaUCByNick"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 40).Value = Trim(Me.cNick)
        GetRecordUCPersonaByNick = cmdSQL.ExecuteReader()

        Return GetRecordUCPersonaByNick

    End Function
    Public Function VerificarUsuarioExiste(ByVal _pNick As String) As Integer

        Dim readers As IDataReader
        Dim respuesta As Integer
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_COND_VerificarUsuarioExiste"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 50).Value = Trim(_pNick)

        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            respuesta = CInt(readers.GetValue(0))
        End If
        readers.Close()
        Return respuesta
    End Function

    Public Function RegistrarBloqueo(ByVal _pNick As String) As Integer

        Dim respuesta As Integer
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_ACTU_BloqueoUsuario"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 40).Value = Trim(_pNick)

        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            respuesta = CInt(readers.GetValue(0))
        End If
        readers.Close()
        Return respuesta
    End Function
    Public Function VerificarBloqueo(ByVal _pNick As String) As Integer
        Dim respuesta As Integer
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_COND_VerificarBloqueoPorUsuario"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 40).Value = Trim(_pNick)

        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            respuesta = CInt(readers.GetValue(0))
        End If
        readers.Close()
        Return respuesta
    End Function

    Public Function VerificarAcceso(ByVal _pNick As String) As Integer

        Dim respuesta As Integer
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_COND_VerificarTipoAccesoPorUsuario"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 40).Value = Trim(_pNick)

        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            respuesta = CInt(readers.GetValue(0))
        End If
        readers.Close()
        Return respuesta
    End Function

    Public Function GetLogin(ByVal pNick As String, ByVal pClave As String) As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_ROW_GetLogin"
        cmdSQL.Parameters.Add("@cNick", SqlDbType.VarChar, 40).Value = pNick
        cmdSQL.Parameters.Add("@cClave", SqlDbType.VarChar, 40).Value = pClave

        GetLogin = cmdSQL.ExecuteReader(CommandBehavior.SingleRow)
        Return GetLogin
    End Function

    Public Function GetPermisosWebPorUsuario() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "main.SP_DT_UsuarioPermiso"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

End Class
