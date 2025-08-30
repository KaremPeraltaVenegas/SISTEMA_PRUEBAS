Imports System.Data.SqlClient
Public Class Uconfig
Public iCodUConfig As String
Public cDisplay As String
Public cValue1 As String
Public cValue2 As String
Public cValue3 As String
Public cValue4 As String
Public cValue5 As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
    Public mc As New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM dbo.UConfig"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into dbo.UConfig (cDisplay,cValue1,cValue2,cValue3,cValue4,cValue5 ) VALUES(@cDisplay,@cValue1,@cValue2,@cValue3,@cValue4,@cValue5); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cDisplay", SqlDbType.Varchar,200).Value = Me.cDisplay
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varbinary,1000).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varbinary,1000).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varbinary,1000).Value = Me.cValue3
	cmdSQL.Parameters.Add("@cValue4", SqlDbType.Varbinary,1000).Value = Me.cValue4
	cmdSQL.Parameters.Add("@cValue5", SqlDbType.Varbinary,1000).Value = Me.cValue5

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUConfig=pCodInsert
	Else
		Me.iCodUConfig=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into dbo.UConfig (cDisplay,cValue1,cValue2,cValue3,cValue4,cValue5 ) VALUES(@cDisplay,@cValue1,@cValue2,@cValue3,@cValue4,@cValue5); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cDisplay", SqlDbType.Varchar,200).Value = Me.cDisplay
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varbinary,1000).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varbinary,1000).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varbinary,1000).Value = Me.cValue3
	cmdSQL.Parameters.Add("@cValue4", SqlDbType.Varbinary,1000).Value = Me.cValue4
	cmdSQL.Parameters.Add("@cValue5", SqlDbType.Varbinary,1000).Value = Me.cValue5

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodUConfig=pCodInsert
	Else
		Me.iCodUConfig=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  dbo.UConfig SET cDisplay=@cDisplay,cValue1=@cValue1,cValue2=@cValue2,cValue3=@cValue3,cValue4=@cValue4,cValue5=@cValue5 WHERE iCodUConfig=@iCodUConfig"
	cmdSQL.Parameters.Add("@iCodUConfig", SqlDbType.Int).Value = Me.iCodUConfig
	cmdSQL.Parameters.Add("@cDisplay", SqlDbType.Varchar,200).Value = Me.cDisplay
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varbinary,1000).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varbinary,1000).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varbinary,1000).Value = Me.cValue3
	cmdSQL.Parameters.Add("@cValue4", SqlDbType.Varbinary,1000).Value = Me.cValue4
	cmdSQL.Parameters.Add("@cValue5", SqlDbType.Varbinary,1000).Value = Me.cValue5

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  dbo.UConfig SET cDisplay=@cDisplay,cValue1=@cValue1,cValue2=@cValue2,cValue3=@cValue3,cValue4=@cValue4,cValue5=@cValue5 WHERE iCodUConfig=@iCodUConfig"
	cmdSQL.Parameters.Add("@iCodUConfig", SqlDbType.Int).Value = Me.iCodUConfig
	cmdSQL.Parameters.Add("@cDisplay", SqlDbType.Varchar,200).Value = Me.cDisplay
	cmdSQL.Parameters.Add("@cValue1", SqlDbType.Varbinary,1000).Value = Me.cValue1
	cmdSQL.Parameters.Add("@cValue2", SqlDbType.Varbinary,1000).Value = Me.cValue2
	cmdSQL.Parameters.Add("@cValue3", SqlDbType.Varbinary,1000).Value = Me.cValue3
	cmdSQL.Parameters.Add("@cValue4", SqlDbType.Varbinary,1000).Value = Me.cValue4
	cmdSQL.Parameters.Add("@cValue5", SqlDbType.Varbinary,1000).Value = Me.cValue5

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  dbo.UConfig  WHERE iCodUConfig=@iCodUConfig"
'cmdSQL.CommandText = "UPDATE dbo.UConfig  SET bAnulado=1 WHERE  iCodUConfig=@iCodUConfig"
cmdSQL.Parameters.Add("@iCodUConfig", SqlDbType.Int).Value = Me.iCodUConfig
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  dbo.UConfig  WHERE iCodUConfig=@iCodUConfig"
'cmdSQL.CommandText = "UPDATE dbo.UConfig  SET bAnulado=1 WHERE  iCodUConfig=@iCodUConfig"
cmdSQL.Parameters.Add("@iCodUConfig", SqlDbType.Int).Value = Me.iCodUConfig
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

        cmdSQL.CommandText = "SELECT iCodUconfig,cDisplay,dbo.fnLeeClave(cValue1),dbo.fnLeeClave(cValue2),dbo.fnLeeClave(cValue3),dbo.fnLeeClave(cValue4),dbo.fnLeeClave(cValue5) FROM dbo.UConfig WHERE iCodUConfig=@iCodUConfig"
	cmdSQL.Parameters.Add("@iCodUConfig", SqlDbType.Int).Value = Me.iCodUConfig
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodUConfig = CStr(readers.GetValue(0))
		Me.cDisplay = CStr(readers.GetValue(1))
		Me.cValue1 = CStr(readers.GetValue(2))
		Me.cValue2 = CStr(readers.GetValue(3))
		Me.cValue3 = CStr(readers.GetValue(4))
		Me.cValue4 = CStr(readers.GetValue(5))
		Me.cValue5 = CStr(readers.GetValue(6))
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
	cmdSQL.CommandText = "SELECT * FROM dbo.UConfig"
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
