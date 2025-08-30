Imports System.Data.SqlClient
Public Class Tiporequerimiento
Public iCodTipoRequerimiento As String
Public cTipoRequerimiento As String
Public bPublicar As String
Public bDirecto As String
Public bIndirecto As String
Public bExterno As String
Public bAnulado As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.TipoRequerimiento"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.TipoRequerimiento (cTipoRequerimiento,bPublicar,bDirecto,bIndirecto,bExterno,bAnulado ) VALUES(@cTipoRequerimiento,@bPublicar,@bDirecto,@bIndirecto,@bExterno,@bAnulado); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cTipoRequerimiento", SqlDbType.Varchar,50).Value = Me.cTipoRequerimiento
	cmdSQL.Parameters.Add("@bPublicar", SqlDbType.Bit).Value = Me.bPublicar
	cmdSQL.Parameters.Add("@bDirecto", SqlDbType.Bit).Value = Me.bDirecto
	cmdSQL.Parameters.Add("@bIndirecto", SqlDbType.Bit).Value = Me.bIndirecto
	cmdSQL.Parameters.Add("@bExterno", SqlDbType.Bit).Value = Me.bExterno
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoRequerimiento=pCodInsert
	Else
		Me.iCodTipoRequerimiento=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.TipoRequerimiento (cTipoRequerimiento,bPublicar,bDirecto,bIndirecto,bExterno,bAnulado ) VALUES(@cTipoRequerimiento,@bPublicar,@bDirecto,@bIndirecto,@bExterno,@bAnulado); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cTipoRequerimiento", SqlDbType.Varchar,50).Value = Me.cTipoRequerimiento
	cmdSQL.Parameters.Add("@bPublicar", SqlDbType.Bit).Value = Me.bPublicar
	cmdSQL.Parameters.Add("@bDirecto", SqlDbType.Bit).Value = Me.bDirecto
	cmdSQL.Parameters.Add("@bIndirecto", SqlDbType.Bit).Value = Me.bIndirecto
	cmdSQL.Parameters.Add("@bExterno", SqlDbType.Bit).Value = Me.bExterno
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoRequerimiento=pCodInsert
	Else
		Me.iCodTipoRequerimiento=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.TipoRequerimiento SET cTipoRequerimiento=@cTipoRequerimiento,bPublicar=@bPublicar,bDirecto=@bDirecto,bIndirecto=@bIndirecto,bExterno=@bExterno,bAnulado=@bAnulado WHERE iCodTipoRequerimiento=@iCodTipoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
	cmdSQL.Parameters.Add("@cTipoRequerimiento", SqlDbType.Varchar,50).Value = Me.cTipoRequerimiento
	cmdSQL.Parameters.Add("@bPublicar", SqlDbType.Bit).Value = Me.bPublicar
	cmdSQL.Parameters.Add("@bDirecto", SqlDbType.Bit).Value = Me.bDirecto
	cmdSQL.Parameters.Add("@bIndirecto", SqlDbType.Bit).Value = Me.bIndirecto
	cmdSQL.Parameters.Add("@bExterno", SqlDbType.Bit).Value = Me.bExterno
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.TipoRequerimiento SET cTipoRequerimiento=@cTipoRequerimiento,bPublicar=@bPublicar,bDirecto=@bDirecto,bIndirecto=@bIndirecto,bExterno=@bExterno,bAnulado=@bAnulado WHERE iCodTipoRequerimiento=@iCodTipoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
	cmdSQL.Parameters.Add("@cTipoRequerimiento", SqlDbType.Varchar,50).Value = Me.cTipoRequerimiento
	cmdSQL.Parameters.Add("@bPublicar", SqlDbType.Bit).Value = Me.bPublicar
	cmdSQL.Parameters.Add("@bDirecto", SqlDbType.Bit).Value = Me.bDirecto
	cmdSQL.Parameters.Add("@bIndirecto", SqlDbType.Bit).Value = Me.bIndirecto
	cmdSQL.Parameters.Add("@bExterno", SqlDbType.Bit).Value = Me.bExterno
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.TipoRequerimiento  WHERE iCodTipoRequerimiento=@iCodTipoRequerimiento"
'cmdSQL.CommandText = "UPDATE prov.TipoRequerimiento  SET bAnulado=1 WHERE  iCodTipoRequerimiento=@iCodTipoRequerimiento"
cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.TipoRequerimiento  WHERE iCodTipoRequerimiento=@iCodTipoRequerimiento"
'cmdSQL.CommandText = "UPDATE prov.TipoRequerimiento  SET bAnulado=1 WHERE  iCodTipoRequerimiento=@iCodTipoRequerimiento"
cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.TipoRequerimiento WHERE iCodTipoRequerimiento=@iCodTipoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoRequerimiento
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTipoRequerimiento = CStr(readers.GetValue(0))
		Me.cTipoRequerimiento = CStr(readers.GetValue(1))
		Me.bPublicar = CStr(readers.GetValue(2))
		Me.bDirecto = CStr(readers.GetValue(3))
		Me.bIndirecto = CStr(readers.GetValue(4))
		Me.bExterno = CStr(readers.GetValue(5))
		Me.bAnulado = CStr(readers.GetValue(6))
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
	cmdSQL.CommandText = "SELECT * FROM prov.TipoRequerimiento"
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
