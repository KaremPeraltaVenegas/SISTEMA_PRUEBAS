Imports System.Data.SqlClient
Public Class Uconfig2
Public iCodUConfig2 As String
Public cName As String
Public cValue1 As String
Public cValue2 As String
Public cValue3 As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.UConfig2"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.UConfig2 (cName,cValue1,cValue2,cValue3 ) VALUES(@cName,@cValue1,@cValue2,@cValue3); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cName", SqlDbType.Varchar,50).Value = Me.cName
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varchar,50).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varchar,50).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varchar,50).Value = Me.cValue3

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUConfig2=pCodInsert
	Else
		Me.iCodUConfig2=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.UConfig2 (cName,cValue1,cValue2,cValue3 ) VALUES(@cName,@cValue1,@cValue2,@cValue3); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cName", SqlDbType.Varchar,50).Value = Me.cName
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varchar,50).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varchar,50).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varchar,50).Value = Me.cValue3

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUConfig2=pCodInsert
	Else
		Me.iCodUConfig2=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.UConfig2 SET cName=@cName,cValue1=@cValue1,cValue2=@cValue2,cValue3=@cValue3 WHERE iCodUConfig2=@iCodUConfig2"
	cmdSQL.Parameters.Add("@iCodUConfig2", SqlDbType.Int).Value = Me.iCodUConfig2
	cmdSQL.Parameters.Add("@cName", SqlDbType.Varchar,50).Value = Me.cName
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varchar,50).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varchar,50).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varchar,50).Value = Me.cValue3

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.UConfig2 SET cName=@cName,cValue1=@cValue1,cValue2=@cValue2,cValue3=@cValue3 WHERE iCodUConfig2=@iCodUConfig2"
	cmdSQL.Parameters.Add("@iCodUConfig2", SqlDbType.Int).Value = Me.iCodUConfig2
	cmdSQL.Parameters.Add("@cName", SqlDbType.Varchar,50).Value = Me.cName
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varchar,50).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varchar,50).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varchar,50).Value = Me.cValue3

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.UConfig2  WHERE iCodUConfig2=@iCodUConfig2"
'cmdSQL.CommandText = "UPDATE dbo.UConfig2  SET bAnulado=1 WHERE  iCodUConfig2=@iCodUConfig2"
cmdSQL.Parameters.Add("@iCodUConfig2", SqlDbType.Int).Value = Me.iCodUConfig2
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.UConfig2  WHERE iCodUConfig2=@iCodUConfig2"
'cmdSQL.CommandText = "UPDATE dbo.UConfig2  SET bAnulado=1 WHERE  iCodUConfig2=@iCodUConfig2"
cmdSQL.Parameters.Add("@iCodUConfig2", SqlDbType.Int).Value = Me.iCodUConfig2
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM dbo.UConfig2 WHERE iCodUConfig2=@iCodUConfig2"
	cmdSQL.Parameters.Add("@iCodUConfig2", SqlDbType.Int).Value = Me.iCodUConfig2
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodUConfig2 = CStr(readers.GetValue(0))
		Me.cName = CStr(readers.GetValue(1))
		Me.cValue1 = CStr(readers.GetValue(2))
		Me.cValue2 = CStr(readers.GetValue(3))
		Me.cValue3 = CStr(readers.GetValue(4))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.UConfig2"
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
End Class
