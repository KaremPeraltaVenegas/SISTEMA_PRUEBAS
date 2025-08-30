Imports System.Data.SqlClient
Public Class Tipoestadorequerimiento
Public iCodTipoEstadoRequerimiento As String
Public cEstadoRequerimiento As String
Public cAbrEstado As String
Public bAnulado As String
Public iOrden As String
Public qSelect As String
Public cTipoOpe as Char
Public bTransaccion as Boolean=False
Public mc as New ConnectSQL
 Public Function ListaDatos() As DataTable
	Dim Query As String
	Dim readers As DataTable
	Query = "SELECT * FROM prov.TipoEstadoRequerimiento"
	readers = mc.ExecuteDataTable(Query)
	Return readers
End Function
 Public Sub Insertar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText ="INSERT into prov.TipoEstadoRequerimiento (cEstadoRequerimiento,cAbrEstado,bAnulado,iOrden ) VALUES(@cEstadoRequerimiento,@cAbrEstado,@bAnulado,@iOrden); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cEstadoRequerimiento", SqlDbType.Varchar,50).Value = Me.cEstadoRequerimiento
	cmdSQL.Parameters.Add("@cAbrEstado", SqlDbType.Varchar,10).Value = Me.cAbrEstado
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoEstadoRequerimiento=pCodInsert
	Else
		Me.iCodTipoEstadoRequerimiento=0
	End If
End Sub
 Public Sub InsertarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText ="INSERT into prov.TipoEstadoRequerimiento (cEstadoRequerimiento,cAbrEstado,bAnulado,iOrden ) VALUES(@cEstadoRequerimiento,@cAbrEstado,@bAnulado,@iOrden); SELECT SCOPE_IDENTITY(); "
	cmdSQL.Parameters.Add("@cEstadoRequerimiento", SqlDbType.Varchar,50).Value = Me.cEstadoRequerimiento
	cmdSQL.Parameters.Add("@cAbrEstado", SqlDbType.Varchar,10).Value = Me.cAbrEstado
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden

	Dim pCodInsert = CInt(cmdSQL.ExecuteScalar())
	If pCodInsert > 0 Then
		Me.iCodTipoEstadoRequerimiento=pCodInsert
	Else
		Me.iCodTipoEstadoRequerimiento=0
	End If
End Sub
 Public Sub Modificar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "UPDATE  prov.TipoEstadoRequerimiento SET cEstadoRequerimiento=@cEstadoRequerimiento,cAbrEstado=@cAbrEstado,bAnulado=@bAnulado,iOrden=@iOrden WHERE iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
	cmdSQL.Parameters.Add("@cEstadoRequerimiento", SqlDbType.Varchar,50).Value = Me.cEstadoRequerimiento
	cmdSQL.Parameters.Add("@cAbrEstado", SqlDbType.Varchar,10).Value = Me.cAbrEstado
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub ModificarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "UPDATE  prov.TipoEstadoRequerimiento SET cEstadoRequerimiento=@cEstadoRequerimiento,cAbrEstado=@cAbrEstado,bAnulado=@bAnulado,iOrden=@iOrden WHERE iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
	cmdSQL.Parameters.Add("@cEstadoRequerimiento", SqlDbType.Varchar,50).Value = Me.cEstadoRequerimiento
	cmdSQL.Parameters.Add("@cAbrEstado", SqlDbType.Varchar,10).Value = Me.cAbrEstado
	cmdSQL.Parameters.Add("@bAnulado", SqlDbType.Bit).Value = Me.bAnulado
	cmdSQL.Parameters.Add("@iOrden", SqlDbType.Tinyint).Value = Me.iOrden

	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub Eliminar()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.CommandText = "DELETE from  prov.TipoEstadoRequerimiento  WHERE iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
'cmdSQL.CommandText = "UPDATE prov.TipoEstadoRequerimiento  SET bAnulado=1 WHERE  iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
	cmdSQL.ExecuteNonQuery()
End Sub
 Public Sub EliminarTransact()
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	cmdSQL.Transaction = Me.mc.miTransact 
	cmdSQL.CommandText = "DELETE from  prov.TipoEstadoRequerimiento  WHERE iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
'cmdSQL.CommandText = "UPDATE prov.TipoEstadoRequerimiento  SET bAnulado=1 WHERE  iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
	cmdSQL.ExecuteNonQuery()
End Sub
Public Sub getRecord()
	Dim readers As IDataReader
	Dim cmdSQL As New SqlCommand
	cmdSQL.Parameters.Clear()
	cmdSQL.Connection = ConnectSQL.linkSQL
	
	If bTransaccion=True Then cmdSQL.Transaction = Me.mc.miTransact Else 

	cmdSQL.CommandText = "SELECT * FROM prov.TipoEstadoRequerimiento WHERE iCodTipoEstadoRequerimiento=@iCodTipoEstadoRequerimiento"
	cmdSQL.Parameters.Add("@iCodTipoEstadoRequerimiento", SqlDbType.Smallint).Value = Me.iCodTipoEstadoRequerimiento
	readers = cmdSQL.ExecuteReader
	If readers.Read() Then
		Me.iCodTipoEstadoRequerimiento = CStr(readers.GetValue(0))
		Me.cEstadoRequerimiento = CStr(readers.GetValue(1))
		Me.cAbrEstado = CStr(readers.GetValue(2))
		Me.bAnulado = CStr(readers.GetValue(3))
		Me.iOrden = CStr(readers.GetValue(4))
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
	cmdSQL.CommandText = "SELECT * FROM prov.TipoEstadoRequerimiento"
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
