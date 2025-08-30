Imports System.Data.SqlClient
Public Class Usuariocontrata
    Public iCodUsuarioContrata As String
    Public iCodPersona As String
    Public iCodUsuario As String
    Public iCodContrata As String
    Public bAcceder As String
    Public qSelect As String
    Public cTipoOpe As Char
    Public bTransaccion As Boolean = False
    Public mc As New ConnectSQL
    Public Function ListaDatos() As DataTable
        Dim Query As String
        Dim readers As DataTable
        Query = "SELECT * FROM dbo.UsuarioContrata"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.UsuarioContrata (iCodPersona,iCodUsuario,iCodContrata,bAcceder ) VALUES(@iCodPersona,@iCodUsuario,@iCodContrata,@bAcceder); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.SmallInt).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@bAcceder", SqlDbType.Bit).Value = Me.bAcceder

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodUsuarioContrata = pCodInsert
        Else
            Me.iCodUsuarioContrata = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.UsuarioContrata (iCodPersona,iCodUsuario,iCodContrata,bAcceder ) VALUES(@iCodPersona,@iCodUsuario,@iCodContrata,@bAcceder); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@bAcceder", SqlDbType.Bit).Value = Me.bAcceder

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodUsuarioContrata = pCodInsert
        Else
            Me.iCodUsuarioContrata = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.UsuarioContrata SET iCodPersona=@iCodPersona,iCodUsuario=@iCodUsuario,iCodContrata=@iCodContrata,bAcceder=@bAcceder WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@bAcceder", SqlDbType.Bit).Value = Me.bAcceder

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.UsuarioContrata SET iCodPersona=@iCodPersona,iCodUsuario=@iCodUsuario,iCodContrata=@iCodContrata,bAcceder=@bAcceder WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona

        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Smallint).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = Me.iCodContrata
        cmdSQL.Parameters.Add("@bAcceder", SqlDbType.Bit).Value = Me.bAcceder

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        'cmdSQL.CommandText = "DELETE from  dbo.UsuarioContrata  WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.CommandText = "UPDATE dbo.UsuarioContrata  SET bAcceder=0 WHERE  iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        'cmdSQL.CommandText = "DELETE from  dbo.UsuarioContrata  WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.CommandText = "UPDATE dbo.UsuarioContrata  SET bAcceder=0 WHERE  iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioContrata WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodUsuarioContrata = CStr(readers.GetValue(0))
            Me.iCodPersona = CStr(readers.GetValue(1))
            Me.iCodUsuario = CStr(readers.GetValue(2))
            Me.iCodContrata = CStr(readers.GetValue(3))
            Me.bAcceder = CStr(readers.GetValue(4))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioContrata"
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
    '****************************************

    Public Function ListaUsuarios() As DataTable
        Dim Query As String

        Dim readers As DataTable
        Query = " SELECT * FROM web_UsuarioContrata order By cNomContrata asc,cNomCompleto asc "
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function

    Public Function GetRecordUCPersona() As DataTable
        'Dim Query As String = ""
        'Dim readers As DataTable

        'Query = " exec dbo.SP_ROW_PersonaUCByID " & _
        '             " @iCodUsuarioContrata='" & Trim(Me.iCodUsuarioContrata) & "'"



        'readers = mc.ExecuteDataTable(Query)

        'Return readers



        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ROW_PersonaUCByID"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

    Public Sub getRecordByNick()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioContrata WHERE iCodUsuarioContrata=@iCodUsuarioContrata"
        cmdSQL.Parameters.Add("@iCodUsuarioContrata", SqlDbType.Int).Value = Me.iCodUsuarioContrata
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodUsuarioContrata = CStr(readers.GetValue(0))
            Me.iCodPersona = CStr(readers.GetValue(1))
            Me.iCodUsuario = CStr(readers.GetValue(2))
            Me.iCodContrata = CStr(readers.GetValue(3))
            Me.bAcceder = CStr(readers.GetValue(4))
        End If
        readers.Close()
    End Sub



    Public Function ListaUsuariosActivosPorContrata(ByVal pCodContrata As String) As DataTable

        If Me.iCodContrata = "" Or Me.iCodContrata Is Nothing Then
            Me.iCodContrata = -1
        End If
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DTW_UsariosPorContrata"
        cmdSQL.Parameters.Add("@iCodContrata", SqlDbType.Int).Value = pCodContrata


        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function
End Class
