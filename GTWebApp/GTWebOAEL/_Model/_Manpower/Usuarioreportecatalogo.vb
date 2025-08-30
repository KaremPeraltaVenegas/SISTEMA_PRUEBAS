Imports System.Data.SqlClient
Public Class Usuarioreportecatalogo
Public iCodUsuarioReporteCatalogo As String
Public iCodUsuarioSistema As String
Public iCodReporteCatalogo As String
Public bHabilitar As String
Public iCodUsuario As String
Public dFechaSis As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.UsuarioReporteCatalogo"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.UsuarioReporteCatalogo (iCodUsuarioSistema,iCodReporteCatalogo,bHabilitar,iCodUsuario,dFechaSis ) VALUES(@iCodUsuarioSistema,@iCodReporteCatalogo,@bHabilitar,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@bHabilitar", SqlDbType.Bit).Value = Me.bHabilitar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUsuarioReporteCatalogo=pCodInsert
	Else
		Me.iCodUsuarioReporteCatalogo=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.UsuarioReporteCatalogo (iCodUsuarioSistema,iCodReporteCatalogo,bHabilitar,iCodUsuario,dFechaSis ) VALUES(@iCodUsuarioSistema,@iCodReporteCatalogo,@bHabilitar,@iCodUsuario,@dFechaSis); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@bHabilitar", SqlDbType.Bit).Value = Me.bHabilitar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUsuarioReporteCatalogo=pCodInsert
	Else
		Me.iCodUsuarioReporteCatalogo=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.UsuarioReporteCatalogo SET iCodUsuarioSistema=@iCodUsuarioSistema,iCodReporteCatalogo=@iCodReporteCatalogo,bHabilitar=@bHabilitar,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodUsuarioReporteCatalogo", SqlDbType.Int).Value = Me.iCodUsuarioReporteCatalogo
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@bHabilitar", SqlDbType.Bit).Value = Me.bHabilitar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.UsuarioReporteCatalogo SET iCodUsuarioSistema=@iCodUsuarioSistema,iCodReporteCatalogo=@iCodReporteCatalogo,bHabilitar=@bHabilitar,iCodUsuario=@iCodUsuario,dFechaSis=@dFechaSis WHERE iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodUsuarioReporteCatalogo", SqlDbType.Int).Value = Me.iCodUsuarioReporteCatalogo
	cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema
	cmdSQL.Parameters.Add("@iCodReporteCatalogo", SqlDbType.Int).Value = Me.iCodReporteCatalogo
	cmdSQL.Parameters.Add("@bHabilitar", SqlDbType.Bit).Value = Me.bHabilitar
	cmdSQL.Parameters.Add("@iCodUsuario", SqlDbType.Int).Value = Me.iCodUsuario
	cmdSQL.Parameters.Add("@dFechaSis", SqlDbType.Datetime).Value = Me.dFechaSis

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.UsuarioReporteCatalogo  WHERE iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.UsuarioReporteCatalogo  SET bAnulado=1 WHERE  iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
cmdSQL.Parameters.Add("@iCodUsuarioReporteCatalogo", SqlDbType.Int).Value = Me.iCodUsuarioReporteCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.UsuarioReporteCatalogo  WHERE iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
'cmdSQL.CommandText = "UPDATE dbo.UsuarioReporteCatalogo  SET bAnulado=1 WHERE  iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
cmdSQL.Parameters.Add("@iCodUsuarioReporteCatalogo", SqlDbType.Int).Value = Me.iCodUsuarioReporteCatalogo
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioReporteCatalogo WHERE iCodUsuarioReporteCatalogo=@iCodUsuarioReporteCatalogo"
	cmdSQL.Parameters.Add("@iCodUsuarioReporteCatalogo", SqlDbType.Int).Value = Me.iCodUsuarioReporteCatalogo
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodUsuarioReporteCatalogo = CStr(readers.GetValue(0))
		Me.iCodUsuarioSistema = CStr(readers.GetValue(1))
		Me.iCodReporteCatalogo = CStr(readers.GetValue(2))
		Me.bHabilitar = CStr(readers.GetValue(3))
		Me.iCodUsuario = CStr(readers.GetValue(4))
		Me.dFechaSis = CStr(readers.GetValue(5))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.UsuarioReporteCatalogo"
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
    '*************************************************************************

    Public Function ListaReportesUsuario() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_UsuarioReporteCatalogo"

        cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

    Public Function ListaReporteHabilitados() As DataTable

        Dim cmdSQL As New SqlCommand
        cmdSQL.Parameters.Clear()
        cmdSQL.Connection = ConnectSQL.linkSQL
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandText = "SP_DT_UsuarioReporteHabilitados"

        cmdSQL.Parameters.Add("@iCodUsuarioSistema", SqlDbType.Int).Value = Me.iCodUsuarioSistema

        Dim readers As SqlDataReader
        readers = cmdSQL.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(readers)
        Return dt

    End Function

End Class
