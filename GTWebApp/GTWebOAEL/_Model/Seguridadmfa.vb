Imports System.Data.SqlClient
Public Class Seguridadmfa
Public iCodSeguridadMFA As String
Public iCodUsuario As String
Public iCodPersona As String
Public cTipo As String
Public cToken As String
Public cTokenBinary As String
Public dFechaHoraIni As String
Public dFechaHoraFin As String
Public bAutenticado As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
        Query = "SELECT * FROM dbo.SeguridadMFA"
        readers = mc.ExecuteDataTable(Query)
        Return readers
    End Function
    Public Sub Insertar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "INSERT into dbo.SeguridadMFA (iCodUsuario,iCodPersona,cTipo,cToken,cTokenBinary,dFechaHoraIni,dFechaHoraFin,bAutenticado ) VALUES(@iCodUsuario,@iCodPersona,@cTipo,@cToken,@cTokenBinary,@dFechaHoraIni,@dFechaHoraFin,@bAutenticado); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 5).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cToken", SqlDbType.Varchar, 50).Value = Me.cToken
        cmdSQL.Parameters.Add("@cTokenBinary", SqlDbType.varchar, 800).Value = Me.cTokenBinary
        cmdSQL.Parameters.Add("@dFechaHoraIni", SqlDbType.Datetime).Value = Me.dFechaHoraIni
        cmdSQL.Parameters.Add("@dFechaHoraFin", SqlDbType.Datetime).Value = Me.dFechaHoraFin
        cmdSQL.Parameters.Add("@bAutenticado", SqlDbType.Bit).Value = Me.bAutenticado

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadMFA = pCodInsert
        Else
            Me.iCodSeguridadMFA = 0
        End If
    End Sub
    Public Sub InsertarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "INSERT into dbo.SeguridadMFA (iCodUsuario,iCodPersona,cTipo,cToken,cTokenBinary,dFechaHoraIni,dFechaHoraFin,bAutenticado ) VALUES(@iCodUsuario,@iCodPersona,@cTipo,@cToken,@cTokenBinary,@dFechaHoraIni,@dFechaHoraFin,@bAutenticado); SELECT SCOPE_IDENTITY(); "
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 5).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cToken", SqlDbType.Varchar, 50).Value = Me.cToken
        cmdSQL.Parameters.Add("@cTokenBinary", SqlDbType.varchar, 800).Value = Me.cTokenBinary
        cmdSQL.Parameters.Add("@dFechaHoraIni", SqlDbType.Datetime).Value = Me.dFechaHoraIni
        cmdSQL.Parameters.Add("@dFechaHoraFin", SqlDbType.Datetime).Value = Me.dFechaHoraFin
        cmdSQL.Parameters.Add("@bAutenticado", SqlDbType.Bit).Value = Me.bAutenticado

        Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
        If pCodInsert > 0 Then
            Me.iCodSeguridadMFA = pCodInsert
        Else
            Me.iCodSeguridadMFA = 0
        End If
    End Sub
    Public Sub Modificar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadMFA SET iCodUsuario=@iCodUsuario,iCodPersona=@iCodPersona,cTipo=@cTipo,cToken=@cToken,cTokenBinary=@cTokenBinary,dFechaHoraIni=@dFechaHoraIni,dFechaHoraFin=@dFechaHoraFin,bAutenticado=@bAutenticado WHERE iCodSeguridadMFA=@iCodSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodSeguridadMFA", SqlDbType.Int).Value = Me.iCodSeguridadMFA
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 5).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cToken", SqlDbType.Varchar, 50).Value = Me.cToken
        cmdSQL.Parameters.Add("@cTokenBinary", SqlDbType.varchar, 800).Value = Me.cTokenBinary
        cmdSQL.Parameters.Add("@dFechaHoraIni", SqlDbType.Datetime).Value = Me.dFechaHoraIni
        cmdSQL.Parameters.Add("@dFechaHoraFin", SqlDbType.Datetime).Value = Me.dFechaHoraFin
        cmdSQL.Parameters.Add("@bAutenticado", SqlDbType.Bit).Value = Me.bAutenticado

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub ModificarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "UPDATE  dbo.SeguridadMFA SET iCodUsuario=@iCodUsuario,iCodPersona=@iCodPersona,cTipo=@cTipo,cToken=@cToken,cTokenBinary=@cTokenBinary,dFechaHoraIni=@dFechaHoraIni,dFechaHoraFin=@dFechaHoraFin,bAutenticado=@bAutenticado WHERE iCodSeguridadMFA=@iCodSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodSeguridadMFA", SqlDbType.Int).Value = Me.iCodSeguridadMFA
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cTipo", SqlDbType.Varchar, 5).Value = Me.cTipo
        cmdSQL.Parameters.Add("@cToken", SqlDbType.Varchar, 50).Value = Me.cToken
        cmdSQL.Parameters.Add("@cTokenBinary", SqlDbType.varchar, 800).Value = Me.cTokenBinary
        cmdSQL.Parameters.Add("@dFechaHoraIni", SqlDbType.Datetime).Value = Me.dFechaHoraIni
        cmdSQL.Parameters.Add("@dFechaHoraFin", SqlDbType.Datetime).Value = Me.dFechaHoraFin
        cmdSQL.Parameters.Add("@bAutenticado", SqlDbType.Bit).Value = Me.bAutenticado

        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub Eliminar()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadMFA  WHERE iCodSeguridadMFA=@iCodSeguridadMFA"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadMFA  SET bAnulado=1 WHERE  iCodSeguridadMFA=@iCodSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodSeguridadMFA", SqlDbType.Int).Value = Me.iCodSeguridadMFA
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub EliminarTransact()
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.Transaction = Me.mc.miTransact
        cmdSQL.CommandText = "DELETE from  dbo.SeguridadMFA  WHERE iCodSeguridadMFA=@iCodSeguridadMFA"
        'cmdSQL.CommandText = "UPDATE dbo.SeguridadMFA  SET bAnulado=1 WHERE  iCodSeguridadMFA=@iCodSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodSeguridadMFA", SqlDbType.Int).Value = Me.iCodSeguridadMFA
        cmdSQL.ExecuteNonQuery()
    End Sub
    Public Sub getRecord()
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL

        If bTransaccion = True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadMFA WHERE iCodSeguridadMFA=@iCodSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodSeguridadMFA", SqlDbType.Int).Value = Me.iCodSeguridadMFA
        readers = cmdSQL.ExecuteReader
        If readers.Read() Then
            Me.iCodSeguridadMFA = CStr(readers.GetValue(0))
            Me.iCodUsuario = CStr(readers.GetValue(1))
            Me.iCodPersona = CStr(readers.GetValue(2))
            Me.cTipo = CStr(readers.GetValue(3))
            Me.cToken = CStr(readers.GetValue(4))
            Me.cTokenBinary = CStr(readers.GetValue(5))
            Me.dFechaHoraIni = CStr(readers.GetValue(6))
            Me.dFechaHoraFin = CStr(readers.GetValue(7))
            Me.bAutenticado = CStr(readers.GetValue(8))
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
        cmdSQL.CommandText = "SELECT * FROM dbo.SeguridadMFA"
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

    Public Function LoginSeguridad() As DataTable
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        Dim dt As New DataTable()

        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL


        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ROW_LoginPersonaSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodPersona", SqlDbType.Int).Value = Me.iCodPersona
        cmdSQL.Parameters.Add("@cToken", SqlDbType.VarChar, 50).Value = Me.cToken

        readers = cmdSQL.ExecuteReader

        dt.Load(readers)
        readers.Close()
        Return dt
    End Function

    Public Function LoginUsuarioSeguridad() As DataTable
        Dim readers As IDataReader
        Dim cmdSQL As New SqlCommand
        Dim dt As New DataTable()

        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL


        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "dbo.SP_ROW_LoginUsuarioSeguridadMFA"
        cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
        cmdSQL.Parameters.Add("@cToken", SqlDbType.VarChar, 50).Value = Me.cToken

        readers = cmdSQL.ExecuteReader

        dt.Load(readers)
        readers.Close()
        Return dt
    End Function
End Class
